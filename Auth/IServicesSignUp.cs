using Microsoft.AspNetCore.Authentication;
using System.Threading.Tasks;

namespace BugBlaze.Auth
{
    public interface IServicesSignUp
    {
        Task CreateOnSignUp(TicketReceivedContext ticketReceivedContext);
    }
}