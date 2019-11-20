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
            Auxiliar.iniciarControleAcesso();
        }

        private void BotaoCadastro_Click(object sender, EventArgs e)
        {
            Tela_Acesso_Cadastro TelaAcessoCadastro = new Tela_Acesso_Cadastro();
            this.Hide();
            TelaAcessoCadastro.ShowDialog();
            this.Show();
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

            //Buscar no banco de dados o nome de usuário e a senha
            comando.CommandText = "SELECT COUNT(1) FROM TabelaUsuarios WHERE Usuario = @Usuario AND Senha = @Senha";

            Object retorno = comando.ExecuteScalar();
            if (retorno.Equals(1))
            {
                Auxiliar.nome_usuario = caixaUsuario.Text;
                try
                {
                    Auxiliar.criarTabelaControleUsuario();
                    Auxiliar.criarTabelaHistoricoUsuario();
                }
                catch { }


                //Capturar Nome de usuário e nível de acesso.
                comando.CommandText = "SELECT NivelDeAcesso FROM TabelaUsuarios WHERE Usuario = '" + caixaUsuario.Text + "' AND Senha = '" + caixaSenha.Text+"'";

                Auxiliar.nome_usuario = caixaUsuario.Text;
                Auxiliar.nivel_acesso = comando.ExecuteScalar().ToString();

                
                TelaControleCentral tela_Controle = new TelaControleCentral();
                this.Hide();
                tela_Controle.ShowDialog();
                

                /*
               TelaEscolhas tela_Escolhas = new TelaEscolhas();
               this.Hide();
               tela_Escolhas.ShowDialog();
              */
                this.Show();
                
            }
            else
            {
                MessageBox.Show("Usuário ou senha inválidos!");
            }

            comando.Dispose();
            ligacao.Dispose();
        }

        private void Botao_Voltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
