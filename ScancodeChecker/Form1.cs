﻿using System;
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

        //仮想キーコードからスキャンコードに変換するためのAPI
        [DllImport("user32.dll", EntryPoint = "MapVirtualKeyA")]
        private extern static int MapVirtualKey(int wCode, int wMapType);

        //キーボード入力をグローバルフックしたときに発生するイベント
        private void keyboardHook1_KeyboardHooked(object sender, ScanCodeChecker.KeyboardHookedEventArgs e)
        {
            if (Form.ActiveForm == this)
            {   //フォームがアクティブな時だけ
                //textBox1にキーコードを表示
                textBox1.Text = e.KeyCode.ToString();
                //textBox2にスキャンコードを表示（4桁の16進数にフォーマット)
                textBox2.Text = String.Format("{0:X4}", MapVirtualKey(e.KeyCode.GetHashCode(), 0));

                //キー入力の処理をキャンセル
                e.Cancel = true;
            }

        }
    }
}
