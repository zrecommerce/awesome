using System;

namespace AwesomeAPI.Models
{
    public class Message
    {
        public int ID { get; set; }
        public DateTime Timestamp { get; set; }
        public MessageType Type { get; set; }
        public string Content { get; set; }
    }
}