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
    public BasePage()
    {
        //
        // TODO: Add constructor logic here
        //
        //BasePage: chở hàng từ chỗ giao hàng đến cổng trường ĐHHL
    }
}