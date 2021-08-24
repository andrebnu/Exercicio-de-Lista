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
    public partial class TelaAdmin : Form
    {
        public TelaAdmin()
        {
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            new Exec01cs().Show();
            this.Hide();

        }

      

        private void TelaAdmin_Load(object sender, EventArgs e)
        {
            listUsuarios.Items.Add("UserName\tPassWord\tAccessLevel");
            string select = "SELECT * from dbo.Usuario";
            SqlCommand cmd = new SqlCommand(select, DBConnection.Connection);
            DBConnection.Connection.Open();
            SqlDataReader dr = cmd.ExecuteReader(); 
            while (dr.Read())
            {
                string texto = "";
                for (int i = 1; i < 4; i++)
                {
                    texto += dr[i].ToString() + "  ";

                }
                listUsuarios.Items.Add(texto);
            }
            dr.Close();
            DBConnection.Connection.Close();
        }
    }
}
