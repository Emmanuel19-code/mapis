namespace mapis.Domain
{
    public class UploadEvent
    {
        public string EventName { get; set; }
        public string EventType { get; set; }
        public string Venue { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }

    }
    public class AllEvents
    {
        public Guid EventId { get; set; }
        public string EventName { get; set; }
        public string EventType { get; set; }
        public string Venue { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Status { get; set; }
    }

    public class UpdateEvent
    {
        public Guid EventId { get; set; }
        public string EventName { get; set; }
        public string EventType { get; set; }
        public string Venue { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Status { get; set; }
    }

    public class RegisterEvent
    {
        public Guid CILTUserId { get; set; }
    }
    public class RegisteringEvent
    {
        public Guid EventRegistrationId { get; set; }
        public Guid CILTUserId { get; set; }
        public Guid EventId { get; set; }
    }

}