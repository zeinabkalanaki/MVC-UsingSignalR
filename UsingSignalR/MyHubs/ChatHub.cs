using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace UsingSignalR.MyHubs
{
    public class ChatHub : Hub
    {
        //تمام متد های این کلاس از سمت کلاینت قابل صدا زدن می باشند
        public async Task SendMessage(string user, string message)
        {
            //All همه کانکشن های متصل به سرور
            //Caller جواب به (صدا کننده این متد)فرستنده پیام پاسخ دهیم --> مث تیک اول تلگرام
            //Others جواب به همه به غیر از صدا کننده این متد

            //ReceivedMessage نام متدی که در جاوا اسکریپت جواب را تحویل می گیرد
            await Clients.All.SendAsync("ReceivedMessage", user, message);
        }

        public override Task OnConnectedAsync()
        {
            //این event
            //با وصل شدن هر نفر فراخوانی میشود
            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception exception)
        {
            //این event
            //با قطع شدن هر نفر فراخوانی میشود
            return base.OnDisconnectedAsync(exception);
        }
    }
}
