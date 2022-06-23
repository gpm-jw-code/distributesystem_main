using DistributedSystem_Main.Systems;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp.Server;

namespace DistributedSystem_Main.WebService.WebsocketBehaviors
{
    public class GroupInfoBehavior : WebSocketBehavior
    {
        protected override void OnOpen()
        {
            base.OnOpen();
            //var action = Context.QueryString[0];
            //var edgeName = Context.QueryString[1];
            Send(JsonConvert.SerializeObject(Systems.cls_HomePageManager.Dict_GroupObject));
            Systems.cls_HomePageManager.Event_GroupSettingChange = SendGroupSetting;
        }

        private void SendGroupSetting(Dictionary<string, cls_HomePageManager.cls_GroupObject> obj)
        {
            Send(JsonConvert.SerializeObject(obj));
        }
    }
}
