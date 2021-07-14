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
using System.Security.Cryptography;

namespace ChatAuth
{
    public partial class Authorization : Form
    {
        public Authorization()
        {
            InitializeComponent();
        }

        public Authorization(string log, string pass)
        {
            InitializeComponent();
            loginBox.Text = log;
            passwordBox.Text = pass;
        }

        public string GetHash(string input)
        {
            
            byte[] hash = Encoding.ASCII.GetBytes(input);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] hashenc = md5.ComputeHash(hash);
            string result = "";
            foreach (var b in hashenc)
            {
                result += b.ToString("x2");
            }
            return result;

        }

        Registration reg;
        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            reg = new Registration();
            reg.ShowDialog();
        }

        private void Authorization_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private List<List<string>> getUsers()
        {
            OleDbConnection dbConnection = new OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;Data Source=ChatDB.mdb");
            dbConnection.Open();
            OleDbCommand dbCommand = new OleDbCommand("SELECT * FROM USERS", dbConnection);
            OleDbDataReader dbReader = dbCommand.ExecuteReader();

            List<List<string>> users = new List<List<string>>();

            int userCount = 0;
            while (dbReader.Read())
            {
                
                users.Add(new List<string>());
                users[userCount].Add(dbReader["ID"].ToString());
                users[userCount].Add(dbReader["Логин"].ToString());
                users[userCount].Add(Program.Dec(dbReader["Представление ФИО"].ToString()));
                users[userCount].Add(dbReader["Пароль"].ToString());
                userCount++;
            }
            dbConnection.Close();
            return users;
        }

        private string getPassword(string login)
        {
            OleDbConnection dbConnection = new OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;Data Source=ChatDB.mdb");
            dbConnection.Open();
            OleDbCommand dbCommand = new OleDbCommand("SELECT Пароль FROM USERS WHERE [Логин] = '" + login + "'", dbConnection);
            OleDbDataReader dbReader = dbCommand.ExecuteReader();
            string outStr = null;
            while (dbReader.Read())
            {
                outStr = dbReader[0].ToString();
            }
            


            dbConnection.Close();
            return outStr;
        }

        private bool fieldIsExist(string value, List<List<string>> arr, int param)
        {
            string[] array = new string[arr.Count()];
            for (int i = 0; i < arr.Count(); i++)
            {
                array[i] = arr[i][param];
            }

            foreach (string str in array)
            {
                if (str == value)
                {
                    return true;
                }
            }
            return false;
        }

        private void logInButton_Click(object sender, EventArgs e)
        {
            List<List<string>> us = new List<List<string>>();
            us = getUsers();

            Chat ch;

            if (loginBox.Text == "")
                MessageBox.Show("Введите логин");
            else if (!fieldIsExist(loginBox.Text, us, 1))
                MessageBox.Show("Пользователь не зарегистрирован");
            else if (passwordBox.Text == "")
                MessageBox.Show("Введите пароль");
            else if (GetHash(passwordBox.Text) != getPassword(loginBox.Text))
                MessageBox.Show("Неверный пароль");
            else
            {
                MessageBox.Show("Вход выполнен");
                Hide();
                ch = new Chat(loginBox.Text);
                ch.Show();
            }
        }
    }
}
