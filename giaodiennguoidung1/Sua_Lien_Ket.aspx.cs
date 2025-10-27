using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Sua_Lien_Ket : System.Web.UI.Page
{
    dao_Lien_Ket DAO_Lien_Ket = new dao_Lien_Ket(); //Tạo 1 đối tượng DAO_Lien_Ket thuộc lớp dao_Lien_Ket để kế thừa hàm dao_Lien_Ket bao gồm các phương thức, 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            HienThi();
        }
    }
    protected void HienThi()
    {
        int ID_Lien_Ket = -1;
        try
        {
            ID_Lien_Ket = Convert.ToInt32(Request.QueryString["ID_Lien_Ket"].ToString());
        }
        catch
        {
        }
        if (ID_Lien_Ket != -1)
        {
            btn_Cap_Nhat.Visible = true;
            DataSet ds;
            try
            {
                ds = DAO_Lien_Ket.HienThi_Lien_Ket(ID_Lien_Ket);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Image1.ImageUrl = "~/" + ds.Tables[0].Rows[0]["Anh"].ToString();
                    TextBox1.Text = ds.Tables[0].Rows[0]["Link"].ToString();
                    ds.Tables.Clear();
                    ds.Clear();
                }
                else
                {
                    btn_Cap_Nhat.Visible = false;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                ds = null;
            }
        }
        else
        {
            btn_Cap_Nhat.Visible = false;
        }
    }
    protected void btn_Cap_Nhat_Click(object sender, EventArgs e)
    {
        int ID_Lien_Ket = Convert.ToInt32(Request.QueryString["ID_Lien_Ket"]);
        string Link = TextBox1.Text.Trim();
        string Anh = Image1.ImageUrl.Replace("~/", ""); // ảnh cũ mặc định

        // Nếu có chọn ảnh mới thì lưu ảnh mới và thay đường dẫn
        if (FileUpload1.HasFile)
        {
            string strPath = Server.MapPath("~\\") + "Anh_Lien_Ket/";
            string filename = FileUpload1.FileName;

            // Tách tên và phần mở rộng (đuôi)
            string tmp = filename.Substring(0, filename.LastIndexOf('.'));
            string exp = filename.Substring(filename.LastIndexOf('.'));

            // Thêm thời gian vào tên ảnh để tránh trùng
            DateTime dt = DateTime.Now;
            string strdt = dt.ToString("ddMMyyyyHHmmss");

            // Tạo tên ảnh mới kèm ngày tháng
            string newFileName = tmp + "_" + strdt + exp;
            string fullPath = strPath + newFileName;

            // Lưu ảnh vào thư mục
            FileUpload1.SaveAs(fullPath);

            // Cập nhật đường dẫn trong DB (chỉ lưu tên tương đối)
            Anh = "Anh_Lien_Ket/" + newFileName;
        }

        // Gọi hàm cập nhật trong DAO
        DAO_Lien_Ket.CapNhat_Lien_Ket(ID_Lien_Ket, Anh, Link);

        // Quay lại trang danh sách
        Response.Redirect("QuanLiLienKet.aspx");
    }

}
