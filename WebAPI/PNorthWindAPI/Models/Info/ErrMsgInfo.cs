using System;
using System.Net;
using System.Net.Http;

namespace PCATAPI.Models.Infos
{
    public class ErrMsgInfo
    {
        private string m_ErrCode = "";
        private string m_ErrMsg = "";
        private string m_ErrTime = "";
        private string m_ErrJSON = "";

        private Exception m_Ex = null;
        private HttpResponseMessage m_RepMsg = null;

        public Exception ex
        {
            set
            {
                m_Ex = value;
                if (m_Ex != null)
                {
                    m_ErrCode = m_Ex.HResult.ToString();
                    m_ErrMsg = m_Ex.Message;
                    GenErrJSON();
                }
            }
        }

        public HttpResponseMessage RepMsg
        {
            get
            {
                return m_RepMsg;
            }
        }


        private void GenErrJSON()
        {
            //throw new NotImplementedException(); 
            if (m_ErrCode != "" && m_ErrMsg != "")
            {
                m_ErrJSON = "{\"ErrCode\":" + m_ErrCode + ",\"ErrMsg\":" + m_ErrMsg + "}";
                m_RepMsg = new HttpResponseMessage(HttpStatusCode.ExpectationFailed);
                m_RepMsg.Content = new StringContent(m_ErrJSON);
                m_ErrTime = DateTime.Now.ToString("yyyyMMddHHmmss");
                m_RepMsg.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            }
        }
    }
}