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
        public Tela_ControleCentral()
        {
            InitializeComponent();
        }

        private void Timer_Monitoramento_Tick(object sender, EventArgs e)
        {
            verificarProdutosEmProducao();
        }
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

        private void Botao_TelaAplicação_Click(object sender, EventArgs e)
        {
            if(Auxiliar.nivel_acesso == "Nivel 1" || Auxiliar.nivel_acesso == "All")
            {
                MessageBox.Show("Entrou na tela de aplicação!!");
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
                MessageBox.Show("Entrou na tela de aplicação!!");
            }
            else
            {
                MessageBox.Show("Nível de acesso insuficiente!");
            }
        }
    
    }
}
