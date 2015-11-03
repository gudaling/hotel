using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hotel.Model;
using Hotel.Common;
using System.Configuration;


namespace Hotel.BLL
{
    public class PhoneJFInfo:AbBaseBll
    {
        private localhost.JFService jfs = new Hotel.BLL.localhost.JFService();
        public PhoneJFInfo()
        {
            jfs.Url = ConfigurationManager.AppSettings["WebSvrUrl"];
        }
        public List<JFModel> GetPhoneDetail(JFModel mJf, ObjectControls oCtrl, DateTime dtmNow)
        {
            return (List<JFModel>)cmn.DeserializeObject(jfs.GetPhoteDetail(cmn.SerializeObject(mJf), cmn.SerializeObject(oCtrl), dtmNow));
        }
    }
}
