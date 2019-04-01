using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Collections;

namespace Ascan
{
    public partial class FormMaterialVelocity : Form
    {
        public FormMaterialVelocity()
        {
            InitializeComponent();        
        }

        private void FormMaterialVelocity_Load(object sender, EventArgs e)
        {
            MultiLanguage.getNames(this);
            initMatVelocity();
            longitudinal.Checked = true;
            getMaterialVelocity("Longitudinal");
        }

        /**Init material velocity*/
        public void initMatVelocity()
        {
            int error_code;
            double velocity = 0;
            error_code = GetMaterialVelocityDAQ.Velocity(SelectAscan.sessionIndex, SelectAscan.port, ref velocity);
            if (error_code != 0)
                return;

            numUpDownMatVelocity.Value = Convert.ToDecimal(velocity);
        }


        /**Add material velocity to datatable.
         * @param velocityTypeName name of Longitudinal or Tranverse.
         */
        private void getMaterialVelocity(string velocityTypeName)
        {
            Dictionary<string, string> dict = ReadResource(velocityTypeName);
            if (dict == null)
                return;

            DataTable tableShape = new DataTable();
            tableShape.Columns.Clear();
            tableShape.Rows.Clear();
            tableShape.Columns.Add("Material");
            tableShape.Columns.Add("Velocity");
            tableShape.Columns.Add("Uint");
            object[] values = new object[3];
            foreach (string key in dict.Keys)
            {
                values[0] = key;//key
                values[1] = dict[key];//value
                values[2] = "m/s";
                tableShape.Rows.Add(values);
            }
            materialList.DataSource = tableShape;
        }


        /**Get datas from the designed resource MaterialVelocity.xml.
        * @param velocityTypeName name of the Longitudinal or Tranverse.
        * @return result a dictionary contains resource material velocity datas.
        */
        private Dictionary<string, string> ReadResource(string velocityTypeName)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            XmlReader reader = null;
            FileInfo fi = new FileInfo("MaterialVelocity/MaterialVelocity.xml");
            if (!fi.Exists)
            {
                MessageShow.show("There is no MaterialVelocity.xml!",
                    "MaterialVelocity.xml不存在!");
                return null;
            }
            reader = new XmlTextReader("MaterialVelocity/MaterialVelocity.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);

            XmlNode root = doc.DocumentElement;
            XmlNodeList nodelist = root.SelectNodes("MaterialVelocity[Name='" + velocityTypeName + "']/Params/Param");
            foreach (XmlNode node in nodelist)
            {
                try
                {
                    XmlNode node1 = node.SelectSingleNode("@name");
                    XmlNode node2 = node.SelectSingleNode("@value");
                    if (node1 != null)
                    {
                        dict.Add(node1.InnerText, node2.InnerText);
                    }
                }
                catch 
                {
                    MessageShow.show("Error:Get material velocity from xml failed!",
                        "错误:从xml文件中获得材料声速失败!");
                }
            }
            reader.Close();

            return dict;
        }


        /**Get the material velocity of current rows selected.*/
        private void materialList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string velocity = materialList.Rows[materialList.CurrentRow.Index]
                .Cells["Velocity"].Value.ToString();

            numUpDownMatVelocity.Text = velocity;

            SetMaterialVelocityDAQ.Velocity(SelectAscan.sessionIndex, SelectAscan.port, Convert.ToDouble(velocity));
        }

        private void judgeNumUpDownInput(NumericUpDown numUpDown, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8
                 && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && numUpDown.Text.IndexOf(".") != -1)
            {
                e.Handled = true;
            }
        }

        private void numUpDownMatVelocity_Click(object sender, EventArgs e)
        {
            double velocity = Convert.ToDouble(numUpDownMatVelocity.Value);
            SetMaterialVelocityDAQ.Velocity(SelectAscan.sessionIndex, SelectAscan.port, velocity);
        }

        private void numUpDownMatVelocity_KeyPress(object sender, KeyPressEventArgs e)
        {
            double velocity = Convert.ToDouble(numUpDownMatVelocity.Value);
            judgeNumUpDownInput(numUpDownMatVelocity, e);

            if (e.KeyChar == (char)Keys.Enter)
            {
                SetMaterialVelocityDAQ.Velocity(SelectAscan.sessionIndex, SelectAscan.port, velocity);
            }
        }

        private void numUpDownMatVelocity_Leave(object sender, EventArgs e)
        {
            double velocity = Convert.ToDouble(numUpDownMatVelocity.Value);

            SetMaterialVelocityDAQ.Velocity(SelectAscan.sessionIndex, SelectAscan.port, velocity);
        }

        private void longitudinal_Click(object sender, EventArgs e)
        {
            getMaterialVelocity("Longitudinal");
        }

        private void tranverse_Click(object sender, EventArgs e)
        {
            getMaterialVelocity("Tranverse");
        }
    }
}
