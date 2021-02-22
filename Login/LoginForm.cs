using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        // Arrays containing the username and passwords
        string[] usernames = { "Username1", "Username2" };
        string[] passwords = { "Password1", "Password2" };
        // List used to store password and usernames
        List<String> users = new List<String>();
        List<String> pass = new List<String>();


        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            // using an array to login 
            if (usernames.Contains(txtUserName.Text) && passwords.Contains(txtPassword.Text) && Array.IndexOf(usernames,txtUserName.Text) == Array.IndexOf(passwords,txtPassword.Text))
            {
                Form2 form = new Form2();
                form.ShowDialog();
            }
            // using a TextFile
            else if (users.Contains(txtUserName.Text) && pass.Contains(txtPassword.Text) && Array.IndexOf(users.ToArray(), txtUserName.Text) == Array.IndexOf(pass.ToArray(), txtPassword.Text))
            {
                Menu form = new Menu();
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("The Username or Password entered is incorrect");
            }
          
        }

        private void Login_Load(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("Login.txt");
            string line = "";
            while ((line = sr.ReadLine()) !=null)
            {
                string[] components = line.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                users.Add(components[0]);
                pass.Add(components[1]);
            }
            sr.Close();

        }
    }
}
