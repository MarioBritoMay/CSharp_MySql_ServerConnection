using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace formulario_prueba
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String servidor = txtServidor.Text;
            String puerto = txtPuerto.Text;
            String usuario = txtUsuario.Text;
            String password = txtPaswword.Text;
            String datos = "";
            String connectChain = "server=" + servidor + "; port=" + puerto + "; user id=" + usuario + "; password=" + password + "; database=mysql;";

            MySqlConnection connectBD = new MySqlConnection(connectChain);

            try
            {
                connectBD.Open();//abrimos la coneccion a la base de datos
                MySqlDataReader reader = null;
                MySqlCommand cmd = new MySqlCommand("SHOW DATABASES", connectBD);//hago una consulta
                reader = cmd.ExecuteReader();// almaceno los resultados de la consulta en el objeto reader
                while (reader.Read())
                {
                    datos += reader.GetString(0) + "\n";
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            MessageBox.Show(datos);
        }
    }
}
