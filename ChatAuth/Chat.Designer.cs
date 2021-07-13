namespace ChatAuth
{
    partial class Chat
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.chatsChoose = new System.Windows.Forms.ListBox();
            this.cHATSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.chatWindow = new System.Windows.Forms.DataGridView();
            this.time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.message = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sendMessage = new System.Windows.Forms.Button();
            this.messageBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.cHATSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chatWindow)).BeginInit();
            this.SuspendLayout();
            // 
            // chatsChoose
            // 
            this.chatsChoose.Location = new System.Drawing.Point(487, 26);
            this.chatsChoose.Name = "chatsChoose";
            this.chatsChoose.Size = new System.Drawing.Size(164, 459);
            this.chatsChoose.TabIndex = 1;
            this.chatsChoose.SelectedIndexChanged += new System.EventHandler(this.chatsChoose_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(488, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Чаты";
            // 
            // chatWindow
            // 
            this.chatWindow.AllowUserToAddRows = false;
            this.chatWindow.AllowUserToDeleteRows = false;
            this.chatWindow.AllowUserToResizeColumns = false;
            this.chatWindow.AllowUserToResizeRows = false;
            this.chatWindow.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.chatWindow.BackgroundColor = System.Drawing.Color.White;
            this.chatWindow.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.chatWindow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.chatWindow.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.time,
            this.sender,
            this.message});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.chatWindow.DefaultCellStyle = dataGridViewCellStyle1;
            this.chatWindow.GridColor = System.Drawing.Color.White;
            this.chatWindow.Location = new System.Drawing.Point(13, 13);
            this.chatWindow.MultiSelect = false;
            this.chatWindow.Name = "chatWindow";
            this.chatWindow.ReadOnly = true;
            this.chatWindow.RowHeadersVisible = false;
            this.chatWindow.RowHeadersWidth = 45;
            this.chatWindow.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.chatWindow.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.chatWindow.ShowEditingIcon = false;
            this.chatWindow.Size = new System.Drawing.Size(468, 445);
            this.chatWindow.TabIndex = 3;
            // 
            // time
            // 
            this.time.Frozen = true;
            this.time.HeaderText = "Время";
            this.time.Name = "time";
            this.time.ReadOnly = true;
            this.time.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.time.Width = 50;
            // 
            // sender
            // 
            this.sender.Frozen = true;
            this.sender.HeaderText = "Отправитель";
            this.sender.Name = "sender";
            this.sender.ReadOnly = true;
            this.sender.Width = 150;
            // 
            // message
            // 
            this.message.Frozen = true;
            this.message.HeaderText = "Сообщение";
            this.message.Name = "message";
            this.message.ReadOnly = true;
            this.message.Width = 268;
            // 
            // sendMessage
            // 
            this.sendMessage.Enabled = false;
            this.sendMessage.Location = new System.Drawing.Point(392, 464);
            this.sendMessage.Name = "sendMessage";
            this.sendMessage.Size = new System.Drawing.Size(89, 20);
            this.sendMessage.TabIndex = 4;
            this.sendMessage.Text = "Отправить";
            this.sendMessage.UseVisualStyleBackColor = true;
            this.sendMessage.Click += new System.EventHandler(this.sendMessage_Click);
            // 
            // messageBox
            // 
            this.messageBox.Enabled = false;
            this.messageBox.Location = new System.Drawing.Point(12, 465);
            this.messageBox.Name = "messageBox";
            this.messageBox.Size = new System.Drawing.Size(373, 20);
            this.messageBox.TabIndex = 5;
            // 
            // Chat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 489);
            this.Controls.Add(this.messageBox);
            this.Controls.Add(this.sendMessage);
            this.Controls.Add(this.chatWindow);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chatsChoose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Chat";
            this.Text = "Чат";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Chat_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.cHATSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chatWindow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox chatsChoose;
        private System.Windows.Forms.BindingSource cHATSBindingSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView chatWindow;
        private System.Windows.Forms.DataGridViewTextBoxColumn time;
        private System.Windows.Forms.DataGridViewTextBoxColumn sender;
        private System.Windows.Forms.DataGridViewTextBoxColumn message;
        private System.Windows.Forms.Button sendMessage;
        private System.Windows.Forms.TextBox messageBox;
    }
}