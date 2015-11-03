using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hotel.Model;
using Hotel.DataAccess;
using Hotel.Common;

namespace Hotel.DAL
{
    public class PrintDao:AbBaseDao
    {
        public PrintModel GetPrintConfig(PrintModel mPrint, ObjectControls oCtrl)
        {
            string sql = @"SELECT A.PRINT_ID, A.PRINT_NAME, A.PRINT_NO,A.START_X,A.START_Y,A.TABLE_ALIGN, 
                              A.LAND_SCAPE,B.PRINT_DETAIL_ID, 
                              B.CONTENT_DESC, B.FONT_SIZE, B.FONT_COLOR, 
                              B.FONT_BOLD, B.FONT_UNDER_LINE, B.ALIGN, B.SITE_X, B.SITE_Y, B.BIND_VALUE, B.VALUE_TYPE,
                              B.CREATE_DATE, B.CREATE_USERID
                        FROM PRINT_HEADER AS A INNER JOIN
                              PRINT_DETAIL AS B ON A.PRINT_ID = B.PRINT_ID";
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByPrintNo) && oCtrl.Append(ref sql, " AND A.PRINT_NO=" + SQL(mPrint.PrintNo)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByPrintId) && oCtrl.Append(ref sql, " AND A.PRINT_ID=" + SQL(mPrint.PrintId)));

            sdr = ExecuteReader(sql);
            using (sdr)
            {
                PrintModel mPrintNew = new PrintModel();
                mPrintNew.PrintDetailList = new List<PrintDetailModel>();
                while (sdr.Read())
                {
                    mPrintNew.PrintId = ToInt32(sdr["PRINT_ID"]);
                    mPrintNew.PrintNo = ToString(sdr["PRINT_NO"]);
                    mPrintNew.PrintName = ToString(sdr["PRINT_NAME"]);
                    mPrintNew.StartX = ToInt32(sdr["START_X"]);
                    mPrintNew.StartY = ToInt32(sdr["START_Y"]);
                    mPrintNew.TableAlign = ToInt32(sdr["TABLE_ALIGN"]);
                    mPrintNew.LandScape = ToInt32(sdr["LAND_SCAPE"]);
                    PrintDetailModel mPrintDetail = new PrintDetailModel();
                    mPrintDetail.PrintDetailId = ToInt32(sdr["PRINT_DETAIL_ID"]);
                    mPrintDetail.ContentDesc = ToString(sdr["CONTENT_DESC"]);
                    mPrintDetail.FontSize = ToInt32(sdr["FONT_SIZE"]);
                    mPrintDetail.sFontColor = ToString(sdr["FONT_COLOR"]);
                    mPrintDetail.nBold = ToInt32(sdr["FONT_BOLD"]);
                    mPrintDetail.nUnderLine = ToInt32(sdr["FONT_UNDER_LINE"]);
                    mPrintDetail.Align = ToInt32(sdr["ALIGN"]);
                    mPrintDetail.SiteX = ToInt32(sdr["SITE_X"]);
                    mPrintDetail.SiteY = ToInt32(sdr["SITE_Y"]);
                    mPrintDetail.BindValue = ToString(sdr["BIND_VALUE"]);
                    mPrintDetail.ValueType = ToChar(sdr["VALUE_TYPE"]);
                    mPrintDetail.CommonInfo.CreateDate = ToDateTime(sdr["CREATE_DATE"]);
                    mPrintDetail.CommonInfo.CreateUserId = ToInt32(sdr["CREATE_USERID"]);
                    mPrintNew.PrintDetailList.Add(mPrintDetail);
                }
                return mPrintNew;
            }
        }
    }
}
