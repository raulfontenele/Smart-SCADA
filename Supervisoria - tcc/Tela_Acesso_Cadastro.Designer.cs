namespace Supervisoria___tcc
{
    partial class Tela_Acesso_Cadastro
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
            this.caiaxaUsuario = new System.Windows.Forms.TextBox();
            this.caixaSenha = new System.Windows.Forms.TextBox();
            this.botaoConfirmar = new System.Windows.Forms.Button();
            this.botaoVoltar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // caiaxaUsuario
            // 
            this.caiaxaUsuario.Location = new System.Drawing.Point(201, 72);
            this.caiaxaUsuario.Name = "caiaxaUsuario";
            this.caiaxaUsuario.Size = new System.Drawing.Size(100, 20);
            this.caiaxaUsuario.TabIndex = 0;
            // 
            // caixaSenha
            // 
            this.caixaSenha.Location = new System.Drawing.Point(201, 145);
            this.caixaSenha.Name = "caixaSenha";
            this.caixaSenha.PasswordChar = '*';
            this.caixaSenha.Size = new System.Drawing.Size(100, 20);
            this.caixaSenha.TabIndex = 1;
            this.caixaSenha.UseSystemPasswordChar = true;
            // 
            // botaoConfirmar
            // 
            this.botaoConfirmar.Location = new System.Drawing.Point(301, 236);
            this.botaoConfirmar.Name = "botaoConfirmar";
            this.botaoConfirmar.Size = new System.Drawing.Size(75, 23);
            this.botaoConfirmar.TabIndex = 2;
            this.botaoConfirmar.Text = "Confirmar";
            this.botaoConfirmar.UseVisualStyleBackColor = true;
            this.botaoConfirmar.Click += new System.EventHandler(this.BotaoConfirmar_Click);
            // 
            // botaoVoltar
            // 
            this.botaoVoltar.Location = new System.Drawing.Point(145, 236);
            this.botaoVoltar.Name = "botaoVoltar";
            this.botaoVoltar.Size = new System.Drawing.Size(75, 23);
            this.botaoVoltar.TabIndex = 3;
            this.botaoVoltar.Text = "Voltar";
            this.botaoVoltar.UseVisualStyleBackColor = true;
            this.botaoVoltar.Click += new System.EventHandler(this.BotaoVoltar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(117, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Usuário";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(117, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Senha";
            // 
            // Tela_Acesso_Cadastro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.botaoVoltar);
            this.Controls.Add(this.botaoConfirmar);
            this.Controls.Add(this.caixaSenha);
            this.Controls.Add(this.caiaxaUsuario);
            this.Name = "Tela_Acesso_Cadastro";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox caiaxaUsuario;
        private System.Windows.Forms.TextBox caixaSenha;
        private System.Windows.Forms.Button botaoConfirmar;
        private System.Windows.Forms.Button botaoVoltar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}