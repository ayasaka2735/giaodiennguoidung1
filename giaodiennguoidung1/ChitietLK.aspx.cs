using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ChitietLK : System.Web.UI.Page
{
    dao_Lien_Ket DAO_Lien_Ket = new dao_Lien_Ket();
    public void HienThi()
    {
        int ID_Lien_Ket = Convert.ToInt32(Request.QueryString["ID_Lien_Ket"].ToString());
        DataSet ds;
        try
        {
            ds = DAO_Lien_Ket.ChiTiet_LK(ID_Lien_Ket);
            img_Anh_Cu.ImageUrl = ds.Tables[0].Rows[0]["Anh"].ToString();
            txt_Link.Text = ds.Tables[0].Rows[0]["Link"].ToString();

            ds.Tables.Clear();
            ds.Clear();
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    protected void btn_CapNhat_Click(object sender, EventArgs e)
    {
        int ID_Lien_Ket = Convert.ToInt32(Request.QueryString["ID_Lien_Ket"].ToString());
        //Yêu cầu phải điền url, nếu không phải hiển thị thông báo
        if (txt_Link.Text != null)
        {
            string Anh, Link;
            Link = txt_Link.Text;
            //Nếu có ảnh mới
            if (ful_Anh_Moi.HasFile)
            {
                //1. Xóa ảnh cũ đi
                DataSet ds;
                try
                {
                    ds = DAO_Lien_Ket.ChiTiet_LK(ID_Lien_Ket);
                    //Lấy đường dẫn tới ảnh cũ
                    Anh = ds.Tables[0].Rows[0]["Anh"].ToString();
                    //Xóa ảnh cũ tại đường dẫn
                    System.IO.File.Delete(Server.MapPath("~\\" + Anh));

                    ds.Tables.Clear();
                    ds.Clear();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                //2. Copy ảnh mới vào thư mục mywweb

                //1. Copy ảnh vào trong thư mục Anh_Lien_Ket
                //2. Đưa đường dãn vào trong CSDL
                //Tìm đường vào thư mục chứa ảnh Server.MapPath("~\\") 
                string strPath = Server.MapPath("~\\") + "Anh_Lien_Ket/";
                //Lấy tên của ảnh đưa vào
                string filename = ful_Anh_Moi.FileName;
                //Tách ảnh: Tên ảnh + Đuôi mở rộng 
                string tmp = filename.Substring(0, filename.Length - 4);//Tách tên 
                                                                        //Có thể về học thêm vòng for để tách tại đuôi mở rộng bất kì
                string exp = filename.Substring(filename.Length - 4, 4);//Tách đuôi
                                                                        //Thêm thời gian vào tên ảnh
                DateTime dt = DateTime.Now;//Lấy ngày giờ hệ thống, cụ thể là tại pin cmos
                string strdt = dt.ToString("ddMMyyyyhhmmss");//Chuyển về dạng ngày tháng năm
                                                             //Lưu ảnh vào trong thư mục Anh_Lien_Ket đã tạo
                                                             //ful_anh.SaveAs(strPath + filename); // Đã xong bước 1, cái này thì sẽ không có đuôi ngày tháng năm, bị trùng tên thì không biết lấy gì
                //3. Lấy đường dẫn ảnh để chuẩn bị đưa vào CSDL

                //Tên Ảnh_Time.đuôi mở rộng
                ful_Anh_Moi.SaveAs(strPath + tmp + "_" + strdt + exp); // Đã xong bước 1, cái này thì sẽ có đuôi ngày tháng năm, không bị trùng tên vì đã có ngày tháng năm làm gốc
                //2. Thực hiện đưa đường dẫn vào cơ sở dữ liệu
                Anh = "Anh_Lien_Ket/" + tmp + "_" + strdt + exp;
                HienThi();// Hiển thị lại kết quả sau khi thêm mới
            }
            //Ngược lại 
            else 
            {
                DataSet ds;
                try
                {
                    ds = DAO_Lien_Ket.ChiTiet_LK(ID_Lien_Ket);
                    Anh = ds.Tables[0].Rows[0]["Anh"].ToString();

                    ds.Tables.Clear();
                    ds.Clear();
                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }
           
            DAO_Lien_Ket.Sua_Lien_Ket(ID_Lien_Ket, Anh, Link);
            Response.Redirect("QuanLiLienKet.aspx");  
        }
        else
            lb_ThongBao.Text = "Bạn phải điền thông tin địa chi liên kết";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack) 
        {
            HienThi(); 
        }
    }


}