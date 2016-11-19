using System;
using System.Runtime.InteropServices;
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

        private void keyboardHook1_KeyboardHooked(object sender, ScanCodeChecker.KeyboardHookedEventArgs e)
        {
            if (this.Focused == true)
            {
                textBox1.Text = e.KeyCode.ToString();
                textBox2.Text = String.Format("{0:X4}", MapVirtualKey(e.KeyCode.GetHashCode(), 0));
                e.Cancel = true;
            }

        }
    }
}
