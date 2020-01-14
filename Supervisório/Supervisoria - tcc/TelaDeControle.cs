using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using S7.Net;

namespace Supervisoria___tcc
{
    public partial class TelaDeControle : Form
    {
        public TelaDeControle()
        {
            InitializeComponent();
            adicionarProdutos();
            Auxiliar.inicializarDemanda();
            
        }
        bool ctr = false;
        Stopwatch timerCtr = new Stopwatch();

        private void Label1_Click(object sender, EventArgs e)
        {

        }
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


        private void BotaoStatusProducao_Click(object sender, EventArgs e)
        {

            TelaProducao telaProducao = new TelaProducao();
            telaProducao.Show();
            //Console.WriteLine("Qualquer coisa");
        }

        private void ProcessarDemanda_Click(object sender, EventArgs e)
        {
            if (Auxiliar.controleDemanda ==  false)
            {
                //Enviar dados para o banco de dados
                Auxiliar.demandaProdutos[0] = Convert.ToDouble(textBoxDemanda1.Text);
                Auxiliar.demandaProdutos[1] = Convert.ToDouble(textBoxDemanda2.Text);
                Auxiliar.demandaProdutos[2] = Convert.ToDouble(textBoxDemanda3.Text);

                Auxiliar.demandaProdutosAuxiliar[0] = Convert.ToDouble(textBoxDemanda1.Text);
                Auxiliar.demandaProdutosAuxiliar[1] = Convert.ToDouble(textBoxDemanda2.Text);
                Auxiliar.demandaProdutosAuxiliar[2] = Convert.ToDouble(textBoxDemanda3.Text);

                Auxiliar.controleDemanda = true;
            }
            else
            {
                Auxiliar.demandaProdutosAuxiliar[0] = Convert.ToDouble(textBoxDemanda1.Text);
                Auxiliar.demandaProdutosAuxiliar[1] = Convert.ToDouble(textBoxDemanda2.Text);
                Auxiliar.demandaProdutosAuxiliar[2] = Convert.ToDouble(textBoxDemanda3.Text);
            }


            MessageBox.Show("Produção processada com sucesso!");
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            //Console.WriteLine("Entrou no tck 1");
            Auxiliar.buscarValoresProducao();
            Auxiliar.enviarDadosProducao();

            timer1.Interval = 1000;

            
            Auxiliar.timer--;

        }

        private void TelaDeControle_Load(object sender, EventArgs e)
        {
            //Garantir demanda inicial
            double[] demanda = sortearDemanda();
            textBoxDemanda1.Text = demanda[0].ToString();
            textBoxDemanda2.Text = demanda[1].ToString();
            textBoxDemanda3.Text = demanda[2].ToString();

            Auxiliar.demandaProdutos[0] = demanda[0];
            Auxiliar.demandaProdutos[1] = demanda[1];
            Auxiliar.demandaProdutos[2] = demanda[2];
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

            //Auxiliar.enviarBitLigar();

            //timer1.Enabled = true;
            //timer2.Enabled = true;

        }

        private void Botao_Ligar_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer2.Enabled = true;

            Auxiliar.enviarBitLigar();
            timerCtr.Start();
        }

        private void Botao_desligar_Click(object sender, EventArgs e)
        {
            timerCtr.Stop();
            timer1.Enabled = false;
            timer2.Enabled = false;

            Auxiliar.EnviarBitDesligar();      
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            //Console.WriteLine("Entrou no tick 2");
            /*
            double[] demanda = sortearDemanda();

            Auxiliar.demandaProdutos[0] =  demanda[0];
            Auxiliar.demandaProdutos[1] =  demanda[1];
            Auxiliar.demandaProdutos[2] =  demanda[2];
            
            //Auxiliar.demandaProdutos[0] = Auxiliar.demandaProdutos[0] + demanda[0];
            //Auxiliar.demandaProdutos[1] = Auxiliar.demandaProdutos[1] + demanda[1];
            //Auxiliar.demandaProdutos[2] = Auxiliar.demandaProdutos[2] + demanda[2];

            textBoxDemanda1.Text = demanda[0].ToString();
            textBoxDemanda2.Text = demanda[1].ToString();
            textBoxDemanda3.Text = demanda[2].ToString();
            */
            Auxiliar.EnviarBitDesligar();

            timer1.Enabled = false;
            timer2.Enabled = false;

            timer2.Interval = 600000;
            timer1.Interval = 1000;

            Auxiliar.timer = 600;

            timerCtr.Reset();
            
        }

        private double[] sortearDemanda()
        {
            Random rand = new Random();

            double[] demanda = new double[3];

            var value = rand.Next(3);

            if (ctr ==  false)
            {
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

                //ctr = true;
            }
            /*
            else
            {
                if (value == 0)
                {
                    demanda[0] = rand.Next(6);
                    demanda[1] = rand.Next(6);
                    demanda[2] = 100 - demanda[0] - demanda[1];
                }
                else if (value == 1)
                {
                    demanda[0] = rand.Next(6);
                    demanda[2] = rand.Next(6);
                    demanda[1] = 16 - demanda[0] - demanda[2];
                }
                else if (value == 2)
                {
                    demanda[1] = rand.Next(6);
                    demanda[2] = rand.Next(6);
                    demanda[0] = 16 - demanda[1] - demanda[2];
                }
            }
            */
           

            return demanda;

        }

        private void BotaoZerar_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer2.Enabled = false;
            timerCtr.Reset();
            //timer1.Interval = false;
            timer2.Interval = 600000;
            Auxiliar.timer = 600;
            Auxiliar.enviarBitZerar();

            double[] demanda = sortearDemanda();

            Auxiliar.demandaProdutos[0] = demanda[0];
            Auxiliar.demandaProdutos[1] = demanda[1];
            Auxiliar.demandaProdutos[2] = demanda[2];


            textBoxDemanda1.Text = demanda[0].ToString();
            textBoxDemanda2.Text = demanda[1].ToString();
            textBoxDemanda3.Text = demanda[2].ToString();


        }
        bool ctrPause = false;
        private void Botao_pause_Click(object sender, EventArgs e)
        {
            if(ctrPause == false)
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
        }
    }
}
