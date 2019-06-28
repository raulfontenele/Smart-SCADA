using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlServerCe;
using System.IO;

namespace Supervisoria___tcc
{
    public static partial class Auxiliar

    {   // Define o endereço da pasta de dados
        public static string pasta_dados = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Bancos de dados\";
        public static string base_dados = pasta_dados + "DadosScada.sdf" + ";password = 'password123'";
        public static string base_dados_senha;


        public static void iniciarControleAcesso()
        {
            // Define o endereço da pasta de dados
            //pasta_dados = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Bancos de dados\";
            //base_dados_senha = pasta_dados + "DadosScada.sdf" + ";password = 'password123'";
            //base_dados = pasta_dados + "DadosScada.sdf";

            //Verifica se a pasta existe. Se não existir, cria.
            if (!Directory.Exists(pasta_dados))
                Directory.CreateDirectory(pasta_dados);

            //Verificar se a base de dados existe
            if (!File.Exists(pasta_dados + "DadosScada.sdf"))
            {
                criarBaseDadosAcessos();
                criarUsuarioPrincipal();
                
            }
        }


        private static void criarBaseDadosAcessos()
        {
            SqlCeEngine criador = new SqlCeEngine(@"Data Source = " + base_dados);
            criador.CreateDatabase();

            SqlCeConnection ligacao = new SqlCeConnection();
            ligacao.ConnectionString = @"Data Source = " + base_dados;
            ligacao.Open();

            SqlCeCommand comando = new SqlCeCommand();
            comando.CommandText =
                "CREATE TABLE TabelaUsuarios (" +
                "Usuario             nvarchar(50) not null," +
                "Senha               nvarchar(50) not null," +
                "NivelDeAcesso     nvarchar(50) not null)";

            comando.Connection = ligacao;
            comando.ExecuteNonQuery();

            comando.Dispose();
            ligacao.Dispose();

        }

        private static void criarUsuarioPrincipal()
        {
            //Criar a ligação com a base de dados
            SqlCeConnection ligacao = new SqlCeConnection();
            ligacao.ConnectionString = @"Data Source = " + base_dados;

            //Abrindo ligação com a base de dados   
            ligacao.Open();


            //criar um comando
            SqlCeCommand comando = new SqlCeCommand();
            comando.Connection = ligacao;

            //adicionando os parâmetros
            comando.Parameters.AddWithValue(@"Usuario", "Adm");
            comando.Parameters.AddWithValue(@"Senha", "Adm123");
            comando.Parameters.AddWithValue(@"NivelDeAcesso", "All");

            //inserir no banco de dados
            comando.CommandText = "INSERT INTO TabelaUsuarios VALUES(@Usuario,@Senha,@NivelDeAcesso)";
            comando.ExecuteNonQuery();

            comando.Dispose();
            ligacao.Dispose();
        }
    }
}

