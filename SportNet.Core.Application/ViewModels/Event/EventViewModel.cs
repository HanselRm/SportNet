

namespace SportNet.Core.Application.ViewModels.Event
{
    public class EventViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Caption { get; set; }
        public string Location { get; set; }
        public string Sport { get; set; }
        public int stars { get; set; }
        public DateOnly? Date { get; set; }
        public TimeOnly? Hour { get; set; }
        public int UserId { get; set; }
    }
}
