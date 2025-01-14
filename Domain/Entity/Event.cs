using System.ComponentModel.DataAnnotations;

namespace mapis.Domain
{
    public class Events
    {
        public Events ()
        {
            Status = "Scheduled";
        }
        [Key]
        public Guid EventId {get;set;}
        public string EventName {get;set;}
        public string EventType {get;set;}
        public string Venue {get;set;}
        public string StartTime {get;set;}
        public string EndTime {get;set;}
        public string StartDate {get;set;}
        public string EndDate {get;set;}
        public string Status {get;set;}
    }
}