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

            if (Context.QueryString.Count != 0)
            {
                var action = Context.QueryString[0];
                if (action.ToUpper() == "GET_GROUP_LIST")
                {
                    Send(JsonConvert.SerializeObject(cls_HomePageManager.Dict_GroupObject.Keys));
                }

            }
            else
            {
                Send(JsonConvert.SerializeObject(Systems.cls_HomePageManager.Dict_GroupObject));
                Systems.cls_HomePageManager.Event_GroupSettingChange = SendGroupSetting;
            }
        }

        private void SendGroupSetting(Dictionary<string, cls_HomePageManager.cls_GroupObject> obj)
        {
            try
            {
                Send(JsonConvert.SerializeObject(obj));
            }
            catch (Exception ex)
            {
            }
        }
    }
}
