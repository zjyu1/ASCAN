using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ascan
{
    public partial class FormBoot : Form
    {
        static FormBoot instance;
        Bitmap bitmap;
        Font font;
        Graphics g;
        static public string showInfo = "程序加载中，请稍后...";

        private static System.Timers.Timer timer = new System.Timers.Timer(100);
        private delegate void updateDelegate();
        private updateDelegate updateCallBack;
        public static FormBoot Instance
        {
            get
            {
                return instance;
            }
            set
            {
                instance = value;
            }
        }

        public FormBoot()
        {
            InitializeComponent();
            progressBar.Minimum = 0;
            progressBar.Maximum = 100;
            //timer.Elapsed += new System.Timers.ElapsedEventHandler(UpdateLabel);

            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.CenterScreen;
            ShowInTaskbar = false;
            bitmap = new Bitmap(Properties.Resources.banner0619_1);
            ClientSize = bitmap.Size;
            labelInfo.BackColor = Color.Transparent;
            BackgroundImage = bitmap;
        }

        //private void UpdateLabel(object sender, System.Timers.ElapsedEventArgs e)
        //{
        //    if (updateCallBack == null)
        //        updateCallBack = new updateDelegate(updateinfo);
        //    this.BeginInvoke(updateCallBack);
        //}

        public void updateinfo(int per)
        {
            labelInfo.Text = showInfo;
            progressBar.Value = per;
            //labelInfo.Refresh();
            //labelInfo.Update();
            Application.DoEvents();

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                if (bitmap != null)
                {
                    bitmap.Dispose();
                    bitmap = null;
                }
                components.Dispose();
            }
            base.Dispose(disposing);

            timer.Enabled = false;
        }
        public static void ShowSplashScreen()
        {
            instance = new FormBoot();
            instance.Show();
            //instance.panel1.Refresh();
            //timer.Enabled = true;
        }
    }
}
