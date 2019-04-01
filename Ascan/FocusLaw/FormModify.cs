using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Collections;
using System.IO;

namespace Ascan
{
    public partial class FormModify : Form
    {
        private FormFocus formFocus;
        public double yd = 0;
        public double angled = 0;
        public int method = 0;

        private double[] range = new double[3];
        private Groove groove = new Groove();
        private int cancelflag = 1;
        private int modifyflag = 0;
        public FormModify(FormFocus fromFocus, int flag, Groove gro,int meth)
        {
            InitializeComponent();
            MultiLanguage.getNames(this);

            this.formFocus = fromFocus;
            modifyflag = flag;
            groove = gro;
            method = meth;
            if (modifyflag == 0)
            {
                methodlabel.Visible = false;
                methodbox.Visible = false;
            }
            Yrange.Text = "";
            Anglerange.Text = "";
            if (modifyflag == 0)
            {
                Setrange();
            }
        }

        private void Setrange()
        {
            switch (groove.type)
            {
                case GrooveType.V:
                    SetVgrooveInputRange(method);
                    break;
                case GrooveType.X:
                    SetVgrooveInputRange(method);
                    break;
                case GrooveType.CRC:
                    SetCRCgrooveInputRange(method);
                    break;
                default:
                    MessageShow.show("testblock type error", "坡口类型错误");
                    break;
            }

            Yrange.Location = new Point(300, 65);
            Yrange.Text = range[0] + "<Y<" + range[1];
            if ((groove.type == GrooveType.CRC) && (method == (int)PathMethod.Direct))
            {
                Yrange.Location = new Point(300,61);
                Yrange.Text = range[0] + "<Y<" + range[2] + "\r\n" + range[2] + "<Y<" + range[1];
            }
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (modifyflag == 1)
                {
                    method = Convert.ToInt32((PathMethod)Enum.Parse(typeof(PathMethod), methodbox.Text));
                }

                if (Convert.ToDouble(xtext.Text) > range[0] && Convert.ToDouble(xtext.Text) < range[1])
                {
                    yd = Convert.ToDouble(xtext.Text);
                }
                else
                {
                    MessageShow.show("input out of range", "输入超出范围");
                }

                angled = Convert.ToDouble(angletext.Text);
                cancelflag = 0;
            }
            catch
            {
                MessageShow.show("input error","输入错误");
                return;
            }
        }

        private void SetVgrooveInputRange(int method)
        {
            if (method == (int)PathMethod.Reflect)
            {
                range[0] = 0;
                range[1] = groove.height[0];
                Anglerange.Text = "90";
            }
            else if (method == (int)PathMethod.Direct)
            {
                range[0] = groove.height[0];
                range[1] = groove.height[0] + groove.height[1];
                Anglerange.Text = "70";
            }
            else
            {
                MessageShow.show("input error","输入错误");
            }
        }

        private void SetXgrooveInputRange(int method)
        {
            if (method == (int)PathMethod.Reflect)
            {
                range[0] = 0;
                range[1] = groove.height[0];
                Anglerange.Text = "90";
            }
            else if (method == (int)PathMethod.Direct)
            {
                range[0] = groove.height[0];
                range[1] = groove.height[0] + groove.height[1];
                Anglerange.Text = "90";
            }
            else
            {
                MessageShow.show("input error", "输入错误");
            }
        }

        private void SetCRCgrooveInputRange(int method)
        {
            if (method == (int)PathMethod.Reflect)
            {
                range[0] = groove.height[0];
                range[1] = groove.height[0] + groove.height[1];
                Anglerange.Text = "90";
            }
            else if (method == (int)PathMethod.Direct)
            {
                range[0] = groove.height[0] + groove.height[1];
                range[2] = groove.height.Sum() - groove.height[2];
                range[1] = groove.height.Sum();
                Anglerange.Text = "70 or 90";
            }
            else if(method == (int)PathMethod.Series)
            {
                range[0] = 0;
                range[1] = groove.height[0];
                Anglerange.Text = "45";
            }
        }

        private void FormModify_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (modifyflag == 0)
            {
                formFocus.Modifypara(this, cancelflag);
            }
            else if(modifyflag == 1)
            {
                formFocus.Addpara(this, cancelflag);
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            cancelflag = 1;
            this.Close();
            formFocus.Modifypara(this, cancelflag);
        }

        private void methodbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            method = methodbox.SelectedIndex;
            Setrange();
        }

    }
}
