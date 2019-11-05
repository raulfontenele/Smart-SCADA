namespace Supervisoria___tcc
{
    partial class TelaAutonoma
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
            this.botao_Treinamento = new System.Windows.Forms.Button();
            this.botao_Status = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.textBoxDemanda1 = new System.Windows.Forms.TextBox();
            this.textBoxDemanda2 = new System.Windows.Forms.TextBox();
            this.textBoxDemanda3 = new System.Windows.Forms.TextBox();
            this.botao_AplicacaoRede = new System.Windows.Forms.Button();
            this.botao_zerar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // botao_Treinamento
            // 
            this.botao_Treinamento.Location = new System.Drawing.Point(291, 54);
            this.botao_Treinamento.Name = "botao_Treinamento";
            this.botao_Treinamento.Size = new System.Drawing.Size(95, 42);
            this.botao_Treinamento.TabIndex = 0;
            this.botao_Treinamento.Text = "Treinar rede";
            this.botao_Treinamento.UseVisualStyleBackColor = true;
            this.botao_Treinamento.Click += new System.EventHandler(this.Botao_Treinamento_Click);
            // 
            // botao_Status
            // 
            this.botao_Status.Location = new System.Drawing.Point(479, 216);
            this.botao_Status.Name = "botao_Status";
            this.botao_Status.Size = new System.Drawing.Size(209, 139);
            this.botao_Status.TabIndex = 1;
            this.botao_Status.Text = "Status";
            this.botao_Status.UseVisualStyleBackColor = true;
            this.botao_Status.Click += new System.EventHandler(this.Botao_Status_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 600000;
            this.timer2.Tick += new System.EventHandler(this.Timer2_Tick);
            // 
            // textBoxDemanda1
            // 
            this.textBoxDemanda1.Location = new System.Drawing.Point(557, 54);
            this.textBoxDemanda1.Name = "textBoxDemanda1";
            this.textBoxDemanda1.Size = new System.Drawing.Size(100, 20);
            this.textBoxDemanda1.TabIndex = 2;
            // 
            // textBoxDemanda2
            // 
            this.textBoxDemanda2.Location = new System.Drawing.Point(557, 99);
            this.textBoxDemanda2.Name = "textBoxDemanda2";
            this.textBoxDemanda2.Size = new System.Drawing.Size(100, 20);
            this.textBoxDemanda2.TabIndex = 3;
            // 
            // textBoxDemanda3
            // 
            this.textBoxDemanda3.Location = new System.Drawing.Point(557, 150);
            this.textBoxDemanda3.Name = "textBoxDemanda3";
            this.textBoxDemanda3.Size = new System.Drawing.Size(100, 20);
            this.textBoxDemanda3.TabIndex = 4;
            // 
            // botao_AplicacaoRede
            // 
            this.botao_AplicacaoRede.Location = new System.Drawing.Point(291, 128);
            this.botao_AplicacaoRede.Name = "botao_AplicacaoRede";
            this.botao_AplicacaoRede.Size = new System.Drawing.Size(95, 42);
            this.botao_AplicacaoRede.TabIndex = 5;
            this.botao_AplicacaoRede.Text = "Aplicar rede";
            this.botao_AplicacaoRede.UseVisualStyleBackColor = true;
            this.botao_AplicacaoRede.Click += new System.EventHandler(this.Botao_AplicacaoRede_Click);
            // 
            // botao_zerar
            // 
            this.botao_zerar.Location = new System.Drawing.Point(291, 190);
            this.botao_zerar.Name = "botao_zerar";
            this.botao_zerar.Size = new System.Drawing.Size(95, 31);
            this.botao_zerar.TabIndex = 6;
            this.botao_zerar.Text = "Zerar";
            this.botao_zerar.UseVisualStyleBackColor = true;
            this.botao_zerar.Click += new System.EventHandler(this.Botao_zerar_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(680, 79);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 27);
            this.button1.TabIndex = 7;
            this.button1.Text = "Processar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // TelaAutonoma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Supervisoria___tcc.Properties.Resources.Capturar1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.botao_zerar);
            this.Controls.Add(this.botao_AplicacaoRede);
            this.Controls.Add(this.textBoxDemanda3);
            this.Controls.Add(this.textBoxDemanda2);
            this.Controls.Add(this.textBoxDemanda1);
            this.Controls.Add(this.botao_Status);
            this.Controls.Add(this.botao_Treinamento);
            this.DoubleBuffered = true;
            this.Name = "TelaAutonoma";
            this.Text = "TelaAutonoma";
            this.Load += new System.EventHandler(this.TelaAutonoma_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button botao_Treinamento;
        private System.Windows.Forms.Button botao_Status;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.TextBox textBoxDemanda1;
        private System.Windows.Forms.TextBox textBoxDemanda2;
        private System.Windows.Forms.TextBox textBoxDemanda3;
        private System.Windows.Forms.Button botao_AplicacaoRede;
        private System.Windows.Forms.Button botao_zerar;
        private System.Windows.Forms.Button button1;
    }
}