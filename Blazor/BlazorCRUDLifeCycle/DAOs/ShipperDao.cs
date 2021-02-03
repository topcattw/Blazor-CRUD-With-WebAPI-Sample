using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BlazorCRUDLifeCycle.Data;
using PCAT_Blazor.Data;

namespace BlazorCRUDLifeCycle.DAOs
{

    public class ShipperDao
    {
        private string urlServer = "";

        public ShipperDao()
        {
            UriWebAPI oUriWebAPI = new UriWebAPI();
            urlServer = oUriWebAPI.UriServer;
        }

        #region 查詢

        public async Task<List<ShipperVM>> GetShippersAsync()
        {
            List<ShipperVM> oShippers = new List<ShipperVM>();
            try
            {
                HttpClient client = new HttpClient();
                string sUrl = urlServer + "/api/Shipper";

                HttpResponseMessage response = await client.GetAsync(sUrl);
                string jData = await response.Content.ReadAsStringAsync();
                oShippers = JsonSerializer.Deserialize<List<ShipperVM>>(jData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oShippers;
        }

        public async Task<ShipperVM> GetShipperAsync(int ShipperID)
        {
            ShipperVM oShipper = new ShipperVM();
            try
            {
                HttpClient client = new HttpClient();
                string sUrl = urlServer + "/api/Shipper/" + ShipperID.ToString(); ;

                HttpResponseMessage response = await client.GetAsync(sUrl);
                string jData = await response.Content.ReadAsStringAsync();
                oShipper = JsonSerializer.Deserialize<ShipperVM>(jData);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oShipper;
        }

        #endregion


        #region 維護

        public async Task<string> InsertItemAsync(ShipperVM oShipper)
        {
            string rc = "";
            try
            {
                string sUrl = urlServer + "/api/Shipper/Insert";
                string jsonData = JsonSerializer.Serialize<ShipperVM>(oShipper);

                HttpClient http = new HttpClient();
                HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await http.PostAsync(sUrl, content);
                if (response.IsSuccessStatusCode)
                {
                    string jRlt = await response.Content.ReadAsStringAsync();
                    JsonRltInfo oRlt = JsonSerializer.Deserialize<JsonRltInfo>(jRlt);
                    if (oRlt.rltCode == 0)
                    {
                        rc = oRlt.rltMsg;
                    }
                    else
                    {
                        throw new Exception(oRlt.rltMsg);
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return rc;
        }

        public async Task<string> UpdateItemAsync(ShipperVM oShipper)
        {
            string rc = "";
            try
            {
                string sUrl = urlServer + "/api/Shipper/Update";
                string jsonData = JsonSerializer.Serialize<ShipperVM>(oShipper);

                HttpClient http = new HttpClient();
                HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await http.PostAsync(sUrl, content);
                if (response.IsSuccessStatusCode)
                {
                    string jRlt = await response.Content.ReadAsStringAsync();
                    JsonRltInfo oRlt = JsonSerializer.Deserialize<JsonRltInfo>(jRlt);
                    if (oRlt.rltCode == 0)
                    {
                        rc = oRlt.rltMsg;
                    }
                    else
                    {
                        throw new Exception(oRlt.rltMsg);
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return rc;  
        }

        public async Task<string> DelItemAsync(int ShipperID)
        {
            string rc = "";
            try
            {
                HttpClient client = new HttpClient();
                string sUrl = urlServer + "/api/Shipper/Del/" + ShipperID.ToString();

                HttpResponseMessage response = await client.GetAsync(sUrl);
                string jData = await response.Content.ReadAsStringAsync();
                JsonRltInfo oRlt = JsonSerializer.Deserialize<JsonRltInfo>(jData);
                if (oRlt.rltCode == 0)
                {
                    rc = oRlt.rltMsg;
                }
                else
                {
                    throw new Exception(oRlt.rltMsg);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return rc;
        }
        #endregion

    }
}
