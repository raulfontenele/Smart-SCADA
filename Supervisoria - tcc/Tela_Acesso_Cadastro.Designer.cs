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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tela_Acesso_Cadastro));
            this.caiaxaUsuario = new System.Windows.Forms.TextBox();
            this.caixaSenha = new System.Windows.Forms.TextBox();
            this.botaoConfirmar = new System.Windows.Forms.Button();
            this.botaoVoltar = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label_confirmacao = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // caiaxaUsuario
            // 
            this.caiaxaUsuario.Location = new System.Drawing.Point(120, 66);
            this.caiaxaUsuario.Name = "caiaxaUsuario";
            this.caiaxaUsuario.Size = new System.Drawing.Size(110, 20);
            this.caiaxaUsuario.TabIndex = 0;
            // 
            // caixaSenha
            // 
            this.caixaSenha.Location = new System.Drawing.Point(120, 115);
            this.caixaSenha.Name = "caixaSenha";
            this.caixaSenha.PasswordChar = '*';
            this.caixaSenha.Size = new System.Drawing.Size(110, 20);
            this.caixaSenha.TabIndex = 1;
            this.caixaSenha.UseSystemPasswordChar = true;
            // 
            // botaoConfirmar
            // 
            this.botaoConfirmar.BackColor = System.Drawing.Color.CornflowerBlue;
            this.botaoConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botaoConfirmar.Location = new System.Drawing.Point(97, 178);
            this.botaoConfirmar.Name = "botaoConfirmar";
            this.botaoConfirmar.Size = new System.Drawing.Size(133, 50);
            this.botaoConfirmar.TabIndex = 2;
            this.botaoConfirmar.Text = "Confirmar";
            this.botaoConfirmar.UseVisualStyleBackColor = false;
            this.botaoConfirmar.Click += new System.EventHandler(this.BotaoConfirmar_Click);
            // 
            // botaoVoltar
            // 
            this.botaoVoltar.BackColor = System.Drawing.Color.CornflowerBlue;
            this.botaoVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botaoVoltar.Location = new System.Drawing.Point(97, 258);
            this.botaoVoltar.Name = "botaoVoltar";
            this.botaoVoltar.Size = new System.Drawing.Size(133, 50);
            this.botaoVoltar.TabIndex = 3;
            this.botaoVoltar.Text = "Voltar";
            this.botaoVoltar.UseVisualStyleBackColor = false;
            this.botaoVoltar.Click += new System.EventHandler(this.BotaoVoltar_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(97, 115);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(17, 20);
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(97, 66);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(17, 20);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // label_confirmacao
            // 
            this.label_confirmacao.AutoSize = true;
            this.label_confirmacao.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_confirmacao.Location = new System.Drawing.Point(38, 25);
            this.label_confirmacao.Name = "label_confirmacao";
            this.label_confirmacao.Size = new System.Drawing.Size(251, 24);
            this.label_confirmacao.TabIndex = 12;
            this.label_confirmacao.Text = "Confirmação de Acesso";
            // 
            // Tela_Acesso_Cadastro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(326, 450);
            this.ControlBox = false;
            this.Controls.Add(this.label_confirmacao);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.botaoVoltar);
            this.Controls.Add(this.botaoConfirmar);
            this.Controls.Add(this.caixaSenha);
            this.Controls.Add(this.caiaxaUsuario);
            this.Name = "Tela_Acesso_Cadastro";
            this.Text = "                                     Tela de verificação";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox caiaxaUsuario;
        private System.Windows.Forms.TextBox caixaSenha;
        private System.Windows.Forms.Button botaoConfirmar;
        private System.Windows.Forms.Button botaoVoltar;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label_confirmacao;
    }
}