namespace Supervisoria___tcc
{
    partial class TelaEscolhas
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
            this.botao_Tela_Controle = new System.Windows.Forms.Button();
            this.botao_Tela_Autonoma = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // botao_Tela_Controle
            // 
            this.botao_Tela_Controle.Location = new System.Drawing.Point(311, 109);
            this.botao_Tela_Controle.Name = "botao_Tela_Controle";
            this.botao_Tela_Controle.Size = new System.Drawing.Size(137, 23);
            this.botao_Tela_Controle.TabIndex = 0;
            this.botao_Tela_Controle.Text = "Tela de treino";
            this.botao_Tela_Controle.UseVisualStyleBackColor = true;
            this.botao_Tela_Controle.Click += new System.EventHandler(this.Botao_Tela_Controle_Click);
            // 
            // botao_Tela_Autonoma
            // 
            this.botao_Tela_Autonoma.Location = new System.Drawing.Point(311, 187);
            this.botao_Tela_Autonoma.Name = "botao_Tela_Autonoma";
            this.botao_Tela_Autonoma.Size = new System.Drawing.Size(137, 32);
            this.botao_Tela_Autonoma.TabIndex = 1;
            this.botao_Tela_Autonoma.Text = "Tela autônoma";
            this.botao_Tela_Autonoma.UseVisualStyleBackColor = true;
            this.botao_Tela_Autonoma.Click += new System.EventHandler(this.Botao_Tela_Autonoma_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(311, 259);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(137, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Voltar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // TelaEscolhas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.botao_Tela_Autonoma);
            this.Controls.Add(this.botao_Tela_Controle);
            this.Name = "TelaEscolhas";
            this.Text = "TelaEscolhas";
            this.Load += new System.EventHandler(this.TelaEscolhas_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button botao_Tela_Controle;
        private System.Windows.Forms.Button botao_Tela_Autonoma;
        private System.Windows.Forms.Button button3;
    }
}