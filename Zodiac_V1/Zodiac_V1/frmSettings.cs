using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.IO;

namespace MASSync
{
    public partial class frmSettings : Form
    {
        DataTable dt = new DataTable("Tenants");
        public frmSettings()
        {
            InitializeComponent();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            Configuration config =  ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            config.AppSettings.Settings["Server"].Value = txtDatabase.Text;
            config.AppSettings.Settings["User"].Value = txtUserName.Text;
            config.AppSettings.Settings["Password"].Value = MainModule.EncPassword(txtPassword.Text);
           // config.AppSettings.Settings["Database"].Value = txtDatabase.Text;
            config.AppSettings.Settings["FTP"].Value = txtFTP.Text;
            config.AppSettings.Settings["FTPUserName"].Value = txtFtpUserName.Text;
            config.AppSettings.Settings["FTPUserPWD"].Value = MainModule.EncPassword(txtFtpUserPwd.Text);
            //config.AppSettings.Settings["WebServiceURL"].Value = txtWebserviceURL.Text;
            config.AppSettings.Settings["Frequency"].Value = cboFrequency.Text;
            config.AppSettings.Settings["TenantID"].Value = txtTenantID.Text;
            config.AppSettings.Settings["TerminalID"].Value = txtTerminalID.Text;
            //config.AppSettings.Settings["Application"].Value = cboApplicationName.Text;
            config.AppSettings.Settings["LiveFrom"].Value = dtLive.Value.ToString("dd/MMM/yyyy");
           // config.AppSettings.Settings["LastPooledDate"].Value = dtLive.Value.ToString("dd/MMM/yyyy");

            config.Save();

            //MainModule.gsApplicationName=cboApplicationName.Text;
            MainModule.gsServer = txtDatabase.Text;
            //MainModule.gsDatabase=
            MainModule.gsUser=txtUserName.Text;
            MainModule.gsPassword=txtPassword.Text;
            MainModule.gsFTP=txtFTP.Text;
            MainModule.gsFTPUserName=txtFtpUserName.Text;
            MainModule.gsFTPUserPWD=txtFtpUserPwd.Text;
            MainModule.gsFrequency=cboFrequency.Text;
            MainModule.gsTenantID=txtTenantID.Text;
            MainModule.gsTerminalID=txtTerminalID.Text;
            //MainModule.gsLastPooledDate = dtLive.Value.ToString("dd/MMM/yyyy");
            MainModule.gsLiveFrom = dtLive.Value.ToString("dd/MMM/yyyy");

            MainModule.oConnString = "Dsn=" + MainModule.gsServer + ";" +
                                        "Uid=" + MainModule.gsUser + ";" +
                                        "Pwd=" + MainModule.gsPassword + ";";
            
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            ds.WriteXml(Application.StartupPath + "\\Tenants.xml");
            this.Close();
        }

        

        private void frmSettings_Load(object sender, EventArgs e)
        {
          

           // DateTime dst=Convert.ToDateTime( String.Format("{0:MM/dd/yyyy}",dtt));

            CreateStruc();
            if (File.Exists(Application.StartupPath + "\\Tenants.xml"))
            {
                DataSet dspos = new DataSet();
                dspos.ReadXml(Application.StartupPath + "\\Tenants.xml");
                if (dspos.Tables.Count > 0)
                {
                    foreach (DataRow dr in dspos.Tables[0].Rows)
                    {
                        dt.ImportRow(dr);
                    }
                    //dt.AcceptChanges();
                }
            }
            dgvTen.Refresh();
            //txtServerName.Text = MainModule.gsServer;
            txtDatabase.Text = MainModule.gsServer; ;//MainModule.gsDatabase;
            txtUserName.Text = MainModule.gsUser;
            txtPassword.Text =  MainModule.gsPassword;
            txtFTP.Text = MainModule.gsFTP;
            txtFtpUserName .Text = MainModule.gsFTPUserName ;
            txtFtpUserPwd .Text = MainModule.gsFTPUserPWD ;
            cboFrequency.Text = MainModule.gsFrequency;
            txtTenantID.Text = "";// MainModule.gsTenantID;
           // txtTerminalID.Text = MainModule.gsTerminalID;
            if (MainModule.gsLiveFrom == "") MainModule.gsLiveFrom = DateTime.Today.ToString();
            dtLive.Value = Convert.ToDateTime(MainModule.gsLiveFrom);
            txtTerminalID.Text = "";// DateTime.Today.Year.ToString() + (DateTime.Today.Year + 1).ToString();
        }

        private void frmSettings_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{tab}");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] sdts;
            string sdt;
            if (txtTenantID.Text == "")
            {
                txtTenantID.Focus();
                return;
            }
            if (txtTerminalID.Text == "")
            {
                txtTerminalID.Focus();
                return;
            }
            if (txtDatabase.Text == "")
            {
                txtDatabase.Focus();
                return;
            }

            if (button1.Text == "Add")
            {
                sdts = txtTerminalID.Text.Split(',');
                for (int i = 0; i < sdts.Length; i++)
                {
                    sdts[i] = dtLive.Value.ToString("dd/MMM/yyyy");
                }
                sdt = String.Join(",", sdts);
                dt.Rows.Add(txtTenantID.Text, txtTerminalID.Text, txtbrand.Text, txtDatabase.Text, txtUserName.Text,MainModule.EncPassword(txtPassword.Text),txtFTP.Text,txtFtpUserName.Text,MainModule.EncPassword(txtFtpUserPwd.Text), sdt, true);
                dt.AcceptChanges();
            }
            else
            {
                DataRow[] drs = dt.Select("TenantId='" + txtTenantID.Tag + "'", "");
                if (drs.Length > 0)
                {
                    drs[0][0] = txtTenantID.Text;
                    drs[0][1] = txtTerminalID.Text;
                    drs[0][2] = txtbrand.Text;
                    drs[0][3] = txtDatabase.Text;
                    drs[0][4] = txtUserName.Text;
                    drs[0][5] =MainModule.EncPassword( txtPassword.Text);
                    drs[0][6] = txtFTP.Text;
                    drs[0][7] = txtFtpUserName.Text;
                    drs[0][8] = MainModule.EncPassword( txtFtpUserPwd.Text);                    
                    drs[0][9] = dtLive.Value.ToString("dd/MMM/yyyy");
                    drs[0][10] = true;
                    dt.AcceptChanges();
                }
            }
            //txtTenantID.Tag = "";
            //txtTenantID.Text = "";
            //txtTerminalID.Text = "";
            //txtPassword.Text = "";
            //txtUserName.Text = "";
            //txtDatabase.Text = "";
            //txtbrand.Text = "";
            button1.Text = "Add";
            txtTenantID.Focus();

        }
        void CreateStruc()
        {
            dt.Columns.Add("TenantId",typeof(string));
            dt.Columns.Add("BranchID", typeof(string));
            dt.Columns.Add("Brand", typeof(string));
            dt.Columns.Add("DSN", typeof(string));
            dt.Columns.Add("Uid", typeof(string));
            dt.Columns.Add("Pwd", typeof(string));
            dt.Columns.Add("FTP", typeof(string));
            dt.Columns.Add("FTPUserName", typeof(string));
            dt.Columns.Add("FTPPassword", typeof(string));
            dt.Columns.Add("LastPooleddate", typeof(string));
            dt.Columns.Add("Selected", typeof(bool));
            dgvTen.DataSource = dt;
            dgvTen.Columns[10].Visible = false;

        }

        private void dgvTen_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTenantID.Tag = dt.Rows[dgvTen.CurrentRow.Index][0].ToString();
            txtTenantID.Text = dt.Rows[dgvTen.CurrentRow.Index][0].ToString();
            txtTerminalID.Text = dt.Rows[dgvTen.CurrentRow.Index][1].ToString();
            txtbrand.Text = dt.Rows[dgvTen.CurrentRow.Index][2].ToString();
            txtDatabase.Text = dt.Rows[dgvTen.CurrentRow.Index][3].ToString();
            txtUserName.Text = dt.Rows[dgvTen.CurrentRow.Index][4].ToString();
            txtPassword.Text = MainModule.DecPassword(dt.Rows[dgvTen.CurrentRow.Index][5].ToString());
            txtFTP.Text = dt.Rows[dgvTen.CurrentRow.Index][6].ToString();
            txtFtpUserName.Text = dt.Rows[dgvTen.CurrentRow.Index][7].ToString();
            txtFtpUserPwd.Text = MainModule.DecPassword(dt.Rows[dgvTen.CurrentRow.Index][8].ToString());
            button1.Text = "Update";
            txtTenantID.Focus();
        }
    }
}
