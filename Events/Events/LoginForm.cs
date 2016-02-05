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
    public partial class LoginForm : Form
    {
        private List<ChatForm> _chatForms;

        public LoginForm()
        {
            InitializeComponent();
            _chatForms = new List<ChatForm>();
        }

        private void okBttn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(usernameTxtBox.Text))
            {
                ChatForm chatForm = new ChatForm(usernameTxtBox.Text);
                _chatForms.Add(chatForm);
                chatForm.ChatForms = _chatForms;
                usernameTxtBox.Clear();
                chatForm.Show();
            }
            else
            {
                MessageBox.Show("Please enter a name!");
            }
        }
    }
}
