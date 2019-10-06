using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            bool ctr = false;
        }

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
            Console.WriteLine("Qualquer coisa");
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
            Auxiliar.buscarValoresProducao();
            //Auxiliar.EnviarBitDesligar();
            //Auxiliar.enviarDadosProducao();
            //Console.WriteLine("Rodando tick 1");

        }

        private void TelaDeControle_Load(object sender, EventArgs e)
        {

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
           // timer1.Enabled = true;

        }

        private void Botao_Ligar_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer2.Enabled = true;
            Auxiliar.enviarBitLigar();
        }

        private void Botao_desligar_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer2.Enabled = false;
            Auxiliar.EnviarBitDesligar();
            
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            Auxiliar.demandaProdutos[0] = Auxiliar.demandaProdutos[0] + Auxiliar.demandaProdutosAuxiliar[0];
            Auxiliar.demandaProdutos[1] = Auxiliar.demandaProdutos[1] + Auxiliar.demandaProdutosAuxiliar[1];
            Auxiliar.demandaProdutos[2] = Auxiliar.demandaProdutos[2] + Auxiliar.demandaProdutosAuxiliar[2];
            //Auxiliar.EnviarBitDesligar();
        }
    }
}
