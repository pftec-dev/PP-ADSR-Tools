using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Odbc;
using System.IO;
using System.Configuration ;
using Microsoft.VisualBasic;

namespace MASSync
{
    public partial class frmSync : Form
    {
        public string sStartTime="",sStartSystemTime="";
        public string sEndTime = "", sEndSystemTime = "", TittleHeader = "", SegmentHeader = "";
        public DateTime dselectDate, dServerDate;
        WebSync.FtpConnection Ftpconn=new WebSync.FtpConnection();
        DateTime dtLast;
        string spos = "";
        string sLastDate = "",sline="";
        string sLastBillID = "0", sLastRetBillID = "0", sLastCancelledBillID="0";
        string gsLastBillID = "0", gsLastRetBillID = "0", gsLastCancelledBillID="0";
        Int32 icnt = 0;
        decimal dtot = 0;
        DataSet dspos = new DataSet();
        DataTable dtpos = new DataTable();
        public frmSync()
        {
            InitializeComponent();
        }

        private void frmSync_Load(object sender, EventArgs e)
        {
            
            notifyIcon1.ShowBalloonTip(100, "XtreMe Integra Zodiac_V1.0", "Auto Sync Tool Started ....", ToolTipIcon.Info);


            if (sStartTime == "")
            {
                OdbcDataReader sdr1;
                OdbcConnection sConn1 = new OdbcConnection();
                sConn1.ConnectionString = MainModule.oConnString;

                OdbcCommand sCmd = new OdbcCommand();

                sConn1.Open();
                sCmd.CommandText = "Select sysdate from dual";
                sCmd.CommandType = CommandType.Text;
                sCmd.Connection = sConn1;
                sdr1 = sCmd.ExecuteReader();
                while (sdr1.Read())
                {
                    dServerDate = Convert.ToDateTime(sdr1[0].ToString());
                }
                sdr1.Close();
                sConn1.Close();

                dselectDate = DateTime.Now;
                sStartSystemTime = String.Format("{0:dd/MMM/yyyy HH:mm:ss tt}", dselectDate);

                sStartTime = String.Format("{0:dd/MMM/yyyy HH:mm:ss tt}", dServerDate);
                sEndingTime();

            }
           
            CreateDirectoryInAppPath("SyncFile");
            CreateDirectoryInAppPath("SyncError");
            if (File.Exists(Application.StartupPath + "\\Tenants.xml"))
            {
                dspos.ReadXml(Application.StartupPath + "\\Tenants.xml");
                if (dspos.Tables.Count <= 0)
                {
                    frmSettings frmset = new frmSettings();
                    frmset.ShowDialog();
                }
            }
            else
            {
                frmSettings frmset = new frmSettings();
                frmset.ShowDialog();
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            this.Visible = false;
            //this.WindowState = FormWindowState.Minimized;
        }

        private void btSettings_Click(object sender, EventArgs e)
        {
            frmSettings frmset = new frmSettings();
            frmset.ShowDialog();

        }

        private void btGenerateFile_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;  
            string sBusDate ="",sCreateTime="";
            Int16 iSequenceNo = 0;
            DateTime dCreateDate, dCreatetime;
            Configuration confg = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
           // string  spos="";
            string[] sposs;
            string[] sldates;
            string sten = "";
            string constr = "";
            string ftp = "", ftpusername = "", ftppassword = "";
            dspos = new DataSet();
            dspos.ReadXml(Application.StartupPath + "\\Tenants.xml");
            if (dspos.Tables.Count <= 0) return;
            OdbcDataReader sdr;
            OdbcDataAdapter dap;
            OdbcConnection sConn = new OdbcConnection();
                       
            if (chkFilter.Checked)
            {
                foreach (DataGridViewRow dgr in dgvTen.Rows)
                {
                    dspos.Tables[0].Rows[dgr.Index]["selected"] = dgr.Cells[0].Value;
                }
                dspos.Tables[0].AcceptChanges();
            }
         

            try
            {

                OdbcCommand sCmd = new OdbcCommand();

                dspos.Tables[0].AcceptChanges();
                if (dspos.Tables[0].Rows.Count > 0)
                {
                    for (int irow = 0; irow < dspos.Tables[0].Rows.Count; irow++)
                    {
                       
                        if (dspos.Tables[0].Rows[irow]["Selected"].ToString().ToUpper() == "FALSE") continue;
                       
                            if (sConn.State == ConnectionState.Open) sConn.Close();
                                                    try
                                                    {
                                                         constr = "Dsn=" + dspos.Tables[0].Rows[irow]["DSN"].ToString() + ";" +
                                                                  "Uid=" + dspos.Tables[0].Rows[irow]["Uid"].ToString() + ";" +
                                                                  "Pwd=" + MainModule.DecPassword(dspos.Tables[0].Rows[irow]["Pwd"].ToString()) + ";";
                                                        // writelog("TestLOG",constr);
                                                        sConn.ConnectionString = constr;
                                                        sConn.Open();
                                                    }
                                                    catch (Exception connection)
                                                    {
                                                        TextWriter twEr = new StreamWriter(Application.StartupPath.ToString() + "\\SyncError\\SyncError" + DateTime.Now.ToString("HHmmss") + ".txt");
                                                        twEr.WriteLine(sline);
                                                        twEr.WriteLine("ten:" + sten + "E" + connection.Message.ToString());
                                                        twEr.Close();

                                                    }
                            ftp = ""; ftpusername = ""; ftppassword = "";
                            spos = "";
                            sten = dspos.Tables[0].Rows[irow]["tenantid"].ToString();
                            spos = dspos.Tables[0].Rows[irow]["BranchID"].ToString();
                            ftp = dspos.Tables[0].Rows[irow]["FTP"].ToString();
                            ftpusername = dspos.Tables[0].Rows[irow]["FTPUserName"].ToString();
                            ftppassword = MainModule.DecPassword(dspos.Tables[0].Rows[irow]["FTPPassword"].ToString());
                        
                      

                            gsLastBillID = "0";
                            dtLast = Convert.ToDateTime("01/May/2011 00:01:01");
                            if (!chkFilter.Checked)
                            {
                                dtLast = Convert.ToDateTime(dspos.Tables[0].Rows[irow]["LastPooleddate"].ToString());
                            }
                            else
                            {
                                dtLast = Convert.ToDateTime(dateTimePicker1.Value);
                            }
                            DateTime dttemp = Convert.ToDateTime("01/Jan/2000");                           
                            sLastDate = dtLast.ToString("dd/MMM/yyyy HH:mm:ss");//last pooled
                            sline = "1***";
                            //23-may-12
                            if (!chkFilter.Checked)
                            {
                              
                                sCmd.CommandText = " select '1' as \"Postill\", h.Shift_no,h.receipt_no,Receipt_Datetime, to_date(Receipt_Datetime ,'DD/MM/YYYY') as \"Createdate\",h.customer_gender as \"gender\",0 as \"Retamt\",to_char(sum(inv_amt),'999999999999.99') as \"invamt\",to_char(sum(Discount_amount),'999999999999.99') as \"Discamt\",to_char(sum(Net_amt),'999999999999.99') as \"Netamt\",'SALES' as  transaction_status,to_char(sum(\"Tax\"),'9999999999.99') as \"TaxAmt\",CUSTOMER_NAME as \"customername\"  from ILS2." + spos + "_HEADER h  left outer join  (Select receipt_no ,SUM(Tax_Amount) as \"Tax\" from ILS2." + spos + "_ITEMDETAIL group by receipt_no) tx on h.receipt_no=tx.receipt_no where Net_amt <> 0 and to_date( Receipt_Datetime,'DD/MM/YYYY')>=to_date('" + Convert.ToDateTime(sLastDate).ToString("dd/MM/yyyy") + "','DD/MM/YYYY')  and transaction_status in ('SALES','CANCELLED')  group by  h.receipt_no,Receipt_Datetime,h.customer_gender,CUSTOMER_NAME,h.Shift_no  ";
                            }
                            else
                            {
                             
                                sCmd.CommandText = " select '1' as \"Postill\", h.Shift_no,h.receipt_no,Receipt_Datetime, to_date(Receipt_Datetime ,'DD/MM/YYYY') as \"Createdate\",h.customer_gender as \"gender\",0 as \"Retamt\",to_char(sum(inv_amt),'999999999999.99') as \"invamt\",to_char(sum(Discount_amount),'999999999999.99') as \"Discamt\",to_char(sum(Net_amt),'999999999999.99') as \"Netamt\",'SALES' as transaction_status,to_char(sum(\"Tax\"),'9999999999.99') as \"TaxAmt\",CUSTOMER_NAME as \"customername\"  from ILS2." + spos + "_HEADER h  left outer join  (Select receipt_no ,SUM(Tax_Amount) as \"Tax\" from ILS2." + spos + "_ITEMDETAIL group by receipt_no) tx on h.receipt_no=tx.receipt_no where Net_amt <> 0 and to_date( Receipt_Datetime,'DD/MM/YYYY') between to_date('" + Convert.ToDateTime(dateTimePicker1.Value).ToString("dd/MMM/yyyy") + "','DD/MM/YYYY') and to_date('" + Convert.ToDateTime(dateTimePicker2.Value).ToString("dd/MMM/yyyy") + "','DD/MM/YYYY')  and transaction_status in ('SALES','CANCELLED')  group by  h.receipt_no,Receipt_Datetime,h.customer_gender,CUSTOMER_NAME,h.Shift_no  ";
                            }
                          
                            sCmd.CommandType = CommandType.Text;
                            sline += sCmd.CommandText;                         
                            sCmd.Connection = sConn;
                            sCmd.CommandTimeout = 0;
                            dap = new OdbcDataAdapter(sCmd);
                            DataTable dt = new DataTable();
                            dap.Fill(dt);
                            dap.Dispose();
                            icnt = 0;
                            dtot = 0;
                            dt.DefaultView.Sort = "Createdate ASC";
                            dt = dt.DefaultView.ToTable();
                            if (dt.Rows.Count > 0)
                            {

                                sBusDate = String.Format("{0:yyyyMMdd}", DateTime.Today);

                                dCreateDate = DateTime.Today;
                                dCreatetime = DateTime.Now;


                                if (MainModule.gsFrequency == "End of Day")
                                {
                                    TittleHeader = "E" + sten + "_" + String.Format("{0:yyMMdd}", dCreateDate) + String.Format("{0:HHmmss}", dCreatetime);
                                    SegmentHeader = "G010" + "E" + sten.PadLeft(20, ' ') + " ".PadLeft(10, ' ') + iSequenceNo.ToString().PadLeft(4, ' ') + String.Format("{0:yyyyMMdd}", dCreateDate) + String.Format("{0:HHmmss}", dCreatetime) + sBusDate;
                                }
                                else
                                {
                                    TittleHeader = "I" + sten + "_" + String.Format("{0:yyMMdd}", dCreateDate) + String.Format("{0:HHmmss}", dCreatetime);
                                    SegmentHeader = "G010" + "I" + sten.PadLeft(20, ' ') + " ".PadLeft(10, ' ') + iSequenceNo.ToString().PadLeft(4, ' ') + String.Format("{0:yyyyMMdd}", dCreateDate) + String.Format("{0:HHmmss}", dCreatetime) + sBusDate;
                                }
                                TextWriter tw = new StreamWriter(Application.StartupPath + "\\SyncFile\\" + TittleHeader + ".txt");

                                tw.WriteLine(SegmentHeader);
                                

                                foreach (DataRow dr in dt.Rows)
                                {
                                    sline += "NOSALES" + dr["Createdate"].ToString();                                 
                                    long idays = 0, n = 1;
                                    if (dttemp.ToString("dd/MMM/yyyy") != dtLast.ToString("dd/MMM/yyyy"))
                                    {
                                        sline += "&&&" + dr["createdate"].ToString();
                                        sBusDate = dt.Compute("min(Createdate)", "Createdate>'" + dtLast.ToString("dd/MMM/yyyy") + "'").ToString();                                        
                                        if (sBusDate != "")
                                        {
                                            idays = DateAndTime.DateDiff(DateInterval.Day, Convert.ToDateTime(dtLast.ToString("dd/MMM/yyyy")), Convert.ToDateTime(sBusDate), FirstDayOfWeek.System, FirstWeekOfYear.System);                                          
                                         
                                            sline += "NOSALES**" + dr["Createdate"].ToString();
                                            idays -= 1;
                                            while (n <= idays)
                                            {
                                                tw.WriteLine("G100" +
                                                Strings.Left("".ToString().PadLeft(5, ' '), 5) +
                                                Strings.Left("".ToString().PadLeft(2, '0'), 2) +
                                                "   NOSALES" +
                                                String.Format("{0:yyyyMMdd}", dtLast.AddDays(n)) +
                                                "0000000000000000000000000000000000000000000000000000000000000000000000000000000                                                                                            SALES");
                                                tw.WriteLine("G111                                                                                      00000000000000000000000                                                                                000000000000000I000000000000000000000000000000");
                                                tw.WriteLine("G115                                    CASH   00000000000000000000000");
                                                n += 1;
                                            }
                                        }
                                    }

                                    sline += spos + "***" + ChangeDateformat(dr["Createdate"].ToString());
                                    dttemp = Convert.ToDateTime(dtLast.ToString("dd/MMM/yyyy"));                                  
                                    sline += "dtlast:" + dttemp.ToString();
                                  
                                    if (dtLast < Convert.ToDateTime(dr["Createdate"]))
                                    {
                                        dtLast = Convert.ToDateTime(dr["Createdate"]);
                                    }                                  
                                    sline += " A";
                                    DateTime billdt = Convert.ToDateTime((dr["Createdate"].ToString()));
                                  

                                    WriteData(dr, tw, "S", sConn);


                                }
                                sline = "bef ret";
                                if (!chkFilter.Checked)
                                {
                                 
                                    sCmd.CommandText = " select '1' as \"Postill\", h.Shift_no,h.receipt_no, Receipt_Datetime,to_date(Receipt_Datetime ,'DD/MM/YYYY') as \"Createdate\",h.customer_gender as \"gender\",0 as \"Netamt\",to_char(inv_amt,'999999999999.99') as \"invamt\",to_char(Discount_amount,'999999999999.99') as \"Discamt\",to_char(Net_amt,'999999999999.99') as \"Retamt\",'RETURN' as \"transaction_status\",to_char(\"Tax\",'9999999999.99') as \"TaxAmt\",CUSTOMER_NAME as \"customername\"  from ILS2." + spos + "_HEADER h  left outer join  (Select receipt_no ,SUM(Tax_Amount) as \"Tax\" from ILS2." + spos + "_ITEMDETAIL group by receipt_no) tx on h.receipt_no=tx.receipt_no where to_date( Receipt_Datetime,'DD/MM/YYYY')>=to_date('" + Convert.ToDateTime(sLastDate).ToString("dd/MM/yyyy") + "','DD/MM/YYYY')  and transaction_status in ('RETURN','CANCELLED') ";  
                                }
                                else
                                {
                                    sCmd.CommandText = " select '1' as \"Postill\", h.Shift_no,h.receipt_no,Receipt_Datetime, to_date(Receipt_Datetime ,'DD/MM/YYYY')  as \"Createdate\",h.customer_gender as \"gender\",0 as \"Netamt\",to_char(inv_amt,'999999999999.99') as \"invamt\",to_char(Discount_amount,'999999999999.99') as \"Discamt\",to_char(Net_amt,'999999999999.99') as \"Retamt\",'RETURN' as \"transaction_status\",to_char(\"Tax\",'9999999999.99') as \"TaxAmt\",CUSTOMER_NAME as \"customername\"  from ILS2." + spos + "_HEADER h  left outer join  (Select receipt_no ,SUM(Tax_Amount) as \"Tax\" from ILS2." + spos + "_ITEMDETAIL group by receipt_no) tx on h.receipt_no=tx.receipt_no where to_date( Receipt_Datetime,'DD/MM/YYYY') between to_date('" + Convert.ToDateTime(dateTimePicker1.Value).ToString("dd/MMM/yyyy") + "','DD/MM/YYYY') and to_date('" + Convert.ToDateTime(dateTimePicker2.Value).ToString("dd/MMM/yyyy") + "','DD/MM/YYYY')  and transaction_status in ('RETURN','CANCELLED') ";
                                }
                                sline = sCmd.CommandText;
                                sCmd.CommandType = CommandType.Text;
                                sCmd.Connection = sConn;
                                sCmd.CommandTimeout = 0;
                                dap = new OdbcDataAdapter(sCmd);
                                DataTable rdt = new DataTable();
                                dap.Fill(rdt);
                                dap.Dispose();

                                foreach (DataRow rdr in rdt.Rows)
                                {
                                   
                                    sline += spos + "**";
                                  
                                    if (dtLast < Convert.ToDateTime(rdr["Createdate"].ToString()))//Convert.ToDateTime(rdr["Createdate"].ToString()))
                                    {
                                        dtLast = Convert.ToDateTime(rdr["Createdate"].ToString());
                                    }
                                    DateTime billdt = Convert.ToDateTime((rdr["Createdate"].ToString()));
                                   

                                    WriteData(rdr, tw, "R", sConn);

                                }
                                if (icnt > 0)
                                {
                                    tw.WriteLine("G020" +
                                       Strings.Right(icnt.ToString().PadLeft(4, '0'), 4) +
                                       Strings.Right(Math.Abs(dtot).ToString().Replace(".", "").PadLeft(15, '0'), 15));
                                }

                                tw.Close();
                                sline = " end ";
                                sConn.Close();
                                sConn.Dispose();
                                //chkFilter.Checked = false;
                                try
                                {
                                    if (ftp.ToString() != "")
                                    {
                                        Ftpconn.Host = ftp;
                                        Ftpconn.UserName = ftpusername;
                                        Ftpconn.Password = ftppassword;
                                        Ftpconn.Upload(Application.StartupPath.ToString() + "\\SyncFile\\" + TittleHeader + ".txt");
                                        sline = "4***";

                                        sLastDate = dtLast.ToString("dd/MMM/yyyy");                                       
                                        CreateDirectoryInAppPath("BackUp");
                                        File.Move(Application.StartupPath.ToString() + "\\SyncFile\\" + TittleHeader + ".txt", Application.StartupPath.ToString() + "\\BackUp\\" + TittleHeader + ".txt");
                                    }
                                }
                                catch (Exception ftperror)
                                {
                                    TextWriter twEr = new StreamWriter(Application.StartupPath.ToString() + "\\SyncError\\SyncError" + DateTime.Now.ToString("HHmmss") + ".txt");
                                    twEr.WriteLine(sline);
                                    twEr.WriteLine(ftperror.Message.ToString());
                                    twEr.Close();
                                
                                }

                            }//if count
                        TittleHeader = "";
                        SegmentHeader = "";
                        dspos.Tables[0].Rows[irow]["LastPooleddate"] = sLastDate;
                    } //for rows
                    dspos.Tables[0].AcceptChanges();
                    foreach (DataRow dr in dspos.Tables[0].Rows)
                    {
                        dr["Selected"] = true;
                    }
                    dspos.Tables[0].AcceptChanges();
                    dspos.WriteXml(Application.StartupPath + "\\Tenants.xml");

                }//if rows count
                chkFilter.Checked = false;
            }
            catch (Exception ex)
            {
                TextWriter twEr = new StreamWriter(Application.StartupPath.ToString()+"\\SyncError\\SyncError" + DateTime.Now.ToString("HHmmss") + ".txt");
                twEr.WriteLine(sline);
                twEr.WriteLine(ex.Message.ToString());
                twEr.Close();

               MessageBox.Show(ex.Message.ToString());

                
            }
            Cursor = Cursors.Arrow;

        }
        private void WriteData(DataRow dr, TextWriter tw, string Trantype, OdbcConnection sConn)
        {
            string sqty = "", stax = "", snet = "", sitem = "", sdis = "";
            decimal dretamt = 0, ddisamt = 0, dnetamt = 0, dinvamt = 0, dtaxamt = 0,dnet = 0;
            decimal damt = 0;
            OdbcCommand sCmd;
            OdbcDataReader sdr;

            dinvamt = Information.IsDBNull(dr["invAMT"]) ? 0 : Convert.ToDecimal(dr["invAMT"]);
            ddisamt = Information.IsDBNull(dr["discamt"]) ? 0 : Convert.ToDecimal(dr["discamt"]);
            dtaxamt = Information.IsDBNull(dr["taxamt"]) ? 0 : Convert.ToDecimal(dr["taxamt"]);
            dnet = Information.IsDBNull(dr["NetAmt"]) ? 0 : Convert.ToDecimal(dr["NetAmt"]);
            dretamt = Information.IsDBNull(dr["RetAmt"]) ? 0 : Convert.ToDecimal(dr["RetAmt"]);


            tw.WriteLine("G100" +
                          Strings.Left(dr["POSTill"].ToString().PadLeft(5, ' '), 5) +
                          Strings.Left(dr["Shift_no"].ToString().PadLeft(2, '0'), 2) +
                          Strings.Right(dr["Receipt_No"].ToString().Replace("/", "").Trim().PadLeft(10, ' '), 10) +
                          //Convert.ToDateTime(ChangeDateformat( dr["Createdate"].ToString())).ToString("yyyyMMddHHmm") +
                          Convert.ToDateTime((dr["Createdate"].ToString())).ToString("yyyyMMddHHmm") +
                          (Convert.ToDecimal(dinvamt) < 0 ? Strings.Right("-" + Math.Abs(Convert.ToDecimal(dinvamt)).ToString().Trim().PadLeft(15, '0').Replace(".", ""), 15) : Strings.Right(dinvamt.ToString().Trim().PadLeft(16, '0').Replace(".", ""), 15)) +
                          (Convert.ToDecimal(dtaxamt) < 0 ? Strings.Right("-" + Math.Abs(Convert.ToDecimal(dtaxamt)).ToString().Trim().PadLeft(15, '0').Replace(".", ""), 15) : Strings.Right(dtaxamt.ToString().Trim().PadLeft(16, '0').Replace(".", ""), 15)) +
                          (Convert.ToDecimal(ddisamt) < 0 ? Strings.Right("-" + Math.Abs(Convert.ToDecimal(ddisamt)).ToString().Trim().PadLeft(15, '0').Replace(".", ""), 15) : Strings.Right(ddisamt.ToString().Trim().PadLeft(16, '0').Replace(".", ""), 15)) +
                          (Convert.ToDecimal(dnet) < 0 ? Strings.Right("-" + Math.Abs(Convert.ToDecimal(dnet)).ToString().Trim().PadLeft(15, '0').Replace(".", ""), 15) : Strings.Right(dnet.ToString().Trim().PadLeft(16, '0').Replace(".", ""), 15)) +
                          (Convert.ToDecimal(dretamt) < 0 ? Strings.Right("-" + Math.Abs(Convert.ToDecimal(dretamt)).ToString().Trim().PadLeft(15, '0').Replace(".", ""), 15) : Strings.Right(dretamt.ToString().Trim().PadLeft(16, '0').Replace(".", ""), 15)) +
                          Strings.Left(dr["CustomerName"].ToString().Trim().PadLeft(50, ' '), 50) +
                          Strings.Left("".PadLeft(1, ' '), 1) +
                          Strings.Left("".ToString().PadLeft(12, ' '), 12) +
                          Strings.Left("".ToString().PadLeft(2, ' '), 2) +
                          Strings.Left("".ToString().PadLeft(1, ' '), 1) +
                          Strings.Left("".ToString().PadLeft(10, ' '), 10) +
                          Strings.Left("".ToString().PadLeft(10, ' '), 10) +
                          Strings.Left("".ToString().PadLeft(1, ' '), 1) +
                          Strings.Left(dr["TRANSACTION_STATUS"].ToString().PadLeft(10, ' '), 10));
            icnt += 1;
            if (Trantype == "R")
            {
                dtot -= Convert.ToDecimal(dr["RetAMT"]);
            }
            else
            {
                dtot += Convert.ToDecimal(dr["NetAMT"]);
            }

            //BillTrans
            sCmd = new OdbcCommand();
            //sCmd.CommandText = "select 'G111' as \"Record_Type\",item_code,item_name,to_char(Item_quantity,'9999.999') as \"item_qty\",0 as \"Disc_amt\",to_char(item_price,'9999999.99') as \"item_price\", to_char(tax_amount,'99999999.99') as \"Tax_amt\",tax_type,Item_category as \"item_catg\",tax_name,to_char(item_price,'99999999.99') as \"Net_amt\" from ILS2.MIAL_ITEMDETAIL Where Receipt_No='" + dr["Receipt_No"].ToString() + "'";
            sCmd.CommandText = "select 'G111' as \"Record_Type\",item_code,item_name,to_char (abs(Item_quantity),'9999.999') as \"item_qty\",0 as \"Disc_amt\",to_char(abs(item_price),'9999999.99') as \"item_price\", to_char(abs(tax_amount),'99999999.99') as \"Tax_amt\",tax_type,Item_category as \"item_catg\",tax_name,to_char(abs(item_price),'99999999.99') as \"Net_amt\" from ILS2." + spos + "_ITEMDETAIL Where Receipt_No='" + dr["Receipt_No"].ToString() + "'";
            sline = sCmd.CommandText;            
            sCmd.CommandType = CommandType.Text;
            sCmd.Connection = sConn;
            sCmd.CommandTimeout = 0;
            sdr = sCmd.ExecuteReader();

            while (sdr.Read())
            {
                if (Trantype == "R")
                {
                    sqty = Strings.Right("-" + Math.Abs(Convert.ToDecimal(sdr["ITEM_QTY"])).ToString().Replace(".", "").PadLeft(7, '0'), 8);
                    stax = Strings.Right("-" + Math.Abs(Convert.ToDecimal(sdr["TAX_AMT"])).ToString().Replace(".", "").PadLeft(14, '0'), 15);
                    snet = Strings.Right("-" + Math.Abs(Convert.ToDecimal(sdr["NET_AMT"])).ToString().Replace(".", "").PadLeft(14, '0'), 15);
                    sitem = Strings.Right("-" + Math.Abs(Convert.ToDecimal(sdr["ITEM_PRICE"])).ToString().PadLeft(16, '0').Replace(".", ""), 15);
                    sdis = Strings.Right("-" + Math.Abs(Convert.ToDecimal(sdr["DISC_AMT"])).ToString().Replace(".", "").PadLeft(14, '0'), 15);

                }
                else
                {
                    sqty = Strings.Right(Math.Abs(Convert.ToDecimal(sdr["ITEM_QTY"])).ToString().Replace(".", "").PadLeft(8, '0'), 8);
                    stax = Strings.Right(Math.Abs(Convert.ToDecimal(sdr["TAX_AMT"])).ToString().PadLeft(16, '0').Replace(".", ""), 15);
                    snet = Strings.Right(Math.Abs(Convert.ToDecimal(sdr["NET_AMT"])).ToString().PadLeft(16, '0').Replace(".", ""), 15);
                    sitem = Strings.Right(Math.Abs(Convert.ToDecimal(sdr["ITEM_PRICE"])).ToString().PadLeft(16, '0').Replace(".", ""), 15);
                    sdis = Strings.Right(Math.Abs(Convert.ToDecimal(sdr["DISC_AMT"])).ToString().PadLeft(16, '0').Replace(".", ""), 15);
                }


                tw.WriteLine(sdr["RECORD_TYPE"].ToString() +
                     Strings.Left(sdr["ITEM_CODE"].ToString().PadLeft(16, ' '), 16) +
                      Strings.Left(sdr["ITEM_NAME"].ToString().PadLeft(70, ' '), 70) +
                      sqty +
                      sitem +
                      Strings.Left(sdr["ITEM_CATG"].ToString().PadLeft(40, ' '), 40) +
                      Strings.Left(sdr["TAX_NAME"].ToString().PadLeft(40, ' '), 40) +
                      stax +
                      Strings.Left(sdr["TAX_TYPE"].ToString().PadLeft(1, ' '), 1) +
                      sdis +
                      snet);
            }
            sdr.Close();

            sline = "Pay";
            sCmd.CommandText = "SELECT 'G115' as \"Record_Type\",Payment_name,Exchange_rate,to_char(Payment_amount,'999999999999.99' ) as \"Amount\",'' as \"Curr_code\" from ILS2." + spos + "_payment Where Receipt_No='" + dr["Receipt_No"].ToString() + "'";
            sCmd.CommandType = CommandType.Text;
            sCmd.Connection = sConn;
            sCmd.CommandTimeout = 0;
            OdbcDataAdapter dap;
            dap = new OdbcDataAdapter(sCmd);
            sline += sCmd.CommandText;
            DataTable dtPay = new DataTable();
            dap.Fill(dtPay);
            dap.Dispose();
            Int32 ir = 0;
            Int32 ic = 0;
            for (ir = 0; ir < dtPay.Rows.Count; ir++)
            {
                sline = "pay";
                if (Convert.ToDecimal(dtPay.Rows[ir]["Amount"]) < 0)
                {
                    sline = "G115" +
                    Strings.Left(dtPay.Rows[ir]["PAYMENT_NAME"].ToString().PadLeft(40, ' '), 40) +
                    Strings.Left(dtPay.Rows[ir]["CURR_CODE"].ToString().PadLeft(3, ' '), 3) +
                    Strings.Left(dtPay.Rows[ir]["Exchange_Rate"].ToString().Trim().PadLeft(9, '0').Replace(".", ""), 8) +
                    "-" + Strings.Left(Math.Abs(Convert.ToDecimal(dtPay.Rows[ir]["Amount"].ToString().Trim())).ToString().PadLeft(15, '0').Replace(".", ""), 14);

                    tw.WriteLine("G115" +
                    Strings.Left(dtPay.Rows[ir]["PAYMENT_NAME"].ToString().PadLeft(40, ' '), 40) +
                    Strings.Left(dtPay.Rows[ir]["CURR_CODE"].ToString().PadLeft(3, ' '), 3) +
                    Strings.Left(dtPay.Rows[ir]["Exchange_Rate"].ToString().PadLeft(9, '0').Replace(".", ""), 8) +
                    "-" + Strings.Left(Math.Abs(Convert.ToDecimal(dtPay.Rows[ir]["Amount"].ToString())).ToString().Trim().PadLeft(15, '0').Replace(".", ""), 14));
                }
                else
                {
                    sline = ir.ToString();
                    tw.WriteLine("G115" +
                    Strings.Left(dtPay.Rows[ir]["PAYMENT_NAME"].ToString().PadLeft(40, ' '), 40) +
                    Strings.Left(dtPay.Rows[ir]["CURR_CODE"].ToString().PadLeft(3, ' '), 3) +
                    Strings.Left(dtPay.Rows[ir]["Exchange_Rate"].ToString().PadLeft(9, '0').Replace(".", ""), 8) +
                    Strings.Left(dtPay.Rows[ir]["Amount"].ToString().Trim().PadLeft(16, '0').Replace(".", ""), 15));
                }
            }
            sline = "pay aft";
            sdr.Close();


        }
        private string ChangeDateformat(string dt)
        {
            string dtt;
            string dd = Microsoft.VisualBasic.Strings.Left(dt, 3);
            string mm = dt.Substring(3, 3);
            string yy = dt.Substring(6, 4);
            dtt = mm + dd + yy;
            return dtt;
        }
        private void UploadFiles()
        {
            string[] files;
            CreateDirectoryInAppPath("BackUp");

            if (MainModule.gsFTP != "")
            {
                files = Directory.GetFiles("C:\\SyncFiles", "*.txt");
                foreach (string file in files)
                {
                    try
                    {
                        Ftpconn.Host = MainModule.gsFTP;
                        Ftpconn.UserName = MainModule.gsFTPUserName;
                        Ftpconn.Password = MainModule.gsFTPUserPWD;
                        //Ftpconn.Upload("C:\\SyncFiles\\" + TittleHeader + ".txt");
                        Ftpconn.Upload(file );

                        File.Move(file , Application.StartupPath.ToString()+"\\BackUp\\" + TittleHeader + ".txt");
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
          
        }

        private void writelog(string filename, string txt)
        {
            FileStream fs = new FileStream(Application.StartupPath + "\\" + filename + ".txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.BaseStream.Seek(0, SeekOrigin.End);
            sw.WriteLine(txt);
            sw.Flush();
            sw.Close();
        }

        
        private void sEndingTime()
        {
            switch (MainModule.gsFrequency)
            {
                case "Every 15 Minutes":
                    sEndSystemTime  = String.Format("{0:dd/MMM/yyyy HH:mm:ss tt}", dselectDate.AddMinutes(15));
                    sEndTime = String.Format("{0:dd/MMM/yyyy HH:mm:ss tt}", dServerDate.AddMinutes(15)); 
                    break;
                case "Every 30 Minutes":
                    sEndSystemTime = String.Format("{0:dd/MMM/yyyy HH:mm:ss tt}", dselectDate.AddMinutes(30));
                    sEndTime = String.Format("{0:dd/MMM/yyyy HH:mm:ss tt}", dServerDate.AddMinutes(30));
                    break;
                case "Every 1 Hour":
                    sEndSystemTime = String.Format("{0:dd/MMM/yyyy HH:mm:ss tt}", dselectDate.AddHours(1));
                    sEndTime = String.Format("{0:dd/MMM/yyyy HH:mm:ss tt}", dServerDate.AddHours(1));
                    break;
                case "Every 2 Hour":
                    sEndSystemTime = String.Format("{0:dd/MMM/yyyy HH:mm:ss tt}", dselectDate.AddHours(2));
                    sEndTime = String.Format("{0:dd/MMM/yyyy HH:mm:ss tt}", dServerDate.AddHours(2));
                    break;
                case "Every 4 Hour":
                    sEndSystemTime = String.Format("{0:dd/MMM/yyyy HH:mm:ss tt}", dselectDate.AddHours(4));
                    sEndTime = String.Format("{0:dd/MMM/yyyy HH:mm:ss tt}", dServerDate.AddHours(4));
                    break;
                case "End of Day":
                    sEndSystemTime = String.Format("{0:dd/MMM/yyyy HH:mm:ss tt}", dselectDate.AddDays(1));
                    sEndTime = String.Format("{0:dd/MMM/yyyy HH:mm:ss tt}", dServerDate.AddDays(1));
                    break;
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
            dselectDate = DateTime.Now;
            if (MainModule.gsFrequency != "End of Day")
            {
                if (Convert.ToDateTime(sEndSystemTime) < dselectDate) sEndSystemTime = dselectDate.ToString ("dd/MMM/yyyy HH:mm:ss tt");// Ravi -to avoid restart of the Sync tool when Systemdate is changed to POST date after dayend
                if (sEndSystemTime  == String.Format("{0:dd/MMM/yyyy HH:mm:ss tt}", dselectDate))
                //if (sEndSystemTime == dselectDate.ToString ("dd/MMM/yyyy HH:mm:ss tt"))
                {
                    //MessageBox.Show(sEndSystemTime);
                    //MessageBox.Show(dselectDate.ToString("dd/MMM/yyyy HH:mm:ss tt"));
                    dServerDate = Convert.ToDateTime(sEndTime);
                    btGenerateFile_Click(sender, e);
                    sEndingTime();
                }
            }
        }

        private void CreateDirectoryInAppPath(string  sDirecName)
        {
             if (Directory.Exists( Application.StartupPath.ToString()+"\\" + sDirecName )== false)
             {
                 Directory.CreateDirectory(Application.StartupPath.ToString() + "\\" + sDirecName);
             }
        }

        private void btnFileDateWiseGenerate_Click(object sender, EventArgs e)
        {

        }
 
        private void chkFilter_CheckedChanged(object sender, EventArgs e)
        {
            dgvTen.DataSource = null;
            dgvTen.Refresh();
            if (chkFilter.Checked == true)
            {
                panel1.Visible = true;
                //btGenerateFile.Top = 202;
                //this.Height = 318;
                dspos = new DataSet();
                dspos.ReadXml(Application.StartupPath + "\\Tenants.xml");
                if (dspos.Tables.Count <= 0) return;
                dtpos = new DataTable();
                dtpos = dspos.Tables[0].Clone();
                foreach (DataRow dr in dspos.Tables[0].Rows)
                {
                    dtpos.ImportRow(dr);
                }
               //// dgvTen.Rows.Clear();
                dgvTen.DataSource = dtpos;// dspos.Tables[0];
                foreach (DataGridViewRow row in dgvTen.Rows)
                {
                    row.Cells[0].Value = true;
                }
                dgvTen.Refresh();
                
                dgvTen.Columns[1].Visible = true;
                dgvTen.Columns[2].Visible = false;
                dgvTen.Columns[3].Visible = false;
                dgvTen.Columns[4].Visible = false;
                dgvTen.Columns[5].Visible = false;
                dgvTen.Columns[6].Visible = false;
                dgvTen.Columns[7].Visible = false;
                dgvTen.Columns[8].Visible = false;
                this.Height = 470;
                panel1.Location = new Point(5, 136);
                btGenerateFile.Top = 347;
                btClose.Top = 388;
            }
            else
            {
                //dgvTen.Rows.Clear();
                panel1.Visible = false;
                btGenerateFile.Top = 137;
                btClose.Top = 178;
                this.Height = 262;
            }
            btClose.Top = btGenerateFile.Top + btGenerateFile.Height + 5;
        }

        private void dgvTen_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dgvTen_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
            ch1 = (DataGridViewCheckBoxCell)dgvTen.Rows[dgvTen.CurrentRow.Index].Cells[0];

            if (ch1.Value == null)
                ch1.Value = false;
            switch (ch1.Value.ToString())
            {
                case "True":
                    ch1.Value = false;
                    //dspos.Tables[0].Rows[dgvTen.CurrentCell.RowIndex]["Selected"] = false;
                    //dtpos.Rows[dgvTen.CurrentCell.RowIndex]["Selected"] = false;
                    break;
                case "False":
                    ch1.Value = true;
                    //dspos.Tables[0].Rows[dgvTen.CurrentCell.RowIndex]["Selected"] = true ;
                    //dtpos.Rows[dgvTen.CurrentCell.RowIndex]["Selected"] = true ;
                     break;
            }
          
           // dspos.Tables[0].AcceptChanges();
        }
        
    }
}
