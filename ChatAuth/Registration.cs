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
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
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

        private void registerUser(string login, string FIO, string password)
        {
            password = GetHash(password);
            OleDbConnection dbConnection = new OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;Data Source=ChatDB.mdb");
            dbConnection.Open();
            OleDbCommand dbCommand = new OleDbCommand("INSERT INTO USERS (Логин, [Представление ФИО], Пароль) VALUES ('" + login + "', '" + Program.Enc(FIO) + "', '" + password +"')", dbConnection);
            dbCommand.ExecuteNonQuery();
            MessageBox.Show("Пользователь успешно зарегистрирован");
            dbConnection.Close();
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

        Authorization auth;
        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            auth = new Authorization();
            auth.ShowDialog();
            
        }

        private void Registration_FormClosed(object sender, FormClosedEventArgs e)
        {
            auth = new Authorization();
            auth.Show();
        }

        private void regButton_Click(object sender, EventArgs e)
        {
            List<List<string>> us = new List<List<string>>();
            us = getUsers();

            if (loginBox.Text == "")
                MessageBox.Show("Введите логин");
            else if (fieldIsExist(loginBox.Text, us, 1))
                MessageBox.Show("Пользователь существует");
            else if (fioBox.Text == "")
                MessageBox.Show("Введите ФИО");
            else if (passwordBox.Text == "")
                MessageBox.Show("Введите пароль");
            else if (passwordBox.Text.Length < 8 || passwordBox.Text.Length > 16)
                MessageBox.Show("Пароль должен быть длиной от 8 до 16 символов");
            else
            {
                try
                {
                    registerUser(loginBox.Text, fioBox.Text.ToUpper(), passwordBox.Text);
                }
                catch
                {
                    MessageBox.Show("Возникла ошибка");
                }
                finally
                {
                    Hide();
                    auth = new Authorization(loginBox.Text, passwordBox.Text);
                    auth.Show();
                }
            }

        }

        private void fioBox_Click(object sender, EventArgs e)
        {
            MessageBox.Show("В этом поле введите свои данные в формате Фамилия И.О.", "Внимание!");
        }
    }
}
