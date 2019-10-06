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
    public partial class Tela_Cadastro : Form
    {
        public Tela_Cadastro()
        {
            InitializeComponent();
            inserirNiveisAcesso();
        }

        private void BotaoVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void inserirNiveisAcesso()
        {
            //inserir nomes no comboBox
            caixaNiveis.Items.Add("Nivel 1");
            caixaNiveis.Items.Add("Nivel 2");
            caixaNiveis.Items.Add("All");
            caixaNiveis.SelectedIndex = 0;
        }

        private void BotaoCriarUsuario_Click(object sender, EventArgs e)
        {
            if (caixaUsuario.TextLength > 0 && caixaSenha.TextLength > 0 && caixaNiveis.SelectedIndex >= 0 && caixaSenha.Text == caixaConfSenha.Text && verificarExistencia()==false)
            {
                CadastrarUsuario();
                MessageBox.Show("Usuário cadastrado com sucesso.");
            }
            else if (caixaUsuario.TextLength <= 0 && caixaSenha.TextLength <= 0)
                MessageBox.Show("Usuário ou senha inválidos!");
            else if (caixaUsuario.TextLength <= 0 && caixaSenha.TextLength <= 0)
                MessageBox.Show("Nível de acesso não selecionado.");
            else if (verificarExistencia())
            {
                MessageBox.Show("Usuário já cadastrado.");
            }
            else
                MessageBox.Show("O campo de confirmação não está igual ao campo da senha.");
        }

        private void CadastrarUsuario()
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
            comando.Parameters.AddWithValue(@"NivelDeAcesso", caixaNiveis.SelectedItem);

            //inserir no banco de dados
            comando.CommandText = "INSERT INTO TabelaUsuarios(Usuario,Senha,NivelDeAcesso) VALUES(@Usuario,@Senha,@NivelDeAcesso)";

            comando.ExecuteNonQuery();

            comando.Dispose();
            ligacao.Dispose();
        }
        private bool verificarExistencia()
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

            //inserir no banco de dados
            comando.CommandText = "SELECT COUNT(1) FROM TabelaUsuarios WHERE Usuario = @Usuario";

            Object retorno = comando.ExecuteScalar();
            comando.Dispose();
            ligacao.Dispose();

            if (retorno.Equals(1))
            {
                return true;
            }
            else
            {
                return false;
            }



        }
    }
}
