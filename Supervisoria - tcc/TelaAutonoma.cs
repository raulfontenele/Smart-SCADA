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

        static int[] vet = new int[] { 14,14,14,14,14 };
        static MLP teste = new MLP(0.3, 0.000001, vet, 6, 12000);
        
        bool ctr = false;
        Stopwatch timerCtr = new Stopwatch();


        private void Botao_Status_Click(object sender, EventArgs e)
        {
            TelaProducao telaProducao = new TelaProducao();
            telaProducao.Show();
        }

        private void Botao_Treinamento_Click(object sender, EventArgs e)
        {

           // var eqm = teste.treinamento();
            Console.WriteLine("//===================================//");
           // Console.WriteLine("Erro quadrático médio do treinamento:" + eqm);
            MessageBox.Show("Terminado o treinamento");
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            aplicarRede();
            Auxiliar.gravarHistoricoProducao();

            Auxiliar.timer--;
          
            //Auxiliar.enviarBitProdutos();
            // MessageBox.Show("Produtos cadastrados com sucesso!");
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            /*
            double[] demanda = sortearDemanda();

            Auxiliar.demandaProdutos[0] = demanda[0];
            Auxiliar.demandaProdutos[1] = demanda[1];
            Auxiliar.demandaProdutos[2] = demanda[2];

            textBoxDemanda1.Text = demanda[0].ToString();
            textBoxDemanda2.Text = demanda[1].ToString();
            textBoxDemanda3.Text = demanda[2].ToString();
            */
            //Auxiliar.EnviarBitDesligar();

            //timer1.Enabled = false;
            //timer2.Enabled = false;

            timer2.Interval = 570000;
            timer1.Interval = 1000;

            timer1.Enabled = false;
            timer2.Enabled = false;

            Auxiliar.timer = 570;

            timerCtr.Reset();

            Auxiliar.EnviarBitDesligar();
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
            Console.WriteLine("Demanda:" + Auxiliar.demandaProdutos[0] + ":" + Auxiliar.demandaProdutos[1] + ":" + Auxiliar.demandaProdutos[2]);
            timer1.Enabled = true;
            timer2.Enabled = true;
            aplicarRede();

            Auxiliar.enviarBitLigar();
            //timerCtr.Start();
        }

        private void aplicarRede()
        {
            Auxiliar.buscarValoresProducao();
            double[] vetorEntrada = new double[6];
            
            for (var index = 0; index < 3; index++)
            {
                if (Auxiliar.bitFuncionamento[index] == true)
                {
                    vetorEntrada[index] = 0;
                }
                else
                {
                    vetorEntrada[index] = 1;
                }
            }
            
            for (var index = 0; index < 3; index++)
            {
                vetorEntrada[index] = Auxiliar.demandaProdutos[index];
            }
            for (var index = 0; index < 3; index++)
            {
                vetorEntrada[index + 3] = Auxiliar.qtdProduzidaProdutos[index];
            }
            Console.WriteLine("=================");
            //var vetinho = Matrix<double>.Build.Dense( 1,6,vetorEntrada);
            //Console.WriteLine("vetinho" + vetinho);
            
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
            Auxiliar.timer = 570;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Auxiliar.demandaProdutos[0] = Convert.ToDouble(textBoxDemanda1.Text);
            Auxiliar.demandaProdutos[1] = Convert.ToDouble(textBoxDemanda2.Text);
            Auxiliar.demandaProdutos[2] = Convert.ToDouble(textBoxDemanda3.Text);

            MessageBox.Show("Demanda processada com sucesso!");
        }
    }
}
