﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCafe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripQuanLy_Click(object sender, EventArgs e)
        {

        }

        private void đăngNhậpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form dangnhap = new Login();
            dangnhap.MdiParent = this;
            dangnhap.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AdminControl dangnhap = new AdminControl();
            dangnhap.MdiParent = this;
            dangnhap.Show();
        }
    }
}
