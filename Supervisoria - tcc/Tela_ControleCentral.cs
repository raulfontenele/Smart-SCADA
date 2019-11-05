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
    public partial class Tela_ControleCentral : Form
    {
        List<Panel> listaPaineis = new List<Panel>();

        public Tela_ControleCentral()
        {
            InitializeComponent();
            Auxiliar.inicializarDemanda();
        }

        private void Timer_Monitoramento_Tick(object sender, EventArgs e)
        {
            //verificarProdutosEmProducao();
            AtualizarDemanda();
            inicializacaoComboBox();
            //this.Parent = ucAquisicao1;
            //ucMonitoramento1.timer1.Start();
            
        }

        private void inicializacaoComboBox()
        {
            //lista_produtos_3.Items.Add("0");
            //lista_produtos_3.Items.Add("1");
            //lista_produtos_3.Items.Add("2");
            //lista_produtos_3.Items.Add("3");

            //lista_produtos_1.Items.Add("0");
            //lista_produtos_1.Items.Add("1");
            //lista_produtos_1.Items.Add("2");
            //lista_produtos_1.Items.Add("3");

            //lista_produtos_2.Items.Add("0");
            //lista_produtos_2.Items.Add("1");
            //lista_produtos_2.Items.Add("2");
            //lista_produtos_2.Items.Add("3");

            //lista_produtos_1.SelectedIndex = 0;
            //lista_produtos_2.SelectedIndex = 0;
            //lista_produtos_3.SelectedIndex = 0;
        }

        private void AtualizarDemanda()
        {
            /*
            label_DemandaValor_1.Text = Auxiliar.demandaProdutos[0].ToString();
            label_DemandaValor_2.Text = Auxiliar.demandaProdutos[1].ToString();
            label_DemandaValor_3.Text = Auxiliar.demandaProdutos[2].ToString();
        */
        }

        /*
        private void verificarProdutosEmProducao()
        {
            for (var index = 0; index < 6; index = index + 2)
            {
                if (Auxiliar.bitProdutos[index] == false && Auxiliar.bitProdutos[index + 1] == false)
                {
                    if (index == 0)
                    {
                        label_Produção_1.Text = "Parado";
                    }
                    else if(index == 2)
                    {
                        label_Produção_2.Text = "Parado";
                    }
                    else
                    {
                        label_Produção_3.Text = "Parado";
                    }
                }
                else if(Auxiliar.bitProdutos[index] == false && Auxiliar.bitProdutos[index + 1] == true){
                    if (index == 0)
                    {
                        label_Produção_1.Text = "Produto 1";
                    }
                    else if (index == 2)
                    {
                        label_Produção_2.Text = "Produto 1";
                    }
                    else
                    {
                        label_Produção_3.Text = "Produto 1";
                    }
                }
                else if (Auxiliar.bitProdutos[index] == true && Auxiliar.bitProdutos[index + 1] == false){
                    if (index == 0)
                    {
                        label_Produção_1.Text = "Produto 2";
                    }                                    
                    else if (index == 2)                 
                    {                                    
                        label_Produção_2.Text = "Produto 2";
                    }                                    
                    else                                 
                    {                                    
                        label_Produção_3.Text = "Produto 2";
                    }
                }
                else { 
                    if (index == 0)
                    {
                        label_Produção_1.Text = "Produto 3";
                    }
                    else if (index == 2)
                    {
                        label_Produção_2.Text = "Produto 3";
                    }
                    else
                    {
                        label_Produção_3.Text = "Produto 3";
                    }
                }

           }
        }
        */
        private void Botao_TelaAplicação_Click(object sender, EventArgs e)
        {
            if(Auxiliar.nivel_acesso == "Nivel 1" || Auxiliar.nivel_acesso == "All")
            {
                MessageBox.Show("Entrou na tela de aplicação!!");
                //TelaAutonoma tela_Autonoma = new TelaAutonoma();
                //this.Hide();
                //tela_Autonoma.ShowDialog();
                TelaAutonoma telaAuto = new TelaAutonoma();
                this.Hide();
                telaAuto.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Nível de acesso insuficiente!");
            }
        }

        private void Botao_TelaColeta_Click(object sender, EventArgs e)
        {
            if (Auxiliar.nivel_acesso == "All")
            {
                MessageBox.Show("Entrou na tela de Controle!!");
                //ucAquisicao1.Visible = true;
                //ucMonitoramento1.Visible = false;
            }
            else
            {
                MessageBox.Show("Nível de acesso insuficiente!");
            }
        }

        private void Botao_Sair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            TelaProducao tela_Producao = new TelaProducao();
            tela_Producao.Show();
        }

        private void Botao_Bit_Produtos_Click(object sender, EventArgs e)
        {
            // Relativo ao produto 1
            //if (lista_produtos_1.Text == "1")
            //{
            //    Auxiliar.bitProdutos[0] = false;
            //    Auxiliar.bitProdutos[1] = true;
            //}
            //else if (lista_produtos_1.Text == "2")
            //{
            //    Auxiliar.bitProdutos[0] = true;
            //    Auxiliar.bitProdutos[1] = false;
            //}
            //else if (lista_produtos_1.Text == "3")
            //{
            //    Auxiliar.bitProdutos[0] = true;
            //    Auxiliar.bitProdutos[1] = true;
            //}
            //else
            //{
            //    Auxiliar.bitProdutos[0] = false;
            //    Auxiliar.bitProdutos[1] = false;
            //}

            //// Relativo ao produto 2
            //if (lista_produtos_2.Text == "1")
            //{
            //    Auxiliar.bitProdutos[2] = false;
            //    Auxiliar.bitProdutos[3] = true;
            //}
            //else if (lista_produtos_2.Text == "2")
            //{
            //    Auxiliar.bitProdutos[2] = true;
            //    Auxiliar.bitProdutos[3] = false;
            //}
            //else if (lista_produtos_2.Text == "3")
            //{
            //    Auxiliar.bitProdutos[2] = true;
            //    Auxiliar.bitProdutos[3] = true;
            //}
            //else
            //{
            //    Auxiliar.bitProdutos[2] = false;
            //    Auxiliar.bitProdutos[3] = false;
            //}

            //// Relativo ao produto 3
            //if (lista_produtos_3.Text == "1")
            //{
            //    Auxiliar.bitProdutos[4] = false;
            //    Auxiliar.bitProdutos[5] = true;
            //}
            //else if (lista_produtos_3.Text == "2")
            //{
            //    Auxiliar.bitProdutos[4] = true;
            //    Auxiliar.bitProdutos[5] = false;
            //}
            //else if (lista_produtos_3.Text == "3")
            //{
            //    Auxiliar.bitProdutos[4] = true;
            //    Auxiliar.bitProdutos[5] = true;
            //}
            //else
            //{
            //    Auxiliar.bitProdutos[4] = false;
            //    Auxiliar.bitProdutos[5] = false;
            //}

            //Auxiliar.enviarBitProdutos();
            //MessageBox.Show("Produtos cadastrados com sucesso!");
        }

        private void Botao_Ligar_Click(object sender, EventArgs e)
        {
            //COLOCAR OS TIMER CERTOS

            //timer1.Enabled = true;
            //timer2.Enabled = true;

            Auxiliar.enviarBitLigar();
            //timerCtr.Start();
        }

        private void Botao_desligar_Click(object sender, EventArgs e)
        {
            //Colocar os timers certos

            //timerCtr.Stop();
            //timer1.Enabled = false;
            //timer2.Enabled = false;

            Auxiliar.EnviarBitDesligar();
        }

        private void BotaoZerar_Click(object sender, EventArgs e)
        {
            /*
            timer1.Enabled = false;
            timer2.Enabled = false;
            timerCtr.Reset();
            //timer1.Interval = false;
            timer2.Interval = 600000;
            */
            Auxiliar.timer = 600;
            Auxiliar.enviarBitZerar();


            /*

            textBoxDemanda1.Text = demanda[0].ToString();
            textBoxDemanda2.Text = demanda[1].ToString();
            textBoxDemanda3.Text = demanda[2].ToString();
            */
        }

        bool ctrPause = false;
        private void Botao_pause_Click(object sender, EventArgs e)
        {/*
            if (ctrPause == false)
            {
                timerCtr.Stop();
                Auxiliar.EnviarBitDesligar();

                timer1.Enabled = false;
                timer2.Enabled = false;

                ctrPause = true;

            }
            else
            {
                ctrPause = false;
                timer1.Enabled = true;
                timer2.Enabled = true;

                timer2.Interval = 600000 - (int)timerCtr.ElapsedMilliseconds;
                timer1.Interval = 1000 - (int)timerCtr.ElapsedMilliseconds % 1000;

                Auxiliar.enviarBitLigar();
                timerCtr.Start();
            }
            */
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

        private void Botao_SortearDemanda_Click(object sender, EventArgs e)
        {
            double[] demanda = sortearDemanda();

            Auxiliar.demandaProdutos[0] = demanda[0];
            Auxiliar.demandaProdutos[1] = demanda[1];
            Auxiliar.demandaProdutos[2] = demanda[2];
        }

        private void Botao_Producao_Click(object sender, EventArgs e)
        {
            TelaProducao tela_Producao = new TelaProducao();
            tela_Producao.Show();
        }

        private void Tela_ControleCentral_Load(object sender, EventArgs e)
        {
           // ucAquisicao1.Visible = false;
            //ucMonitoramento1.Visible = true;
        }


        private void Botao_Historico_Click(object sender, EventArgs e)
        {
            Tela_Graficos tela_grafico = new Tela_Graficos();
            tela_grafico.Show();
        }


        private void Button2_Click(object sender, EventArgs e)
        {
            //this.ucMonitoramento1.e
        }

    }
}
