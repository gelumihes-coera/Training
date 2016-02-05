using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Events
{
    public partial class ChatForm : Form
    {
        public string CurrentUser { get; set; }
        public event EventHandler NewMessage;
        public List<ChatForm> ChatForms { get; set; }

        public ChatForm(string currentUser)
        {
            InitializeComponent();
            CurrentUser = currentUser;
            ChatForms = new List<ChatForm>();
            IChatMessage chatMessage = new ChatMessage(this);
            NewMessage += chatMessage.ReceiveNewMessage;
        }

        public void WriteOnScreen(string output)
        {
            foreach (var form in ChatForms)
            {
                form.chatTxtBox.AppendText(output);
            }
        }

        private void sendBttn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(messageTxtBox.Text)) return;
            Message message = new Message(CurrentUser, messageTxtBox.Text, DateTime.Now);
            NewMessage?.Invoke(message, EventArgs.Empty);
            messageTxtBox.Clear();
        }
    }
}
