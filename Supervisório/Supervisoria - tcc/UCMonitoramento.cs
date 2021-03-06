﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supervisoria___tcc
{
    public partial class UCMonitoramento : UserControl
    {
        public UCMonitoramento()
        {
            InitializeComponent();
        }


        private void atualizarProdutos()
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

        private void atualizarDemanda()
        {
            caixaDemanda1.Text = Auxiliar.demandaProdutos[0].ToString();
            caixaDemanda2.Text = Auxiliar.demandaProdutos[1].ToString();
            caixaDemanda3.Text = Auxiliar.demandaProdutos[2].ToString();
        }

        private void TimerAtualizacao_Tick(object sender, EventArgs e)
        {
            atualizarProdutos();
            atualizarDemanda();
            AtualizarSimbolos();
        }

        public void HabiliarTela()
        {
            timerAtualizacao.Enabled = true;
        }
        public void DesabilitarTela()
        {
            timerAtualizacao.Enabled = true;
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
