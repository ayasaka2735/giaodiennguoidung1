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
    public void Themmoi_LienKet(string Anh, string Link)
    {
        try
        {
            SqlDataAccess.ExecuteNonQuery(Connection, "sp_Themmoi_LienKet", Anh, Link);
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    // ✅ Lấy chi tiết 1 liên kết (để hiển thị dữ liệu cũ)
    public DataSet HienThi_Lien_Ket(int ID_Lien_Ket)
    {
        try
        {
            return SqlDataAccess.ExecuteDataset(Connection, "sp_HienThi_Lien_Ket", ID_Lien_Ket);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    // ✅ Cập nhật dữ liệu trong DB
    public void CapNhat_Lien_Ket(int ID_Lien_Ket, string Anh, string Link)
    {
        try
        {
            SqlDataAccess.ExecuteNonQuery(Connection, "sp_CapNhat_Lien_Ket", ID_Lien_Ket, Anh, Link);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet ChiTiet_LK(int ID_Lien_Ket)
    {
        try
        {
            return SqlDataAccess.ExecuteDataset(Connection, "sp_ChiTiet_LK", ID_Lien_Ket);
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    public void Sua_Lien_Ket(int ID_Lien_Ket, string Anh, string Link)
    {
        try
        {
            SqlDataAccess.ExecuteNonQuery(Connection, "sp_Sua_Lien_Ket", ID_Lien_Ket, Anh, Link);
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    public dao_Lien_Ket()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}