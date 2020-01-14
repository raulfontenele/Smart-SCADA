using System;
using System.Windows.Forms;
using System.Diagnostics;
using MathNet.Numerics.LinearAlgebra;

namespace Supervisoria___tcc
{
    public partial class UCAutonoma : UserControl
    {
        public UCAutonoma()
        {
            InitializeComponent();
        }

        static int[] vet = new int[] { 12, 12, 12, 12 };
        static MLP teste = new MLP(0.3, 0.000001, vet, 6, 12000);

        private void BotaoDemanda_Click(object sender, EventArgs e)
        {
            if (caixaDemanda1.Text != "" && caixaDemanda2.Text != "" && caixaDemanda1.Text != "")
            {
                Auxiliar.demandaProdutos[0] = Convert.ToDouble(caixaDemanda1.Text);
                Auxiliar.demandaProdutos[1] = Convert.ToDouble(caixaDemanda2.Text);
                Auxiliar.demandaProdutos[2] = Convert.ToDouble(caixaDemanda3.Text);
            }
            else
            {
                MessageBox.Show("Algum dos campos não foi preenchido corretamente!");
            }
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

            var retorno = (Matrix<double>)teste.aplicacao(vetorEntrada);
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

        private void Botao_Treinamento_Click(object sender, EventArgs e)
        {
            var eqm = teste.treinamento();
            Console.WriteLine("Erro quadrático médio do treinamento:" + eqm);
            MessageBox.Show("Terminado o treinamento");
        }

        private void TimerAtualizacao_Tick(object sender, EventArgs e)
        {
            aplicarRede();
            atualizarProdutos();
            AtualizarSimbolos();
            Auxiliar.timer--;
            Auxiliar.gravarHistoricoProducao();

        }

        private void TimerCiclo_Tick(object sender, EventArgs e)
        {
            //Timer referente a atualização de um novo ciclo produtivo
            Auxiliar.reinicializacaoSistema();
            pausarTimers();
        }
        public void atualizarProdutos()
        {
            for (var index = 0; index < 6; index = index + 2)
            {
                if (index == 0)
                {
                    if (Auxiliar.bitProdutos[index] == false && Auxiliar.bitProdutos[index + 1] == true)
                    {
                        labelProduto1.Text = "1";
                    }
                    else if (Auxiliar.bitProdutos[index] == true && Auxiliar.bitProdutos[index + 1] == false)
                    {
                        labelProduto1.Text = "2";
                    }
                    else if (Auxiliar.bitProdutos[index] == true && Auxiliar.bitProdutos[index + 1] == true)
                    {
                        labelProduto1.Text = "3";
                    }
                    else
                    {
                        labelProduto1.Text = "Parado";
                    }
                }
                else if (index == 2)
                {
                    if (Auxiliar.bitProdutos[index] == false && Auxiliar.bitProdutos[index + 1] == true)
                    {
                        labelProduto2.Text = "1";
                    }
                    else if (Auxiliar.bitProdutos[index] == true && Auxiliar.bitProdutos[index + 1] == false)
                    {
                        labelProduto2.Text = "2";
                    }
                    else if (Auxiliar.bitProdutos[index] == true && Auxiliar.bitProdutos[index + 1] == true)
                    {
                        labelProduto2.Text = "3";
                    }
                    else
                    {
                        labelProduto2.Text = "Parado";
                    }
                }
                else if (index == 4)
                {
                    if (Auxiliar.bitProdutos[index] == false && Auxiliar.bitProdutos[index + 1] == true)
                    {
                        labelProduto3.Text = "1";
                    }
                    else if (Auxiliar.bitProdutos[index] == true && Auxiliar.bitProdutos[index + 1] == false)
                    {
                        labelProduto3.Text = "2";
                    }
                    else if (Auxiliar.bitProdutos[index] == true && Auxiliar.bitProdutos[index + 1] == true)
                    {
                        labelProduto3.Text = "3";
                    }
                    else
                    {
                        labelProduto3.Text = "Parado";
                    }
                }
            }
        }

        private void Botao_Aplicacao_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Demanda:" + Auxiliar.demandaProdutos[0] + ":" + Auxiliar.demandaProdutos[1] + ":" + Auxiliar.demandaProdutos[2]);
            timerAtualizacao.Enabled = true;
            timerCiclo.Enabled = true;
            aplicarRede();

            Auxiliar.enviarBitLigar();
        }
        private void pausarTimers()
        {

            timerAtualizacao.Enabled = false;
            timerCiclo.Enabled = false;

            timerCiclo.Interval = 570000;
            timerAtualizacao.Interval = 1000;

        }
        public void desabilitarTela()
        {
            timerAtualizacaoDemanda.Enabled = false;
        }

        public void habilitarTela()
        {
            timerAtualizacaoDemanda.Enabled = true;
        }

        private void TimerAtualizacaoDemanda_Tick(object sender, EventArgs e)
        {
            caixaDemanda1.Text = Auxiliar.demandaProdutos[0].ToString();
            caixaDemanda2.Text = Auxiliar.demandaProdutos[1].ToString();
            caixaDemanda3.Text = Auxiliar.demandaProdutos[2].ToString();
        }
        private void AtualizarSimbolos()
        {
            for (var index = 0; index < 6; index = index + 2)
            {
                if (index == 0)
                {
                    if (Auxiliar.bitProdutos[index] == false && Auxiliar.bitProdutos[index + 1] == true)
                    {
                        imagemEsteira1Lenta.BackgroundImage = Properties.Resources.elementoVerde;
                        imagemEsteira1Media.BackgroundImage = Properties.Resources.X;
                        imagemEsteira1Rapida.BackgroundImage = Properties.Resources.elementoCinza;
                    }
                    else if (Auxiliar.bitProdutos[index] == true && Auxiliar.bitProdutos[index + 1] == false)
                    {
                        imagemEsteira1Lenta.BackgroundImage = Properties.Resources.elementoVerde;
                        imagemEsteira1Media.BackgroundImage = Properties.Resources.elementoAzul;
                        imagemEsteira1Rapida.BackgroundImage = Properties.Resources.X;
                    }
                    else if (Auxiliar.bitProdutos[index] == true && Auxiliar.bitProdutos[index + 1] == true)
                    {
                        imagemEsteira1Lenta.BackgroundImage = Properties.Resources.X;
                        imagemEsteira1Media.BackgroundImage = Properties.Resources.elementoAzul;
                        imagemEsteira1Rapida.BackgroundImage = Properties.Resources.elementoCinza;
                    }
                    else
                    {
                        imagemEsteira1Lenta.BackgroundImage = Properties.Resources.X;
                        imagemEsteira1Media.BackgroundImage = Properties.Resources.X;
                        imagemEsteira1Rapida.BackgroundImage = Properties.Resources.X;
                    }
                }
                else if (index == 2)
                {
                    if (Auxiliar.bitProdutos[index] == false && Auxiliar.bitProdutos[index + 1] == true)
                    {
                        imagemEsteira2Lenta.BackgroundImage = Properties.Resources.elementoVerde;
                        imagemEsteira2Media.BackgroundImage = Properties.Resources.X;
                        imagemEsteira2Rapida.BackgroundImage = Properties.Resources.elementoCinza;
                    }
                    else if (Auxiliar.bitProdutos[index] == true && Auxiliar.bitProdutos[index + 1] == false)
                    {
                        imagemEsteira2Lenta.BackgroundImage = Properties.Resources.elementoVerde;
                        imagemEsteira2Media.BackgroundImage = Properties.Resources.elementoAzul;
                        imagemEsteira2Rapida.BackgroundImage = Properties.Resources.X;
                    }
                    else if (Auxiliar.bitProdutos[index] == true && Auxiliar.bitProdutos[index + 1] == true)
                    {
                        imagemEsteira2Lenta.BackgroundImage = Properties.Resources.X;
                        imagemEsteira2Media.BackgroundImage = Properties.Resources.elementoAzul;
                        imagemEsteira2Rapida.BackgroundImage = Properties.Resources.elementoCinza;
                    }
                    else
                    {
                        imagemEsteira2Lenta.BackgroundImage = Properties.Resources.X;
                        imagemEsteira2Media.BackgroundImage = Properties.Resources.X;
                        imagemEsteira2Rapida.BackgroundImage = Properties.Resources.X;
                    }
                }
                else if (index == 4)
                {
                    if (Auxiliar.bitProdutos[index] == false && Auxiliar.bitProdutos[index + 1] == true)
                    {
                        imagemEsteira3Lenta.BackgroundImage = Properties.Resources.elementoVerde;
                        imagemEsteira3Media.BackgroundImage = Properties.Resources.X;
                        imagemEsteira3Rapida.BackgroundImage = Properties.Resources.elementoCinza;
                    }
                    else if (Auxiliar.bitProdutos[index] == true && Auxiliar.bitProdutos[index + 1] == false)
                    {
                        imagemEsteira3Lenta.BackgroundImage = Properties.Resources.elementoVerde;
                        imagemEsteira3Media.BackgroundImage = Properties.Resources.elementoAzul;
                        imagemEsteira3Rapida.BackgroundImage = Properties.Resources.X;
                    }
                    else if (Auxiliar.bitProdutos[index] == true && Auxiliar.bitProdutos[index + 1] == true)
                    {
                        imagemEsteira3Lenta.BackgroundImage = Properties.Resources.X;
                        imagemEsteira3Media.BackgroundImage = Properties.Resources.elementoAzul;
                        imagemEsteira3Rapida.BackgroundImage = Properties.Resources.elementoCinza;
                    }
                    else
                    {
                        imagemEsteira3Lenta.BackgroundImage = Properties.Resources.X;
                        imagemEsteira3Media.BackgroundImage = Properties.Resources.X;
                        imagemEsteira3Rapida.BackgroundImage = Properties.Resources.X;
                    }
                }
            }
        }
    }
}
