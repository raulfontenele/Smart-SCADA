namespace Supervisoria___tcc
{
    partial class Tela_login
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

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.caixaUsuario = new System.Windows.Forms.TextBox();
            this.caixaSenha = new System.Windows.Forms.TextBox();
            this.botaoEntrar = new System.Windows.Forms.Button();
            this.botaoCadastro = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // caixaUsuario
            // 
            this.caixaUsuario.Location = new System.Drawing.Point(232, 50);
            this.caixaUsuario.Name = "caixaUsuario";
            this.caixaUsuario.Size = new System.Drawing.Size(100, 20);
            this.caixaUsuario.TabIndex = 0;
            // 
            // caixaSenha
            // 
            this.caixaSenha.Location = new System.Drawing.Point(232, 152);
            this.caixaSenha.Name = "caixaSenha";
            this.caixaSenha.Size = new System.Drawing.Size(100, 20);
            this.caixaSenha.TabIndex = 1;
            this.caixaSenha.UseSystemPasswordChar = true;
            // 
            // botaoEntrar
            // 
            this.botaoEntrar.Location = new System.Drawing.Point(232, 249);
            this.botaoEntrar.Name = "botaoEntrar";
            this.botaoEntrar.Size = new System.Drawing.Size(75, 23);
            this.botaoEntrar.TabIndex = 2;
            this.botaoEntrar.Text = "Entrar";
            this.botaoEntrar.UseVisualStyleBackColor = true;
            this.botaoEntrar.Click += new System.EventHandler(this.BotaoEntrar_Click);
            // 
            // botaoCadastro
            // 
            this.botaoCadastro.Location = new System.Drawing.Point(350, 249);
            this.botaoCadastro.Name = "botaoCadastro";
            this.botaoCadastro.Size = new System.Drawing.Size(75, 23);
            this.botaoCadastro.TabIndex = 3;
            this.botaoCadastro.Text = "Cadastrar ";
            this.botaoCadastro.UseVisualStyleBackColor = true;
            this.botaoCadastro.Click += new System.EventHandler(this.BotaoCadastro_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(156, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Login:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(165, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Senha:";
            // 
            // Tela_login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.botaoCadastro);
            this.Controls.Add(this.botaoEntrar);
            this.Controls.Add(this.caixaSenha);
            this.Controls.Add(this.caixaUsuario);
            this.Name = "Tela_login";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox caixaUsuario;
        private System.Windows.Forms.TextBox caixaSenha;
        private System.Windows.Forms.Button botaoEntrar;
        private System.Windows.Forms.Button botaoCadastro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

