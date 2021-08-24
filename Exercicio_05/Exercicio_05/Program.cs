using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Exercicio_05
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var bdConn = new MySqlConnection("server=localhost;database=exercicio_05;uid=root;pwd='Israel@46743562'");
                bdConn.Open();
                Console.WriteLine("Conectou!");
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
                throw;
            }
        }
    }
}
