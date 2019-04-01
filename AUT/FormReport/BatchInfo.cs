using System;
using System.Collections.Generic;

namespace Ascan
{

    [Serializable]
    public class RecordInfo
    {
        public int id;
        public string result;

        public string fileFullPath;

        //constructor, pls write it here
        public RecordInfo()
        {
            id = 0;
            result = "";
            fileFullPath = "";
        }

    }

    [Serializable]
    public class BatchInfo
    {
        public int id = 0;                 //Batch ID(Key)

        public string name = "";             //Batch Name

        public string startDateTime = "";  //start date time, such as 2017-05-18, 16:44
        public string endDateTime = "";     //end date time, such as 2017-05-19, 20:20

        public string productTypeFullPath = "";  //product type file 's full path, include dir and file name

        public string testingSetUpFullPatch = ""; //testing detection setting up file's full path, include dir and file name

        public int nbDetected=0;          //number tubes or product already detected
        public int nbGood=0;              //good number in nbDetected
        public int nbFail=0;              //unaccepted number in nbDetected

        public string operatorId = "";       //operator id
        public string operatorName = "";     //operator name

        public string custormerName = "";   //customer name
        public string fileNum = "";         //file num

        public string heatProcess = "";    //heat process

        public string grade = "";          //testing piece Grade
        public string nuanceOfSteel = "";  //testing piece nurance of steel
        public string dim = "";            //testing piece demension

        public string area = "";           //factory area
        public string controlSpec = "";    //control sepecfication 

        public List<RecordInfo>    recordList;

        //constructor, pls write it here
        public BatchInfo()
        {
            recordList = new List<RecordInfo>();
        }

    }


    //OrderInfo
    [Serializable]
    public class OderInfo
    {
        public bool isLoad;

        public int id=0;
        public string name="";
        public string date = "";

        public List<BatchInfo> batchList;

        //constructor, pls write it here
        public OderInfo()
        {
            isLoad = false;
            batchList = new List<BatchInfo>();
        }

        //re sync to database
        public void ReSync()
        {

        }
    }

   
}
