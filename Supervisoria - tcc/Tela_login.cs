﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supervisoria___tcc
{
    public partial class Tela_login : Form
    {
        public Tela_login()
        {
            InitializeComponent();
            Auxiliar.iniciarControleAcesso();
        }

        private void BotaoCadastro_Click(object sender, EventArgs e)
        {
            Tela_Acesso_Cadastro TelaAcessoCadastro = new Tela_Acesso_Cadastro();
            TelaAcessoCadastro.ShowDialog();
        }
    }
}