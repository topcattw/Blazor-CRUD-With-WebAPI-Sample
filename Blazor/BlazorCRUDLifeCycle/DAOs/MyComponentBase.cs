using BlazorCRUDLifeCycle.Data;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCRUDLifeCycle.DAOs
{
    public class MyComponentBase : ComponentBase
    {
        public MsgInfo oMsg = new MsgInfo();

        public void ShowMsg(string Msg, string Title = "訊息：")
        {
            oMsg.Title = Title;
            oMsg.Msg = Msg;
            oMsg.showMsg = true;
        }
    }


}
