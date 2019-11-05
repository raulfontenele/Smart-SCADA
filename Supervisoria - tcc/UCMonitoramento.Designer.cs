namespace Supervisoria___tcc
{
    partial class UCMonitoramento
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labelIndicacaoProduto1 = new System.Windows.Forms.Label();
            this.labelIndicacaoProduto2 = new System.Windows.Forms.Label();
            this.labelIndicacaoProduto3 = new System.Windows.Forms.Label();
            this.labelProduto1 = new System.Windows.Forms.Label();
            this.labelProduto2 = new System.Windows.Forms.Label();
            this.labelProduto3 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // labelIndicacaoProduto1
            // 
            this.labelIndicacaoProduto1.AutoSize = true;
            this.labelIndicacaoProduto1.BackColor = System.Drawing.Color.Transparent;
            this.labelIndicacaoProduto1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelIndicacaoProduto1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIndicacaoProduto1.Location = new System.Drawing.Point(102, 62);
            this.labelIndicacaoProduto1.Name = "labelIndicacaoProduto1";
            this.labelIndicacaoProduto1.Size = new System.Drawing.Size(99, 24);
            this.labelIndicacaoProduto1.TabIndex = 0;
            this.labelIndicacaoProduto1.Text = "Produto:";
            // 
            // labelIndicacaoProduto2
            // 
            this.labelIndicacaoProduto2.AutoSize = true;
            this.labelIndicacaoProduto2.BackColor = System.Drawing.Color.Transparent;
            this.labelIndicacaoProduto2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelIndicacaoProduto2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIndicacaoProduto2.Location = new System.Drawing.Point(90, 261);
            this.labelIndicacaoProduto2.Name = "labelIndicacaoProduto2";
            this.labelIndicacaoProduto2.Size = new System.Drawing.Size(99, 24);
            this.labelIndicacaoProduto2.TabIndex = 1;
            this.labelIndicacaoProduto2.Text = "Produto:";
            // 
            // labelIndicacaoProduto3
            // 
            this.labelIndicacaoProduto3.AutoSize = true;
            this.labelIndicacaoProduto3.BackColor = System.Drawing.Color.Transparent;
            this.labelIndicacaoProduto3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelIndicacaoProduto3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIndicacaoProduto3.Location = new System.Drawing.Point(90, 470);
            this.labelIndicacaoProduto3.Name = "labelIndicacaoProduto3";
            this.labelIndicacaoProduto3.Size = new System.Drawing.Size(99, 24);
            this.labelIndicacaoProduto3.TabIndex = 2;
            this.labelIndicacaoProduto3.Text = "Produto:";
            // 
            // labelProduto1
            // 
            this.labelProduto1.AutoSize = true;
            this.labelProduto1.BackColor = System.Drawing.Color.Transparent;
            this.labelProduto1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProduto1.Location = new System.Drawing.Point(196, 60);
            this.labelProduto1.Name = "labelProduto1";
            this.labelProduto1.Size = new System.Drawing.Size(17, 24);
            this.labelProduto1.TabIndex = 3;
            this.labelProduto1.Text = "-";
            // 
            // labelProduto2
            // 
            this.labelProduto2.AutoSize = true;
            this.labelProduto2.BackColor = System.Drawing.Color.Transparent;
            this.labelProduto2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProduto2.Location = new System.Drawing.Point(184, 261);
            this.labelProduto2.Name = "labelProduto2";
            this.labelProduto2.Size = new System.Drawing.Size(17, 24);
            this.labelProduto2.TabIndex = 4;
            this.labelProduto2.Text = "-";
            // 
            // labelProduto3
            // 
            this.labelProduto3.AutoSize = true;
            this.labelProduto3.BackColor = System.Drawing.Color.Transparent;
            this.labelProduto3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProduto3.Location = new System.Drawing.Point(184, 470);
            this.labelProduto3.Name = "labelProduto3";
            this.labelProduto3.Size = new System.Drawing.Size(17, 24);
            this.labelProduto3.TabIndex = 5;
            this.labelProduto3.Text = "-";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // UCMonitoramento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Supervisoria___tcc.Properties.Resources.Capturar1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.labelProduto3);
            this.Controls.Add(this.labelProduto2);
            this.Controls.Add(this.labelProduto1);
            this.Controls.Add(this.labelIndicacaoProduto3);
            this.Controls.Add(this.labelIndicacaoProduto2);
            this.Controls.Add(this.labelIndicacaoProduto1);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UCMonitoramento";
            this.Size = new System.Drawing.Size(1204, 700);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelIndicacaoProduto1;
        private System.Windows.Forms.Label labelIndicacaoProduto2;
        private System.Windows.Forms.Label labelIndicacaoProduto3;
        private System.Windows.Forms.Label labelProduto1;
        private System.Windows.Forms.Label labelProduto2;
        private System.Windows.Forms.Label labelProduto3;
        public System.Windows.Forms.Timer timer1;
    }
}
