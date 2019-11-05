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


            timerCiclo.Interval = 600000;
            Auxiliar.timer = 600;
            Auxiliar.enviarBitZerar();
        }

        private void Botao_Ligar_Click(object sender, EventArgs e)
        {
            timerAtualizacao.Enabled = true;
            timerCiclo.Enabled = true;

            Auxiliar.enviarBitLigar();
            timerCtr.Start();
        }

        private void Botao_desligar_Click(object sender, EventArgs e)
        {
            timerCtr.Stop();
            timerCiclo.Enabled = false;
            timerAtualizacao.Enabled = false;

            Auxiliar.EnviarBitDesligar();
        }

        private void Botao_pause_Click(object sender, EventArgs e)
        {
            if (ctrPause == false)
            {
                timerCtr.Stop();
                Auxiliar.EnviarBitDesligar();

                timerCiclo.Enabled = false;
                timerAtualizacao.Enabled = false;

                ctrPause = true;

            }
            else
            {
                ctrPause = false;
                timerAtualizacao.Enabled = true;
                timerCiclo.Enabled = true;

                timerCiclo.Interval = 600000 - (int)timerCtr.ElapsedMilliseconds;
                timerAtualizacao.Interval = 1000 - (int)timerCtr.ElapsedMilliseconds % 1000;

                Auxiliar.enviarBitLigar();
                timerCtr.Start();
            }
        }
    }
}
