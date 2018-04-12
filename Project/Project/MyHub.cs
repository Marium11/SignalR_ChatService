using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Project.Models;

namespace Project
{
    public class MyHub : Hub
    {
        //static List<RegisterViewModel> connectedUsers = new List<RegisterViewModel>();
        ApplicationDbContext db = new ApplicationDbContext();
        //public void Connect(string name)
        //{
        //    var req = new RequestInfo
        //    {
        //        Approved = false,
        //        GroupName = name,
        //        ReqDateTime = DateTime.Now.ToString(),
        //        UserName = Context.User.Identity.Name

        //    };
        //    db.RequestInfos.Add(req);
        //    db.SaveChanges();
        //    Clients.Others.ReceivedMessage("Server", name);
        //    Clients.Caller.ReceivedMessage("ME", name);

        //}
        public void Send(string msg)
        {
            string gName = db.RequestInfos.Where(u => u.UserName.Equals(Context.User.Identity.Name)).SingleOrDefault().GroupName;
            //MessageInfo messag = new MessageInfo { MessageBody = msg, PostDateTime = DateTime.Now.ToString(), UserName = Context.User.Identity.Name };
           var MessageInfo  = new MessageInfo
           { MessageBody = msg,
               PostDateTime = DateTime.Now.ToString(), 
               UserName = Context.User.Identity.Name };
            //db.MessageInfos.Add(messag);
           db.MessageInfos.Add(MessageInfo);
            if(db.SaveChanges()>0)
            {
                Groups.Add(Context.ConnectionId, gName);
                var type = "str";
            //Clients.Others.ReceivedMessage(Context.User.Identity.Name, msg);
            Clients.OthersInGroup(gName).Received(MessageInfo.UserName,msg,type);

            Clients.Caller.Received("You", msg,type);
            //Clients.Caller.ReceivedMessage("ME", msg);
        }
        }
        //public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
        //{
        //    Clients.All.ReceivedMessage("SERVER", Context.User.Identity.Name + " logout now");
        //    return base.OnDisconnected(stopCalled);
        //}
    }
}