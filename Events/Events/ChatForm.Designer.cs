namespace Events
{
    partial class ChatForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.messageTxtBox = new System.Windows.Forms.TextBox();
            this.chatTxtBox = new System.Windows.Forms.TextBox();
            this.sendBttn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // messageTxtBox
            // 
            this.messageTxtBox.Location = new System.Drawing.Point(12, 25);
            this.messageTxtBox.Multiline = true;
            this.messageTxtBox.Name = "messageTxtBox";
            this.messageTxtBox.Size = new System.Drawing.Size(430, 50);
            this.messageTxtBox.TabIndex = 0;
            // 
            // chatTxtBox
            // 
            this.chatTxtBox.Location = new System.Drawing.Point(12, 96);
            this.chatTxtBox.Multiline = true;
            this.chatTxtBox.Name = "chatTxtBox";
            this.chatTxtBox.ReadOnly = true;
            this.chatTxtBox.Size = new System.Drawing.Size(496, 235);
            this.chatTxtBox.TabIndex = 1;
            // 
            // sendBttn
            // 
            this.sendBttn.Location = new System.Drawing.Point(448, 34);
            this.sendBttn.Name = "sendBttn";
            this.sendBttn.Size = new System.Drawing.Size(60, 31);
            this.sendBttn.TabIndex = 2;
            this.sendBttn.Text = "Send";
            this.sendBttn.UseVisualStyleBackColor = true;
            this.sendBttn.Click += new System.EventHandler(this.sendBttn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Your message here:";
            // 
            // ChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 343);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sendBttn);
            this.Controls.Add(this.chatTxtBox);
            this.Controls.Add(this.messageTxtBox);
            this.Name = "ChatForm";
            this.Text = "Chat";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox messageTxtBox;
        private System.Windows.Forms.TextBox chatTxtBox;
        private System.Windows.Forms.Button sendBttn;
        private System.Windows.Forms.Label label1;
    }
}