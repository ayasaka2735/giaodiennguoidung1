using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class QuanLiTin : System.Web.UI.Page
{
        dao_Tin_Tuc DAO_Tin_Tuc = new dao_Tin_Tuc();
         protected void Page_Load(object sender, EventArgs e)
    {
        // Page.IsPostBack = false nghĩa là trang vừa được tải lần đầu (chưa bấm nút, chưa submit form)
        // Nếu true (người dùng vừa bấm nút hoặc reload dữ liệu) thì không cần gọi lại HienThiNhomTin()
        // để tránh load lại dữ liệu dropdownlist nhiều lần gây trùng lặp.
        if (!Page.IsPostBack)
        {
            HienThiNhomTin();  // Gọi hàm hiển thị danh sách nhóm tin khi trang lần đầu mở
            HienThiTatCaTin();
        }
    }

    protected void HienThiTatCaTin()
    {
        DataSet ds;
        try
        {
            ds = DAO_Tin_Tuc.DanhSach_TatCaTin();
            grv_Tin.DataSource = ds;
            grv_Tin.DataBind();
            ds.Tables.Clear();
            ds.Clear();
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    // Hàm HienThiNhomTin() có nhiệm vụ lấy dữ liệu từ database thông qua Stored Procedure sp_DS_NhomTin
    // Sau đó gán dữ liệu đó vào dropdownlist (drl_NhomTin)
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

    protected void HienThiDanhSachTin(int ID_Nhom)
    {
        DataSet ds;
        try
        {
            ds = DAO_Tin_Tuc.DanhSach_TinTheoNhomTin(ID_Nhom);
            grv_Tin.DataSource = ds;
            grv_Tin.DataBind();
            ds.Tables.Clear();
            ds.Clear();
        }
        catch (Exception)
        {

            throw;
        }
    }
    protected void drl_NhomTin_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Code của bạn để xử lý khi người dùng chọn một mục
        int ID_Nhom = Convert.ToInt32(drl_NhomTin.SelectedValue.ToString());
        if( ID_Nhom == 0)
        {
            HienThiTatCaTin();
        }
        else
        {
            HienThiDanhSachTin(ID_Nhom);
        }
            
    }
}
