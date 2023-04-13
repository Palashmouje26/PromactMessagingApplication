using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PromactMessagingApp.Core.Hubs
{
    public class ChatHub : Hub
    {
      
        public static List<string> Id = new List<string>();

        /// <summary>
        /// this method is used for connecting to the hub.
        /// </summary>
        /// <returns>return show disconnection</returns>
        public override Task OnConnectedAsync()
        {
            var connectionId = Context.ConnectionId;
            Id.Add(connectionId);
            return base.OnConnectedAsync();
        }

        /// <summary>
        /// This method is for disconnect the user.
        /// </summary>
        /// <returns> return show disconnection</returns>
        public override Task OnDisconnectedAsync(Exception exception)
        {
            var connectionId = Context.ConnectionId;
            Id.Remove(connectionId);
            return base.OnDisconnectedAsync(exception);
        }

        /// <summary>
        /// This method is used for send and recived messages. 
        /// </summary>
        /// <param name="connectionId">It is used for user connection-Id.</param>
        /// <param name="message">It is used for user massage.</param>
        /// <returns>returns the message.</returns>
        public async Task SendAsync(string connectionId, string message)
        {
            await Clients.Client(connectionId).SendAsync("Send", message);
            await Clients.Caller.SendAsync("Send", message);
            return;
        }
    }
}
