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
using MathNet.Numerics.LinearAlgebra;

namespace Supervisoria___tcc
{
    public partial class TelaAutonoma : Form
    {
        public TelaAutonoma()
        {
            InitializeComponent();
        }
        static int[] vet = new int[] { 16, 12, 10};
        static MLP teste = new MLP(0.8, 0.000001, vet, 6, 15000);

        bool ctr = false;
        Stopwatch timerCtr = new Stopwatch();


        private void Botao_Status_Click(object sender, EventArgs e)
        {
            TelaProducao telaProducao = new TelaProducao();
            telaProducao.Show();
        }

        private void Botao_Treinamento_Click(object sender, EventArgs e)
        {

            var eqm = teste.treinamento();
            Console.WriteLine("//===================================//");
            Console.WriteLine("Erro quadrático médio do treinamento:" + eqm);
            MessageBox.Show("Terminado o treinamento");
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            aplicarRede();

            Auxiliar.timer--;
          
            //Auxiliar.enviarBitProdutos();
            // MessageBox.Show("Produtos cadastrados com sucesso!");
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            double[] demanda = sortearDemanda();

            Auxiliar.demandaProdutos[0] = Auxiliar.demandaProdutos[0] + demanda[0];
            Auxiliar.demandaProdutos[1] = Auxiliar.demandaProdutos[1] + demanda[1];
            Auxiliar.demandaProdutos[2] = Auxiliar.demandaProdutos[2] + demanda[2];

            textBoxDemanda1.Text = demanda[0].ToString();
            textBoxDemanda2.Text = demanda[1].ToString();
            textBoxDemanda3.Text = demanda[2].ToString();

            //Auxiliar.EnviarBitDesligar();

            //timer1.Enabled = false;
            //timer2.Enabled = false;

            timer2.Interval = 60000;
            timer1.Interval = 1000;

            Auxiliar.timer = 60;

            timerCtr.Reset();
        }

        private double[] sortearDemanda()
        {
            Random rand = new Random();

            double[] demanda = new double[3];

            var value = rand.Next(3);

            if (ctr == false)
            {
                if (value == 0)
                {
                    demanda[0] = rand.Next(6);
                    demanda[1] = rand.Next(6);
                    demanda[2] = 14 - demanda[0] - demanda[1];
                }
                else if (value == 1)
                {
                    demanda[0] = rand.Next(6);
                    demanda[2] = rand.Next(6);
                    demanda[1] = 14 - demanda[0] - demanda[2];
                }
                else if (value == 2)
                {
                    demanda[1] = rand.Next(6);
                    demanda[2] = rand.Next(6);
                    demanda[0] = 14 - demanda[1] - demanda[2];
                }

                ctr = true;
            }
            else
            {
                if (value == 0)
                {
                    demanda[0] = rand.Next(6);
                    demanda[1] = rand.Next(6);
                    demanda[2] = 16 - demanda[0] - demanda[1];
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


            return demanda;

        }

        private void TelaAutonoma_Load(object sender, EventArgs e)
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

        private void Botao_AplicacaoRede_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer2.Enabled = true;
            aplicarRede();

            Auxiliar.enviarBitLigar();
            timerCtr.Start();
        }

        private void aplicarRede()
        {
            Auxiliar.buscarValoresProducao();
            double[] vetorEntrada = new double[9];
            for (var index = 0; index < 3; index++)
            {
                if (Auxiliar.bitFuncionamento[index] == true)
                {
                    vetorEntrada[index] = 1;
                }
                else
                {
                    vetorEntrada[index] = -1;
                }
            }

            for (var index = 0; index < 3; index++)
            {
                vetorEntrada[index + 3] = Auxiliar.demandaProdutos[index];
            }
            for (var index = 0; index < 3; index++)
            {
                vetorEntrada[index + 6] = Auxiliar.qtdProduzidaProdutos[index];
            }
            Console.WriteLine("=================");
            
            var retorno= (Matrix<double>)teste.aplicacao(vetorEntrada);
            Console.WriteLine(retorno);
            
            for (var index = 0; index < 6; index++)
            {
                if (retorno[index, 0] == 1)
                {
                    Auxiliar.bitProdutos[index] = true;
                }
                else
                {
                    Auxiliar.bitProdutos[index] = false;
                }
            }

    
            

            Auxiliar.enviarBitProdutos();
        }

        private void Botao_zerar_Click(object sender, EventArgs e)
        {
            Auxiliar.enviarBitZerar();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            double[] vet = new double[] {1,1,1,0, 4, 10, 0, 4, 8};
            var retorno = (Matrix<double>)teste.aplicacao(vet);
            Console.WriteLine(retorno);
        }
    }
}
