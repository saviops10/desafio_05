using MySql.Data.MySqlClient;
using System;
using System.Data.SqlClient;

namespace Desafio5
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Id do aluno: ");
                int id = Convert.ToInt32(Console.ReadLine());

                Console.Write("Nome: ");
                string nome = Console.ReadLine();

                Console.Write("N° de matrícula: ");
                string matricula = Console.ReadLine();

                Console.Write("Telefone: ");
                string telefone = Console.ReadLine();

                string query = "insert into tb_alunos values(" +
                      id + ", '" + nome + "', '" + matricula + "', " + telefone + ") ";
                Console.WriteLine(query);

                string cs = @"Server=localhost;Port=3306;database=escola;User=root;Pwd=password";

                MySqlConnection cn = new MySqlConnection(cs);
                cn.Open();
                Console.WriteLine("Conectado.");

                MySqlCommand cmd = new MySqlCommand(query, cn);
                int result = cmd.ExecuteNonQuery();
                Console.WriteLine(result + " Dados inseridos na tabela.");

                Console.WriteLine("\nDados dos alunos");
                query = "select * from tb_alunos";
                MySqlCommand cmd2 = new MySqlCommand(query, cn);
                MySqlDataReader r = cmd2.ExecuteReader();

                while (r.Read() == true)
                {
                    int aid = r.GetInt32(0);
                    string nm = r.GetString(1);
                    string mat = r.GetString(2);
                    string tel = r.GetString(3);
                    Console.WriteLine("{0}\t {1} \t {2}\t {3}", aid, nm, mat, tel);
                }

                cn.Close();



            }
            catch (MySqlException e)
            {
                Console.WriteLine(e);
            }


        }
    }
}
