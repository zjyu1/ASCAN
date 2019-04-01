using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ascan;

namespace AUT
{
    public partial class TestReport : Form
    {
        MainForm tmp = new MainForm();
        OderInfo order = new OderInfo();
        public TestReport()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            testforbatch();
            string path = AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\order1.odr";
            string date = string.Format("{0:yyyy-MM-dd HH_mm_ss}", DateTime.Now);
            date = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");//"G"
            SystemConfig.WriteConfigData(path, "date", date);
            SystemConfig.WriteBase64Data(path, "order", order);
            FormReport formreport = new FormReport(tmp);
            formreport.Show();
        }

        private void testforbatch()
        {
            RecordInfo record = new RecordInfo();
            BatchInfo batch = new BatchInfo();
            record.id = 0;
            record.result = "pass";
            record.fileFullPath = AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\0606.mmp";

            batch.recordList.Add(record);
            batch.productTypeFullPath = AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\product.xml";
            batch.name = "AUT720";
            batch.nbDetected = 1;
            batch.nbGood = 0;
            batch.nbFail = 1;
            batch.area = "China";
            batch.custormerName = "b";
            batch.startDateTime = "2017-6-9";
            batch.operatorId = "1";
            batch.operatorName = "operatorA";
            batch.controlSpec = "modeA";

            order.name = "Weld1";
            order.date = "2017-05-27";
            order.batchList.Add(batch);

            batch = new BatchInfo();
            record = new RecordInfo();
            record.id = 1;
            record.result = "reject";
            record.fileFullPath = AppDomain.CurrentDomain.BaseDirectory.ToString() + "0606.mmp";

            batch.recordList.Add(record);
            batch.productTypeFullPath = AppDomain.CurrentDomain.BaseDirectory.ToString() + "product.xml";
            batch.name = "AUT360";
            batch.nbDetected = 1;
            batch.nbGood = 1;
            batch.nbFail = 0;
            batch.area = "China";
            batch.custormerName = "b";
            batch.startDateTime = "2017-6-9";
            batch.operatorId = "2";
            batch.operatorName = "operatorB";
            batch.controlSpec = "modeA";

            order.batchList.Add(batch);
        }
    }
}
