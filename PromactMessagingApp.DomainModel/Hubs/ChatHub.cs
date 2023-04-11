using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PromactMessagingApp.Core.Hubs
{
    public class ChatHub : Hub
    {
        public static List<string> Id = new List<string>();

        public static class ConnectedUser
        {

        }


        public override Task OnConnectedAsync()
        {

            var connectionId = Context.ConnectionId;
            Id.Add(connectionId);
            //var username = Context.User.Identity.Name;
            //Id.Add(username,connectionId);
            Clients.Client(connectionId).SendAsync(connectionId, "ReceiveMessage");
            Clients.Caller.SendAsync(connectionId, "ReceiveMessage");
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            var connectionId = Context.ConnectionId;
            Id.Remove(connectionId);
            return base.OnDisconnectedAsync(exception);
        }

        public async Task RecieveMesssageAsync(string message, string connectionId)
        {
            await Clients.Client(connectionId).SendAsync("RecieveMesssage", message);
            await Clients.Caller.SendAsync("RecieveMesssage", message);
            return;
        }





    }
}
