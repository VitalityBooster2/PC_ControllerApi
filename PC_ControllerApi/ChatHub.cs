using Microsoft.AspNetCore.SignalR;
using PC_ControllerApi.Models;
using System.Collections.Concurrent;

namespace PC_ControllerApi
{
    public class ChatHub:Hub
    {
        public static ConcurrentDictionary<Guid,IClientProxy> ClientProxies { get; private set; } = new ConcurrentDictionary<Guid,IClientProxy>();

        public async Task Register(Guid token, string message)
        {
            IClientProxy proxy = Clients.Client(Context.ConnectionId);
            ClientProxies.AddOrUpdate(token, (id, proxy) => proxy, (id, oldVal, newVal) => newVal, proxy);
        }
    }
}
