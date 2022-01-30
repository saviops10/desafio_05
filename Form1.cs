using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Desafio_05_db
{
    public partial class Form1 : Form
    {
        MySqlConnection conexao;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                string data_source = "datasource=localhost;username=root;password=;database=db_agenda";

                //Cria conexão com MySQL

                conexao = new MySqlConnection(data_source);

                string sql = "INSERT INTO contato (nome, email, telefone)" +
                    "VALUES " +
                    "('" + txtNome.Text + "','" + txtEmail.Text + "','" + txtTelefone.Text + "') ";

                MySqlCommand comando = new MySqlCommand(sql, conexao);
                conexao.Open();

                comando.ExecuteReader();

                MessageBox.Show("Dados inseridos com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }
    }
}
