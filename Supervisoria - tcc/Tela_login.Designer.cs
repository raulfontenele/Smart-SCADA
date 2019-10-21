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
            this.botao_Voltar = new System.Windows.Forms.Button();
            this.Label_nome = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // caixaUsuario
            // 
            this.caixaUsuario.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.caixaUsuario.Location = new System.Drawing.Point(157, 97);
            this.caixaUsuario.Name = "caixaUsuario";
            this.caixaUsuario.Size = new System.Drawing.Size(100, 20);
            this.caixaUsuario.TabIndex = 0;
            // 
            // caixaSenha
            // 
            this.caixaSenha.Location = new System.Drawing.Point(157, 152);
            this.caixaSenha.Name = "caixaSenha";
            this.caixaSenha.Size = new System.Drawing.Size(100, 20);
            this.caixaSenha.TabIndex = 1;
            this.caixaSenha.UseSystemPasswordChar = true;
            // 
            // botaoEntrar
            // 
            this.botaoEntrar.BackColor = System.Drawing.Color.LightGray;
            this.botaoEntrar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botaoEntrar.Location = new System.Drawing.Point(112, 209);
            this.botaoEntrar.Name = "botaoEntrar";
            this.botaoEntrar.Size = new System.Drawing.Size(145, 53);
            this.botaoEntrar.TabIndex = 2;
            this.botaoEntrar.TabStop = false;
            this.botaoEntrar.Text = "Entrar";
            this.botaoEntrar.UseVisualStyleBackColor = false;
            this.botaoEntrar.Click += new System.EventHandler(this.BotaoEntrar_Click);
            // 
            // botaoCadastro
            // 
            this.botaoCadastro.BackColor = System.Drawing.Color.LightGray;
            this.botaoCadastro.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botaoCadastro.Location = new System.Drawing.Point(112, 278);
            this.botaoCadastro.Name = "botaoCadastro";
            this.botaoCadastro.Size = new System.Drawing.Size(145, 57);
            this.botaoCadastro.TabIndex = 3;
            this.botaoCadastro.Text = "Cadastrar ";
            this.botaoCadastro.UseVisualStyleBackColor = false;
            this.botaoCadastro.Click += new System.EventHandler(this.BotaoCadastro_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(98, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Login:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(98, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Senha:";
            // 
            // botao_Voltar
            // 
            this.botao_Voltar.BackColor = System.Drawing.Color.LightGray;
            this.botao_Voltar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botao_Voltar.Location = new System.Drawing.Point(112, 345);
            this.botao_Voltar.Name = "botao_Voltar";
            this.botao_Voltar.Size = new System.Drawing.Size(145, 57);
            this.botao_Voltar.TabIndex = 6;
            this.botao_Voltar.Text = "Voltar";
            this.botao_Voltar.UseVisualStyleBackColor = false;
            this.botao_Voltar.Click += new System.EventHandler(this.Botao_Voltar_Click);
            // 
            // Label_nome
            // 
            this.Label_nome.AutoSize = true;
            this.Label_nome.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_nome.Location = new System.Drawing.Point(95, 26);
            this.Label_nome.Name = "Label_nome";
            this.Label_nome.Size = new System.Drawing.Size(198, 32);
            this.Label_nome.TabIndex = 7;
            this.Label_nome.Text = "Smart SCADA";
            this.Label_nome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Tela_login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 414);
            this.Controls.Add(this.Label_nome);
            this.Controls.Add(this.botao_Voltar);
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
        private System.Windows.Forms.Button botao_Voltar;
        private System.Windows.Forms.Label Label_nome;
    }
}

