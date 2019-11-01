namespace Supervisoria___tcc
{
    partial class TelaProducao
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.caixaProducaoProduto1 = new System.Windows.Forms.TextBox();
            this.caixaProducaoProduto2 = new System.Windows.Forms.TextBox();
            this.caixaProducaoProduto3 = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.botao_voltar = new System.Windows.Forms.Button();
            this.botao_historico = new System.Windows.Forms.Button();
            this.textBoxDemanda3 = new System.Windows.Forms.TextBox();
            this.textBoxDemanda2 = new System.Windows.Forms.TextBox();
            this.textBoxDemanda1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label_time = new System.Windows.Forms.Label();
            this.timerSegundos = new System.Windows.Forms.Timer(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Produção do produto 1:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Produção do produto 2:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 213);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(170, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Produção do produto 3:";
            // 
            // caixaProducaoProduto1
            // 
            this.caixaProducaoProduto1.Location = new System.Drawing.Point(199, 91);
            this.caixaProducaoProduto1.Name = "caixaProducaoProduto1";
            this.caixaProducaoProduto1.Size = new System.Drawing.Size(100, 20);
            this.caixaProducaoProduto1.TabIndex = 3;
            // 
            // caixaProducaoProduto2
            // 
            this.caixaProducaoProduto2.Location = new System.Drawing.Point(199, 152);
            this.caixaProducaoProduto2.Name = "caixaProducaoProduto2";
            this.caixaProducaoProduto2.Size = new System.Drawing.Size(100, 20);
            this.caixaProducaoProduto2.TabIndex = 4;
            // 
            // caixaProducaoProduto3
            // 
            this.caixaProducaoProduto3.Location = new System.Drawing.Point(199, 213);
            this.caixaProducaoProduto3.Name = "caixaProducaoProduto3";
            this.caixaProducaoProduto3.Size = new System.Drawing.Size(100, 20);
            this.caixaProducaoProduto3.TabIndex = 5;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // botao_voltar
            // 
            this.botao_voltar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CornflowerBlue;
            this.botao_voltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botao_voltar.Location = new System.Drawing.Point(69, 286);
            this.botao_voltar.Name = "botao_voltar";
            this.botao_voltar.Size = new System.Drawing.Size(109, 52);
            this.botao_voltar.TabIndex = 6;
            this.botao_voltar.Text = "Voltar";
            this.botao_voltar.UseVisualStyleBackColor = true;
            this.botao_voltar.Click += new System.EventHandler(this.Botao_voltar_Click);
            // 
            // botao_historico
            // 
            this.botao_historico.Location = new System.Drawing.Point(69, 372);
            this.botao_historico.Name = "botao_historico";
            this.botao_historico.Size = new System.Drawing.Size(87, 33);
            this.botao_historico.TabIndex = 7;
            this.botao_historico.Text = "Histórico";
            this.botao_historico.UseVisualStyleBackColor = true;
            this.botao_historico.Click += new System.EventHandler(this.Botao_historico_Click);
            // 
            // textBoxDemanda3
            // 
            this.textBoxDemanda3.Location = new System.Drawing.Point(541, 213);
            this.textBoxDemanda3.Name = "textBoxDemanda3";
            this.textBoxDemanda3.Size = new System.Drawing.Size(100, 20);
            this.textBoxDemanda3.TabIndex = 13;
            // 
            // textBoxDemanda2
            // 
            this.textBoxDemanda2.Location = new System.Drawing.Point(541, 149);
            this.textBoxDemanda2.Name = "textBoxDemanda2";
            this.textBoxDemanda2.Size = new System.Drawing.Size(100, 20);
            this.textBoxDemanda2.TabIndex = 12;
            // 
            // textBoxDemanda1
            // 
            this.textBoxDemanda1.Location = new System.Drawing.Point(541, 91);
            this.textBoxDemanda1.Name = "textBoxDemanda1";
            this.textBoxDemanda1.Size = new System.Drawing.Size(100, 20);
            this.textBoxDemanda1.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(365, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(170, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Demanda do produto 3:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(365, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(170, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Demanda do produto 2:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(365, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(170, 16);
            this.label6.TabIndex = 8;
            this.label6.Text = "Demanda do produto 1:";
            // 
            // label_time
            // 
            this.label_time.AutoSize = true;
            this.label_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_time.Location = new System.Drawing.Point(447, 299);
            this.label_time.Name = "label_time";
            this.label_time.Size = new System.Drawing.Size(0, 42);
            this.label_time.TabIndex = 14;
            // 
            // timerSegundos
            // 
            this.timerSegundos.Interval = 1000;
            this.timerSegundos.Tick += new System.EventHandler(this.TimerSegundos_Tick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(360, 314);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(175, 24);
            this.label7.TabIndex = 15;
            this.label7.Text = "Tempo restante:";
            // 
            // TelaProducao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(705, 417);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label_time);
            this.Controls.Add(this.textBoxDemanda3);
            this.Controls.Add(this.textBoxDemanda2);
            this.Controls.Add(this.textBoxDemanda1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.botao_historico);
            this.Controls.Add(this.botao_voltar);
            this.Controls.Add(this.caixaProducaoProduto3);
            this.Controls.Add(this.caixaProducaoProduto2);
            this.Controls.Add(this.caixaProducaoProduto1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "TelaProducao";
            this.Text = "TelaProducao";
            this.Load += new System.EventHandler(this.TelaProducao_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox caixaProducaoProduto1;
        private System.Windows.Forms.TextBox caixaProducaoProduto2;
        private System.Windows.Forms.TextBox caixaProducaoProduto3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button botao_voltar;
        private System.Windows.Forms.Button botao_historico;
        private System.Windows.Forms.TextBox textBoxDemanda3;
        private System.Windows.Forms.TextBox textBoxDemanda2;
        private System.Windows.Forms.TextBox textBoxDemanda1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label_time;
        private System.Windows.Forms.Timer timerSegundos;
        private System.Windows.Forms.Label label7;
    }
}