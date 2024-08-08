using SportNet.Core.Application.DTOS.Email;


namespace SportNet.Core.Application.Services
{
    public interface IEmailServices
    {
        Task sendAsync(EmailRequest request);
    }
}
