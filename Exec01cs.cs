using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exec01Lista2
{
    public partial class Exec01cs : Form
    {
        public Exec01cs()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUserName.Text))
            {
                bool admin = false;
                string select = $"SELECT AccessLevel from dbo.Usuario WHERE UserName = '{txtUserName.Text}' and PasswordKey = '{txtPassWord.Text}'";
                SqlCommand cmd = new SqlCommand(select, DBConnection.Connection);
                DBConnection.Connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (Convert.ToInt32(dr[0]) > 4)
                    {
                        //carrega a proxima tela
                        admin = true;

                    }
                    else
                    {
                        MessageBox.Show("LOGIN EFETUADO");
                    }

                }
                else
                {
                    MessageBox.Show("Login NÂO efetuado!");
                }
                dr.Close();
                DBConnection.Connection.Close();
                if (admin)
                {
                    //carregar a telaAdmin
                    new TelaAdmin().Show();
                    this.Hide();
                    

                }
            }
            else
            {
                MessageBox.Show("UserName is Empty");
            }

        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
