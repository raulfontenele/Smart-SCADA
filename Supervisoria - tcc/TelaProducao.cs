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
    public partial class TelaProducao : Form
    {
        public TelaProducao()
        {
            InitializeComponent();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Auxiliar.buscarValoresProducao();

            caixaProducaoProduto1.Text = Auxiliar.qtdProduzidaProdutos[0].ToString();
            caixaProducaoProduto2.Text = Auxiliar.qtdProduzidaProdutos[1].ToString();
            caixaProducaoProduto3.Text = Auxiliar.qtdProduzidaProdutos[2].ToString();

            textBoxDemanda1.Text = Auxiliar.demandaProdutos[0].ToString();
            textBoxDemanda2.Text = Auxiliar.demandaProdutos[1].ToString();
            textBoxDemanda3.Text = Auxiliar.demandaProdutos[2].ToString();

            //Auxiliar.enviarDadosProducao();


            //Console.WriteLine("Rodando tick 2");
        }

        private void Botao_voltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Botao_historico_Click(object sender, EventArgs e)
        {
            Tela_Graficos telaGrafico = new Tela_Graficos();
            telaGrafico.Show();
        }
    }
}
