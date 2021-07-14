// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;


namespace ChatAuth
{
    public partial class Chat : Form
    {

        int userID = -1;
        public Chat(string user)
        {
            InitializeComponent();
            this.Text = "Чат (" + user + ")";
            chatsChoose.Items.AddRange(getChatsNames(user));
        }

        private string[] getChatsNames(string login)
        {
            OleDbConnection dbConnection = new OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;Data Source=ChatDB.mdb");
            dbConnection.Open();
            OleDbCommand dbCommand = new OleDbCommand("SELECT ID FROM USERS WHERE Логин = '" + login + "'", dbConnection);
            OleDbDataReader dbReader = dbCommand.ExecuteReader();

            
            while (dbReader.Read())
            {
                userID = Convert.ToInt32(dbReader["ID"]);
            }
            OleDbCommand dbCommand1 = new OleDbCommand("SELECT Chat FROM USERCHAT WHERE User = " + userID, dbConnection);
            dbReader = dbCommand1.ExecuteReader();

            List<int> chatsID = new List<int>();
            while (dbReader.Read())
            {
                chatsID.Add(Convert.ToInt32(dbReader["Chat"]));
            }

            int[] chID = new int[chatsID.Count()];
            for (int i = 0; i < chatsID.Count(); i++)
            {
                chID[i] = chatsID[i];
            }

            List<string> chNames = new List<string>();

            foreach (int id in chID)
            {
                OleDbCommand dbCommand2 = new OleDbCommand("SELECT ChName FROM CHATS WHERE Код = " + id, dbConnection);
                dbReader = dbCommand2.ExecuteReader();
                while (dbReader.Read())
                {
                    chNames.Add(dbReader["ChName"].ToString());
                }
            }

            string[] names = new string[chNames.Count()];
            for (int i = 0; i < chNames.Count(); i++)
            {
                names[i] = chNames[i];
            }

            dbConnection.Close();
            return names;
            
        }

        Authorization auth;
        private void Chat_FormClosed(object sender, FormClosedEventArgs e)
        {
            auth = new Authorization();
            auth.Show();
        }

        int chatID = 999;

        private void updateChat()
        {
            //MessageBox.Show(chatsChoose.SelectedItem.ToString());
            List<List<object>> messages = new List<List<object>>();

            OleDbConnection dbConnection = new OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;Data Source=ChatDB.mdb");
            dbConnection.Open();

            try
            {
                OleDbCommand dbCommand = new OleDbCommand("SELECT Код FROM CHATS WHERE chName = '" + chatsChoose.SelectedItem.ToString() + "'", dbConnection);
                OleDbDataReader dbReader = dbCommand.ExecuteReader();

                while (dbReader.Read())
                {
                    chatID = Convert.ToInt32(dbReader[0].ToString());
                }
            }
            catch
            {

            }






            OleDbCommand dbCommand1 = new OleDbCommand("SELECT * FROM MESSAGES INNER JOIN USERS ON MESSAGES.[ID отправителя] = USERS.[ID]  WHERE [ID чата] = " + chatID + " ORDER BY [Тайм-код]", dbConnection);
            OleDbDataReader dbReader1 = dbCommand1.ExecuteReader();
            /*
            OleDbCommand dbCommand2 = new OleDbCommand("SELECT [Представление ФИО] FROM USERS WHERE ID = " + chatID, dbConnection);
            OleDbDataReader dbReader2 = dbCommand2.ExecuteReader();
            */
            int iter = 0;
            chatWindow.Rows.Clear();
            while (dbReader1.Read())
            {
                if (Program.Dec(dbReader1[4].ToString()) != null)
                {
                    messages.Add(new List<object>());
                    messages[iter].Add(dbReader1[1]);
                    messages[iter].Add(dbReader1[3]);
                    messages[iter].Add(dbReader1[4]);
                    chatWindow.Rows.Add(Convert.ToDateTime(dbReader1[3]).ToString("HH:mm"), Program.Dec(dbReader1[7].ToString()), Program.Dec(dbReader1[4].ToString())); //Items.Add(dbReader1[1].ToString() + "\t" + dbReader1[3].ToString() + "\t" + dbReader1[4].ToString());
                    iter++;
                }
            }
            /*
            for (int i = 0; i < messages.Count; i++)
            {
                chatWindow.Items.Add();
            }
            */
            dbConnection.Close();
        }

        private void chatsChoose_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateChat();
            if (chatsChoose.SelectedItem != null)
            {
                messageBox.Enabled = true;
                sendMessage.Enabled = true;
            }
        }

        private void sendMessage_Click(object sender, EventArgs e)
        {
            string text = messageBox.Text;
            //if (text.Length > 64)
            //{
            //    text = text.Substring(0, 63);
            //}
                OleDbConnection dbConnection = new OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;Data Source=ChatDB.mdb");
                dbConnection.Open();
                
                OleDbCommand dbCommand = new OleDbCommand("INSERT INTO MESSAGES ([ID отправителя], [ID чата], [Тайм-код], [Сообщение]) VALUES (" + userID + ", " + chatID + ", '" + DateTime.Now.ToString() + "', '" + Program.Enc(messageBox.Text) + "')", dbConnection);
                OleDbDataReader dbReader = dbCommand.ExecuteReader();

                
                
                

                
                dbConnection.Close();
                updateChat();
                messageBox.Clear();
            
            


        }
    }
}
