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
            this.botaoCriarUsuario.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CornflowerBlue;
            this.botaoCriarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botaoCriarUsuario.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botaoCriarUsuario.Location = new System.Drawing.Point(174, 317);
            this.botaoCriarUsuario.Name = "botaoCriarUsuario";
            this.botaoCriarUsuario.Size = new System.Drawing.Size(128, 56);
            this.botaoCriarUsuario.TabIndex = 0;
            this.botaoCriarUsuario.Text = "Casdastrar";
            this.botaoCriarUsuario.UseVisualStyleBackColor = true;
            this.botaoCriarUsuario.Click += new System.EventHandler(this.BotaoCriarUsuario_Click);
            // 
            // caixaUsuario
            // 
            this.caixaUsuario.Location = new System.Drawing.Point(21, 63);
            this.caixaUsuario.Name = "caixaUsuario";
            this.caixaUsuario.Size = new System.Drawing.Size(270, 20);
            this.caixaUsuario.TabIndex = 1;
            // 
            // caixaSenha
            // 
            this.caixaSenha.Location = new System.Drawing.Point(21, 131);
            this.caixaSenha.Name = "caixaSenha";
            this.caixaSenha.Size = new System.Drawing.Size(270, 20);
            this.caixaSenha.TabIndex = 2;
            this.caixaSenha.UseSystemPasswordChar = true;
            // 
            // caixaConfSenha
            // 
            this.caixaConfSenha.Location = new System.Drawing.Point(21, 186);
            this.caixaConfSenha.Name = "caixaConfSenha";
            this.caixaConfSenha.Size = new System.Drawing.Size(270, 20);
            this.caixaConfSenha.TabIndex = 3;
            this.caixaConfSenha.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nome:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Senha:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Confirmar a senha:";
            // 
            // caixaNiveis
            // 
            this.caixaNiveis.AccessibleRole = System.Windows.Forms.AccessibleRole.ListItem;
            this.caixaNiveis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.caixaNiveis.FormattingEnabled = true;
            this.caixaNiveis.Location = new System.Drawing.Point(21, 265);
            this.caixaNiveis.Name = "caixaNiveis";
            this.caixaNiveis.Size = new System.Drawing.Size(128, 21);
            this.caixaNiveis.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(18, 233);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Nível de acesso:";
            // 
            // botaoVoltar
            // 
            this.botaoVoltar.Cursor = System.Windows.Forms.Cursors.No;
            this.botaoVoltar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CornflowerBlue;
            this.botaoVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botaoVoltar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botaoVoltar.Location = new System.Drawing.Point(21, 317);
            this.botaoVoltar.Name = "botaoVoltar";
            this.botaoVoltar.Size = new System.Drawing.Size(128, 56);
            this.botaoVoltar.TabIndex = 9;
            this.botaoVoltar.Text = "Voltar";
            this.botaoVoltar.UseVisualStyleBackColor = true;
            this.botaoVoltar.Click += new System.EventHandler(this.BotaoVoltar_Click);
            // 
            // Tela_Cadastro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(337, 450);
            this.ControlBox = false;
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Tela_Cadastro";
            this.Text = "Formulário de cadastro";
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