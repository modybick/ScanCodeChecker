using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScancodeChecker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll", EntryPoint = "MapVirtualKeyA")]
        private extern static int MapVirtualKey(int wCode, int wMapType);

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            textBox1.Text = e.KeyCode.ToString();
            textBox2.Text = String.Format("{0:X4}", MapVirtualKey(e.KeyValue, 0));
        }
    }
}
