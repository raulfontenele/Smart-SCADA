namespace Supervisoria___tcc
{
    partial class UCAutonoma
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
            this.botao_Treinamento = new System.Windows.Forms.Button();
            this.botao_Aplicacao = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.caixaDemanda1 = new System.Windows.Forms.TextBox();
            this.caixaDemanda2 = new System.Windows.Forms.TextBox();
            this.caixaDemanda3 = new System.Windows.Forms.TextBox();
            this.botaoDemanda = new System.Windows.Forms.Button();
            this.timerAtualizacao = new System.Windows.Forms.Timer(this.components);
            this.timerCiclo = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelProduto1 = new System.Windows.Forms.Label();
            this.labelProduto2 = new System.Windows.Forms.Label();
            this.labelProduto3 = new System.Windows.Forms.Label();
            this.timerAtualizacaoDemanda = new System.Windows.Forms.Timer(this.components);
            this.imagemEsteira1Media = new System.Windows.Forms.PictureBox();
            this.imagemEsteira1Rapida = new System.Windows.Forms.PictureBox();
            this.imagemEsteira3Rapida = new System.Windows.Forms.PictureBox();
            this.imagemEsteira3Media = new System.Windows.Forms.PictureBox();
            this.imagemEsteira3Lenta = new System.Windows.Forms.PictureBox();
            this.imagemEsteira2Rapida = new System.Windows.Forms.PictureBox();
            this.imagemEsteira2Media = new System.Windows.Forms.PictureBox();
            this.imagemEsteira2Lenta = new System.Windows.Forms.PictureBox();
            this.imagemEsteira1Lenta = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imagemEsteira1Media)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imagemEsteira1Rapida)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imagemEsteira3Rapida)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imagemEsteira3Media)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imagemEsteira3Lenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imagemEsteira2Rapida)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imagemEsteira2Media)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imagemEsteira2Lenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imagemEsteira1Lenta)).BeginInit();
            this.SuspendLayout();
            // 
            // botao_Treinamento
            // 
            this.botao_Treinamento.BackColor = System.Drawing.Color.LightGray;
            this.botao_Treinamento.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CornflowerBlue;
            this.botao_Treinamento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botao_Treinamento.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botao_Treinamento.ForeColor = System.Drawing.SystemColors.ControlText;
            this.botao_Treinamento.Location = new System.Drawing.Point(720, 578);
            this.botao_Treinamento.Name = "botao_Treinamento";
            this.botao_Treinamento.Size = new System.Drawing.Size(145, 68);
            this.botao_Treinamento.TabIndex = 0;
            this.botao_Treinamento.Text = "Treinar a rede";
            this.botao_Treinamento.UseVisualStyleBackColor = false;
            this.botao_Treinamento.Click += new System.EventHandler(this.Botao_Treinamento_Click);
            // 
            // botao_Aplicacao
            // 
            this.botao_Aplicacao.BackColor = System.Drawing.Color.LightGray;
            this.botao_Aplicacao.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CornflowerBlue;
            this.botao_Aplicacao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botao_Aplicacao.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botao_Aplicacao.ForeColor = System.Drawing.SystemColors.ControlText;
            this.botao_Aplicacao.Location = new System.Drawing.Point(950, 578);
            this.botao_Aplicacao.Name = "botao_Aplicacao";
            this.botao_Aplicacao.Size = new System.Drawing.Size(145, 68);
            this.botao_Aplicacao.TabIndex = 1;
            this.botao_Aplicacao.Text = "Modo autônomo";
            this.botao_Aplicacao.UseVisualStyleBackColor = false;
            this.botao_Aplicacao.Click += new System.EventHandler(this.Botao_Aplicacao_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(734, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Demanda do produto 1:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(734, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(178, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Demanda do produto 2:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(734, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(178, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Demanda do produto 3:";
            // 
            // caixaDemanda1
            // 
            this.caixaDemanda1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.caixaDemanda1.Location = new System.Drawing.Point(918, 73);
            this.caixaDemanda1.Name = "caixaDemanda1";
            this.caixaDemanda1.Size = new System.Drawing.Size(77, 21);
            this.caixaDemanda1.TabIndex = 5;
            // 
            // caixaDemanda2
            // 
            this.caixaDemanda2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.caixaDemanda2.Location = new System.Drawing.Point(918, 133);
            this.caixaDemanda2.Name = "caixaDemanda2";
            this.caixaDemanda2.Size = new System.Drawing.Size(77, 21);
            this.caixaDemanda2.TabIndex = 6;
            // 
            // caixaDemanda3
            // 
            this.caixaDemanda3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.caixaDemanda3.Location = new System.Drawing.Point(918, 196);
            this.caixaDemanda3.Name = "caixaDemanda3";
            this.caixaDemanda3.Size = new System.Drawing.Size(77, 21);
            this.caixaDemanda3.TabIndex = 7;
            // 
            // botaoDemanda
            // 
            this.botaoDemanda.BackColor = System.Drawing.Color.LightGray;
            this.botaoDemanda.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CornflowerBlue;
            this.botaoDemanda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botaoDemanda.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botaoDemanda.ForeColor = System.Drawing.SystemColors.ControlText;
            this.botaoDemanda.Location = new System.Drawing.Point(737, 251);
            this.botaoDemanda.Name = "botaoDemanda";
            this.botaoDemanda.Size = new System.Drawing.Size(258, 35);
            this.botaoDemanda.TabIndex = 8;
            this.botaoDemanda.Text = "Processar Demanda";
            this.botaoDemanda.UseVisualStyleBackColor = false;
            this.botaoDemanda.Click += new System.EventHandler(this.BotaoDemanda_Click);
            // 
            // timerAtualizacao
            // 
            this.timerAtualizacao.Interval = 1000;
            this.timerAtualizacao.Tick += new System.EventHandler(this.TimerAtualizacao_Tick);
            // 
            // timerCiclo
            // 
            this.timerCiclo.Interval = 570000;
            this.timerCiclo.Tick += new System.EventHandler(this.TimerCiclo_Tick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(87, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 22);
            this.label4.TabIndex = 9;
            this.label4.Text = "Produto:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(87, 256);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 22);
            this.label5.TabIndex = 10;
            this.label5.Text = "Produto:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(87, 469);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 22);
            this.label6.TabIndex = 11;
            this.label6.Text = "Produto:";
            // 
            // labelProduto1
            // 
            this.labelProduto1.AutoSize = true;
            this.labelProduto1.BackColor = System.Drawing.Color.Transparent;
            this.labelProduto1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProduto1.Location = new System.Drawing.Point(182, 54);
            this.labelProduto1.Name = "labelProduto1";
            this.labelProduto1.Size = new System.Drawing.Size(16, 22);
            this.labelProduto1.TabIndex = 12;
            this.labelProduto1.Text = "-";
            // 
            // labelProduto2
            // 
            this.labelProduto2.AutoSize = true;
            this.labelProduto2.BackColor = System.Drawing.Color.Transparent;
            this.labelProduto2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProduto2.Location = new System.Drawing.Point(182, 256);
            this.labelProduto2.Name = "labelProduto2";
            this.labelProduto2.Size = new System.Drawing.Size(16, 22);
            this.labelProduto2.TabIndex = 13;
            this.labelProduto2.Text = "-";
            // 
            // labelProduto3
            // 
            this.labelProduto3.AutoSize = true;
            this.labelProduto3.BackColor = System.Drawing.Color.Transparent;
            this.labelProduto3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProduto3.Location = new System.Drawing.Point(182, 469);
            this.labelProduto3.Name = "labelProduto3";
            this.labelProduto3.Size = new System.Drawing.Size(16, 22);
            this.labelProduto3.TabIndex = 14;
            this.labelProduto3.Text = "-";
            // 
            // timerAtualizacaoDemanda
            // 
            this.timerAtualizacaoDemanda.Interval = 7000;
            this.timerAtualizacaoDemanda.Tick += new System.EventHandler(this.TimerAtualizacaoDemanda_Tick);
            // 
            // imagemEsteira1Media
            // 
            this.imagemEsteira1Media.BackColor = System.Drawing.Color.Transparent;
            this.imagemEsteira1Media.BackgroundImage = global::Supervisoria___tcc.Properties.Resources.X;
            this.imagemEsteira1Media.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imagemEsteira1Media.Location = new System.Drawing.Point(55, 132);
            this.imagemEsteira1Media.Name = "imagemEsteira1Media";
            this.imagemEsteira1Media.Size = new System.Drawing.Size(28, 21);
            this.imagemEsteira1Media.TabIndex = 33;
            this.imagemEsteira1Media.TabStop = false;
            // 
            // imagemEsteira1Rapida
            // 
            this.imagemEsteira1Rapida.BackColor = System.Drawing.Color.Transparent;
            this.imagemEsteira1Rapida.BackgroundImage = global::Supervisoria___tcc.Properties.Resources.X;
            this.imagemEsteira1Rapida.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imagemEsteira1Rapida.Location = new System.Drawing.Point(55, 175);
            this.imagemEsteira1Rapida.Name = "imagemEsteira1Rapida";
            this.imagemEsteira1Rapida.Size = new System.Drawing.Size(28, 21);
            this.imagemEsteira1Rapida.TabIndex = 32;
            this.imagemEsteira1Rapida.TabStop = false;
            // 
            // imagemEsteira3Rapida
            // 
            this.imagemEsteira3Rapida.BackColor = System.Drawing.Color.Transparent;
            this.imagemEsteira3Rapida.BackgroundImage = global::Supervisoria___tcc.Properties.Resources.X;
            this.imagemEsteira3Rapida.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imagemEsteira3Rapida.Location = new System.Drawing.Point(42, 597);
            this.imagemEsteira3Rapida.Name = "imagemEsteira3Rapida";
            this.imagemEsteira3Rapida.Size = new System.Drawing.Size(28, 21);
            this.imagemEsteira3Rapida.TabIndex = 31;
            this.imagemEsteira3Rapida.TabStop = false;
            // 
            // imagemEsteira3Media
            // 
            this.imagemEsteira3Media.BackColor = System.Drawing.Color.Transparent;
            this.imagemEsteira3Media.BackgroundImage = global::Supervisoria___tcc.Properties.Resources.X;
            this.imagemEsteira3Media.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imagemEsteira3Media.Location = new System.Drawing.Point(42, 548);
            this.imagemEsteira3Media.Name = "imagemEsteira3Media";
            this.imagemEsteira3Media.Size = new System.Drawing.Size(28, 21);
            this.imagemEsteira3Media.TabIndex = 30;
            this.imagemEsteira3Media.TabStop = false;
            // 
            // imagemEsteira3Lenta
            // 
            this.imagemEsteira3Lenta.BackColor = System.Drawing.Color.Transparent;
            this.imagemEsteira3Lenta.BackgroundImage = global::Supervisoria___tcc.Properties.Resources.X;
            this.imagemEsteira3Lenta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imagemEsteira3Lenta.Location = new System.Drawing.Point(42, 502);
            this.imagemEsteira3Lenta.Name = "imagemEsteira3Lenta";
            this.imagemEsteira3Lenta.Size = new System.Drawing.Size(28, 21);
            this.imagemEsteira3Lenta.TabIndex = 29;
            this.imagemEsteira3Lenta.TabStop = false;
            // 
            // imagemEsteira2Rapida
            // 
            this.imagemEsteira2Rapida.BackColor = System.Drawing.Color.Transparent;
            this.imagemEsteira2Rapida.BackgroundImage = global::Supervisoria___tcc.Properties.Resources.X;
            this.imagemEsteira2Rapida.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imagemEsteira2Rapida.Location = new System.Drawing.Point(55, 385);
            this.imagemEsteira2Rapida.Name = "imagemEsteira2Rapida";
            this.imagemEsteira2Rapida.Size = new System.Drawing.Size(28, 21);
            this.imagemEsteira2Rapida.TabIndex = 28;
            this.imagemEsteira2Rapida.TabStop = false;
            // 
            // imagemEsteira2Media
            // 
            this.imagemEsteira2Media.BackColor = System.Drawing.Color.Transparent;
            this.imagemEsteira2Media.BackgroundImage = global::Supervisoria___tcc.Properties.Resources.X;
            this.imagemEsteira2Media.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imagemEsteira2Media.Location = new System.Drawing.Point(55, 339);
            this.imagemEsteira2Media.Name = "imagemEsteira2Media";
            this.imagemEsteira2Media.Size = new System.Drawing.Size(28, 21);
            this.imagemEsteira2Media.TabIndex = 27;
            this.imagemEsteira2Media.TabStop = false;
            // 
            // imagemEsteira2Lenta
            // 
            this.imagemEsteira2Lenta.BackColor = System.Drawing.Color.Transparent;
            this.imagemEsteira2Lenta.BackgroundImage = global::Supervisoria___tcc.Properties.Resources.X;
            this.imagemEsteira2Lenta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imagemEsteira2Lenta.Location = new System.Drawing.Point(55, 295);
            this.imagemEsteira2Lenta.Name = "imagemEsteira2Lenta";
            this.imagemEsteira2Lenta.Size = new System.Drawing.Size(28, 21);
            this.imagemEsteira2Lenta.TabIndex = 26;
            this.imagemEsteira2Lenta.TabStop = false;
            // 
            // imagemEsteira1Lenta
            // 
            this.imagemEsteira1Lenta.BackColor = System.Drawing.Color.Transparent;
            this.imagemEsteira1Lenta.BackgroundImage = global::Supervisoria___tcc.Properties.Resources.X;
            this.imagemEsteira1Lenta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imagemEsteira1Lenta.Location = new System.Drawing.Point(55, 89);
            this.imagemEsteira1Lenta.Name = "imagemEsteira1Lenta";
            this.imagemEsteira1Lenta.Size = new System.Drawing.Size(28, 21);
            this.imagemEsteira1Lenta.TabIndex = 25;
            this.imagemEsteira1Lenta.TabStop = false;
            // 
            // UCAutonoma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Supervisoria___tcc.Properties.Resources.Capturar1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.imagemEsteira1Media);
            this.Controls.Add(this.imagemEsteira1Rapida);
            this.Controls.Add(this.imagemEsteira3Rapida);
            this.Controls.Add(this.imagemEsteira3Media);
            this.Controls.Add(this.imagemEsteira3Lenta);
            this.Controls.Add(this.imagemEsteira2Rapida);
            this.Controls.Add(this.imagemEsteira2Media);
            this.Controls.Add(this.imagemEsteira2Lenta);
            this.Controls.Add(this.imagemEsteira1Lenta);
            this.Controls.Add(this.labelProduto3);
            this.Controls.Add(this.labelProduto2);
            this.Controls.Add(this.labelProduto1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.botaoDemanda);
            this.Controls.Add(this.caixaDemanda3);
            this.Controls.Add(this.caixaDemanda2);
            this.Controls.Add(this.caixaDemanda1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.botao_Aplicacao);
            this.Controls.Add(this.botao_Treinamento);
            this.DoubleBuffered = true;
            this.Name = "UCAutonoma";
            this.Size = new System.Drawing.Size(1204, 700);
            ((System.ComponentModel.ISupportInitialize)(this.imagemEsteira1Media)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imagemEsteira1Rapida)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imagemEsteira3Rapida)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imagemEsteira3Media)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imagemEsteira3Lenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imagemEsteira2Rapida)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imagemEsteira2Media)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imagemEsteira2Lenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imagemEsteira1Lenta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button botao_Treinamento;
        private System.Windows.Forms.Button botao_Aplicacao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox caixaDemanda1;
        private System.Windows.Forms.TextBox caixaDemanda2;
        private System.Windows.Forms.TextBox caixaDemanda3;
        private System.Windows.Forms.Button botaoDemanda;
        private System.Windows.Forms.Timer timerAtualizacao;
        private System.Windows.Forms.Timer timerCiclo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelProduto1;
        private System.Windows.Forms.Label labelProduto2;
        private System.Windows.Forms.Label labelProduto3;
        private System.Windows.Forms.Timer timerAtualizacaoDemanda;
        private System.Windows.Forms.PictureBox imagemEsteira1Media;
        private System.Windows.Forms.PictureBox imagemEsteira1Rapida;
        private System.Windows.Forms.PictureBox imagemEsteira3Rapida;
        private System.Windows.Forms.PictureBox imagemEsteira3Media;
        private System.Windows.Forms.PictureBox imagemEsteira3Lenta;
        private System.Windows.Forms.PictureBox imagemEsteira2Rapida;
        private System.Windows.Forms.PictureBox imagemEsteira2Media;
        private System.Windows.Forms.PictureBox imagemEsteira2Lenta;
        private System.Windows.Forms.PictureBox imagemEsteira1Lenta;
    }
}
