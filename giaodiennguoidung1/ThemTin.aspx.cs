using FreeTextBoxControls;
using System;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//| Thư viện | Dùng để |
//| --------------------------- | -------------------------------------------------------------------------------------------------------------------------------------- |
//| `System`                    | Các lớp cơ bản (Console, Exception, Convert, ...).                                                                                     |
//| `System.Data`               | Làm việc với dữ liệu (DataSet, DataTable, ...).                                                                                        |
//| `System.Web.UI.WebControls` | Các control web như `Button`, `TextBox`, `DropDownList`, ...                                                                           |
//| `FreeTextBoxControls`       | Một **thư viện ngoài** cho phép tạo **ô nhập nội dung dạng HTML (giống editor trên web)**. Dùng để nhập bài viết/tin tức có định dạng. |

public partial class ThemTin : System.Web.UI.Page
{
    //B2: VIết phương thức để lấy storeproceduce, Stored Procedure giống như một “hàm” trong lập trình nhưng dành cho SQL.
    //Nó giúp bạn gom nhiều câu lệnh SQL(SELECT, INSERT, UPDATE, DELETE, IF, WHILE, v.v.) lại thành một khối logic có thể tái sử dụng.
    //B3: Viết phương thức
    //B4: Viết code phần thêm mới tin

    // Ở phần Thêm Tin này, chúng ta sẽ tìm hiểu cách lấy dữ liệu từ Database và đổ lên giao diện.
    // Dữ liệu được truyền qua các lớp theo thứ tự: web.config -> BasePage -> dao_Tin_Tuc -> ThemTin.aspx.cs.
    // Cụ thể:
    // - web.config: chứa chuỗi kết nối (connection string) đến SQL Server.
    // - BasePage: nhận chuỗi kết nối từ web.config và cung cấp biến "Connection" dùng chung.
    // - dao_Tin_Tuc: gọi Stored Procedure để lấy dữ liệu nhóm tin từ SQL (dạng DataSet).
    // - ThemTin.aspx.cs: kế thừa lại lớp dao_Tin_Tuc, nhận DataSet và đổ dữ liệu vào DropDownList "Nhóm tin".
    // Sau đó ta có thể viết thêm phương thức thêm mới tin để chèn dữ liệu mới vào Database.


    // Khai báo một đối tượng (instance) của lớp dao_Tin_Tuc
    // "Instance" nghĩa là một bản thể cụ thể được tạo ra từ lớp (class),
    // để có thể sử dụng các hàm, thuộc tính bên trong lớp đó.
    dao_Tin_Tuc DAO_Tin_Tuc = new dao_Tin_Tuc();

    // Hàm Page_Load là sự kiện chạy đầu tiên khi trang được tải lên
    protected void Page_Load(object sender, EventArgs e)
    {
        // Page.IsPostBack = false nghĩa là trang vừa được tải lần đầu (chưa bấm nút, chưa submit form)
        // Nếu true (người dùng vừa bấm nút hoặc reload dữ liệu) thì không cần gọi lại HienThiNhomTin()
        // để tránh load lại dữ liệu dropdownlist nhiều lần gây trùng lặp.
        if (!Page.IsPostBack)
        {
            HienThiNhomTin();  // Gọi hàm hiển thị danh sách nhóm tin khi trang lần đầu mở
        }
    }

    protected void HienThiNhomTin()
    {
        DataSet ds;  // DataSet là một cấu trúc dữ liệu dùng để chứa nhiều bảng dữ liệu (Tables)
        try
        {
            // Gọi hàm DS_NhomTin() trong lớp dao_Tin_Tuc để lấy dữ liệu nhóm tin từ database
            ds = DAO_Tin_Tuc.DanhSach_NhomTin();

            // Gán nguồn dữ liệu (DataSource) cho dropdownlist là DataSet vừa lấy được
            drl_NhomTin.DataSource = ds;

            // Thuộc tính DataTextField chỉ định cột nào trong bảng sẽ hiển thị ra giao diện (ví dụ: "Tin tức", "Thể thao")
            // Nếu như không setup DataTextField thì nó sẽ mặc định ID_NhomTin hiển thị ra bên ngoài dropdownlist thay vì hiển thị TenNhom
            drl_NhomTin.DataTextField = "TenNhom";

            // Thuộc tính DataValueField là giá trị ẩn phía sau (thường là ID của nhóm tin)
            drl_NhomTin.DataValueField = "ID_Nhom";

            // Lệnh DataBind() sẽ "kết nối" dữ liệu từ DataSet vào dropdownlist để hiển thị thật sự
            drl_NhomTin.DataBind();

            // Sau khi dữ liệu đã được đổ ra giao diện, ta xóa dữ liệu trong DataSet để giải phóng RAM
            ds.Tables.Clear();
            ds.Clear();
        }
        catch (Exception ex)
        {
            // Nếu có lỗi trong quá trình lấy dữ liệu, ném lỗi ra để debug hoặc hiển thị thông báo
            throw ex;
        }
    }

    protected void btn_ThemMoi_Click(object sender, EventArgs e)
    {
        string TenTin, Anh, TomTat, NoiDung;
        try
        {
            int ID_Nhom = Convert.ToInt32(drl_NhomTin.SelectedValue.ToString());
            TenTin = txt_TenTin.Text;
            TomTat = ftb_TomTat.Text;
            NoiDung = ftb_NoiDung.Text;

            //1. Copy ảnh vào trong thư mục Anh_Lien_Ket
            //2. Đưa đường dãn vào trong CSDL
            //Tìm đường vào thư mục chứa ảnh Server.MapPath("~\\") 
            string strPath = Server.MapPath("~\\") + "Anh_Tin/";
            //Lấy tên của ảnh đưa vào
            string filename = ful_Anh.FileName;
            //Tách ảnh: Tên ảnh + Đuôi mở rộng 
            string tmp = filename.Substring(0, filename.Length - 4);//Tách tên 
            //Có thể về học thêm vòng for để tách tại đuôi mở rộng bất kì
            string exp = filename.Substring(filename.Length - 4, 4);//Tách đuôi
            //Thêm thời gian vào tên ảnh
            DateTime dt = DateTime.Now;//Lấy ngày giờ hệ thống, cụ thể là tại pin cmos
            string strdt = dt.ToString("ddMMyyyyhhmmss");//Chuyển về dạng ngày tháng năm
            //Lưu ảnh vào trong thư mục Anh_Lien_Ket đã tạo
            //ful_anh.SaveAs(strPath + filename); // Đã xong bước 1, cái này thì sẽ không có đuôi ngày tháng năm, bị trùng tên thì không biết lấy gì

            //Tên Ảnh_Time.đuôi mở rộng
            ful_Anh.SaveAs(strPath + tmp + "_" + strdt + exp); // Đã xong bước 1, cái này thì sẽ có đuôi ngày tháng năm, không bị trùng tên vì đã có ngày tháng năm làm gốc
            //2. Thực hiện đưa đường dẫn vào cơ sở dữ liệu
            Anh = "Anh_Tin/" + tmp + "_" + strdt + exp;
            DAO_Tin_Tuc.ThemMoi_Tin(TenTin, Anh, TomTat, NoiDung, ID_Nhom);
            Response.Redirect("QuanLiTin.aspx");
        }
        catch (Exception ex)
        {

            throw ex;
        }
       
    }
}