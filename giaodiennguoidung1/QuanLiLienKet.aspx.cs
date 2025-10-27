using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataAccess;
using System.Data.SqlClient;
public partial class QuanLiLienKet : BasePage
{
    dao_Lien_Ket DAO_Lien_Ket = new dao_Lien_Ket(); //Tạo 1 đối tượng DAO_Lien_Ket thuộc lớp dao_Lien_Ket để kế thừa hàm dao_Lien_Ket bao gồm các phương thức,
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            HienThi();
        }
    }
    public void HienThi()
    {
        DataSet ds;
        try
        {
            ds = DAO_Lien_Ket.DanhSach_LienKet();
            grv_LienKet.DataSource = ds;
            grv_LienKet.DataBind();
            
            //ds.Tables.Clear();
            //ds.Clear();
        }
        catch (Exception ex)
        {

            throw ex;
        } 
    }

    public void Xoa_Lien_Ket(int ID_Lien_Ket)
    {
        try
        {
            SqlDataAccess.ExecuteNonQuery(Connection, "sp_Xoa_Lien_Ket", ID_Lien_Ket);
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    protected void grv_LienKet_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int ID_Lien_Ket = Convert.ToInt32(grv_LienKet.DataKeys[e.RowIndex].Value.ToString());
        try
        {
            DAO_Lien_Ket.Xoa_Lien_Ket(ID_Lien_Ket);
            HienThi();
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }


    protected void btn_Themmoi_Click(object sender, EventArgs e)
    {
        if (ful_anh.HasFile && txt_link.Text != null)
        {
            //Thực hiện chèn
            string Anh, Link;
            Link = txt_link.Text;
            //1. Copy ảnh vào trong thư mục Anh_Lien_Ket
            //2. Đưa đường dãn vào trong CSDL
            //Tìm đường vào thư mục chứa ảnh Server.MapPath("~\\") 
            string strPath = Server.MapPath("~\\") + "Anh_Lien_Ket/";
            //Lấy tên của ảnh đưa vào
            string filename = ful_anh.FileName;
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
            ful_anh.SaveAs(strPath + tmp + "_" + strdt + exp); // Đã xong bước 1, cái này thì sẽ có đuôi ngày tháng năm, không bị trùng tên vì đã có ngày tháng năm làm gốc
            //2. Thực hiện đưa đường dẫn vào cơ sở dữ liệu
            Anh = "Anh_Lien_Ket/" + tmp + "_" + strdt + exp;
            DAO_Lien_Ket.Themmoi_LienKet(Anh, Link);
            HienThi();// Hiển thị lại kết quả sau khi thêm mới
        }
        else
            lb_ThongBao.Text = "Bạn chưa điền liên kết hoặc chọn ảnh";
    }
    //ful_anh mà có gạch đỏ ( Không tim thấy ID Control trong file .aspx ), kiểu mà chưa được tạo ở phần Design, .aspx
    //Nếu sai nữa thì inherit trong phần .aspx.cs không trùng với class trong .aspx

    protected void grv_LienKet_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int ID_Lien_Ket = Convert.ToInt32(grv_LienKet.DataKeys[e.NewEditIndex].Value.ToString());
        Response.Redirect("Sua_Lien_Ket.aspx?ID_Lien_Ket=" + ID_Lien_Ket);
    }
}
