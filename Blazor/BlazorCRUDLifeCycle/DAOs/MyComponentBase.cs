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
    }
}
