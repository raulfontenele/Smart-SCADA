namespace Supervisoria___tcc
{
    partial class TelaControleCentral
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaControleCentral));
            this.panel1 = new System.Windows.Forms.Panel();
            this.botao_Voltar = new System.Windows.Forms.Button();
            this.botao_Sorteio = new System.Windows.Forms.Button();
            this.botao_Aquisicao = new System.Windows.Forms.Button();
            this.botao_Producao = new System.Windows.Forms.Button();
            this.botao_Historico = new System.Windows.Forms.Button();
            this.botao_Autonoma = new System.Windows.Forms.Button();
            this.botao_Monitoramento = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tela_Autonoma = new Supervisoria___tcc.UCAutonoma();
            this.tela_Aquisicao = new Supervisoria___tcc.UCAquisicao();
            this.tela_Monitoramento = new Supervisoria___tcc.UCMonitoramento();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(76)))), ((int)(((byte)(66)))));
            this.panel1.Controls.Add(this.botao_Voltar);
            this.panel1.Controls.Add(this.botao_Sorteio);
            this.panel1.Controls.Add(this.botao_Aquisicao);
            this.panel1.Controls.Add(this.botao_Producao);
            this.panel1.Controls.Add(this.botao_Historico);
            this.panel1.Controls.Add(this.botao_Autonoma);
            this.panel1.Controls.Add(this.botao_Monitoramento);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(135, 700);
            this.panel1.TabIndex = 0;
            // 
            // botao_Voltar
            // 
            this.botao_Voltar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(167)))), ((int)(((byte)(154)))));
            this.botao_Voltar.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.botao_Voltar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CornflowerBlue;
            this.botao_Voltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botao_Voltar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botao_Voltar.Location = new System.Drawing.Point(0, 628);
            this.botao_Voltar.Margin = new System.Windows.Forms.Padding(0);
            this.botao_Voltar.Name = "botao_Voltar";
            this.botao_Voltar.Size = new System.Drawing.Size(135, 72);
            this.botao_Voltar.TabIndex = 3;
            this.botao_Voltar.Text = "Voltar";
            this.botao_Voltar.UseVisualStyleBackColor = false;
            this.botao_Voltar.Click += new System.EventHandler(this.Botao_Voltar_Click);
            // 
            // botao_Sorteio
            // 
            this.botao_Sorteio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(167)))), ((int)(((byte)(154)))));
            this.botao_Sorteio.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.botao_Sorteio.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CornflowerBlue;
            this.botao_Sorteio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botao_Sorteio.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botao_Sorteio.Location = new System.Drawing.Point(0, 526);
            this.botao_Sorteio.Margin = new System.Windows.Forms.Padding(0);
            this.botao_Sorteio.Name = "botao_Sorteio";
            this.botao_Sorteio.Size = new System.Drawing.Size(135, 72);
            this.botao_Sorteio.TabIndex = 6;
            this.botao_Sorteio.Text = "Sortear Demanda";
            this.botao_Sorteio.UseVisualStyleBackColor = false;
            this.botao_Sorteio.Click += new System.EventHandler(this.Botao_Sorteio_Click);
            // 
            // botao_Aquisicao
            // 
            this.botao_Aquisicao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(167)))), ((int)(((byte)(154)))));
            this.botao_Aquisicao.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.botao_Aquisicao.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CornflowerBlue;
            this.botao_Aquisicao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botao_Aquisicao.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botao_Aquisicao.Location = new System.Drawing.Point(0, 212);
            this.botao_Aquisicao.Margin = new System.Windows.Forms.Padding(0);
            this.botao_Aquisicao.Name = "botao_Aquisicao";
            this.botao_Aquisicao.Size = new System.Drawing.Size(135, 72);
            this.botao_Aquisicao.TabIndex = 5;
            this.botao_Aquisicao.Text = "Tela de Aquisição";
            this.botao_Aquisicao.UseVisualStyleBackColor = false;
            this.botao_Aquisicao.Click += new System.EventHandler(this.Botao_Aquisicao_Click);
            // 
            // botao_Producao
            // 
            this.botao_Producao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(167)))), ((int)(((byte)(154)))));
            this.botao_Producao.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.botao_Producao.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CornflowerBlue;
            this.botao_Producao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botao_Producao.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botao_Producao.Location = new System.Drawing.Point(0, 424);
            this.botao_Producao.Margin = new System.Windows.Forms.Padding(0);
            this.botao_Producao.Name = "botao_Producao";
            this.botao_Producao.Size = new System.Drawing.Size(135, 72);
            this.botao_Producao.TabIndex = 4;
            this.botao_Producao.Text = "Tela de Produção";
            this.botao_Producao.UseVisualStyleBackColor = false;
            this.botao_Producao.Click += new System.EventHandler(this.Botao_Producao_Click);
            // 
            // botao_Historico
            // 
            this.botao_Historico.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(167)))), ((int)(((byte)(154)))));
            this.botao_Historico.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.botao_Historico.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CornflowerBlue;
            this.botao_Historico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botao_Historico.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botao_Historico.Location = new System.Drawing.Point(0, 318);
            this.botao_Historico.Margin = new System.Windows.Forms.Padding(0);
            this.botao_Historico.Name = "botao_Historico";
            this.botao_Historico.Size = new System.Drawing.Size(135, 72);
            this.botao_Historico.TabIndex = 2;
            this.botao_Historico.Text = "Tela de Histórico";
            this.botao_Historico.UseVisualStyleBackColor = false;
            this.botao_Historico.Click += new System.EventHandler(this.Botao_Historico_Click);
            // 
            // botao_Autonoma
            // 
            this.botao_Autonoma.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(167)))), ((int)(((byte)(154)))));
            this.botao_Autonoma.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.botao_Autonoma.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CornflowerBlue;
            this.botao_Autonoma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botao_Autonoma.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botao_Autonoma.Location = new System.Drawing.Point(0, 106);
            this.botao_Autonoma.Margin = new System.Windows.Forms.Padding(0);
            this.botao_Autonoma.Name = "botao_Autonoma";
            this.botao_Autonoma.Size = new System.Drawing.Size(135, 72);
            this.botao_Autonoma.TabIndex = 1;
            this.botao_Autonoma.Text = "Tela Autônoma";
            this.botao_Autonoma.UseVisualStyleBackColor = false;
            this.botao_Autonoma.Click += new System.EventHandler(this.Botao_Autonoma_Click);
            // 
            // botao_Monitoramento
            // 
            this.botao_Monitoramento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(167)))), ((int)(((byte)(154)))));
            this.botao_Monitoramento.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.botao_Monitoramento.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CornflowerBlue;
            this.botao_Monitoramento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botao_Monitoramento.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botao_Monitoramento.Location = new System.Drawing.Point(0, 0);
            this.botao_Monitoramento.Margin = new System.Windows.Forms.Padding(0);
            this.botao_Monitoramento.Name = "botao_Monitoramento";
            this.botao_Monitoramento.Size = new System.Drawing.Size(135, 72);
            this.botao_Monitoramento.TabIndex = 0;
            this.botao_Monitoramento.Text = "Tela de Monitoramento";
            this.botao_Monitoramento.UseVisualStyleBackColor = false;
            this.botao_Monitoramento.Click += new System.EventHandler(this.Botao_Monitoramento_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tela_Monitoramento);
            this.panel2.Controls.Add(this.tela_Aquisicao);
            this.panel2.Controls.Add(this.tela_Autonoma);
            this.panel2.Location = new System.Drawing.Point(135, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1204, 700);
            this.panel2.TabIndex = 1;
            // 
            // tela_Autonoma
            // 
            this.tela_Autonoma.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tela_Autonoma.BackgroundImage")));
            this.tela_Autonoma.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tela_Autonoma.Location = new System.Drawing.Point(0, 0);
            this.tela_Autonoma.Name = "tela_Autonoma";
            this.tela_Autonoma.Size = new System.Drawing.Size(1204, 700);
            this.tela_Autonoma.TabIndex = 0;
            this.tela_Autonoma.Load += new System.EventHandler(this.UcAutonoma1_Load);
            // 
            // tela_Aquisicao
            // 
            this.tela_Aquisicao.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tela_Aquisicao.BackgroundImage")));
            this.tela_Aquisicao.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tela_Aquisicao.Location = new System.Drawing.Point(0, 0);
            this.tela_Aquisicao.Margin = new System.Windows.Forms.Padding(0);
            this.tela_Aquisicao.Name = "tela_Aquisicao";
            this.tela_Aquisicao.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tela_Aquisicao.Size = new System.Drawing.Size(1204, 700);
            this.tela_Aquisicao.TabIndex = 1;
            // 
            // tela_Monitoramento
            // 
            this.tela_Monitoramento.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tela_Monitoramento.BackgroundImage")));
            this.tela_Monitoramento.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tela_Monitoramento.Location = new System.Drawing.Point(0, 0);
            this.tela_Monitoramento.Margin = new System.Windows.Forms.Padding(0);
            this.tela_Monitoramento.Name = "tela_Monitoramento";
            this.tela_Monitoramento.Size = new System.Drawing.Size(1204, 700);
            this.tela_Monitoramento.TabIndex = 2;
            // 
            // TelaControleCentral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1337, 700);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "TelaControleCentral";
            this.Text = "TelaControleCentral";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button botao_Voltar;
        private System.Windows.Forms.Button botao_Historico;
        private System.Windows.Forms.Button botao_Autonoma;
        private System.Windows.Forms.Button botao_Monitoramento;
        private System.Windows.Forms.Button botao_Sorteio;
        private System.Windows.Forms.Button botao_Aquisicao;
        private System.Windows.Forms.Button botao_Producao;
        private UCAutonoma tela_Autonoma;
        private UCAquisicao tela_Aquisicao;
        private UCMonitoramento tela_Monitoramento;
    }
}