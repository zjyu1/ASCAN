using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Xml;
using System.Collections;
using System.Windows.Forms;

namespace Ascan
{
    /**This class is used to get the datas of language resources.*/
    public static class MultiLanguage
    {
        /**The current language used.*/
        public static string lang { get; set; }
        public static string baseUrl = "";

        /**Get the default language storaged in file.*/
        public static string ReadDefaultLanguage()
        {
            XmlReader reader = new XmlTextReader("resources/LanguageDefine.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
            XmlNode root = doc.DocumentElement;
            XmlNode node = root.SelectSingleNode("DefaultLanguage");

            string result = "EN";
            if (node != null)
                result = node.InnerText;

            reader.Close();
            return result;
        }

        /**Set the default language into file.*/
        public static void WriteDefaultLanguage(string lang)
        {
            DataSet ds = new DataSet();
            ds.ReadXml("resources/LanguageDefine.xml");
            DataTable dt = ds.Tables["Language"];

            dt.Rows[0]["DefaultLanguage"] = lang;
            ds.AcceptChanges();
            ds.WriteXml("resources/LanguageDefine.xml");
        }

        /**Get datas from the designed resource XML file.
         * @param frmName name of the Form.
         * @param lang the language convert to.
         * @return result a table contains resource language datas.
         */
        public static Hashtable ReadResource(string frmName, string lang)
        {
            Hashtable result = new Hashtable();
            if (MultiLanguage.baseUrl == "")
                MultiLanguage.baseUrl = Application.StartupPath + "\\";

            XmlReader reader = null;
            FileInfo fi = new FileInfo(MultiLanguage.baseUrl + "resources\\AppResource_" + lang + ".xml");
            if (!fi.Exists)
                reader = new XmlTextReader(MultiLanguage.baseUrl + "resources\\AppResource.xml");
            else
                reader = new XmlTextReader(MultiLanguage.baseUrl + "resources\\AppResource_" + lang + ".xml");

            XmlDocument doc = new XmlDocument();
            doc.Load(reader);

            XmlNode root = doc.DocumentElement;
            XmlNodeList nodelist = root.SelectNodes("Form[Name='" + frmName + "']/Controls/Control");
            foreach (XmlNode node in nodelist)
            {
                try
                {
                    XmlNode node1 = node.SelectSingleNode("@name");
                    XmlNode node2 = node.SelectSingleNode("@text");
                    if (node1 != null)
                    {
                        result.Add(node1.InnerText, node2.InnerText);
                    }
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.ToString());
                }
            }
            reader.Close();

            return result;
        }

        /**Set the text of the form's control.
         * @param form name of the convert Form
         */
        public static void getNames(Form form) 
        { 
            Hashtable table = MultiLanguage.ReadResource(form.Name, lang); 
            Control.ControlCollection controlNames = form.Controls; 

            try 
            { 
                foreach(Control control in controlNames) 
                {
                    if (control.GetType() == typeof(System.Windows.Forms.MenuStrip))
                        GetMenuStripName(control, table);
                    else if (control.GetType() == typeof(System.Windows.Forms.DataGridView))
                        GetDataGridColumnsName(control, table);
                    else if (control.GetType() == typeof(System.Windows.Forms.ToolStrip))
                        GetToolStripName(control, table);
                    else 
                        GetSubControls(control.Controls, table);
                        
                    if(table.Contains(control.Name)) 
                        control.Text = (string)table[control.Name]; 
                } 
                FindContextMenuStrip(form, table);
                if(table.Contains(form.Name)) 
                    form.Text = (string)table[form.Name]; 
            } 
            catch(Exception ex) 
            {
                Console.WriteLine(ex.ToString()); 
            }
            
        }

        /**Set the text of the subControl.
         * @param controls subControls collections get from father control.
         * @param table a table contains resource language datas.
         */
        private static void GetSubControls(Control.ControlCollection controls, Hashtable table)
        {
            foreach (Control control in controls)
            {
                if (control.GetType() == typeof(System.Windows.Forms.ComboBox))
                    GetComboBoxName(control, table);
                if (control.GetType() == typeof(System.Windows.Forms.DataGridView))
                    GetDataGridColumnsName(control, table);
                else if (control.Controls.Count != 0)
                    GetSubControls(control.Controls, table);

                if (table.Contains(control.Name))
                    control.Text = (string)table[control.Name];
            }
        }

        /**Set the text of the MenuStrip control.
        * @param control a menuStrip control.
        * @param table a table contains resource language datas.
        */
        private static void GetMenuStripName(Control control, Hashtable table)
        {
            foreach (ToolStripMenuItem item in ((MenuStrip)control).Items)
            {
                if (table.Contains(item.Name))
                    item.Text = (string)table[item.Name];
                if (item.DropDownItems.Count != 0)
                    EnumerateMenu(item, table);
            }
        }

        /**Set the text of the MenuStrip control's dropDownItems.
        * @param control a subMenuStrip control.
        * @param table a table contains resource language datas.
        */
        private static void EnumerateMenu(ToolStripMenuItem control, Hashtable table)
        {
            foreach (ToolStripMenuItem item in control.DropDownItems)
            {
                if (item.DropDownItems.Count != 0)
                    EnumerateMenu(item, table);
                if (table.Contains(item.Name))
                    item.Text = (string)table[item.Name];
            }
        }

        /**Set the text of the DataGridView control.
        * @param control a DataGridView control.
        * @param table a table contains resource language datas.
        */
        private static void GetDataGridColumnsName(Control control, Hashtable table)
        {
            DataGridView dateGridView = (DataGridView)control;
            int leng = dateGridView.ColumnCount;
            for (int i = 0; i < leng; i++)
            {
                if (table.Contains(dateGridView.Columns[i].Name))
                {
                    string headerStr = (string)table[dateGridView.Columns[i].Name];
                    dateGridView.Columns[i].HeaderText = headerStr;
                }
            }
        }

        /**Set the text of the ToolStrip control.
        * @param control a ToolStrip control.
        * @param table a table contains resource language datas.
        */
        private static void GetToolStripName(Control control, Hashtable table) 
        {
            ToolStrip toolStrip = (ToolStrip)control;
            int leng = toolStrip.Items.Count;
            for (int i = 0; i < leng; i++)
            {
                if (table.Contains(toolStrip.Items[i].Name))
                {
                    string headerStr = (string)table[toolStrip.Items[i].Name];
                    toolStrip.Items[i].Text = headerStr;
                }
            }
        }

        /**Set the text of the ContextMenuStrip control
         * @param name of the convert Form
         * @param table a table contains resource language datas.
         */
        private static void FindContextMenuStrip(Form form, Hashtable table)
        {
            System.Reflection.FieldInfo[] fieldinfo = form.GetType().GetFields(System.Reflection.BindingFlags.NonPublic 
                | System.Reflection.BindingFlags.Instance);
            for (int i = 0; i < fieldinfo.Length; i++)
            {
                if (fieldinfo[i].FieldType.Name == "ContextMenuStrip")
                {
                    ContextMenuStrip context = (ContextMenuStrip)fieldinfo[i].GetValue(form);
                    foreach (ToolStripMenuItem item in context.Items)
                    {
                        if (table.Contains(item.Name))
                            item.Text = (string)table[item.Name];
                    }
                }
            }
        }

        /**Set the text of the ComboBox control
         *@param name of the convert Form
         *@param table a table contains resource language datas.
         */
        private static void GetComboBoxName(Control control, Hashtable table)
        {
            if(control.Name!="cmbType")
                return;

            ComboBox comboBox = (ComboBox)control;
            comboBox.Items.Clear();
            int len = Convert.ToInt32(comboBox.Tag);
            for (int i = 0; i < len; i++)
            {
                if (table.Contains(comboBox.Name +"Item"+i))
                {
                    string cmbItem=(string)table[comboBox.Name +"Item"+i];
                    comboBox.Items.Add(cmbItem);     
                }
            }
        }
    }
}
