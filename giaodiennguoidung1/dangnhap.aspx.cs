using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class dangnhap : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_dangnhap_Click(object sender, EventArgs e)
    {
        if (txt_tendangnhap.Text == "Admin" && txt_matkhau.Text == "123")
        {
            Session["Tendangnhap"] = "Admin";
           //Session["Tendangnhap"] = txt_tendangnhap.Text;
            Response.Redirect("Default.aspx");
        }
        else
            lb_thongbao.Text = "Sai tên đăng nhập hoặc mật khẩu";

    }
    
}