using PCATAPI.Models.Infos;
using PNorthWindAPI.Models.ApiModel;
using PNorthWindAPI.Models.DAOs;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;

namespace PNorthWindAPI.Controllers.WebAPI
{
    public class ShipperController : ApiController
    {
        [HttpGet]
        [Route("api/Shipper")]
        public List<ShipperAM> getShippers()
        {
            List<ShipperAM> oShippers = new List<ShipperAM>();
            ShipperDao dao = new ShipperDao();
            try
            {
                oShippers = dao.getShipprs();
            }
            catch (Exception ex)
            {
                ErrMsgInfo oErr = new ErrMsgInfo();
                oErr.ex = ex;
                HttpResponseMessage RepMsg = oErr.RepMsg;
                throw new HttpResponseException(RepMsg);
            }
            return oShippers;
        }

        [HttpGet]
        [Route("api/Shipper/{ShipperID}")]
        public ShipperAM getShipper(int ShipperID = 0)
        {
            ShipperAM oShipper = new ShipperAM();
            ShipperDao dao = new ShipperDao();
            try
            {
                oShipper = dao.getShipper(ShipperID);
            }
            catch (Exception ex)
            {
                ErrMsgInfo oErr = new ErrMsgInfo();
                oErr.ex = ex;
                HttpResponseMessage RepMsg = oErr.RepMsg;
                throw new HttpResponseException(RepMsg);
            }
            return oShipper;
        }

        [HttpPost]
        [Route("api/Shipper/Insert")]
        public JsonRltInfo InsertItem([FromBody]ShipperAM oShipper)
        {
            JsonRltInfo oRlt = new JsonRltInfo();
            ShipperDao dao = new ShipperDao();
            try
            {
                string rc = dao.InsertShipper(oShipper);
                if (rc == "Success")
                {
                    oRlt.rltCode = 0;
                    oRlt.rltMsg = "新增成功";
                }
            }
            catch (Exception ex)
            {
                oRlt.rltCode = 417;
                oRlt.rltMsg = ex.Message;
            }
            return oRlt;
        }

        [HttpPost]
        [Route("api/Shipper/Update")]
        public JsonRltInfo UpdateItem([FromBody]ShipperAM oShipper)
        {
            JsonRltInfo oRlt = new JsonRltInfo();
            ShipperDao dao = new ShipperDao();
            try
            {
                string rc = dao.ChgShipper(oShipper);
                if (rc == "Success")
                {
                    oRlt.rltCode = 0;
                    oRlt.rltMsg = "更新成功";
                }
            }
            catch (Exception ex)
            {
                oRlt.rltCode = 417;
                oRlt.rltMsg = ex.Message;
            }
            return oRlt;
        }

        [HttpGet]
        [Route("api/Shipper/Del/{ShipperID}")]
        public JsonRltInfo DelItem(int ShipperID)
        {
            JsonRltInfo oRlt = new JsonRltInfo();
            ShipperDao dao = new ShipperDao();
            try
            {
                string rc = dao.DelShipper(ShipperID);
                if (rc == "Success")
                {
                    oRlt.rltCode = 0;
                    oRlt.rltMsg = "刪除成功";
                }
            }
            catch (Exception ex)
            {
                oRlt.rltCode = 417;
                oRlt.rltMsg = ex.Message;
            }
            return oRlt;
        }

    }
}
