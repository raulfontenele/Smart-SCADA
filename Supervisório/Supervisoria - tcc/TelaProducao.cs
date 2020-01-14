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


        private void Timer1_Tick(object sender, EventArgs e)
        {
            //Auxiliar.buscarValoresProducao();

            //for (var i = 0;i<3;i++) Console.WriteLine("Controle"+ (i+1) + " = " + Auxiliar.bitFuncionamento[i]);

            caixaProducaoProduto1.Text = Auxiliar.qtdProduzidaProdutos[0].ToString();
            caixaProducaoProduto2.Text = Auxiliar.qtdProduzidaProdutos[1].ToString();
            caixaProducaoProduto3.Text = Auxiliar.qtdProduzidaProdutos[2].ToString();

            textBoxDemanda1.Text = Auxiliar.demandaProdutos[0].ToString();
            textBoxDemanda2.Text = Auxiliar.demandaProdutos[1].ToString();
            textBoxDemanda3.Text = Auxiliar.demandaProdutos[2].ToString();

            //Auxiliar.enviarDadosProducao();

            label_time.Text = Auxiliar.timer.ToString();


            //Console.WriteLine("Rodando tick 2");
        }

        private void Botao_voltar_Click(object sender, EventArgs e)
        {
            Auxiliar.ctrTelaProducao = false;
            this.Close();
        }

        private void Botao_historico_Click(object sender, EventArgs e)
        {
            Tela_Graficos telaGrafico = new Tela_Graficos();
            telaGrafico.Show();
        }

        private void TelaProducao_Load(object sender, EventArgs e)
        {

        }

        private void TimerSegundos_Tick(object sender, EventArgs e)
        {
            label_time.Text = Auxiliar.timer.ToString();
            
        }

    }
}
