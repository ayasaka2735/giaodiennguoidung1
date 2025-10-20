using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Tendangnhap"] == null)
        {
            Response.Redirect("Dangnhap.aspx");
        }
        else
            lbl_tendangnhap.Text = Session["Tendangnhap"].ToString(); //Tên đăng nhập trong trang Quản trị phải nhập lại để lấy thông tin người dùng đã nhập từ bên trang đăng nhập
    }

    protected void lkb_dangxuat_Click(object sender, EventArgs e)
    {
        Session.Remove("Tendangnhap");
        //Session.Abandon(); Để clear toàn bộ các session, kiểu sẽ xóa đi tất cả tên đăng nhập mật khẩu đã dùng trước đó
        Response.Redirect("Dangnhap.aspx"); //Khi click vào đăng xuất thì sẽ trở lại trang đăng nhập
    }
}
