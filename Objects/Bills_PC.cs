using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace Inventory
{
  public class Bills_PC
  {
    private int _DEX_NO;
    private string _Name;
    private string _NickName;
    private int _LV_;

    public Bills_PC(int DEX_NO, string Name, string NickName, int LV_)
    {
      _DEX_NO = DEX_NO;
      _Name = Name;
      _NickName = NickName;
      _LV_ = LV_;
    }

    public int GetDex()
    {
        return _DEX_NO;
    }

    public string GetName()
    {
        return _Name;
    }

    public string GetNick()
    {
        return _NickName;
    }

    public int GetLv()
    {
        return _LV_;
    }

    public static List<Bills_PC> GetAll()
    {
      List<Bills_PC> allBills_PCs = new List<Bills_PC>{};

      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM Bills_PC;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int dex = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        string nickName = rdr.GetString(2);
        int lv = rdr.GetInt32(3);
        Bills_PC newBill = new Bills_PC(dex, name, nickName, lv);
        allBills_PCs.Add(newBill);
      }

      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }

      return allBills_PCs;
    }

    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO Bills_PC (DEX_NO, Name, NickName, LV_) VALUES (@DEX_NO, @Name, @NickName, @LV_);", conn);

      SqlParameter dexParameter = new SqlParameter();
      dexParameter.ParameterName = "@DEX_NO";
      dexParameter.Value = this.GetDex();
      cmd.Parameters.Add(dexParameter);
      SqlParameter nameParameter = new SqlParameter();
      nameParameter.ParameterName = "@Name";
      nameParameter.Value = this.GetName();
      cmd.Parameters.Add(nameParameter);
      SqlParameter nickParameter = new SqlParameter();
      nickParameter.ParameterName = "@NickName";
      nickParameter.Value = this.GetNick();
      cmd.Parameters.Add(nickParameter);
      SqlParameter lvParameter = new SqlParameter();
      lvParameter.ParameterName = "@LV_";
      lvParameter.Value = this.GetLv();
      cmd.Parameters.Add(lvParameter);
      SqlDataReader rdr = cmd.ExecuteReader();

      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
    }

    public static void DeleteOne(string nick)
    {
        SqlConnection conn = DB.Connection();
        conn.Open();

        SqlCommand cmd = new SqlCommand("DELETE FROM Bills_PC WHERE NickName = @NickName;", conn);
        SqlParameter searchParameter = new SqlParameter();
        searchParameter.ParameterName = "@NickName";
        searchParameter.Value = nick;
        cmd.Parameters.Add(searchParameter);
    }

    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM Bills_PC;", conn);
      cmd.ExecuteNonQuery();
      conn.Close();
    }

  }
}
