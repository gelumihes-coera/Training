using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    public class Message
    {
        public string Sender { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }

        public Message(string sender, string content, DateTime date)
        {
            Sender = sender;
            Content = content;
            Date = date;
        }
    }
}
