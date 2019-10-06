namespace Supervisoria___tcc
{
    partial class TelaDeControle
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.lista_produtos_3 = new System.Windows.Forms.ComboBox();
            this.lista_produtos_2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lista_produtos_1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxDemanda1 = new System.Windows.Forms.TextBox();
            this.textBoxDemanda2 = new System.Windows.Forms.TextBox();
            this.textBoxDemanda3 = new System.Windows.Forms.TextBox();
            this.processarDemanda = new System.Windows.Forms.Button();
            this.botaoStatusProducao = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.botao_Bit_Produtos = new System.Windows.Forms.Button();
            this.botao_Ligar = new System.Windows.Forms.Button();
            this.botao_desligar = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(63, 259);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Produto:";
            this.label1.Click += new System.EventHandler(this.Label1_Click);
            // 
            // lista_produtos_3
            // 
            this.lista_produtos_3.FormattingEnabled = true;
            this.lista_produtos_3.Location = new System.Drawing.Point(136, 260);
            this.lista_produtos_3.Name = "lista_produtos_3";
            this.lista_produtos_3.Size = new System.Drawing.Size(133, 21);
            this.lista_produtos_3.TabIndex = 1;
            // 
            // lista_produtos_2
            // 
            this.lista_produtos_2.FormattingEnabled = true;
            this.lista_produtos_2.Location = new System.Drawing.Point(148, 134);
            this.lista_produtos_2.Name = "lista_produtos_2";
            this.lista_produtos_2.Size = new System.Drawing.Size(121, 21);
            this.lista_produtos_2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(75, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "Produto:";
            // 
            // lista_produtos_1
            // 
            this.lista_produtos_1.FormattingEnabled = true;
            this.lista_produtos_1.Location = new System.Drawing.Point(148, 23);
            this.lista_produtos_1.Name = "lista_produtos_1";
            this.lista_produtos_1.Size = new System.Drawing.Size(121, 21);
            this.lista_produtos_1.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(75, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 22);
            this.label3.TabIndex = 4;
            this.label3.Text = "Produto:";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(421, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(165, 22);
            this.label4.TabIndex = 6;
            this.label4.Text = "Demanda do produto 1:";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(421, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(165, 22);
            this.label5.TabIndex = 8;
            this.label5.Text = "Demanda do produto 2:";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(421, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(165, 22);
            this.label6.TabIndex = 9;
            this.label6.Text = "Demanda do produto 3:";
            // 
            // textBoxDemanda1
            // 
            this.textBoxDemanda1.Location = new System.Drawing.Point(600, 57);
            this.textBoxDemanda1.Name = "textBoxDemanda1";
            this.textBoxDemanda1.Size = new System.Drawing.Size(59, 20);
            this.textBoxDemanda1.TabIndex = 10;
            // 
            // textBoxDemanda2
            // 
            this.textBoxDemanda2.Location = new System.Drawing.Point(600, 97);
            this.textBoxDemanda2.Name = "textBoxDemanda2";
            this.textBoxDemanda2.Size = new System.Drawing.Size(59, 20);
            this.textBoxDemanda2.TabIndex = 11;
            // 
            // textBoxDemanda3
            // 
            this.textBoxDemanda3.Location = new System.Drawing.Point(600, 134);
            this.textBoxDemanda3.Name = "textBoxDemanda3";
            this.textBoxDemanda3.Size = new System.Drawing.Size(59, 20);
            this.textBoxDemanda3.TabIndex = 12;
            // 
            // processarDemanda
            // 
            this.processarDemanda.Location = new System.Drawing.Point(695, 94);
            this.processarDemanda.Name = "processarDemanda";
            this.processarDemanda.Size = new System.Drawing.Size(79, 22);
            this.processarDemanda.TabIndex = 13;
            this.processarDemanda.Text = "Processar";
            this.processarDemanda.UseVisualStyleBackColor = true;
            this.processarDemanda.Click += new System.EventHandler(this.ProcessarDemanda_Click);
            // 
            // botaoStatusProducao
            // 
            this.botaoStatusProducao.BackColor = System.Drawing.Color.Transparent;
            this.botaoStatusProducao.ForeColor = System.Drawing.SystemColors.ControlText;
            this.botaoStatusProducao.Location = new System.Drawing.Point(569, 194);
            this.botaoStatusProducao.Name = "botaoStatusProducao";
            this.botaoStatusProducao.Size = new System.Drawing.Size(247, 121);
            this.botaoStatusProducao.TabIndex = 14;
            this.botaoStatusProducao.Text = "Status";
            this.botaoStatusProducao.UseVisualStyleBackColor = false;
            this.botaoStatusProducao.Click += new System.EventHandler(this.BotaoStatusProducao_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // botao_Bit_Produtos
            // 
            this.botao_Bit_Produtos.Location = new System.Drawing.Point(315, 23);
            this.botao_Bit_Produtos.Name = "botao_Bit_Produtos";
            this.botao_Bit_Produtos.Size = new System.Drawing.Size(79, 38);
            this.botao_Bit_Produtos.TabIndex = 15;
            this.botao_Bit_Produtos.Text = "Processar Alterações";
            this.botao_Bit_Produtos.UseVisualStyleBackColor = true;
            this.botao_Bit_Produtos.Click += new System.EventHandler(this.Botao_Bit_Produtos_Click);
            // 
            // botao_Ligar
            // 
            this.botao_Ligar.Location = new System.Drawing.Point(315, 78);
            this.botao_Ligar.Name = "botao_Ligar";
            this.botao_Ligar.Size = new System.Drawing.Size(79, 27);
            this.botao_Ligar.TabIndex = 16;
            this.botao_Ligar.Text = "Ligar";
            this.botao_Ligar.UseVisualStyleBackColor = true;
            this.botao_Ligar.Click += new System.EventHandler(this.Botao_Ligar_Click);
            // 
            // botao_desligar
            // 
            this.botao_desligar.Location = new System.Drawing.Point(315, 127);
            this.botao_desligar.Name = "botao_desligar";
            this.botao_desligar.Size = new System.Drawing.Size(79, 27);
            this.botao_desligar.TabIndex = 17;
            this.botao_desligar.Text = "Desligar";
            this.botao_desligar.UseVisualStyleBackColor = true;
            this.botao_desligar.Click += new System.EventHandler(this.Botao_desligar_Click);
            // 
            // timer2
            // 
            this.timer2.Interval = 60000;
            this.timer2.Tick += new System.EventHandler(this.Timer2_Tick);
            // 
            // TelaDeControle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Supervisoria___tcc.Properties.Resources.Capturar1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(948, 402);
            this.Controls.Add(this.botao_desligar);
            this.Controls.Add(this.botao_Ligar);
            this.Controls.Add(this.botao_Bit_Produtos);
            this.Controls.Add(this.processarDemanda);
            this.Controls.Add(this.textBoxDemanda3);
            this.Controls.Add(this.textBoxDemanda2);
            this.Controls.Add(this.textBoxDemanda1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lista_produtos_1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lista_produtos_2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lista_produtos_3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.botaoStatusProducao);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "TelaDeControle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.TelaDeControle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox lista_produtos_3;
        private System.Windows.Forms.ComboBox lista_produtos_2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox lista_produtos_1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxDemanda1;
        private System.Windows.Forms.TextBox textBoxDemanda2;
        private System.Windows.Forms.TextBox textBoxDemanda3;
        private System.Windows.Forms.Button processarDemanda;
        private System.Windows.Forms.Button botaoStatusProducao;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button botao_Bit_Produtos;
        private System.Windows.Forms.Button botao_Ligar;
        private System.Windows.Forms.Button botao_desligar;
        private System.Windows.Forms.Timer timer2;
    }
}