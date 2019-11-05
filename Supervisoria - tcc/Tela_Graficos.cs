using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlServerCe;

namespace Supervisoria___tcc
{
    public partial class Tela_Graficos : Form
    {
        public Tela_Graficos()
        {
            InitializeComponent();
        }

          private void mostrarGrafico()
        {
            //Estabelecendo ligação
            SqlCeConnection ligacao = new SqlCeConnection(@"Data Source = " + Auxiliar.base_dados);
            ligacao.Open();

            //Retirar dados da base de dados
            SqlCeDataAdapter adaptador = new SqlCeDataAdapter("SELECT * FROM TabelaControle" + Auxiliar.nome_usuario, ligacao);

            //Criando tabela de dados
            DataTable dados = new DataTable(); 
            adaptador.Fill(dados);

            //Criando visualizador dos dados
            DataView data = new DataView(dados);
            
            //Definindo fonde de dados do gráfico e qual a fonte das linhas e das colunas
            chart1.DataSource = data;
            chart1.Series[0].XValueMember = "DemandaProduto1";
            chart1.Series[0].YValueMembers = "QtdProduzidaProduto1";
            chart1.DataBind();

            //Desligando todas as ligações
            adaptador.Dispose();
            ligacao.Dispose();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            mostrarGrafico();
        }

        private void Chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
