using System;

namespace CUNA.Documents.Service.Models
{
    public class Payload
    {
        public string Body { get; set; }
        public string Callback { get; set; }
        public string Detail { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public Guid Id { get; set; }
    }
}
