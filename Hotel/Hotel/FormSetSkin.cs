using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hotel.BLL;
using Hotel.Common;
using Hotel.Model;

namespace Hotel
{
    public partial class FormSetSkin : BaseForm
    {
        private bool IsFormLoad = true;
        public FormSetSkin()
        {
            InitializeComponent();
            panel1.Size = this.Size;
            panel1.Location = this.Location;
        }

        private void FormSetSkin_Load(object sender, EventArgs e)
        {
            foreach (object obj in cboSkin.Items)
            {
                if (obj.ToString().Split(':')[1] == UserInfo.SkinId.ToString())
                {
                    cboSkin.SelectedItem = obj;
                    break;
                }
            }
            IsFormLoad = false;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            UserInfo.SkinId = int.Parse(cboSkin.SelectedItem.ToString().Split(':')[1]);
            SysUserInfo bUser = new SysUserInfo();
            bUser.UpdateUserInfo(UserInfo, new ObjectControls(MCtrl.SetSkinId));
            this.Close();
        }

        private void cboSkin_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!IsFormLoad)
            {
                FormMain frm = (FormMain)this.Owner;
                //frm.sk.SkinStream = frm.sk.AddtionalBuiltInSkins[int.Parse(cboSkin.SelectedItem.ToString().Split(':')[1])].SkinSteam;
                frm.sk.ApplyAdditionalBuiltInSkins(int.Parse(cboSkin.SelectedItem.ToString().Split(':')[1]));
                //this.skinEngine1.ApplyAdditionalBuiltInSkins(int.Parse(cboSkin.SelectedItem.ToString().Split(':')[1]));
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            FormMain frm = (FormMain)this.Owner;
            frm.sk.ApplyAdditionalBuiltInSkins(UserInfo.SkinId);
            this.Close();
        }

    }
}
