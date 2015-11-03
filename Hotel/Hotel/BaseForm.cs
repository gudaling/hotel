using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hotel.Common;
using Hotel.BLL;
using Hotel.Model;
using System.Text.RegularExpressions;
using Sunisoft.IrisSkin;

namespace Hotel
{
    public partial class BaseForm : Form
    {
        public ObjectControls oCtrl = new ObjectControls();

        public static SysUserInfoModel UserInfo;

        public CommonLibrary cmn = new CommonLibrary();

        public static List<SysParameterModel> listSysParameter;

        public BaseForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Icon = Properties.Resources.FormIco;
            if (UserInfo != null)
            {
                skinEngine1.SkinDialogs = true;
                skinEngine1.SkinStream = skinEngine1.AddtionalBuiltInSkins[UserInfo.SkinId].SkinSteam;
            }
        }

        /// <summary>
        /// 绑定系统代码与描述.用于ComboBox的显示与选取.
        /// </summary>
        /// <param name="cboTarget"></param>
        /// <param name="sTableName"></param>
        /// <param name="sColumnName"></param>
        public void BindCodeInfo(ComboBox cboTarget, string sTableName, string sColumnName)
        {
            SysLookUpCodeInfo bSysLookupCode = new SysLookUpCodeInfo();
            SysLookupCodeModel mSysLookupCode = new SysLookupCodeModel();
            mSysLookupCode.TableName = sTableName;
            mSysLookupCode.ColumnName = sColumnName;
            ObjectControls oLookCode = new ObjectControls();
            oLookCode.Add(MCtrl.ByColumnName);
            oLookCode.Add(MCtrl.ByTableName);
            cboTarget.DataSource = bSysLookupCode.GetSysLookUpCode(mSysLookupCode, oLookCode);
            cboTarget.DisplayMember = "CodeDesc";
            cboTarget.ValueMember = "CodeNo";
        }

        /// <summary>
        /// 将房间信息绑定到TreeView,可定义首节点描述字符
        /// </summary>
        /// <param name="tv"></param>
        /// <param name="listRoomInfo"></param>
        /// <param name="sFirstNodeDesc"></param>
        public void BindTreeViewRoom(TreeView tv, List<BasRoomModel> listRoomInfo, string sFirstNodeDesc)
        {
            tv.Nodes.Clear();
            tv.Nodes.Add(sFirstNodeDesc);
            HotelMainLogic hml = new HotelMainLogic();
            foreach (BasRoomModel mRoom in listRoomInfo)
            {
                TreeNode[] tnarry = tv.Nodes.Find(mRoom.RoomId.ToString(), true);
                if (tnarry.Length > 0)
                {
                    continue;
                }
                TreeNode tn = new TreeNode();
                tn.Text = mRoom.RoomNo;
                tn.Name = mRoom.RoomId.ToString();
                if (mRoom.Status != 'T')
                {
                    tv.Nodes[0].Nodes.Add(tn);
                }
                else
                {
                    List<BasRoomModel> listTeamRoom = hml.GetTeamRoomListByRoomId(mRoom, 'I');
                    if (cmn.CheckEOF(listTeamRoom))
                    {
                        var query = listTeamRoom.Where(c => c.MainRoomId == c.RoomId).First();
                        TreeNode tnMain = new TreeNode();
                        tnMain.Text = query.RoomNo;
                        tnMain.Name = query.RoomId.ToString();
                        listTeamRoom.Remove(query);
                        foreach (BasRoomModel mTeamRoom in listTeamRoom)
                        {
                            TreeNode tnChild = new TreeNode();
                            tnChild.Text = mTeamRoom.RoomNo;
                            tnChild.Name = mTeamRoom.RoomId.ToString();
                            tnMain.Nodes.Add(tnChild);
                        }
                        tv.Nodes[0].Nodes.Add(tnMain);
                    }
                    //TreeNode[] tnMain = tv.Nodes.Find(mRoom.MainRoomId.ToString(), true);
                    //if (tnMain.Length > 0)
                    //{
                    //    tnMain[0].Nodes.Add(tn);

                    //}
                    else
                    {
                        tv.Nodes[0].Nodes.Add(tn);
                    }
                }
            }
            tv.ExpandAll();
        }

        /// <summary>
        /// 验证用户Key入的字符,防止输入不合法的数据
        /// </summary>
        /// <param name="txtTarget"></param>
        /// <param name="e"></param>
        /// <param name="sChar"></param>
        public void CheckKeyInNumber(TextBox txtTarget, KeyPressEventArgs e, string sChar, int nMaxLength)
        {
            //允许输入的字符
            string AstrictChar = sChar;
            //「BackSpace」「Delete」后退键正常删除操作
            if (e.KeyChar == 8)
            {
                return;
            }
            //「Ctrl+C」(3)「Ctrl+X」(24)特殊组合键正常
            //「Ctrl+Z」(26) 撤消组合键正常
            if ((e.KeyChar == 3) || (e.KeyChar == 24) || (e.KeyChar == 26))
            {
                return;
            }
            if (txtTarget.Text.Contains(".") && e.KeyChar == 46)
            {
                e.Handled = true;
                return;
            }
            if (nMaxLength > 0 && txtTarget.Text.Replace("-", "").Replace(".", "").Length >= nMaxLength)
            {
                e.Handled = true;
                return;
            }
            //允许输入的字符外，
            if (AstrictChar.IndexOf(e.KeyChar.ToString()) == -1)
            {
                e.Handled = true;
                return;
            }
        }

        /// <summary>
        /// 根据一个代码,找到ComboBox中对应的index.用于Selected
        /// </summary>
        /// <param name="cboTarget"></param>
        /// <param name="objKey"></param>
        /// <returns></returns>
        public int GetComboxIndexByKey(ComboBox cboTarget, object objKey)
        {
            if (objKey == null || string.IsNullOrEmpty(objKey.ToString()))
            {
                return 0;
            }
            int index = 0;
            for (int i = 0; i < cboTarget.Items.Count; i++)
            {
                if (((SysLookupCodeModel)cboTarget.Items[i]).CodeNo == objKey.ToString())
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        /// <summary>
        /// 获取日历+ComboBox组成的时间
        /// </summary>
        /// <param name="dtp"></param>
        /// <param name="cboHour"></param>
        /// <returns></returns>
        public DateTime GetDateTimePickValue(DateTimePicker dtp, ComboBox cboHour)
        {
            if (cboHour == null)
            {
                return dtp.Value.Date;
            }
            return DateTime.Parse(dtp.Value.ToShortDateString() + " " + cboHour.SelectedItem + ":00:00");
        }

    }
}
