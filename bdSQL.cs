using System;
using System.Data;
using System.Data.SQLite;

namespace BotTormenta
{
    internal class bdSQL
    {
        private static string connectionString = "Data Source=F:\\_Projetos_C#\\BotDiscord_Test\\bancoDados\\magias.db";

        private static SQLiteConnection GetConnection()
        {
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            return connection;
        }

        public static DataTable ConsultaMagi(string nomeMagia)
        {
            using (SQLiteConnection connection = GetConnection())
            {
                DataTable dataTable = new DataTable();
                try
                {
                    using (SQLiteCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM magias_table WHERE NomeMagia = @value";
                        command.Parameters.AddWithValue("@value", nomeMagia);

                        using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro: " + ex.Message);
                }
                return dataTable;
            }
        }

        public static DataTable ConsultaTalent(string nomeTalent)
        {
            using (SQLiteConnection connection = GetConnection())
            {
                DataTable dataTable = new DataTable();
                try
                {
                    using (SQLiteCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM talentos_table WHERE nomeTalento = @value";
                        command.Parameters.AddWithValue("@value", nomeTalent);

                        using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro: " + ex.Message);
                }
                return dataTable;
            }
        }
    }
}
