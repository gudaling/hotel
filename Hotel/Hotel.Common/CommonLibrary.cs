using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.Linq;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using Hotel.DataAccess;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;

namespace Hotel.Common
{
    public class CommonLibrary
    {
        /// <summary>
        /// 返回房号的大写
        /// </summary>
        /// <param name="sRoomNo"></param>
        /// <returns></returns>
        public string ToRoomNo(string sRoomNo)
        {
            return sRoomNo.Trim().ToUpper();
        }

        /// <summary>
        /// 检测是否为空
        /// </summary>
        /// <param name="txt"></param>
        /// <param name="txtName"></param>
        /// <returns></returns>
        public string CheckNullOrEmpty(TextBox txt, string txtName)
        {
            if (string.IsNullOrEmpty(txt.Text.Trim()))
            {
                throw new Exception(string.Format("{0}不能为空!", txtName));
            }
            return txt.Text.Trim();
        }

        /// <summary>
        /// 检测是否为Double类型数据
        /// </summary>
        /// <param name="txt"></param>
        /// <param name="txtName"></param>
        /// <returns></returns>
        public double CheckIsDouble(TextBox txt, string txtName)
        {
            double d = 0.0;
            if (!double.TryParse(txt.Text.Trim(), out d))
            {
                throw new Exception(string.Format("{0}格式不正确", txtName));
            }
            return double.Parse(txt.Text.Trim());
        }

        /// <summary>
        /// 检测是否是整形数据
        /// </summary>
        /// <param name="txt"></param>
        /// <param name="txtName"></param>
        /// <returns></returns>
        public int CheckIsInt(TextBox txt, string txtName)
        {
            if (!PageValidate.IsNumber(txt.Text.Trim()))
            {
                throw new Exception(string.Format("{0}格式不正确", txtName));
            }
            return int.Parse(txt.Text.Trim());
        }

        /// <summary>
        /// string转换为字符.一般string长度为1.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public char ToChar(object obj)
        {
            if (string.IsNullOrEmpty(obj.ToString()))
            {
                throw new Exception("字符串长度小于1");
            }
            return obj.ToString().ToCharArray(0, 1)[0];
        }

        /// <summary>
        /// 获取数据库时间
        /// </summary>
        public DateTime DateBaseDate
        {
            get
            {
                return new DBHelper().GetDBTime;
            }
        }

        /// <summary>
        /// 显示提示信息
        /// </summary>
        /// <param name="sMsg"></param>
        public void Show(string sMsg)
        {
            MessageBox.Show(sMsg);
        }

        /// <summary>
        /// 显示确认对话框
        /// </summary>
        /// <param name="sMsg"></param>
        /// <returns></returns>
        public bool Confirm(string sMsg)
        {
            if (MessageBox.Show(sMsg, "警告", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 如果有值,返回True.
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool CheckEOF(IList list)
        {
            return !(list == null || list.Count == 0);
        }

        /// <summary>
        /// 有值返回True
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public bool CheckEOF(DataSet ds)
        {
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 汇出DataGridView到Excel文件
        /// </summary>
        /// <param name="datagridview"></param>
        /// <param name="captions"></param>
        public void ExportExcel(DataGridView datagridview, bool captions)
        {
            object objApp_Late;
            object objBook_Late;
            object objBooks_Late;
            object objSheets_Late;
            object objSheet_Late;
            object objRange_Late;
            object[] Parameters;

            string[] headers = new string[datagridview.ColumnCount];
            string[] columns = new string[datagridview.ColumnCount];
            string[] colName = new string[datagridview.ColumnCount];

            int i = 0;
            int c = 0;
            int m = 0;

            for (c = 0; c < datagridview.Columns.Count; c++)
            {
                for (int j = 0; j < datagridview.Columns.Count; j++)
                {
                    DataGridViewColumn tmpcol = datagridview.Columns[j];
                    if (tmpcol.DisplayIndex == c)
                    {
                        if (tmpcol.Visible) //不显示的隐藏列初始化为tag＝0
                        {
                            headers[c - m] = tmpcol.HeaderText;
                            i = c - m + 65;
                            columns[c - m] = Convert.ToString((char)i);
                            colName[c - m] = tmpcol.Name;
                        }
                        else
                        {
                            m++;
                        }
                        break;
                    }
                }
            }

            try
            {
                // Get the class type and instantiate Excel.
                Type objClassType;
                objClassType = Type.GetTypeFromProgID("Excel.Application");
                objApp_Late = Activator.CreateInstance(objClassType);
                //Get the workbooks collection.
                objBooks_Late = objApp_Late.GetType().InvokeMember("Workbooks", BindingFlags.GetProperty, null, objApp_Late, null);
                //Add a new workbook.
                objBook_Late = objBooks_Late.GetType().InvokeMember("Add", BindingFlags.InvokeMethod, null, objBooks_Late, null);
                //Get the worksheets collection.
                objSheets_Late = objBook_Late.GetType().InvokeMember("Worksheets", BindingFlags.GetProperty, null, objBook_Late, null);
                //Get the first worksheet.
                Parameters = new Object[1];
                Parameters[0] = 1;
                objSheet_Late = objSheets_Late.GetType().InvokeMember("Item", BindingFlags.GetProperty, null, objSheets_Late, Parameters);

                if (captions)
                {
                    // Create the headers in the first row of the sheet
                    for (c = 0; c < datagridview.ColumnCount; c++)
                    {
                        //Get a range object that contains cell.
                        if (columns[c] != null)
                        {
                            Parameters = new Object[2];
                            Parameters[0] = columns[c] + "1";
                            Parameters[1] = Missing.Value;
                            objRange_Late = objSheet_Late.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, objSheet_Late, Parameters);
                            //Write Headers in cell.
                            Parameters = new Object[1];
                            Parameters[0] = headers[c];
                            objRange_Late.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, objRange_Late, Parameters);
                        }
                    }
                }

                // Now add the data from the grid to the sheet starting in row 2
                for (i = 0; i < datagridview.RowCount; i++)
                {
                    c = 0;
                    foreach (string txtCol in colName)
                    {
                        if (txtCol == null)
                        {
                            c++;
                            break;
                        }
                        DataGridViewColumn col = datagridview.Columns[txtCol];
                        if (col.Visible)
                        {
                            //Get a range object that contains cell.
                            Parameters = new Object[2];
                            Parameters[0] = columns[c] + Convert.ToString(i + 2);
                            Parameters[1] = Missing.Value;
                            objRange_Late = objSheet_Late.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, objSheet_Late, Parameters);
                            //Write Headers in cell.
                            Parameters = new Object[1];
                            //Parameters[0] = datagridview.Rows[i].Cells[headers[c]].Value.ToString();
                            Parameters[0] = datagridview.Rows[i].Cells[col.Name].Value != null ? datagridview.Rows[i].Cells[col.Name].Value.ToString() : "111";
                            objRange_Late.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, objRange_Late, Parameters);
                            c++;
                        }

                    }
                }

                //Return control of Excel to the user.
                Parameters = new Object[1];
                Parameters[0] = true;
                objApp_Late.GetType().InvokeMember("Visible", BindingFlags.SetProperty,
                null, objApp_Late, Parameters);
                objApp_Late.GetType().InvokeMember("UserControl", BindingFlags.SetProperty,
                null, objApp_Late, Parameters);
            }
            catch (Exception theException)
            {
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, theException.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
                errorMessage = String.Concat(errorMessage, theException.Source);

                MessageBox.Show(errorMessage, "Error");
            }
        }

        //序列化 
        public byte[] SerializeObject(object pObj)
        {
            if (pObj == null)
                return null;
            System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(memoryStream, pObj);
            memoryStream.Position = 0;
            byte[] read = new byte[memoryStream.Length];
            memoryStream.Read(read, 0, read.Length);
            memoryStream.Close();
            return read;
        }
        //反序列化 
        public object DeserializeObject(byte[] pBytes)
        {
            object newOjb = null;
            if (pBytes == null)
            {
                return newOjb;
            }

            System.IO.MemoryStream memoryStream = new System.IO.MemoryStream(pBytes);
            memoryStream.Position = 0;
            BinaryFormatter formatter = new BinaryFormatter();
            newOjb = formatter.Deserialize(memoryStream);
            memoryStream.Close();

            return newOjb;
        }

        /// <summary>
        /// 获取某一路径下的配置文件
        /// </summary>
        /// <param name="sConfigName"></param>
        /// <returns></returns>
        public string GetConnectionStrings(string sConfigName, string sPath)
        {
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
            fileMap.ExeConfigFilename = sPath;
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            return config.ConnectionStrings.ConnectionStrings[sConfigName].ConnectionString;
        }

        public string GetAppSetting(string sAppName, string sPath)
        {
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
            fileMap.ExeConfigFilename = Application.StartupPath;
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            return config.AppSettings.Settings[sAppName].Value;
        }

        /// <summary>
        /// 创建文件夹,返回文件夹路径
        /// </summary>
        /// <param name="sFolderName"></param>
        /// <returns></returns>
        public string CreateFolder(string sFolderName)
        {
            string sFilePath = Application.StartupPath + "\\" + sFolderName;
            if (!Directory.Exists(sFilePath))//验证路径是否存在
            {
                Directory.CreateDirectory(sFilePath);//不存在则创建
            }
            return sFilePath;
        }

        public bool FileExsit(string sFileName)
        {
            if (!string.IsNullOrEmpty(sFileName) && File.Exists(sFileName))
            {
                return true;
            }
            return false;
        }

        public string MakeGroup(string str)
        {
            return "'" + str + "',";
        }

        public string RemoveLastDou(string str)
        {
            if (!string.IsNullOrEmpty(str) && str.Split(',').Length > 0 && str.LastIndexOf(',') == str.Length - 1)
            {
                return str.Remove(str.Length - 1, 1);
            }
            return str;
        }

        /// <summary>
        /// 保存图片文件,返回文件夹以及文件名称,不包括磁盘路径
        /// </summary>
        /// <param name="img"></param>
        /// <param name="sImgName"></param>
        /// <param name="sFolderName"></param>
        /// <returns></returns>
        public string SaveImage(Image img, string sImgName, string sFolderName)
        {
            try
            {
                if (img != null)
                {
                    string sPath = CreateFolder(sFolderName) + "\\" + sImgName + ".jpg";
                    Image imgage = img;
                    imgage.Save(sPath, ImageFormat.Jpeg);
                    return sFolderName + "\\" + sImgName + ".jpg";
                }
                return "";
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public string GetImgFilePath(string sImgOppositPath)
        {
            return Application.StartupPath + "\\" + sImgOppositPath;
        }
    }

    /// <summary>
    /// 记录Log类
    /// </summary>
    public class Log
    {
        /// <summary>
        /// 用于Linq写Log
        /// </summary>
        /// <param name="dc"></param>
        /// <param name="query"></param>
        /// <param name="IsWriteSql"></param>
        public static void WriteLog(DataContext dc, IQueryable query, bool IsWriteSql)
        {
            if (IsWriteSql)
            {
                DbCommand cmd = dc.GetCommand(query);
                WriteLog(cmd.CommandText);
            }
        }

        public static void WriteLog(string strLog)
        {
            try
            {
                string sFilePath = Application.StartupPath + "\\Log";
                string sFileName = DateTime.Now.ToShortDateString() + ".log";
                sFileName = sFilePath + "\\" + sFileName; //文件的绝对路径
                if (!Directory.Exists(sFilePath))//验证路径是否存在
                {
                    Directory.CreateDirectory(sFilePath);//不存在则创建
                }
                FileStream fs;
                StreamWriter sw;
                if (File.Exists(sFileName))//验证文件是否存在，有则追加，无则创建
                {
                    fs = new FileStream(sFileName, FileMode.Append, FileAccess.Write);
                }
                else
                {
                    fs = new FileStream(sFileName, FileMode.Create, FileAccess.Write);
                }
                sw = new StreamWriter(fs);
                sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ":" + strLog);
                sw.Close();
                fs.Close();
            }
            catch
            {
            }
        }

        public static void WriteLog(string strLog,bool IsWriteLog)
        {
            try
            {
                if (!IsWriteLog)
                {
                    return;   
                }
                string sFilePath = Application.StartupPath + "\\Log";
                string sFileName = DateTime.Now.ToShortDateString() + ".log";
                sFileName = sFilePath + "\\" + sFileName; //文件的绝对路径
                if (!Directory.Exists(sFilePath))//验证路径是否存在
                {
                    Directory.CreateDirectory(sFilePath);//不存在则创建
                }
                FileStream fs;
                StreamWriter sw;
                if (File.Exists(sFileName))//验证文件是否存在，有则追加，无则创建
                {
                    fs = new FileStream(sFileName, FileMode.Append, FileAccess.Write);
                }
                else
                {
                    fs = new FileStream(sFileName, FileMode.Create, FileAccess.Write);
                }
                sw = new StreamWriter(fs);
                sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ":" + strLog);
                sw.Close();
                fs.Close();
            }
            catch
            {
            }
        }

        public static void WriteLog(string sPath, string strLog)
        {
            try
            {
                //string sFilePath = Application.StartupPath + "\\Log";
                string sFileName = DateTime.Now.ToShortDateString() + ".log";
                //sFileName = sFilePath + "\\" + sFileName; //文件的绝对路径
                if (!Directory.Exists(sPath))//验证路径是否存在
                {
                    Directory.CreateDirectory(sPath);//不存在则创建
                }
                FileStream fs;
                StreamWriter sw;
                if (File.Exists(sFileName))//验证文件是否存在，有则追加，无则创建
                {
                    fs = new FileStream(sFileName, FileMode.Append, FileAccess.Write);
                }
                else
                {
                    fs = new FileStream(sFileName, FileMode.Create, FileAccess.Write);
                }
                sw = new StreamWriter(fs);
                sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ":" + strLog);
                sw.Close();
                fs.Close();
            }
            catch
            {
            }
        }
    }

    /// <summary>
    /// 对象控制.用于控制SQL的组建
    /// </summary>
    [Serializable]
    public class ObjectControls
    {
        private List<object> listObj;

        public ObjectControls()
        {
            listObj = new List<object>();
        }

        public ObjectControls(string sControls)
        {
            listObj = new List<object>();
            listObj.Add(sControls);
        }

        /// <summary>
        /// 增加控制对象
        /// </summary>
        /// <param name="sControls"></param>
        public void Add(string sControls)
        {
            if (!listObj.Contains(sControls))
            {
                listObj.Add(sControls);
            }
        }

        /// <summary>
        /// 判断是否存在该控制对象
        /// </summary>
        /// <param name="sControls"></param>
        /// <returns></returns>
        public bool Exsit(string sControls)
        {
            if (listObj.Contains(sControls))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 移除控制对象
        /// </summary>
        /// <param name="sControls"></param>
        public void Remove(string sControls)
        {
            if (listObj.Contains(sControls))
            {
                listObj.Remove(sControls);
            }
        }

        /// <summary>
        /// 复位
        /// </summary>
        public void Reset()
        {
            listObj.Clear();
        }

        /// <summary>
        /// 组SQL.
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="sValue"></param>
        /// <returns></returns>
        public bool Append(ref string sql, string sValue)
        {
            sql += sValue.ToString();
            return true;
        }

        /// <summary>
        /// 判断参数是否存在,与Append同时使用.如oCtrl.Helper(oCtrl.Exsit(MCtrl.ByRoomId) && oCtrl.Append(ref sql, " AND A.ROOM_ID=" + mCustomerStay.RoomId));

        /// </summary>
        /// <param name="IsParameter"></param>
        public void Helper(bool IsParameter)
        { 
            
        }

        /// <summary>
        /// 空控制对象.只读
        /// </summary>
        public ObjectControls EmptyCtrl
        {
            get { return new ObjectControls(); }
        }
        
    }
}
