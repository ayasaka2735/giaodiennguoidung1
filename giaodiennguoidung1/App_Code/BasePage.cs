using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
/// <summary>
/// Summary description for BasePage
/// </summary>
public class BasePage : System.Web.UI.Page
{
    public string Connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    //public string Connection: tạo 1 anh xe buýt chuỗi kết nối
    //ConfigurationManager.ConnectionStrings[" "]: Xây dựng 1 con đường để vận chuyển, chỉ rõ con đường phải chạy trên tuyến web.config tên là ConnectionString, tuyến đường trong basepage phải giống hệt tên trong webconfig thì nó mới chạy
    
    /*Ví dụ dễ hiểu theo ngữ cảnh “xe tải chở hàng” 🚛
    ConfigurationManager = ông chủ gara, người giữ toàn bộ hồ sơ giao hàng.
    .ConnectionStrings = tủ hồ sơ chứa danh sách các kho hàng.
    ["ConnectionString"] = chọn đúng hồ sơ của một kho cụ thể.
    .ConnectionString = lấy địa chỉ chi tiết kho hàng (số nhà, tên đường, mật khẩu mở cổng). */
    public BasePage()
    {
        //
        // TODO: Add constructor logic here
        //
        //BasePage: chở hàng từ chỗ giao hàng đến cổng trường ĐHHL
    }
}