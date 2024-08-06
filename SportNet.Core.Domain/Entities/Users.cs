namespace SportNet.Core.Domain.Entities
{
    public class Users
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }

        //Navigation Properties
        public ICollection<Events> CreatedEvents { get; set; }
        public ICollection<EventParticipation> EventParticipations { get; set; }
    }
}
