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
    public partial class TelaEscolhas : Form
    {
        public TelaEscolhas()
        {
            InitializeComponent();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Botao_Tela_Controle_Click(object sender, EventArgs e)
        {
            TelaDeControle tela_Controle = new TelaDeControle();
            this.Hide();
            tela_Controle.ShowDialog();
            this.Close();
        }

        private void Botao_Tela_Autonoma_Click(object sender, EventArgs e)
        {
            TelaAutonoma tela_Autonoma = new TelaAutonoma();
            this.Hide();
            tela_Autonoma.Show();
            this.Close();
        }

        private void TelaEscolhas_Load(object sender, EventArgs e)
        {

        }
    }
}
