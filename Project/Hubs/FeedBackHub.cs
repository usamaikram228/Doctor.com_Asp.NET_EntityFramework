
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
namespace Project.Hubs
{

    public class FeedbackHub : Hub
    {
        public async Task SendFeedback(int doctorId, int rating, string comments)
        {
            await Clients.All.SendAsync("ReceiveFeedback", doctorId, rating, comments);
        }
    }
}
