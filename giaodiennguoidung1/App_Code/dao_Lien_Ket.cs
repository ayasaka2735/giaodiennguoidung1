using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DataAccess;

/// <summary>
/// Summary description for dao_Lien_Ket
/// </summary>
public class dao_Lien_Ket : BasePage
{
    public DataSet DanhSach_LienKet() //Dùng để chứa bảng, lưới //Đây là một người xuống nhận và kiểm tra hàng trước khi đưa vào kí túc xá
    {
        try
        {
            return SqlDataAccess.ExecuteDataset(Connection, "sp_DanhSach_LienKet", null); //Đây là một người xuống nhận và kiểm tra hàng trước khi đưa vào kí túc xá
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
        catch (Exception)
        {

            throw;
        }
    }
    public dao_Lien_Ket()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}