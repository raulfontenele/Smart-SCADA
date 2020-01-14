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
    public partial class TelaControleCentral : Form
    {
        public TelaControleCentral()
        {
            InitializeComponent();
            Auxiliar.inicializarDemanda();
            InicilizacaoTelas();
        }

        private void Botao_Voltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Botao_Producao_Click(object sender, EventArgs e)
        {
            if(Auxiliar.ctrTelaProducao == false)
            {
                TelaProducao tela_Producao = new TelaProducao();
                Auxiliar.ctrTelaProducao = true;
                tela_Producao.Show();
            }
            else
            {
                MessageBox.Show("Tela já encontra-se aberta!");
            }

        }

        private void Botao_Sorteio_Click(object sender, EventArgs e)
        {
            double[] demanda = sortearDemanda();

            Auxiliar.demandaProdutos[0] = demanda[0];
            Auxiliar.demandaProdutos[1] = demanda[1];
            Auxiliar.demandaProdutos[2] = demanda[2];

            MessageBox.Show("Demanda gerada com sucesso!");
        }
        private double[] sortearDemanda()
        {
            Random rand = new Random();

            double[] demanda = new double[3];

            var value = rand.Next(3);

            if (value == 0)
            {
                demanda[0] = rand.Next(70);
                demanda[1] = rand.Next(70);
                demanda[2] = 200 - demanda[0] - demanda[1];
            }
            else if (value == 1)
            {
                demanda[0] = rand.Next(70);
                demanda[2] = rand.Next(70);
                demanda[1] = 200 - demanda[0] - demanda[2];
            }
            else if (value == 2)
            {
                demanda[1] = rand.Next(70);
                demanda[2] = rand.Next(70);
                demanda[0] = 200 - demanda[1] - demanda[2];
            }

            return demanda;

        }


        private void Botao_Monitoramento_Click(object sender, EventArgs e)
        {
            tela_Monitoramento.Visible = true;
            tela_Monitoramento.HabiliarTela();

            tela_Autonoma.Visible = false;
            tela_Autonoma.desabilitarTela();

            tela_Aquisicao.Visible = false;
            tela_Aquisicao.desabilitarTela();
        }

        private void Botao_Autonoma_Click(object sender, EventArgs e)
        {
            tela_Monitoramento.Visible = false;
            tela_Monitoramento.DesabilitarTela();

            tela_Autonoma.Visible = true;
            tela_Autonoma.habilitarTela();

            tela_Aquisicao.Visible = false;
            tela_Aquisicao.desabilitarTela();
        }

        private void Botao_Aquisicao_Click(object sender, EventArgs e)
        {
            if (Auxiliar.nivel_acesso ==  "Nivel2" || Auxiliar.nivel_acesso == "All")
            {
                tela_Monitoramento.Visible = false;
                tela_Monitoramento.DesabilitarTela();

                tela_Autonoma.Visible = false;
                tela_Autonoma.desabilitarTela();

                tela_Aquisicao.Visible = true;
                tela_Aquisicao.habilitarTela();
            }
            else
            {
                MessageBox.Show("Nível de acesso insuficiente!");
            }
        }

        private void UcAutonoma1_Load(object sender, EventArgs e)
        {

        }

        private void Botao_Historico_Click(object sender, EventArgs e)
        {
            if (Auxiliar.ctrTelaHistorico == false)
            {
                Auxiliar.ctrTelaHistorico = true;
                Tela_Graficos tela_Graficos = new Tela_Graficos();
                tela_Graficos.Show();
            }
            else
            {
                MessageBox.Show("Tela encontra-se aberta!");
            }
        }
        
        private void InicilizacaoTelas()
        {
            tela_Monitoramento.Visible = true;
            tela_Monitoramento.HabiliarTela();

            tela_Autonoma.Visible = false;
            tela_Autonoma.desabilitarTela();
            tela_Aquisicao.Visible = false;
            tela_Aquisicao.desabilitarTela();
        }
    }
}
