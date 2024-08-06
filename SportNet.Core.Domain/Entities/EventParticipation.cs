
namespace SportNet.Core.Domain.Entities
{
    public class EventParticipation
    {
        public int EventId { get; set; }
        public int UserId { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
