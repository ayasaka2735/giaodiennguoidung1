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

}