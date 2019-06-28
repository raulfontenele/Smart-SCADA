namespace Supervisoria___tcc
{
    partial class Tela_Cadastro
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
            this.botaoCriarUsuario = new System.Windows.Forms.Button();
            this.caixaUsuario = new System.Windows.Forms.TextBox();
            this.caixaSenha = new System.Windows.Forms.TextBox();
            this.caixaConfSenha = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.caixaNiveis = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.botaoVoltar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // botaoCriarUsuario
            // 
            this.botaoCriarUsuario.Cursor = System.Windows.Forms.Cursors.No;
            this.botaoCriarUsuario.Location = new System.Drawing.Point(172, 299);
            this.botaoCriarUsuario.Name = "botaoCriarUsuario";
            this.botaoCriarUsuario.Size = new System.Drawing.Size(100, 25);
            this.botaoCriarUsuario.TabIndex = 0;
            this.botaoCriarUsuario.Text = "Casdastrar";
            this.botaoCriarUsuario.UseVisualStyleBackColor = true;
            this.botaoCriarUsuario.Click += new System.EventHandler(this.BotaoCriarUsuario_Click);
            // 
            // caixaUsuario
            // 
            this.caixaUsuario.Location = new System.Drawing.Point(127, 66);
            this.caixaUsuario.Name = "caixaUsuario";
            this.caixaUsuario.Size = new System.Drawing.Size(100, 20);
            this.caixaUsuario.TabIndex = 1;
            // 
            // caixaSenha
            // 
            this.caixaSenha.Location = new System.Drawing.Point(127, 127);
            this.caixaSenha.Name = "caixaSenha";
            this.caixaSenha.Size = new System.Drawing.Size(100, 20);
            this.caixaSenha.TabIndex = 2;
            this.caixaSenha.UseSystemPasswordChar = true;
            // 
            // caixaConfSenha
            // 
            this.caixaConfSenha.Location = new System.Drawing.Point(127, 190);
            this.caixaConfSenha.Name = "caixaConfSenha";
            this.caixaConfSenha.Size = new System.Drawing.Size(100, 20);
            this.caixaConfSenha.TabIndex = 3;
            this.caixaConfSenha.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nome:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Senha";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 197);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Confirmar a senha";
            // 
            // caixaNiveis
            // 
            this.caixaNiveis.AccessibleRole = System.Windows.Forms.AccessibleRole.ListItem;
            this.caixaNiveis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.caixaNiveis.FormattingEnabled = true;
            this.caixaNiveis.Location = new System.Drawing.Point(117, 247);
            this.caixaNiveis.Name = "caixaNiveis";
            this.caixaNiveis.Size = new System.Drawing.Size(121, 21);
            this.caixaNiveis.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 250);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Nível de acesso:";
            // 
            // botaoVoltar
            // 
            this.botaoVoltar.Cursor = System.Windows.Forms.Cursors.No;
            this.botaoVoltar.Location = new System.Drawing.Point(15, 299);
            this.botaoVoltar.Name = "botaoVoltar";
            this.botaoVoltar.Size = new System.Drawing.Size(100, 25);
            this.botaoVoltar.TabIndex = 9;
            this.botaoVoltar.Text = "Voltar";
            this.botaoVoltar.UseVisualStyleBackColor = true;
            this.botaoVoltar.Click += new System.EventHandler(this.BotaoVoltar_Click);
            // 
            // Tela_Cadastro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.botaoVoltar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.caixaNiveis);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.caixaConfSenha);
            this.Controls.Add(this.caixaSenha);
            this.Controls.Add(this.caixaUsuario);
            this.Controls.Add(this.botaoCriarUsuario);
            this.Name = "Tela_Cadastro";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button botaoCriarUsuario;
        private System.Windows.Forms.TextBox caixaUsuario;
        private System.Windows.Forms.TextBox caixaSenha;
        private System.Windows.Forms.TextBox caixaConfSenha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox caixaNiveis;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button botaoVoltar;
    }
}