using System;
using System.Windows.Forms;
using System.Data.SqlServerCe;

namespace Supervisoria___tcc
{
    public partial class Tela_Acesso_Cadastro : Form
    {
        public Tela_Acesso_Cadastro()
        {
            InitializeComponent();
            
        }

        private void BotaoConfirmar_Click(object sender, EventArgs e)
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
                //Capturar Nome de usuário e nível de acesso.
                comando.CommandText = "SELECT NivelDeAcesso FROM TabelaUsuarios WHERE Usuario = '" + caixaUsuario.Text + "' AND Senha = '" + caixaSenha.Text + "'";

                if (comando.ExecuteScalar().ToString() == "All")
                {
                    Tela_Cadastro telaCadastro = new Tela_Cadastro();
                    this.Hide();
                    telaCadastro.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Nível de acesso insuficiente para cadastrar novos usuários!");
                }

            }
            else
            {
                MessageBox.Show("Usuário ou senha inválidos!");
            }
        }

        private void Botao_Voltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
