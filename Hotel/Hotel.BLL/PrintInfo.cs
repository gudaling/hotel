using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hotel.DAL;
using Hotel.Common;
using Hotel.Model;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Drawing;
using System.Reflection;

namespace Hotel.BLL
{
    public class PrintInfo:AbBaseBll
    {
        private PrintDao dPrint = new PrintDao();
        /// <summary>
        /// 获取打印的设置信息
        /// </summary>
        /// <param name="mPrint"></param>
        /// <param name="oCtrl"></param>
        /// <returns></returns>
        public PrintModel GetPrintModel(PrintModel mPrint, ObjectControls oCtrl)
        {
            return dPrint.GetPrintConfig(mPrint, oCtrl);
            
            //return mPrint;
        }
        /// <summary>
        /// 根据设置信息,将值进行处理,返回符合当前需求的打印设置信息.
        /// </summary>
        /// <param name="mPrint"></param>
        /// <param name="parame"></param>
        /// <returns></returns>
        public PrintModel GetPrintSet(PrintModel mPrint, Object[] parame)
        {
            if (Cmn.CheckEOF(mPrint.PrintDetailList))
            {
                foreach (PrintDetailModel mPrintDetail in mPrint.PrintDetailList)
                {
                    object objValue = "";
                    PropertyInfo pi;
                    if (mPrintDetail.ValueType== 'D')
                    {
                        if (parame != null)
                        {
                            foreach (Object obj in parame)
                            {
                                if (obj.GetType().Name == mPrintDetail.BindValue.Split('.')[0])
                                {
                                    pi = obj.GetType().GetProperty(mPrintDetail.BindValue.Split('.')[1]);
                                    if (pi != null)
                                    {
                                        objValue = pi.GetValue(obj, null);
                                    }
                                    objValue = objValue != null ? objValue : "";
                                    mPrintDetail.ContentDesc = string.Format(mPrintDetail.ContentDesc, objValue);
                                }
                            }
                        }
                    }
                    //switch (mPrintDetail.ValueType.ToString())
                    //{
                    //    case "S":
                    //        break;
                    //    case "U":
                          
                    //        break;
                    //    case "O":
                    //        foreach (Object obj in parame)
                    //        {
                    //            if (obj.GetType().Name == mPrintDetail.BindValue.Split('.')[0])
                    //            {
                    //                pi = obj.GetType().GetProperty(mPrintDetail.BindValue.Split('.')[1]);
                    //                if (pi != null)
                    //                {
                    //                    objValue = pi.GetValue(obj, null);
                    //                }
                    //                objValue = objValue != null ? objValue : "";
                    //                mPrintDetail.ContentDesc = string.Format(mPrintDetail.ContentDesc, objValue);
                    //            }
                    //        }
                    //        //if (obj != null)
                    //        //{
                    //        //    pi = obj.GetType().GetProperty(mPrintDetail.BindValue);
                    //        //    if (pi != null)
                    //        //    {
                    //        //        objValue = pi.GetValue(obj, null);
                    //        //    }
                    //        //    objValue = objValue != null ? objValue : "";
                    //        //}
                    //        //mPrintDetail.ContentDesc = string.Format(mPrintDetail.ContentDesc, objValue);
                    //        break;
                    //    default:
                    //        break;
                    //}
                }
            }
            return mPrint;
        }

    }

    public class DataGridViewPrint
    {

        private DataGridView[] dataGridView;

        private PrintDocument printDocument;

        private PageSettings ps = new PageSettings();

        private PrintDialog pd = new PrintDialog();

        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog;

        private int dgvIndex = 0;

        private int rowCount = 0;

        private int colCount = 0;

        private int x = 0;

        private int y = 0;

        private bool ShowLine = true;

        int i = 0;

        /// <summary>
        /// 行距
        /// </summary>
        private int rowGap = 20;

        /// <summary>
        /// 是否出现"打印设置"对话框
        /// </summary>
        private bool IsShowSetupDialog;

        /// <summary>
        /// 是否横向打印True,纵向fals
        /// </summary>
        private bool IsLandScape = false;

        private Font font = new Font("Arial", 9);

        /// <summary>
        /// table表头字体样式
        /// </summary>
        private Font headingFont = new Font("Arial", 10, FontStyle.Bold);

        //private Font captionFont = new Font("Arial", 15, FontStyle.Bold);

        private Brush brush = new SolidBrush(Color.Black);

        private string cellValue = "";

        public DataGridViewPrint(DataGridView[] dataGridView)
        {
            this.dataGridView = dataGridView;
        }

        /// <summary>
        /// 打印表格以及自定义字符.输出到打印文档上
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            x = ps.Margins.Left;
            y = ps.Margins.Top;
            #region 打印自定义内容
            
            if (mPrint.PrintId > 0 && mPrint.PrintDetailList.Count > 0)
            {
                int nY = 0;
                foreach (PrintDetailModel mPrintDetail in mPrint.PrintDetailList)
                {
                    FontStyle fs = FontStyle.Regular;
                    if (mPrintDetail.FontBold)
                    {
                        fs |= FontStyle.Bold;
                    }
                    if (mPrintDetail.UnderLine)
                    {
                        fs |= FontStyle.Underline;
                    }
                    Font ft = new Font("Arial", mPrintDetail.FontSize, fs);

                    CurrentSite cs = GetSite(mPrintDetail, x, y, e.PageSettings);

                    Brush bsh = new SolidBrush(mPrintDetail.FontColor);
                    e.Graphics.DrawString(mPrintDetail.ContentDesc, ft, bsh, cs.X, cs.Y);
                    nY = nY < cs.Y ? cs.Y : nY;
                }
                y += nY;//取最大的高.用于未来打印表格.
            }

            #endregion

            #region 打印列表
            
            for (; dgvIndex < dataGridView.Length; dgvIndex++)
            {
                rowCount = dataGridView[dgvIndex].Rows.Count;

                colCount = dataGridView[dgvIndex].ColumnCount;
                //y += rowGap;

                //x = ps.Margins.Left;
                x = GetTableSiteX(dataGridView[dgvIndex], ps);
                //x = IsShowSetupDialog == true ? pageSetupDialog.PageSettings.Margins.Left : LeftMargin;

                #region 打印列头
                
                for (int j = 0; j < colCount; j++)
                {
                    if (dataGridView[dgvIndex].Columns[j].Width > 0 && dataGridView[dgvIndex].Columns[j].Visible == true)
                    {
                        cellValue = dataGridView[dgvIndex].Columns[j].HeaderText;

                        if (ShowLine)
                        {
                            //绘制矩形边框
                            e.Graphics.DrawRectangle(Pens.Black, x, y, dataGridView[dgvIndex].Columns[j].Width, rowGap);
                        }
                        //写入数据
                        e.Graphics.DrawString(cellValue, headingFont, brush, x, y);

                        x += dataGridView[dgvIndex].Columns[j].Width;
                    }
                }

                #endregion

                #region 打印所有行

                for (; i < rowCount; i++)
                {
                    y += rowGap;
                    x = GetTableSiteX(dataGridView[dgvIndex], ps);
                    //x = ps.Margins.Left;
                    //x = IsShowSetupDialog == true ? pageSetupDialog.PageSettings.Margins.Left : LeftMargin;

                    for (int j = 0; j < colCount; j++)
                    {
                        if (dataGridView[dgvIndex].Columns[j].Width > 0 && dataGridView[dgvIndex].Columns[j].Visible == true)
                        {

                            cellValue = dataGridView[dgvIndex].Rows[i].Cells[j].Value != null ? dataGridView[dgvIndex].Rows[i].Cells[j].Value.ToString() : "";
                            if (ShowLine)
                            {
                                e.Graphics.DrawRectangle(Pens.Black, x, y, dataGridView[dgvIndex].Columns[j].Width, rowGap);
                            }
                            e.Graphics.DrawString(cellValue, font, brush, x, y);

                            x += dataGridView[dgvIndex].Columns[j].Width;
                        }
                    }

                    #region 分页

                    if (y >= e.PageBounds.Height - 80)
                    {
                        //允許多頁打印
                        y = 0;
                        e.HasMorePages = true;
                        i++;
                        return;
                    }

                    #endregion
                }
                #endregion

                y += rowGap;

                //for (int j = 0; j < colCount; j++)
                //{
                //    e.Graphics.DrawString(" ", font, brush, x, y);
                //}
                i = 0;
            }
            #endregion

            e.HasMorePages = false;
            dgvIndex = 0;
        }

        /// <summary>
        /// 计算打印位置
        /// </summary>
        /// <param name="mPrintDetail"></param>
        /// <param name="DefultX"></param>
        /// <param name="DefaultY"></param>
        /// <param name="ps"></param>
        /// <returns></returns>
        private CurrentSite GetSite(PrintDetailModel mPrintDetail, int DefultX, int DefaultY, PageSettings ps)
        {
            CurrentSite cs = new CurrentSite();
            switch (mPrintDetail.Align)
            {
                case 0:
                    cs.X = DefultX + mPrintDetail.SiteX;
                    cs.Y = DefaultY + mPrintDetail.SiteY;
                    break;
                case 1:
                    int nStringLength = mPrintDetail.ContentDesc.Length * mPrintDetail.FontSize;
                    int PageWidth = ps.Landscape == true ? ps.PaperSize.Height : ps.PaperSize.Width;
                    cs.X = int.Parse((PageWidth / 2 - nStringLength / 2).ToString());
                    cs.Y = DefaultY + mPrintDetail.SiteY;
                    break;
                default:
                    cs.X = DefultX;
                    cs.Y = DefaultY;
                    break;
            }
            return cs;
        }

        /// <summary>
        /// 获取表格的起始打印位置
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="psTmp"></param>
        /// <returns></returns>
        private int GetTableSiteX(DataGridView dgv, PageSettings psTmp)
        {
            int nx = psTmp.Margins.Left;
            if (mPrint.TableAlign > 0)//居中打印表格
            {
                int PageWidth = ps.Landscape == true ? ps.PaperSize.Height : ps.PaperSize.Width;
                nx = int.Parse((PageWidth / 2 - dgv.Width / 2).ToString());
            }
            return nx;
        }

        /// <summary>
        /// 获取打印的文档
        /// </summary>
        /// <returns></returns>
        public PrintDocument GetPrintDocument()
        {
            return printDocument;
        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="ShowSetupDialog">是否显示打印机选择框</param>
        /// <param name="IsDrawLine">是否画边框</param>
        public void Print(bool ShowSetupDialog,bool IsDrawLine)
        {
            try
            {
                ShowLine = IsDrawLine;
                printDocument = new PrintDocument();
                IsShowSetupDialog = ShowSetupDialog;
                if (IsShowSetupDialog)
                {
                    pd.PrinterSettings = new PrinterSettings();
                    //pageSetupDialog = new PageSetupDialog();
                    //pageSetupDialog.AllowPrinter = true;
                    //pageSetupDialog.PageSettings = ps;
                    if (pd.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }
                    //printDocument.DefaultPageSettings = ps;
                }
                printDocument.PrinterSettings = pd.PrinterSettings;
                printDocument.DefaultPageSettings = ps;
                printDocument.PrintPage += new PrintPageEventHandler(this.printDocument_PrintPage);
                printPreviewDialog = new PrintPreviewDialog();
                printPreviewDialog.Document = printDocument;
                ((Form)printPreviewDialog).WindowState = FormWindowState.Maximized;
                printPreviewDialog.ShowDialog();

            }
            catch (Exception e)
            {
                throw new Exception("Printer error." + e.Message);
            }

        }

        private PrintModel mPrint = new PrintModel();

        /// <summary>
        /// 打印配置信息
        /// </summary>
        public PrintModel GetPrintConfig
        {
            set { 
                mPrint = value;
                if (mPrint.PrintId > 0)
                {
                    ps.Margins.Left = mPrint.StartX;
                    ps.Margins.Top = mPrint.StartY;
                    IsLandScape = mPrint.LandScape == 1 ? true : false;
                    ps.Landscape = IsLandScape;
                }
            }
        }

    }

    /// <summary>
    /// 当前坐标,用于计算居中时打印位置.
    /// </summary>
    internal class CurrentSite
    {
        private int x = 0;
        private int y = 0;
        public int X
        {
            get { return x; }
            set { x = value; }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
    }
}
