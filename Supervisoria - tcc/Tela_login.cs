using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlServerCe;

namespace Supervisoria___tcc
{
    public partial class Tela_login : Form
    {
        public Tela_login()
        {
            InitializeComponent();
            Console.WriteLine("Qualquer bosta");
            Auxiliar.iniciarControleAcesso();
        }

        private void BotaoCadastro_Click(object sender, EventArgs e)
        {
            Tela_Acesso_Cadastro TelaAcessoCadastro = new Tela_Acesso_Cadastro();
            TelaAcessoCadastro.ShowDialog();
        }

        private void BotaoEntrar_Click(object sender, EventArgs e)
        {
            //Criar a ligação com a base de dados
            SqlCeConnection ligacao = new SqlCeConnection();
            ligacao.ConnectionString = @"Data Source = " + Auxiliar.base_dados;

            //Abrindo ligação com a base de dados   
            ligacao.Open();

            //criar um comando
            SqlCeCommand comando = new SqlCeCommand();
            comando.Connection = ligacao;

            //adicionando os parâmetros
            comando.Parameters.AddWithValue(@"Usuario", caixaUsuario.Text);
            comando.Parameters.AddWithValue(@"Senha", caixaSenha.Text);

            //inserir no banco de dados
            comando.CommandText = "SELECT COUNT(1) FROM TabelaUsuarios WHERE Usuario = @Usuario AND Senha = @Senha";

            Object retorno = comando.ExecuteScalar();
            if (retorno.Equals(1))
            {
                TelaDeControle telaControle = new TelaDeControle();
                telaControle.ShowDialog();
            }
            else
            {
                MessageBox.Show("Usuário ou senha inválidos!");
            }

            comando.Dispose();
            ligacao.Dispose();
        }
    }
}
