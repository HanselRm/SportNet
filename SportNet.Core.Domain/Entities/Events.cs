

namespace SportNet.Core.Domain.Entities
{
    public class Events
    {
        public string Name { get; set; }
        //descripción del evento
        public string Caption { get; set; }
        //Localizacion del evento
        public string Location { get; set; }
        //deporte de cual es el evento
        public string Sport { get; set; }
        //puntuaciones de estrellas
        public int stars { get; set; }
        //dia del evento
        public DateOnly Date { get; set; }
        //hora del evento
        public TimeOnly Hour { get; set; }

        //para relacionar quienes estan dentro del evento
        public int UserId { get; set; }

        //Navigation Properties
        public Users User { get; set; }
        public ICollection<EventParticipation> EventParticipations { get; set; }
    }
}
