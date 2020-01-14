using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Supervisoria___tcc
{
    public partial class UCAquisicao : UserControl
    {
        public UCAquisicao()
        {
            InitializeComponent();
            adicionarProdutos();
        }

        Stopwatch timerCtr = new Stopwatch();
        bool ctrPause = false;
        private void adicionarProdutos()
        {
            lista_produtos_3.Items.Add("0");
            lista_produtos_3.Items.Add("1");
            lista_produtos_3.Items.Add("2");
            lista_produtos_3.Items.Add("3");

            lista_produtos_1.Items.Add("0");
            lista_produtos_1.Items.Add("1");
            lista_produtos_1.Items.Add("2");
            lista_produtos_1.Items.Add("3");

            lista_produtos_2.Items.Add("0");
            lista_produtos_2.Items.Add("1");
            lista_produtos_2.Items.Add("2");
            lista_produtos_2.Items.Add("3");

            lista_produtos_1.SelectedIndex = 0;
            lista_produtos_2.SelectedIndex = 0;
            lista_produtos_3.SelectedIndex = 0;
        }


        private void Botao_Bit_Produtos_Click(object sender, EventArgs e)
        {
            // Relativo ao produto 1
            if (lista_produtos_1.Text == "1")
            {
                Auxiliar.bitProdutos[0] = false;
                Auxiliar.bitProdutos[1] = true;
            }
            else if (lista_produtos_1.Text == "2")
            {
                Auxiliar.bitProdutos[0] = true;
                Auxiliar.bitProdutos[1] = false;
            }
            else if (lista_produtos_1.Text == "3")
            {
                Auxiliar.bitProdutos[0] = true;
                Auxiliar.bitProdutos[1] = true;
            }
            else
            {
                Auxiliar.bitProdutos[0] = false;
                Auxiliar.bitProdutos[1] = false;
            }

            // Relativo ao produto 2
            if (lista_produtos_2.Text == "1")
            {
                Auxiliar.bitProdutos[2] = false;
                Auxiliar.bitProdutos[3] = true;
            }
            else if (lista_produtos_2.Text == "2")
            {
                Auxiliar.bitProdutos[2] = true;
                Auxiliar.bitProdutos[3] = false;
            }
            else if (lista_produtos_2.Text == "3")
            {
                Auxiliar.bitProdutos[2] = true;
                Auxiliar.bitProdutos[3] = true;
            }
            else
            {
                Auxiliar.bitProdutos[2] = false;
                Auxiliar.bitProdutos[3] = false;
            }

            // Relativo ao produto 3
            if (lista_produtos_3.Text == "1")
            {
                Auxiliar.bitProdutos[4] = false;
                Auxiliar.bitProdutos[5] = true;
            }
            else if (lista_produtos_3.Text == "2")
            {
                Auxiliar.bitProdutos[4] = true;
                Auxiliar.bitProdutos[5] = false;
            }
            else if (lista_produtos_3.Text == "3")
            {
                Auxiliar.bitProdutos[4] = true;
                Auxiliar.bitProdutos[5] = true;
            }
            else
            {
                Auxiliar.bitProdutos[4] = false;
                Auxiliar.bitProdutos[5] = false;
            }

            Auxiliar.enviarBitProdutos();
            MessageBox.Show("Produtos cadastrados com sucesso!");
        }

        private void BotaoZerar_Click(object sender, EventArgs e)
        {
            timerAtualizacao.Enabled = false;
            timerCiclo.Enabled = false;
            timerCtr.Reset();


            timerCiclo.Interval = 570000;
            Auxiliar.timer = 570;
            Auxiliar.enviarBitZerar();
        }

        private void Botao_Ligar_Click(object sender, EventArgs e)
        {
            timerAtualizacao.Enabled = true;
            timerCiclo.Enabled = true;
            try
            {
                Auxiliar.enviarBitLigar();
            }
            catch
            {
                MessageBox.Show("Controlador não conectado!");
            }
            timerCtr.Start();
        }

        private void Botao_desligar_Click(object sender, EventArgs e)
        {
            timerAtualizacao.Enabled = false;
            timerCiclo.Enabled = false;
            timerCtr.Reset();

            timerCiclo.Interval = 570000;
            Auxiliar.timer = 570;
            try
            {
                Auxiliar.EnviarBitDesligar();
            }
            catch
            {
                MessageBox.Show("Controlador não conectado!");
            }
            
        }

        private void Botao_pause_Click(object sender, EventArgs e)
        {
            //Caso o sistema não tenha sido pausado
            if (ctrPause == false)
            {
                timerCtr.Stop();

                try
                {
                    Auxiliar.EnviarBitDesligar();
                }
                catch
                {
                    MessageBox.Show("Controlador não conectado!");
                }

                timerCiclo.Enabled = false;
                timerAtualizacao.Enabled = false;

                ctrPause = true;

            }
            //Caso o sistema já tenha tenha sido pausado
            else
            {
                ctrPause = false;
                timerAtualizacao.Enabled = true;
                timerCiclo.Enabled = true;

                timerCiclo.Interval = 570000 - (int)timerCtr.ElapsedMilliseconds;
                timerAtualizacao.Interval = 1000 - (int)timerCtr.ElapsedMilliseconds % 1000;
                try
                {
                    Auxiliar.enviarBitLigar();
                }
                catch
                {
                    MessageBox.Show("Controlador não conectado!");
                }
                
                timerCtr.Start();
            }
        }

        private void TimerCiclo_Tick(object sender, EventArgs e)
        {
            //Timer referente a atualização de um novo ciclo produtivo
            Auxiliar.reinicializacaoSistema();
            pausarTimers();

        }

        private void TimerAtualizacao_Tick(object sender, EventArgs e)
        {
            //Timer referente a atualização dos dados produtivos e gravação no banco de dados
            Auxiliar.buscarValoresProducao();
            Auxiliar.enviarDadosProducao();

            timerAtualizacao.Interval = 1000;  //Set do tempo para os casos em que houve pausa
            Auxiliar.timer--;
        }

        private void BotaoDemanda_Click(object sender, EventArgs e)
        {
            if (caixaDemanda1.Text != "" && caixaDemanda2.Text != "" && caixaDemanda1.Text != "")
            {
                if( Convert.ToDouble(caixaDemanda1.Text) + Convert.ToDouble(caixaDemanda2.Text) + Convert.ToDouble(caixaDemanda1.Text) == 200)
                {
                    Auxiliar.demandaProdutos[0] = Convert.ToDouble(caixaDemanda1.Text);
                    Auxiliar.demandaProdutos[1] = Convert.ToDouble(caixaDemanda2.Text);
                    Auxiliar.demandaProdutos[2] = Convert.ToDouble(caixaDemanda3.Text);
                }
                else
                {
                    MessageBox.Show("O somatório das demandas deve ser igual a 200 !");
                }

            }
            else
            {
                MessageBox.Show("Algum dos campos não foi preenchido corretamente!");
            }
        }

        private void TimerAtualizacaoDemanda_Tick(object sender, EventArgs e)
        {
            caixaDemanda1.Text = Auxiliar.demandaProdutos[0].ToString();
            caixaDemanda2.Text = Auxiliar.demandaProdutos[1].ToString();
            caixaDemanda3.Text = Auxiliar.demandaProdutos[2].ToString();
        }
        public void desabilitarTela()
        {
            timerAtualizacaoDemanda.Enabled = false;
        }

        public void habilitarTela()
        {
            timerAtualizacaoDemanda.Enabled = true;
        }

        private void pausarTimers()
        {

            timerAtualizacao.Enabled = false;
            timerCiclo.Enabled = false;

            timerCiclo.Interval = 570000;
            timerAtualizacao.Interval = 1000;


            timerCtr.Reset();
        }
    }
}
