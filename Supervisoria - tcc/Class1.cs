using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlServerCe;
using System.IO;
using S7.Net;

namespace Supervisoria___tcc
{
    public static partial class Auxiliar

    {   // Define o endereço da pasta de dados
        public static string pasta_dados = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Bancos de dados\";
        public static string base_dados = pasta_dados + "DadosScada.sdf" + ";password = 'password123'";
        public static string nome_usuario;
        public static string ipCLP = "172.19.10.113";
        //public static string base_dados_controle = pasta_dados + "DadosScadaControle.sdf" + ";password = 'password123'";

        //Variáveis do supervisório
        public static double[] demandaProdutos = new double[3];

        public static double[] demandaProdutosAuxiliar = new double[3];

        public static double[] qtdProduzidaProdutos = new double[3];

        public static bool[] bitProdutos = new bool[6];

        public static bool[] bitFuncionamento = new bool[3];

        public static bool controleDemanda = false;

        public static int timer = 60;



        public static void iniciarControleAcesso()
        {
            if (!Directory.Exists(pasta_dados))
                Directory.CreateDirectory(pasta_dados);

            //Verificar se a base de dados existe
            if (!File.Exists(pasta_dados + "DadosScada.sdf"))
            {
                criarBaseDadosAcessos();
                criarTabelaControle();
                criarUsuarioPrincipal();
                
            }
        }

        public static void inicializarDemanda()
        {
            demandaProdutos[0] = 0;
            demandaProdutos[1] = 0;
            demandaProdutos[2] = 0;

            demandaProdutosAuxiliar[0] = 0;
            demandaProdutosAuxiliar[1] = 0;
            demandaProdutosAuxiliar[2] = 0;
        }

        public static void iniciarBancoDeDadosControle()
        {
            if (!Directory.Exists(pasta_dados))
                Directory.CreateDirectory(pasta_dados);

            //Verificar se a base de dados existe
            if (!File.Exists(pasta_dados + "DadosScada.sdf"))
            {
                criarTabelaControle();
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
                "Id                  int not null primary key identity(1,1)," +
                "Usuario             nvarchar(50) not null ," +
                "Senha               nvarchar(50) not null," +
                "NivelDeAcesso       nvarchar(50) not null)";

            comando.Connection = ligacao;
            comando.ExecuteNonQuery();

            comando.Dispose();
            ligacao.Dispose();

        }
        private static void criarTabelaControle()
        {
            SqlCeConnection ligacao = new SqlCeConnection();
            ligacao.ConnectionString = @"Data Source = " + base_dados;
            ligacao.Open();

            SqlCeCommand comando = new SqlCeCommand();
            comando.CommandText =
                "CREATE TABLE TabelaControle (" +
                "Id                       int not null primary key identity(0,1)," +
                "Bit1Produto1             int not null," +
                "Bit2Produto1             int not null," +
                "Bit1Produto2             int not null," +
                "Bit2Produto2             int not null," +
                "Bit1Produto3             int not null," +
                "Bit2Produto3             int not null," +
                "BitFuncBloco1            int not null," +
                "BitFuncBloco2            int not null," +
                "BitFuncBloco3            int not null," +
                "DemandaProduto1          int not null," +
                "DemandaProduto2          int not null," +
                "DemandaProduto3          int not null," +
                "QtdProduzidaProduto1     int not null," +
                "QtdProduzidaProduto2     int not null," +
                "QtdProduzidaProduto3     int not null)";

            comando.Connection = ligacao;
            comando.ExecuteNonQuery();

            comando.Dispose();
            ligacao.Dispose();

        }
        public static void criarTabelaControleUsuario()
        {
            SqlCeConnection ligacao = new SqlCeConnection();
            ligacao.ConnectionString = @"Data Source = " + base_dados;
            ligacao.Open();

            SqlCeCommand comando = new SqlCeCommand();
            comando.CommandText =
                "CREATE TABLE TabelaControle" + nome_usuario+ " (" +
                "Id                       int not null primary key identity(0,1)," +
                "Bit1Produto1             int not null," +
                "Bit2Produto1             int not null," +
                "Bit1Produto2             int not null," +
                "Bit2Produto2             int not null," +
                "Bit1Produto3             int not null," +
                "Bit2Produto3             int not null," +
                "BitFuncBloco1            int not null," +
                "BitFuncBloco2            int not null," +
                "BitFuncBloco3            int not null," +
                "DemandaProduto1          int not null," +
                "DemandaProduto2          int not null," +
                "DemandaProduto3          int not null," +
                "QtdProduzidaProduto1     int not null," +
                "QtdProduzidaProduto2     int not null," +
                "QtdProduzidaProduto3     int not null)";

            comando.Connection = ligacao;
            comando.ExecuteNonQuery();

            comando.Dispose();
            ligacao.Dispose();

        }

        public static void enviarDadosProducao()
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
            comando.Parameters.AddWithValue(@"Bit1Produto1", Auxiliar.bitProdutos[0]);
            comando.Parameters.AddWithValue(@"Bit2Produto1", Auxiliar.bitProdutos[1]);
            comando.Parameters.AddWithValue(@"Bit1Produto2", Auxiliar.bitProdutos[2]);
            comando.Parameters.AddWithValue(@"Bit2Produto2", Auxiliar.bitProdutos[3]);
            comando.Parameters.AddWithValue(@"Bit1Produto3", Auxiliar.bitProdutos[4]);
            comando.Parameters.AddWithValue(@"Bit2Produto3", Auxiliar.bitProdutos[5]);
            comando.Parameters.AddWithValue(@"BitFuncBloco1", !Auxiliar.bitFuncionamento[0]);
            comando.Parameters.AddWithValue(@"BitFuncBloco2", !Auxiliar.bitFuncionamento[1]);
            comando.Parameters.AddWithValue(@"BitFuncBloco3", !Auxiliar.bitFuncionamento[2]);
            comando.Parameters.AddWithValue(@"DemandaProduto1", Auxiliar.demandaProdutos[0]);
            comando.Parameters.AddWithValue(@"DemandaProduto2", Auxiliar.demandaProdutos[1]);
            comando.Parameters.AddWithValue(@"DemandaProduto3", Auxiliar.demandaProdutos[2]);
            comando.Parameters.AddWithValue(@"QtdProduzidaProduto1", Auxiliar.qtdProduzidaProdutos[0]);
            comando.Parameters.AddWithValue(@"QtdProduzidaProduto2", Auxiliar.qtdProduzidaProdutos[1]);
            comando.Parameters.AddWithValue(@"QtdProduzidaProduto3", Auxiliar.qtdProduzidaProdutos[2]);



            //inserir no banco de dados
            comando.CommandText = "INSERT INTO TabelaControle" + nome_usuario + "(Bit1Produto1,Bit2Produto1,Bit1Produto2,Bit2Produto2," +
                                  "Bit1Produto3,Bit2Produto3,BitFuncBloco1,BitFuncBloco2,BitFuncBloco3,DemandaProduto1," +
                                  "DemandaProduto2,DemandaProduto3,QtdProduzidaProduto1,QtdProduzidaProduto2,QtdProduzidaProduto3) VALUES(@Bit1Produto1," +
                                  "@Bit2Produto1,@Bit1Produto2,@Bit2Produto2,@Bit1Produto3,@Bit2Produto3,@BitFuncBloco1,@BitFuncBloco2,@BitFuncBloco3,@DemandaProduto1," +
                                  "@DemandaProduto2,@DemandaProduto3,@QtdProduzidaProduto1,@QtdProduzidaProduto2,@QtdProduzidaProduto3)";
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
            //comando.Parameters.AddWithValue(@"Id", "0");
            comando.Parameters.AddWithValue(@"Usuario", "Adm");
            comando.Parameters.AddWithValue(@"Senha", "Adm123");
            comando.Parameters.AddWithValue(@"NivelDeAcesso", "All");

            //inserir no banco de dados
            comando.CommandText = "INSERT INTO TabelaUsuarios(Usuario,Senha,NivelDeAcesso) VALUES(@Usuario,@Senha,@NivelDeAcesso)";
            comando.ExecuteNonQuery();

            comando.Dispose();
            ligacao.Dispose();
        }

        public static void buscarValoresProducao()
        {
            Plc clp = new Plc(S7.Net.CpuType.S71200, ipCLP, 0, 1);
            //Ligação com o CLP
            clp.Open();

            //Dados da produção
            Auxiliar.qtdProduzidaProdutos[0] = ((uint)clp.Read("DB1.DBD2")).ConvertToDouble();
            Auxiliar.qtdProduzidaProdutos[1] = ((uint)clp.Read("DB1.DBD6")).ConvertToDouble();
            Auxiliar.qtdProduzidaProdutos[2] = ((uint)clp.Read("DB1.DBD10")).ConvertToDouble();

            //Bits de funcionamento 
            Auxiliar.bitFuncionamento[0] = (bool)clp.Read("DB1.DBX1.1");
            Auxiliar.bitFuncionamento[1] = (bool)clp.Read("DB1.DBX1.2");
            Auxiliar.bitFuncionamento[2] = (bool)clp.Read("DB1.DBX1.3");
            //Fechando conexão com o CLP
            clp.Close();
        }

        public static void enviarBitProdutos()
        {
            Plc clp = new Plc(S7.Net.CpuType.S71200, ipCLP, 0, 1);
            //Ligação com o CLP
            clp.Open();

            //Enviando valor dos bits de produção
            clp.Write("DB1.DBX0.2", Auxiliar.bitProdutos[0]);
            clp.Write("DB1.DBX0.3", Auxiliar.bitProdutos[1]);
            clp.Write("DB1.DBX0.4", Auxiliar.bitProdutos[2]);
            clp.Write("DB1.DBX0.5", Auxiliar.bitProdutos[3]);
            clp.Write("DB1.DBX0.6", Auxiliar.bitProdutos[4]);
            clp.Write("DB1.DBX0.7", Auxiliar.bitProdutos[5]);

            //Fechando conexão com o CLP
            clp.Close();
        }

        public static void enviarBitLigar()
        {
            Plc clp = new Plc(S7.Net.CpuType.S71200, ipCLP, 0, 1);
            //Ligação com o CLP
            clp.Open();

            //Enviando valor dos bits de controle
            clp.Write("DB1.DBX0.0", true);
            clp.Write("DB1.DBX0.1", false);

            //Fechando conexão com o CLP
            clp.Close();
        }
        public static void EnviarBitDesligar()
        {
            Plc clp = new Plc(S7.Net.CpuType.S71200, ipCLP, 0, 1);
            //Ligação com o CLP
            clp.Open();

            //Enviando valor dos bits de controle
            clp.Write("DB1.DBX0.0", false);
            clp.Write("DB1.DBX0.1", true);

            //Fechando conexão com o CLP
            clp.Close();
        }

        public static void enviarBitZerar()
        {
            Plc clp = new Plc(S7.Net.CpuType.S71200, ipCLP, 0, 1);
            //Ligação com o CLP
            clp.Open();

            //Enviando valor dos bits de controle
            clp.Write("DB1.DBX1.0", true);
            clp.Write("DB1.DBX1.0", false);

            //Fechando conexão com o CLP
            clp.Close();
        }
    }

}


