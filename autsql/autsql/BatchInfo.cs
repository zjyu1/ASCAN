using System;
using System.Collections.Generic;


namespace autsql
{
    public enum dataType //属于数据库，修改的，删除的，增加的｝

    {
        orig,modify,del,add
   }
    public class RecordInfo
    {
        //   public int id;
       
        public dataType  dt;//{属于数据库，修改的，删除的，增加的｝

        public int weldNo;  //焊缝号

        public int  num;     //检测次数
       
        public string batchName;

        public string result;

        public string fileFullPath;

    
        //constructor, pls write it here
        public RecordInfo()
        {

        }

    }

    public class BatchInfo
    {
        //  public int id = 0;                 //Batch ID(Key)
        public dataType dt;
        public string name;             //Batch Name
        public string orderName;         //order name

        public string startDateTime ;  //start date time, such as 2017-05-18, 16:44
        public string endDateTime;     //end date time, such as 2017-05-19, 20:20

        public string productTypeFullPath;  //product type file 's full path, include dir and file name

        public string testingSetUpFullPatch; //testing detection setting up file's full path, include dir and file name

        public int nbDetected;          //number tubes or product already detected
        public int nbGood;              //good number in nbDetected
        public int nbFail;              //unaccepted number in nbDetected

        public string operatorId;       //operator id
        public string operatorName;     //operator name

        public string custormerName;   //customer name
        public string fileNum;         //file num

        public string heatProcess;    //heat process

        public string grade;          //testing piece Grade
        public string nuanceOfSteel;  //testing piece nurance of steel
        public string dim;            //testing piece demension

        public string area;           //factory area
        public string controlSpec;    //control sepecfication 

        public  List<RecordInfo>    recordList;

        //constructor, pls write it here

       
        public BatchInfo()
        {
            List<RecordInfo> recordList = new List<RecordInfo>();
        }

    }


    //OrderInfo
    public class OderInfo
    {
        public bool isLoad;

        public string batchName;
        public string name;
        public string date;
        
        public List<BatchInfo> batchList;

        //constructor, pls write it here
        public OderInfo()
        {
            isLoad = false;
            List<BatchInfo> batchList=new List<BatchInfo>();
        }

        //resync to database
        public static  void ReSync(OderInfo od)

        {
            DataClass.MySQLFunction.AddListToBatchtbl(od.batchList);
        }
    }

   
}
