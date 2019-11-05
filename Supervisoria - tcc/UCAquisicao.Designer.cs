namespace Supervisoria___tcc
{
    partial class UCAquisicao
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
            this.botao_pause = new System.Windows.Forms.Button();
            this.botaoZerar = new System.Windows.Forms.Button();
            this.botao_desligar = new System.Windows.Forms.Button();
            this.botao_Ligar = new System.Windows.Forms.Button();
            this.botao_Bit_Produtos = new System.Windows.Forms.Button();
            this.lista_produtos_2 = new System.Windows.Forms.ComboBox();
            this.lista_produtos_3 = new System.Windows.Forms.ComboBox();
            this.lista_produtos_1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timerAtualizacao = new System.Windows.Forms.Timer(this.components);
            this.timerCiclo = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // botao_pause
            // 
            this.botao_pause.BackColor = System.Drawing.Color.LightGray;
            this.botao_pause.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.botao_pause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botao_pause.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botao_pause.Location = new System.Drawing.Point(433, 353);
            this.botao_pause.Margin = new System.Windows.Forms.Padding(0);
            this.botao_pause.Name = "botao_pause";
            this.botao_pause.Size = new System.Drawing.Size(129, 61);
            this.botao_pause.TabIndex = 24;
            this.botao_pause.TabStop = false;
            this.botao_pause.Text = "Pause";
            this.botao_pause.UseVisualStyleBackColor = false;
            this.botao_pause.Click += new System.EventHandler(this.Botao_pause_Click);
            // 
            // botaoZerar
            // 
            this.botaoZerar.BackColor = System.Drawing.Color.LightGray;
            this.botaoZerar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.botaoZerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botaoZerar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botaoZerar.Location = new System.Drawing.Point(433, 280);
            this.botaoZerar.Margin = new System.Windows.Forms.Padding(0);
            this.botaoZerar.Name = "botaoZerar";
            this.botaoZerar.Size = new System.Drawing.Size(129, 61);
            this.botaoZerar.TabIndex = 23;
            this.botaoZerar.TabStop = false;
            this.botaoZerar.Text = "Zerar";
            this.botaoZerar.UseVisualStyleBackColor = false;
            this.botaoZerar.Click += new System.EventHandler(this.BotaoZerar_Click);
            // 
            // botao_desligar
            // 
            this.botao_desligar.BackColor = System.Drawing.Color.LightGray;
            this.botao_desligar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.botao_desligar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botao_desligar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botao_desligar.Location = new System.Drawing.Point(433, 207);
            this.botao_desligar.Margin = new System.Windows.Forms.Padding(0);
            this.botao_desligar.Name = "botao_desligar";
            this.botao_desligar.Size = new System.Drawing.Size(129, 61);
            this.botao_desligar.TabIndex = 22;
            this.botao_desligar.Text = "Desligar";
            this.botao_desligar.UseVisualStyleBackColor = false;
            this.botao_desligar.Click += new System.EventHandler(this.Botao_desligar_Click);
            // 
            // botao_Ligar
            // 
            this.botao_Ligar.BackColor = System.Drawing.Color.LightGray;
            this.botao_Ligar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.botao_Ligar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botao_Ligar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botao_Ligar.Location = new System.Drawing.Point(433, 129);
            this.botao_Ligar.Margin = new System.Windows.Forms.Padding(0);
            this.botao_Ligar.Name = "botao_Ligar";
            this.botao_Ligar.Size = new System.Drawing.Size(129, 61);
            this.botao_Ligar.TabIndex = 21;
            this.botao_Ligar.Text = "Ligar";
            this.botao_Ligar.UseVisualStyleBackColor = false;
            this.botao_Ligar.Click += new System.EventHandler(this.Botao_Ligar_Click);
            // 
            // botao_Bit_Produtos
            // 
            this.botao_Bit_Produtos.BackColor = System.Drawing.Color.LightGray;
            this.botao_Bit_Produtos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.botao_Bit_Produtos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botao_Bit_Produtos.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botao_Bit_Produtos.Location = new System.Drawing.Point(433, 56);
            this.botao_Bit_Produtos.Margin = new System.Windows.Forms.Padding(0);
            this.botao_Bit_Produtos.Name = "botao_Bit_Produtos";
            this.botao_Bit_Produtos.Size = new System.Drawing.Size(129, 61);
            this.botao_Bit_Produtos.TabIndex = 20;
            this.botao_Bit_Produtos.Text = "Processar Alterações";
            this.botao_Bit_Produtos.UseVisualStyleBackColor = false;
            this.botao_Bit_Produtos.Click += new System.EventHandler(this.Botao_Bit_Produtos_Click);
            // 
            // lista_produtos_2
            // 
            this.lista_produtos_2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lista_produtos_2.FormattingEnabled = true;
            this.lista_produtos_2.Location = new System.Drawing.Point(189, 247);
            this.lista_produtos_2.Name = "lista_produtos_2";
            this.lista_produtos_2.Size = new System.Drawing.Size(73, 26);
            this.lista_produtos_2.TabIndex = 28;
            // 
            // lista_produtos_3
            // 
            this.lista_produtos_3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lista_produtos_3.FormattingEnabled = true;
            this.lista_produtos_3.Location = new System.Drawing.Point(177, 445);
            this.lista_produtos_3.Name = "lista_produtos_3";
            this.lista_produtos_3.Size = new System.Drawing.Size(73, 26);
            this.lista_produtos_3.TabIndex = 26;
            // 
            // lista_produtos_1
            // 
            this.lista_produtos_1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lista_produtos_1.FormattingEnabled = true;
            this.lista_produtos_1.Location = new System.Drawing.Point(189, 51);
            this.lista_produtos_1.Name = "lista_produtos_1";
            this.lista_produtos_1.Size = new System.Drawing.Size(73, 26);
            this.lista_produtos_1.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(82, 55);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(101, 22);
            this.label3.TabIndex = 29;
            this.label3.Text = "Produto:";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(82, 247);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(101, 22);
            this.label1.TabIndex = 31;
            this.label1.Text = "Produto:";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(70, 449);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(101, 22);
            this.label2.TabIndex = 32;
            this.label2.Text = "Produto:";
            // 
            // timerAtualizacao
            // 
            this.timerAtualizacao.Interval = 1000;
            // 
            // UCAquisicao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Supervisoria___tcc.Properties.Resources.Capturar1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lista_produtos_1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lista_produtos_2);
            this.Controls.Add(this.lista_produtos_3);
            this.Controls.Add(this.botao_pause);
            this.Controls.Add(this.botaoZerar);
            this.Controls.Add(this.botao_desligar);
            this.Controls.Add(this.botao_Ligar);
            this.Controls.Add(this.botao_Bit_Produtos);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UCAquisicao";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1204, 700);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button botao_pause;
        private System.Windows.Forms.Button botaoZerar;
        private System.Windows.Forms.Button botao_desligar;
        private System.Windows.Forms.Button botao_Ligar;
        private System.Windows.Forms.Button botao_Bit_Produtos;
        private System.Windows.Forms.ComboBox lista_produtos_2;
        private System.Windows.Forms.ComboBox lista_produtos_3;
        private System.Windows.Forms.ComboBox lista_produtos_1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timerAtualizacao;
        private System.Windows.Forms.Timer timerCiclo;
    }
}
