using System;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Reporting.WebForms;

namespace Machine.Web
{
    public static class CommonUtil
    {
        public static string con = System.Configuration.ConfigurationManager.ConnectionStrings["strCon"].ConnectionString;
        
        public static void ForceDownload(this HttpResponse Response, string virtualPath, string fileName, string cType = null)
        {
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment; filename=" + fileName);
            Response.WriteFile(virtualPath);

            if (string.IsNullOrEmpty(cType))
                Response.ContentType = "";
            else if (cType == "pdf")
                Response.ContentType = "application/pdf";
            else if (cType == "xls")
                Response.ContentType = "application/vnd.ms-excel";
            else if (cType == "doc")
                Response.ContentType = "application/msword";

            Response.End();
        }

        public static void ExpFile(string fPath, string FullExt, LocalReport rpt, HttpResponse Res)
        {
            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string extension;

            byte[] bytes = rpt.Render(FullExt, null, out mimeType, out encoding, out extension, out streamids, out warnings);

            // string fPath = Server.MapPath("~/download/report." + ext.ToLower());
            FileStream fs = new FileStream(fPath, FileMode.Create);
            fs.Write(bytes, 0, bytes.Length);
            fs.Close();

            if (File.Exists(fPath))
                Res.ForceDownload(fPath, Path.GetFileName(fPath), Path.GetExtension(fPath));
        }

        public static void PrintFile(LocalReport rpt)
        {
            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string extension;

            if (File.Exists(HttpContext.Current.Server.MapPath("output.pdf")))
                File.Delete(HttpContext.Current.Server.MapPath("output.pdf"));

            byte[] bytes = rpt.Render("PDF", null, out mimeType, out encoding, out extension, out streamids, out warnings);
            FileStream fs = new FileStream(HttpContext.Current.Server.MapPath("output.pdf"), FileMode.Create);
            fs.Write(bytes, 0, bytes.Length);
            fs.Close();

            //Open exsisting pdf
            Document document = new Document(PageSize.LETTER);
            PdfReader reader = new PdfReader(HttpContext.Current.Server.MapPath("output.pdf"));

            //Getting a instance of new pdf wrtiter
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(HttpContext.Current.Server.MapPath("Print.pdf"), FileMode.Create));
            document.Open();

            PdfContentByte cb = writer.DirectContent;

            int i = 0;
            int p = 0;
            int n = reader.NumberOfPages;
            Rectangle psize = reader.GetPageSize(1);
            float width = psize.Width;
            float height = psize.Height;

            //Add Page to new document
            while (i < n)
            {
                document.NewPage();
                p++;
                i++;
                PdfImportedPage page1 = writer.GetImportedPage(reader, i);
                cb.AddTemplate(page1, 0, 0);
            }

            //Attach javascript to the document
            PdfAction jAction = PdfAction.JavaScript("this.print(true);\r", writer);
            writer.AddJavaScript(jAction);
            document.Close();
        }

        public static void setControl(string strArr, HtmlInputCheckBox chk, ListBox lst, ListBox lstSel, HtmlInputHidden hdn, TextBox txt)
        {
            if (strArr != "")
            {
                string strName = string.Empty;
                chk.Checked = true;
                if (strArr.Contains(","))
                {
                    string[] arr = strArr.Split(',');
                    foreach (string str in arr)
                    {
                        strName += "," + lst.Items.FindByValue(str).Text;
                        lstSel.Items.Add(lst.Items.FindByValue(str));
                        lst.Items.Remove(lst.Items.FindByValue(str));
                    }
                }
                else
                {
                    strName += "," + lst.Items.FindByValue(strArr).Text;
                    lstSel.Items.Add(lst.Items.FindByValue(strArr));
                    lst.Items.Remove(lst.Items.FindByValue(strArr));
                }
                hdn.Value = strArr;
                txt.Text = strName.Remove(0, 1).Trim();
            }
        }

        public static void FillFilter(int FilterId, HtmlInputText txtStTime, HtmlInputText txtEndTime,
           HtmlInputCheckBox chkBranch, ListBox lstBranch, ListBox lstBranchSel, HtmlInputHidden hBranches, TextBox tbBranches,
           HtmlInputCheckBox chkButton, ListBox lstButton, ListBox lstButtonSel, HtmlInputHidden hButtons, TextBox tbButtons,
           HtmlInputCheckBox chkCategories, ListBox lstCategory, ListBox lstCategorySel, HtmlInputHidden hCategory, TextBox tbCategories,
           HtmlInputCheckBox chkCounter, ListBox lstCounter, ListBox lstCounterSel, HtmlInputHidden hCounter, TextBox tbCounter,
           HtmlInputCheckBox chkUsers, ListBox lstUsers, ListBox lstUsersSel, HtmlInputHidden hUsers, TextBox tbUsers,
           HtmlInputCheckBox chkTransactionTime, DropDownList ddlTransFirst, TextBox tbTransFirst, DropDownList ddlTransSecond,
           TextBox tbTransSecond, DropDownList ddlTransThird, TextBox tbTransThird, HtmlInputCheckBox chkWaitingTime, DropDownList ddlWaitingFirst,
           TextBox tbWaitingFirst, DropDownList ddlWaitingSecond, TextBox tbWaitingSecond, DropDownList ddlWaitingThird, TextBox tbWaitingThird,
            CheckBox chkAverage, CheckBox chkMax, CheckBox chkExcludeWeekend)
        {
            DAL.Filter fl = BAL.BLFilter.GetDetail(CommonUtil.con, FilterId);
            if (fl != null)
            {
                #region Lists

                if (fl.StrTime != "")
                {
                    if (fl.StrTime.Contains("$"))
                    {
                        string[] arr = fl.StrTime.Split('$');

                        txtStTime.Value = arr[0];
                        txtEndTime.Value = arr[1];
                    }
                    else
                    {
                        txtStTime.Value = fl.StrTime;
                    }
                }

                if (chkBranch != null)
                    CommonUtil.setControl(fl.StrBranches, chkBranch, lstBranch, lstBranchSel, hBranches, tbBranches);

                if (chkButton != null)
                    CommonUtil.setControl(fl.StrButtons, chkButton, lstButton, lstButtonSel, hButtons, tbButtons);

                if (chkCategories != null)
                    CommonUtil.setControl(fl.StrCategories, chkCategories, lstCategory, lstCategorySel, hCategory, tbCategories);

                if (chkCounter != null)
                    CommonUtil.setControl(fl.StrCounter, chkCounter, lstCounter, lstCounterSel, hCounter, tbCounter);

                if (chkUsers != null)
                    CommonUtil.setControl(fl.StrUsers, chkUsers, lstUsers, lstUsersSel, hUsers, tbUsers);

                #endregion

                if (chkTransactionTime != null)
                {
                    if (!string.IsNullOrEmpty(fl.TransactionTime))
                    {
                        chkTransactionTime.Checked = true;
                        if (fl.TransactionTime.Contains("#"))
                        {
                            string[] row = fl.TransactionTime.Split('#');
                            for (int i = 0; i < row.Length; i++)
                            {
                                if (row[i].Contains("$"))
                                {
                                    string[] col = row[i].Split('$');
                                    if (i == 0)
                                    {
                                        ddlTransFirst.SelectedValue = col[0];
                                        tbTransFirst.Text = col[1];
                                    }
                                    else if (i == 1)
                                    {
                                        ddlTransSecond.SelectedValue = col[0];
                                        tbTransSecond.Text = col[1];
                                    }
                                    else if (i == 2)
                                    {
                                        ddlTransThird.SelectedValue = col[0];
                                        tbTransThird.Text = col[1];
                                    }
                                }
                            }
                        }
                        else if (fl.TransactionTime.Contains("$"))
                        {
                            string[] col = fl.TransactionTime.Split('$');
                            ddlTransFirst.SelectedValue = col[0];
                            tbTransFirst.Text = col[1];
                        }
                    }
                }
                if (chkWaitingTime != null)
                {
                    if (!string.IsNullOrEmpty(fl.WaitingTime))
                    {
                        chkWaitingTime.Checked = true;
                        if (fl.WaitingTime.Contains("#"))
                        {
                            string[] row = fl.WaitingTime.Split('#');
                            for (int i = 0; i < row.Length; i++)
                            {
                                if (row[i].Contains("$"))
                                {
                                    string[] col = row[i].Split('$');
                                    if (i == 0)
                                    {
                                        ddlWaitingFirst.SelectedValue = col[0];
                                        tbWaitingFirst.Text = col[1];
                                    }
                                    else if (i == 1)
                                    {
                                        ddlWaitingSecond.SelectedValue = col[0];
                                        tbWaitingSecond.Text = col[1];
                                    }
                                    else if (i == 2)
                                    {
                                        ddlWaitingThird.SelectedValue = col[0];
                                        tbWaitingThird.Text = col[1];
                                    }
                                }
                            }
                        }
                        else if (fl.WaitingTime.Contains("$"))
                        {
                            string[] col = fl.WaitingTime.Split('$');
                            ddlWaitingFirst.SelectedValue = col[0];
                            tbWaitingFirst.Text = col[1];
                        }
                    }
                }
                chkAverage.Checked = fl.IsAverage;
                chkMax.Checked = fl.ISMax;
                chkExcludeWeekend.Checked = fl.IsExcludeWeekend;
            }
        }

        public static void FillFilter(int FilterId, HtmlInputText txtStTime,
            HtmlInputCheckBox chkBranch, ListBox lstBranch, ListBox lstBranchSel, HtmlInputHidden hBranches, TextBox tbBranches)
        {
            DAL.Filter fl = BAL.BLFilter.GetDetail(CommonUtil.con, FilterId);
            if (fl != null)
            {
                if (fl.StrTime != "")
                {
                    if (fl.StrTime.Contains("$"))
                    {
                        string[] arr = fl.StrTime.Split('$');
                        txtStTime.Value = arr[0];
                    }
                    else
                    {
                        txtStTime.Value = fl.StrTime;
                    }
                }

                if (chkBranch != null)
                    CommonUtil.setControl(fl.StrBranches, chkBranch, lstBranch, lstBranchSel, hBranches, tbBranches);
            }
        }

        public static string GetWeekdays()
        {
            string strWeekdays = string.Empty;
            DataSet dsWeekdays = DAL.Common.ExtDataset(con, "Select Name from tblWeekend where IsWeekend =0 order by SNo");
            foreach (DataRow dr in dsWeekdays.Tables[0].Rows)
                strWeekdays += "," + dr["Name"].ToString();

            return strWeekdays.Contains(",") == true ? strWeekdays.Remove(0, 1) : strWeekdays;
        }

        public static string GetUserBranch(int UserId, string SelBrc)
        {
            string BrcFilter = string.Empty;
            DataSet brnch = DAL.Common.ExtDataset(con, "Select BRANCHCODE from xq.dbo.xqPreferences where BRANCHCODE not in " +
                                "(Select BranchId from tblGroupBranch b inner join tblUserGroup u on b.GroupId= u.GroupId and u.UserId =" + UserId + ")");

            if (brnch != null && brnch.Tables.Count > 0 && brnch.Tables[0] != null && brnch.Tables[0].Rows.Count > 0)
            {
                string Branches = string.Empty;
                foreach (DataRow dr in brnch.Tables[0].Rows)
                    Branches += "," + dr["BRANCHCODE"].ToString();

                if (Branches.Replace(",", "").Trim() != "")
                {
                    Branches = Branches.Remove(0, 1);
                    BrcFilter = " And BRANCHCODE not in(" + Branches + ")";
                }
            }
            if (SelBrc.Replace(",", "").Trim() != "")
                BrcFilter += " And BRANCHCODE in(" + SelBrc + ")";

            return BrcFilter;
        }
        public static string GetUserBranch(int UserId, string SelBrc, HtmlInputHidden hCounters, HtmlInputHidden hUsers, HtmlInputHidden hCategory)
        {
            string BrcFilter, cntrFilter, usrFilter, catFilter;
            BrcFilter = cntrFilter = usrFilter = catFilter = "";
            DataSet brnch = DAL.Common.ExtDataset(con, "Select BRANCHCODE from xq.dbo.xqPreferences where BRANCHCODE not in " +
                                "(Select BranchId from tblGroupBranch b inner join tblUserGroup u on b.GroupId= u.GroupId and u.UserId =" + UserId + ")");

            if (brnch != null && brnch.Tables.Count > 0 && brnch.Tables[0] != null && brnch.Tables[0].Rows.Count > 0)
            {
                string Branches = string.Empty;
                foreach (DataRow dr in brnch.Tables[0].Rows)
                    Branches += "," + dr["BRANCHCODE"].ToString();

                if (Branches.Replace(",", "").Trim() != "")
                {
                    Branches = Branches.Remove(0, 1);
                    BrcFilter = " And BRANCHCODE not in(" + Branches + ")";
                }
            }

            if (SelBrc.Replace(",", "").Trim() != "")
                BrcFilter += " And BRANCHCODE in(" + SelBrc + ")";

            if (hCounters.Value != "")
                cntrFilter = " DESKNO in (" + hCounters.Value + ")";
            else
                cntrFilter = "1=1";
            //--------- Counter or DeskNo Filter according to Branch -------------------//
            DataSet cntr = DAL.Common.ExtDataset(con, "Select Distinct DESKNO from xqBranchDesk where " + cntrFilter + BrcFilter);
            if (cntr != null && cntr.Tables.Count > 0 && cntr.Tables[0] != null && cntr.Tables[0].Rows.Count > 0)
            {
                hCounters.Value = "";
                foreach (DataRow dr in cntr.Tables[0].Rows)
                    hCounters.Value += "," + dr["DESKNO"].ToString();

                if (hCounters.Value.Replace(",", "").Trim() != "")
                    hCounters.Value = hCounters.Value.Remove(0, 1);
            }
            else
                hCounters.Value = "0";

            //--------- User Filter accroding to Branch -------------------//
            if (hUsers.Value != "")
                usrFilter = " USERCODE in (" + hUsers.Value + ")";
            else
                usrFilter = "1=1";

            DataSet usr = DAL.Common.ExtDataset(con, "Select Distinct USERCODE from xqUserBranch  where " + usrFilter + BrcFilter);
            if (usr != null && usr.Tables.Count > 0 && usr.Tables[0] != null && usr.Tables[0].Rows.Count > 0)
            {
                hUsers.Value = "";
                foreach (DataRow dr in usr.Tables[0].Rows)
                    hUsers.Value += "," + dr["USERCODE"].ToString();

                if (hUsers.Value.Replace(",", "").Trim() != "")
                    hUsers.Value = hUsers.Value.Remove(0, 1);
            }
            else
                hUsers.Value = "0";

            //--------- Category Filter accroding to Branch -------------------//
            if (hCategory.Value != "")
                catFilter = " CatId in (" + hCategory.Value + ")";
            else
                catFilter = "1=1";

            DataSet cat = DAL.Common.ExtDataset(con, "Select Distinct CatId from tblCatRelation where " + catFilter + BrcFilter.Replace("BRANCHCODE", "BranchId"));
            if (cat != null && cat.Tables.Count > 0 && cat.Tables[0] != null && cat.Tables[0].Rows.Count > 0)
            {
                hCategory.Value = "";
                foreach (DataRow dr in cat.Tables[0].Rows)
                    hCategory.Value += "," + dr["CatId"].ToString();

                if (hCategory.Value.Replace(",", "").Trim() != "")
                    hCategory.Value = hCategory.Value.Remove(0, 1);
            }
            else
                hCategory.Value = "0";

            return BrcFilter;
        }

        public static string FillBranch(int UserId, ListBox lstBranch, ListBox lstButton, ListBox lstCategory, ListBox lstCounter, ListBox lstUsers, HtmlInputText txtStTime, HtmlInputText txtEndTime)
        {
            string Branches = string.Empty;
            DataSet brnch = DAL.Common.ExtDataset(con, "Select BRANCHCODE,BRANCHNAME from xq.dbo.xqPreferences where BRANCHCODE in " +
                        "(Select BranchId from tblGroupBranch b inner join tblUserGroup u on b.GroupId= u.GroupId and u.UserId=" + UserId + ") Order By BRANCHNAME");

            if (brnch != null && brnch.Tables.Count > 0)
            {
                foreach (DataRow dr in brnch.Tables[0].Rows)
                    Branches += "," + dr["BRANCHCODE"].ToString();

                Branches = Branches.Contains(",") == true ? Branches.Remove(0, 1) : Branches;
            }

            if (lstBranch != null)
            {
                lstBranch.DataSource = brnch;
                lstBranch.DataTextField = "BRANCHNAME";
                lstBranch.DataValueField = "BRANCHCODE";
                lstBranch.DataBind();
            }

            if (lstButton != null)
            {
                lstButton.DataSource = DAL.Common.ExtDataset(CommonUtil.con, "Select BUTTONCODE,BUTTONNAME from xqButton where BUTTONCODE >0 Order By BUTTONNAME ");
                lstButton.DataTextField = "BUTTONNAME";
                lstButton.DataValueField = "BUTTONCODE";
                lstButton.DataBind();
            }

            if (lstCategory != null)
            {
                lstCategory.DataSource = DAL.Common.ExtDataset(CommonUtil.con, "Select CATCODE,CATNAME from xqCategory where CATCODE > 0 Order By CATNAME");
                lstCategory.DataTextField = "CATNAME";
                lstCategory.DataValueField = "CATCODE";
                lstCategory.DataBind();
            }

            if (lstCounter != null)
            {
                lstCounter.DataSource = DAL.Common.ExtDataset(CommonUtil.con, "Select DESKNO from xqDesk");
                lstCounter.DataTextField = "DESKNO";
                lstCounter.DataValueField = "DESKNO";
                lstCounter.DataBind();
            }

            if (lstUsers != null)
            {
                lstUsers.DataSource = DAL.Common.ExtDataset(CommonUtil.con, "Select USERCODE,USERNAME from xqUser Order By USERNAME");
                lstUsers.DataTextField = "USERNAME";
                lstUsers.DataValueField = "USERCODE";
                lstUsers.DataBind();
            }

            if (txtStTime != null && txtStTime.Value.Trim() == "")
                txtStTime.Value = DateTime.Now.ToString("MM/dd/yyyy") + " 07:00";

            if (txtEndTime != null && txtEndTime.Value.Trim() == "")
                txtEndTime.Value = DateTime.Now.ToString("MM/dd/yyyy") + " 23:59";

            return Branches;
        }

        public static string FillBranch(int UserId, ListBox lstBranch, HtmlInputText txtStTime)
        {
            string Branches = string.Empty;
            DataSet brnch = DAL.Common.ExtDataset(con, "Select BRANCHCODE,BRANCHNAME from xq.dbo.xqPreferences where BRANCHCODE in " +
                        "(Select BranchId from tblGroupBranch b inner join tblUserGroup u on b.GroupId= u.GroupId and u.UserId=" + UserId + ") Order By BRANCHNAME");

            if (brnch != null && brnch.Tables.Count > 0)
            {
                foreach (DataRow dr in brnch.Tables[0].Rows)
                    Branches += "," + dr["BRANCHCODE"].ToString();

                Branches = Branches.Contains(",") == true ? Branches.Remove(0, 1) : Branches;
            }

            if (lstBranch != null)
            {
                lstBranch.DataSource = brnch;
                lstBranch.DataTextField = "BRANCHNAME";
                lstBranch.DataValueField = "BRANCHCODE";
                lstBranch.DataBind();
            }

            if (txtStTime != null && txtStTime.Value.Trim() == "")
                txtStTime.Value = DateTime.Now.ToString("MM/dd/yyyy") + " 07:00";

            return Branches;
        }

        public static void ShowError(string Msg, bool IsError, Label lblErr)
        {
            lblErr.Text = Msg;
            lblErr.ForeColor = IsError == true ? System.Drawing.Color.Red : System.Drawing.Color.Green;
        }

        public static void writeLog(string msg)
        {
            string fPath = System.Web.Configuration.WebConfigurationManager.AppSettings["LogFile"].ToString();
            LogWriter log = new LogWriter();
            log.writelogMethod(fPath, msg);
        }
    }

    public class LogWriter
    {
        private readonly object _fileLock = new object();
        public void writelogMethod(string fPath, string msg)
        {
            LogWriter logHel = new LogWriter();
            lock (_fileLock)
            {
                using (StreamWriter sw = File.AppendText(fPath))
                {
                    sw.WriteLine(DateTime.Now.ToString("dd-MM-yyyy : hh:mm:ss") + " :: " + msg + Environment.NewLine);
                }
            }
        }
    }
}