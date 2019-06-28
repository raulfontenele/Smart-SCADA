using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            if(caiaxaUsuario.Text == "Adm" && caixaSenha.Text == "Adm123")
            {
                Tela_Cadastro telaCadastro = new Tela_Cadastro();
                telaCadastro.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuário ou senha inválidos!");
            }
        }

        private void BotaoVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
