using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ascan
{
     public class GeneralFuc
    {
         static public void SetEmptyTextBox(Control ctrlTop)
         {
             if (ctrlTop.GetType() == typeof(TextBox))
             {
                 if (ctrlTop.Text == ""||ctrlTop.Text ==null)
                 {
                     ctrlTop.Text = "0";
                 }
             }
             else
             {
                 foreach (Control ctrl in ctrlTop.Controls)
                 {
                     SetEmptyTextBox(ctrl);
                 }
             }
             
         }

         static public void ClearTextBox(Control ctrlTop)
         {
             if (ctrlTop.GetType() == typeof(TextBox))
                 ctrlTop.Text = "";
             else
             {
                 foreach (Control ctrl in ctrlTop.Controls)
                 {
                     ClearTextBox(ctrl);
                 }
             }
         }



 
    }


    public class Product
    {
        public string name;

        public double length;
        public double outsize;
        public double thickness;

        public string weldingMaterial;

        public Groove groove;
        //public List<Subregion> subregions;
        public Sample sample;
        

        public Product()
        {
            sample=new Sample();
            //subregions=new List<Subregion>();
            groove = new Groove();
            name = "";
            length = 0;
            thickness = 0;
            outsize = 0;
            weldingMaterial = "";
        }
    }


     public class Sample
     {
         public string name;
         public string date;
         public string factory;
         public string drawing;
         public string sn;
         public string standard;
         public string material;
         public GrooveType groType;

         public List<Defect> defects;

         public Sample()
         {
             name = "";
             date = "";
             factory = "";
             drawing = "";
             sn = "";
             standard = "";
             material = "";
             groType = GrooveType.NULL;
             defects = new List<Defect>();
         }
     }


     public class Defect
     {
         public string name;
         public string subregionName;
         public string type;
         public double beginAxial;
         public double endAxial;
         public double beginRadio;
         public double endRadio;

         
         public Defect()       
         {
             name = "";
             subregionName = "";
             type = "";
             beginAxial=0;
             endAxial=0;
             beginRadio=0;
             endRadio = 0;
         }
     }

     //public class Subregion
     //{
     //    public string name;
     //    public double threshold;
     //    public double alarmLevel1;
     //    public double count1;
     //    public double alarmLevel2;
     //    public double count2;
     //    public double limitIn;
     //    public double limitOut;

     //    public Subregion()
     //    {
     //        name = "";
     //        threshold = 0;
     //        alarmLevel1= 0;
     //        count1= 0;
     //        alarmLevel2= 0;
     //        count2= 0;
     //        limitIn= 0;
     //        limitOut = 0;
     //    }
     //}
}