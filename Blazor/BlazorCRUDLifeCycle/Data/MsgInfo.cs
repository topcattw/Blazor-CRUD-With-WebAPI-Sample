using System;

namespace BlazorCRUDLifeCycle.Data
{
    public class MsgInfo
    {
        private bool _showMsg = false;
        private string _NowTime;

        public string Msg { get; set; } = "";

        public string Title { get; set; } = "";

        public bool showMsg 
        {
            get { return _showMsg; } 
            set 
            {
                _showMsg = value;
                _NowTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            } 
        } 

        public string NowTime
        {
            get
            {
                return _NowTime;
            }
        }
    }
}
