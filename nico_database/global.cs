using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;



namespace nico_database
{
    class global
    {
    }

   

    public static class memoryData
    {
       // public static Boolean mouseHold = false; //滑鼠狀態
        //public static Layer[] layereditData = new Layer[1];
        public static ArrayList iconTemp = new ArrayList();//物件名稱暫存
        public static ArrayList iconDelTemp = new ArrayList();//要刪除的物件暫存
        //public static ArrayList LonMonitor = new ArrayList(); //Lon NV 監看表
        public static ArrayList LonDeviceTemp = new ArrayList(); //Lon SOAP 抓設備暫存
        //public static ArrayList Alarminfo = new ArrayList();//alarm列表
        public static ArrayList SmartserverIP = new ArrayList();

        public static ArrayList LayerData = new ArrayList(); //layer list
        public static ArrayList LabelData = new ArrayList(); //label obj list
        public static ArrayList ButtonData = new ArrayList(); //button obj list
        public static ArrayList InputData = new ArrayList(); //input obj list
        public static ArrayList ReadAllNV = new ArrayList(); //read all nv value temp
        public static ArrayList OutputButtonData = new ArrayList(); //output button obj list
        public static ArrayList OutputTextData = new ArrayList(); //output text obj list
        public static ArrayList OutputPopData = new ArrayList(); //output pop obj list
        public static ArrayList PictureData = new ArrayList(); //picture object list
        public static ArrayList AlarmData = new ArrayList(); //alarm info object list
        public static ArrayList AlarmAudioTrue = new ArrayList(); //alarm true audio object list
        public static ArrayList AlarmAudioFalse = new ArrayList(); //alarm false audio object list
        public static ArrayList AlarmMonitorValue = new ArrayList(); //alarm NV value poll
        public static ArrayList contact = new ArrayList();  //contact info
        public static ArrayList database = new ArrayList();  //database info
        //public static ArrayList account = new ArrayList();  //account info
        //public static ContactGroup[] GroupContact = new ContactGroup[1];  // group contact info
        public static ArrayList GroupContact2 = new ArrayList();  //contact info 
        public static ArrayList errorIp = new ArrayList();
        public static ArrayList accountListTemp = new ArrayList();

        public static ArrayList TankData = new ArrayList(); //tank object list
    }

    public struct AccountList
    {
        public int no;
        public string name;
        public string pass;
        public string level; 
    }

    public struct MonitorNV
    {
        public string name;
        public string path;
        public string ip;
        public int time;
        public int count;
        public string unit;
        public string value;
    }

    public struct AlarmMoniTorNV
    {
        public string name;
        public string NVpath;
        public string NVtype;
        public string NVvalue;
        public string ip;
        public int sampleRate;
        public int sampleRatecount;
        public string device;
        public string function;
        public string NV;
        public string states;
        public string preset;
    }

    public struct Layerstruct
    {
        public string name;
        public Int32  backColor;
        public string backImage;
        public string sizeMode;
    }

    //public struct LonDevicetemp
    //{
    //    public string device;
    //    public string path;
    //}

    public struct LonDeviceIp
    {
        public string ip;
        public ArrayList device;
        public ArrayList path;
    }

    public struct LabelObjstruct
    {
        public string layer;
        public string name;
        public string text;
        public Font font;
        public Int32  color;
        public Int32 backcolor;
        public BorderStyle border;
        public int x;
        public int y;
        public string tag;
    }

    public struct ButtonObjstruct
    {
        public string name;
        public string layer;
        public string text;
        public Font font;
        public Int32 forecolor;
        public string AlignText;
        public string backImage;
        public int width;
        public int height;
        public int x;
        public int y;
        public string command;
        public Int32 backColor;
        public string AlignImage;
        public Boolean useBackIMG;
        public Boolean useBackColor;
        public string tag;
    }

    public struct InputObjectstruct
    {
        public string layer;
        public string name;
        public string ip;
        public Font font;
        public Int32 forecolor;
        public Int32 backcolor;
        public string value;  //原int
        public string showvalue;
        public int count;
        public Boolean logdata;
        public int logtime;
        public int logtimecount;

        public string target;
        public string targetindex;
        public Boolean unituse;
        public string unit;
        public string stringFormat;
        public int lonPolltime;
        
        public int x;
        public int y;
        public BorderStyle border;
        public string tag;
        public string potocol;
        public string NVtype;

        public string area;
        public string fab;
        public string site;
        public string device;
        public string function;
        public string NV;
        public string description;
    }

    public struct ReadNVvaluestruct
    {
        public string IP;
        public string device;
        public string function;
        public string NV;
        public string NVtype;
        public string Value;
        public string status;
        public string preset;
    }

    public struct OutputButtonObjectstruct
    {
        public string layer;
        public string name;
        public string ip;
        public int x;
        public int y;
        public int width;
        public int height;
        public string NVvalue;
        public string NVtype;
        public string NVtypeF;
        public string buttontype;
        public string target;
        public string targetindex;
        public string imagePath;
        public Boolean log;
        public Boolean mail;
        public Boolean SMS;
        public string tag;
        public string userOnImagePath;
        public string userOffImagePath;

        public string site;
        public string fab;
        public string area;
        public string device;
        public string function;
        public string NV;
        public string description;
        public string contactGroup;
    }

    public struct OutputTextObjectstruct
    {
        public string layer;
        public string name;
        public string ip;
        public int x;
        public int y;
        public int width;
        public int height;
        public string NVvalue;
        public string NVtype;
        public string NVtypeF;
        public string target;
        public string targetindex;
        public Boolean log;
        public Boolean mail;
        public Boolean SMS;
        public string tag;

        public string site;
        public string fab;
        public string area;
        public string device;
        public string function;
        public string NV;
        public string description;
        public string contactGroup;
    }

    public struct OutputPopObjectstruct
    {
        public string name;
        public string layer;
        public string ip;
        public int width;
        public int height;
        public int x;
        public int y;

        public string text;
        public Font font;
        public Int32 forecolor;
        public ContentAlignment AlignText;
        public string backImage;
        public Int32 backColor;
        
        public string NVtype;
        //public string NVvalue;
        public string target;
        public string targetindex;
        public ContentAlignment AlignIMG;
        public Boolean log;
        public Boolean mail;
        public Boolean SMS;
        public Boolean useBackIMG;
        public Boolean useBackColor;
        public string tag;

        public string site;
        public string fab;
        public string area;
        public string device;
        public string function;
        public string NV;
        public string description;
        public string contactGroup;
    }

    public struct PictureboxObjectstruct
    {
        public string name;
        public string layer;
        public string path;
        public int width;
        public int height;
        public int x;
        public int y;
        public string tag;
    }

    public struct AlarmObjectstruct
    {
        public string name;
        public string layer;
        public string SourceIP;
        public string TargetIP;

        public string NVType;
        public string SourceNVName;
        public string SourceNVindex;
        public string TargetNVName;
        public string TargetNVindex;
        public string CompareType;
        public string CompareValue;
        public string CompareLogic;
        public float CompareMin;
        public float CompareMax;
        public int sampleRate;
        public int sampleRatecount;
        public int timeOver;
        public int timeOvercount;
        public Boolean AlarmTrueRun;
        public Boolean AlarmFalseRun;
        public Boolean AlarmStatus;
        public string description;

        public Boolean LogicTrueOutNV;
        public Boolean LogicTrueOutSMS;
        public Boolean LogicTrueOutemail;
        public Boolean LogicTrueOutLog;
        public string LogicTrueOutNV1;
        public string LogicTrueOutNV2;
        public string LogicTrueOutNV3;
        public string LogicTrueOutNV4;
        public string LogicTrueOutNV5;
        public string LogicTrueOutNV6;
        public string LogicTrueOutNV7;
        public string LogicTrueOutNV8;
        public string LogicTrueOutNV1index;
        public string LogicTrueOutNV2index;
        public string LogicTrueOutNV3index;
        public string LogicTrueOutNV4index;
        public string LogicTrueOutNV5index;
        public string LogicTrueOutNV6index;
        public string LogicTrueOutNV7index;
        public string LogicTrueOutNV8index;
        public string LogicTrueOutNV1Value;
        public string LogicTrueOutNV2Value;
        public string LogicTrueOutNV3Value;
        public string LogicTrueOutNV4Value;
        public string LogicTrueOutNV5Value;
        public string LogicTrueOutNV6Value;
        public string LogicTrueOutNV7Value;
        public string LogicTrueOutNV8Value;
        public string LogicTrueOutMSG;
        public string LogicTrueOutImagePath;
        public Boolean LogicTrueAudioUse;
        public string LogicTrueAudioPath;
        public int LogicTrueWidth;
        public int LogicTrueHeight;
        public int LogicTrueX;
        public int LogicTrueY;
        public string AlarmTrueMailgroup;
        public string AlarmFalseMailgroup;  

        public Boolean LogicFalseOutNV;
        public Boolean LogicFalseOutSMS;
        public Boolean LogicFalseOutemail;
        public Boolean LogicFalseOutLog;
        public string LogicFalseOutNV1;
        public string LogicFalseOutNV2;
        public string LogicFalseOutNV3;
        public string LogicFalseOutNV4;
        public string LogicFalseOutNV5;
        public string LogicFalseOutNV6;
        public string LogicFalseOutNV7;
        public string LogicFalseOutNV8;
        public string LogicFalseOutNV1index;
        public string LogicFalseOutNV2index;
        public string LogicFalseOutNV3index;
        public string LogicFalseOutNV4index;
        public string LogicFalseOutNV5index;
        public string LogicFalseOutNV6index;
        public string LogicFalseOutNV7index;
        public string LogicFalseOutNV8index;
        public string LogicFalseOutNV1Value;
        public string LogicFalseOutNV2Value;
        public string LogicFalseOutNV3Value;
        public string LogicFalseOutNV4Value;
        public string LogicFalseOutNV5Value;
        public string LogicFalseOutNV6Value;
        public string LogicFalseOutNV7Value;
        public string LogicFalseOutNV8Value;
        public string LogicFalseOutMSG;
        public string LogicFalseOutImagePath;
        public Boolean LogicFalseAudioUse;
        public string LogicFalseAudioPath;
        public int LogicFalseWidth;
        public int LogicFalseHeight;
        public int LogicFalseX;
        public int LogicFalseY;

        public string tag;

        public string site;
        public string fab;
        public string area;
        public string device;
        public string function;
        public string NV;
        public string NVtype;

        public string NVpart;
        public Font LogicTrueOutFont;
        public Font LogicFalseOutFont;
        public Int32 LogicTrueforecolor; 
        public Int32 LogicFalseforecolor;
        public Boolean userTrueValue;
        public Boolean userFalseValue;
    }

    public struct AlarmAudiostruct
    {
        public string name;
        public string path;
    }

    public struct TankObjectstruct
    {
        public string name;
        public string layer;
        public string ip;
        public string value;  //原int
        public string showvalue;
        public int count;
        public Boolean logdata;
        public int logtime;
        public int logtimecount;

        public string target;
        public string targetindex;
        public int lonPolltime;

        public int width;
        public int height;
        public int x;
        public int y;
        public string tag;
        public string potocol;
        public string NVtype;

        public string area;
        public string fab;
        public string site;
        public string device;
        public string function;
        public string NV;
        public string description;
    }

    public struct Contactstruct 
    {
        public string name;
        public string mail;
        public string phone;
        public string description;
    }

    public struct ContactGroup
    {
        public string groupname;
        public int groupindex;
        public Contactstruct[] groupmember;
    }

    public struct ContactGroup2
    {
        public string groupname;
        //public int groupindex;
        public ArrayList groupmember;
    }

    public struct database
    {
        public string ip;
        public string port;
        public string user;
        public string password;
        public string DBname;
    }

    public struct account
    {
        public string name;
        public string password;
        public string accountl;
    }
}
