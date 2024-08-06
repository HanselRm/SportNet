
using SportNet.Core.Domain.Common;

namespace SportNet.Core.Domain.Entities
{
    public class EventParticipation : AuditableBaseEntity
    {
        public int EventId { get; set; }
        public int UserId { get; set; }
        public DateTime RegistrationDate { get; set; }

        //Navigation Properties
        public Events Event { get; set; }
        public Users User { get; set; }
    }
}
