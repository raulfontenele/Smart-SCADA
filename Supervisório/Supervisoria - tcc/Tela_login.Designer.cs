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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tela_login));
            this.caixaUsuario = new System.Windows.Forms.TextBox();
            this.caixaSenha = new System.Windows.Forms.TextBox();
            this.botaoEntrar = new System.Windows.Forms.Button();
            this.botaoCadastro = new System.Windows.Forms.Button();
            this.botao_Voltar = new System.Windows.Forms.Button();
            this.Label_nome = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // caixaUsuario
            // 
            this.caixaUsuario.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.caixaUsuario.Location = new System.Drawing.Point(135, 87);
            this.caixaUsuario.Multiline = true;
            this.caixaUsuario.Name = "caixaUsuario";
            this.caixaUsuario.Size = new System.Drawing.Size(122, 20);
            this.caixaUsuario.TabIndex = 0;
            // 
            // caixaSenha
            // 
            this.caixaSenha.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.caixaSenha.Location = new System.Drawing.Point(135, 135);
            this.caixaSenha.Multiline = true;
            this.caixaSenha.Name = "caixaSenha";
            this.caixaSenha.PasswordChar = '*';
            this.caixaSenha.Size = new System.Drawing.Size(122, 20);
            this.caixaSenha.TabIndex = 1;
            // 
            // botaoEntrar
            // 
            this.botaoEntrar.BackColor = System.Drawing.Color.CornflowerBlue;
            this.botaoEntrar.FlatAppearance.BorderSize = 0;
            this.botaoEntrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.botaoEntrar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botaoEntrar.Location = new System.Drawing.Point(112, 214);
            this.botaoEntrar.Name = "botaoEntrar";
            this.botaoEntrar.Size = new System.Drawing.Size(145, 57);
            this.botaoEntrar.TabIndex = 2;
            this.botaoEntrar.TabStop = false;
            this.botaoEntrar.Text = "Entrar";
            this.botaoEntrar.UseVisualStyleBackColor = false;
            this.botaoEntrar.Click += new System.EventHandler(this.BotaoEntrar_Click);
            // 
            // botaoCadastro
            // 
            this.botaoCadastro.BackColor = System.Drawing.Color.CornflowerBlue;
            this.botaoCadastro.FlatAppearance.BorderSize = 0;
            this.botaoCadastro.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botaoCadastro.Location = new System.Drawing.Point(112, 277);
            this.botaoCadastro.Name = "botaoCadastro";
            this.botaoCadastro.Size = new System.Drawing.Size(145, 57);
            this.botaoCadastro.TabIndex = 3;
            this.botaoCadastro.Text = "Cadastrar ";
            this.botaoCadastro.UseVisualStyleBackColor = false;
            this.botaoCadastro.Click += new System.EventHandler(this.BotaoCadastro_Click);
            // 
            // botao_Voltar
            // 
            this.botao_Voltar.BackColor = System.Drawing.Color.CornflowerBlue;
            this.botao_Voltar.FlatAppearance.BorderSize = 0;
            this.botao_Voltar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botao_Voltar.Location = new System.Drawing.Point(112, 345);
            this.botao_Voltar.Name = "botao_Voltar";
            this.botao_Voltar.Size = new System.Drawing.Size(145, 57);
            this.botao_Voltar.TabIndex = 6;
            this.botao_Voltar.Text = "Sair";
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
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(112, 87);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(17, 20);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(112, 135);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(17, 20);
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // Tela_login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(384, 441);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Label_nome);
            this.Controls.Add(this.botao_Voltar);
            this.Controls.Add(this.botaoCadastro);
            this.Controls.Add(this.botaoEntrar);
            this.Controls.Add(this.caixaSenha);
            this.Controls.Add(this.caixaUsuario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Tela_login";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "                                           SMART SCADA TCC";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox caixaUsuario;
        private System.Windows.Forms.TextBox caixaSenha;
        private System.Windows.Forms.Button botaoEntrar;
        private System.Windows.Forms.Button botaoCadastro;
        private System.Windows.Forms.Button botao_Voltar;
        private System.Windows.Forms.Label Label_nome;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

