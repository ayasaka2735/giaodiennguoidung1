using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DataAccess;

/// <summary>
/// Summary description for dao_Tin_Tuc
/// </summary>
public class dao_Tin_Tuc : BasePage
{
    public void ThemMoi_Tin(string TenTin, string Anh, string TomTat,string NoiDung, int ID_Nhom)
    {
        try
        {
            SqlDataAccess.ExecuteNonQuery(Connection, "sp_ThemMoi_Tin", TenTin, Anh, TomTat, NoiDung, ID_Nhom);
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    public DataSet DanhSach_NhomTin()
    {
        try
        {
            return SqlDataAccess.ExecuteDataset(Connection, "sp_DanhSach_NhomTin", null);
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    public DataSet DanhSach_TinTheoNhomTin(int ID_Nhom)
    {
        try
        {
            return SqlDataAccess.ExecuteDataset(Connection, "sp_DanhSach_TinTheoNhomTin", ID_Nhom);
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    public DataSet DanhSach_TatCaTin()
    {
        try
        {
            return SqlDataAccess.ExecuteDataset(Connection, "sp_DanhSach_TatCaTin", null);
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    //sp_DanhSach_TatCa_Tin
    public dao_Tin_Tuc()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}