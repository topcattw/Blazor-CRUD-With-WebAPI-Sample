using Dapper;
using PNorthWindAPI.Models.ApiModel;
using PNorthWindAPI.Models.Info;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Transactions;

namespace PNorthWindAPI.Models.DAOs
{
    public class ShipperDao
    {
        public List<ShipperAM> getShipprs() 
        {
            List<ShipperAM> oShippers = new List<ShipperAM>();
            try
            {
                string ConnStr = GetConnStr();
                using(SqlConnection Conn = new SqlConnection(ConnStr))
                {
                    Conn.Open();
                    string SqlTxt = "";
                    SqlTxt += " SELECT * ";
                    SqlTxt += " FROM [dbo].[Shippers] (NOLOCK) ";
                    SqlTxt += "  ";

                    oShippers = Conn.Query<ShipperAM>(SqlTxt).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oShippers;
        }

        public ShipperAM getShipper(int ShipperID)
        {
            ShipperAM oShipper = new ShipperAM();
            try
            {
                string ConnStr = GetConnStr();
                using(SqlConnection Conn = new SqlConnection(ConnStr))
                {
                    Conn.Open();
                    string SqlTxt = "";
                    SqlTxt += " SELECT * ";
                    SqlTxt += " FROM [dbo].[Shippers] (NOLOCK) ";
                    SqlTxt += " WHERE ShipperID = @ShipperID ";
                    SqlTxt += "  ";

                    oShipper = Conn.Query<ShipperAM>(SqlTxt, new { ShipperID = ShipperID }).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oShipper;
        }

        public string InsertShipper(ShipperAM oShipper)
        {
            string rc = "";
            using (var scope = new TransactionScope())
            {
                try
                {
                    string ConnStr = GetConnStr();
                    using (SqlConnection Conn = new SqlConnection(ConnStr))
                    {
                        Conn.Open();
                        string SqlTxt = "";
                        SqlTxt += " INSERT INTO [dbo].[Shippers] ";
                        SqlTxt += " 	(CompanyName, Phone) ";
                        SqlTxt += " VALUES (@CompanyName, @Phone) ";
                        SqlTxt += "  ";
                        Conn.Execute(SqlTxt, oShipper);
                        rc = "Success";
                    }
                    scope.Complete();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return rc;
        }

        public string ChgShipper(ShipperAM oShipper)
        {
            string rc = "";
            using (var scope = new TransactionScope())
            {
                try
                {
                    string ConnStr = GetConnStr();
                    using (SqlConnection Conn = new SqlConnection(ConnStr))
                    {
                        Conn.Open();
                        string SqlTxt = "";
                        SqlTxt += " UPDATE [dbo].[Shippers] ";
                        SqlTxt += " SET CompanyName = @CompanyName ";
                        SqlTxt += " 	, Phone = @Phone ";
                        SqlTxt += " WHERE ShipperID = @ShipperID ";
                        SqlTxt += "  ";
                        Conn.Execute(SqlTxt, oShipper);
                        rc = "Success";
                    }
                    scope.Complete();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return rc;
        }

        public string DelShipper(int ShipperID)
        {
            string rc = "";
            using (var scope = new TransactionScope())
            {
                try
                {
                    string ConnStr = GetConnStr();
                    using (SqlConnection Conn = new SqlConnection(ConnStr))
                    {
                        Conn.Open();
                        string SqlTxt = "";
                        SqlTxt += " DELETE Shippers ";
                        SqlTxt += " WHERE ShipperID = @ShipperID ";
                        SqlTxt += "  ";
                        Conn.Execute(SqlTxt, new { ShipperID = ShipperID });
                        rc = "Success";
                    }
                    scope.Complete();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return rc;
        }

        private string GetConnStr()
        {
            string ConnStr = "";
            ConnStrInfo oConnStr = new ConnStrInfo();
            ConnStr = oConnStr.ConnStr;
            return ConnStr;
        }
    }
}