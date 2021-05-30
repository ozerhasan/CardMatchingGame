using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardMatchingGame
{
    public partial class MainPage : Form
    {
        public static string name;
        public MainPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Level2 level2 = new Level2();
            level2.Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Level3 level3 = new Level3();
            level3.Show();
            Hide();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            name = nameTxt.Text;
            panel1.Visible = true;
            panel1.Enabled = true;

        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            panel1.Enabled = false;
        }
    }
}
