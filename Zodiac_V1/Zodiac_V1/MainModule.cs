using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Data;
using System.Globalization;
using System.Collections;
using System.Drawing;
using Microsoft.VisualBasic;
using System.Configuration;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.EnterpriseServices;
using System.Security.Principal;
using System.IO;


[assembly: CLSCompliant(true)]

namespace MASSync
{
    class MainModule
    {

        public static String gsServer = System.Configuration.ConfigurationSettings.AppSettings["Server"].ToString();
        public static String gsUser = System.Configuration.ConfigurationSettings.AppSettings["User"].ToString();
        public static String gsPassword = DecPassword(System.Configuration.ConfigurationSettings.AppSettings["Password"].ToString());
        public static String gsDatabase = System.Configuration.ConfigurationSettings.AppSettings["Database"].ToString();
        public static String gsFTP = System.Configuration.ConfigurationSettings.AppSettings["FTP"].ToString();
        public static String gsFTPUserName = System.Configuration.ConfigurationSettings.AppSettings["FTPUserName"].ToString();
        public static String gsFTPUserPWD = DecPassword(System.Configuration.ConfigurationSettings.AppSettings["FTPUserPwd"].ToString());
        public static String gsWebServiceURL = System.Configuration.ConfigurationSettings.AppSettings["WebServiceURL"].ToString();
        static public String gsApplicationName = System.Configuration.ConfigurationSettings.AppSettings["Application"].ToString();
        public static String gsTerminalID = System.Configuration.ConfigurationSettings.AppSettings["TerminalID"].ToString();
        public static String gsFrequency = System.Configuration.ConfigurationSettings.AppSettings["Frequency"].ToString();
        public static String gsTenantID = System.Configuration.ConfigurationSettings.AppSettings["TenantID"].ToString();
        public static string gsLiveFrom = System.Configuration.ConfigurationSettings.AppSettings["LiveFrom"].ToString();
        public static string gsBranchID = System.Configuration.ConfigurationSettings.AppSettings["TerminalID"].ToString();  
        

        public static string gsApplicationPath="HH";
        //public static string oConnString = String.Format("server={0};uid={1};pwd={2};database={3};",
        //        MainModule.gsServer, MainModule.gsUser, MainModule.gsPassword, MainModule.gsDatabase);
        public static String oConnString = "Dsn=" + gsServer + ";" + "Uid=" + gsUser + ";" + "Pwd=" + gsPassword + ";"; 

        public static string EncPassword(string data)
        {
            string Password;
            string fsEncPassword = string.Empty;

            for (int iCount = 1; iCount <= Convert.ToInt32(Strings.Len(data), null); iCount++)
            {
                Password = string.Empty;
                Password = Convert.ToString(Strings.Asc(Strings.Mid(data, iCount, 1)), null);
                Password = Convert.ToString((Conversion.Val(Password) - 15) + 120, null);
                Password = Convert.ToString(Strings.Chr(Convert.ToInt32(Password, null)), null);
                fsEncPassword = string.Concat(fsEncPassword, Password);

            }
            return fsEncPassword;
        }

        public static string DecPassword(string data)
        {
            string Password;
            string fsEncPassword = string.Empty;
            //int nCount;


            for (int iCount = 1; iCount <= Convert.ToInt32(Strings.Len(data), null); iCount++)
            {
                Password = string.Empty;
                Password = Convert.ToString(Strings.Asc(Strings.Mid(data, iCount, 1)), null);
                Password = Convert.ToString((Conversion.Val(Password) + 15) - 120, null);
                Password = Convert.ToString(Strings.Chr(Convert.ToInt32(Password, null)), null);
                fsEncPassword = string.Concat(fsEncPassword, Password);
            }
            return fsEncPassword;
        } 


        

       

    }
    
}
