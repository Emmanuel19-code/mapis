using System.ComponentModel.DataAnnotations;

namespace mapis.Domain
{
    public class EventRegistration
    {
        [Key]
        public Guid EventRegistrationId { get; set; }
        public required string CILTUserId { get; set; }
        public Guid EventId { get; set; }
        public CILTUser CILTUser { get; set; }
        public Events Event { get; set; }
    }

}