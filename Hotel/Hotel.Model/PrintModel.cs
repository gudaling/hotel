using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;


namespace Hotel.Model
{
    public class PrintModel
    {
        public PrintModel()
        {
            PrintId = -1;
        }
        public PrintModel(string sPrintNo)
            : this()
        {
            PrintNo = sPrintNo;
        }

        public int PrintId { get; set; }

        public string PrintNo { get; set; }

        public string PrintName { get; set; }

        /// <summary>
        /// 打印的起始位置
        /// </summary>
        public int StartX { get; set; }
        /// <summary>
        /// 打印的起始位置
        /// </summary>
        public int StartY { get; set; }

        private int nTableAlign = 0;
        /// <summary>
        /// 表格是否居中打印?1:yes,0:no
        /// </summary>
        public int TableAlign
        {
            get { return nTableAlign; }
            set { nTableAlign = value; }
        }

        private int nLandScape = 0;
        /// <summary>
        /// 横向1或纵向打印0
        /// </summary>
        public int LandScape
        {
            get { return nLandScape; }
            set { nLandScape = value; }
        }

        private List<PrintDetailModel> listPrintDetail = new List<PrintDetailModel>();
        public List<PrintDetailModel> PrintDetailList
        {
            get { return listPrintDetail; }
            set { listPrintDetail = value; }
        }

    }

    public class PrintDetailModel
    {
        public PrintDetailModel()
        {
            PrintDetailId = -1;
        }

        public PrintDetailModel(int nPrintDetailId)
            : this()
        {
            PrintDetailId = nPrintDetailId;
        }
        public int PrintDetailId { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string ContentDesc { get; set; }

        /// <summary>
        /// 字体大小
        /// </summary>
        public int FontSize { get; set; }

        public string sFontColor = "";
        /// <summary>
        /// 字体颜色,有红,蓝,黑三色
        /// </summary>
        public Color FontColor
        {
            get
            {
                switch (sFontColor)
                { 
                    case "Black":
                        return Color.Black;
                    case "Red":
                        return Color.Red;
                    case "Blue":
                        return Color.Blue;
                    default:
                        return Color.Black;
                }
            }
        }

        public int nBold = 0;
        /// <summary>
        /// 是否加粗
        /// </summary>
        public bool FontBold
        {
            get
            {
                return nBold == 0 ? false : true;
            }
            set
            {
                nBold = value == true ? 1 : 0;
            }
        }

        public int nUnderLine = 0;
        /// <summary>
        /// 是否下划线
        /// </summary>
        public bool UnderLine
        {
            get
            {
                return nUnderLine == 0 ? false : true;
            }
            set
            {
                nUnderLine = value == true ? 1 : 0;
            }
        }

        /// <summary>
        /// 对齐方式 0:普通,坐标定位,1:居中
        /// </summary>
        public int Align { get; set; }

        /// <summary>
        /// X坐标
        /// </summary>
        public int SiteX { get; set; }

        /// <summary>
        /// Y坐标
        /// </summary>
        public int SiteY { get; set; }

        private string sBindValue = "";
        /// <summary>
        /// 绑定的值
        /// </summary>
        public string BindValue
        {
            get { return sBindValue; }
            set { sBindValue = value; }
        }

        public char ValueType { get; set; }

        private CommonModel cm = new CommonModel();
        public CommonModel CommonInfo
        {
            get { return cm; }
            set { cm = value; }
        }
    }

}
