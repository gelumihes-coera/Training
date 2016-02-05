using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    public class ChatMessage : IChatMessage
    {
        private readonly ChatForm _chatForm;

        public ChatMessage(ChatForm chat)
        {
            _chatForm = chat;
        }

        public void ReceiveNewMessage(object sender, EventArgs e)
        {
            Message message = (Message) sender;
            string output = string.Format("[{0}] [{1}]: {2}\n", message.Date, message.Sender, message.Content);
            _chatForm.WriteOnScreen(output);
        }
    }
}
