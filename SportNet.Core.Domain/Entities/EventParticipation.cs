
namespace SportNet.Core.Domain.Entities
{
    public class EventParticipation
    {
        public int EventId { get; set; }
        public int UserId { get; set; }
        public DateTime RegistrationDate { get; set; }

        //Navigation Properties
        public Events Event { get; set; }
        public Users User { get; set; }
    }
}
