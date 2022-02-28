using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using UFSoft.UBF.Service;

namespace WFTestForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void CreatePerSon_Click(object sender, EventArgs e)
        {
            // ReturnData ret = new ReturnData();
            string Json = string.Empty;
            string OptType = string.Empty;
            try
            {
                //特别注意:该接口仅用在未来U9系统，其他品类公司不需要使用
                SecondStoreILowerHairSVClient client = new SecondStoreILowerHairSVClient();
                UFSoft.UBF.Exceptions.MessageBase[] retMessages; ; //异常信息
                object context; //上下文
                OptType = "SecondStoreLowerHair";//操作类型
                //构建联系对象类
                SecondStore ct = new SecondStore();
                ct.OrgCode = "101";
                ct.CustomerCode = "01.003";
                //Json格式化
                string Outstr = string.Empty;
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                Json=serializer.Serialize(ct);
                Outstr = "传入Json:"+Json.ToString();
                context = CreateContextObj();
                string catchstring = client.Do(out retMessages, context, OptType, Json);
                //返回参数Json解析
               // RntJson ret = serializer.Deserialize<RntJson>(catchstring);
                Outstr= Outstr+ "输出Json:"+ catchstring;
                textBox1.Text = Outstr;
            }
            catch (Exception ex)                                                //捕获异常信息
            {
                throw new Exception(ex.ToString());
            }

        }
        public static UFSoft.UBF.Util.Context.ThreadContext CreateContextObj()
        {

            UFSoft.UBF.Util.Context.ThreadContext thContext = new UFSoft.UBF.Util.Context.ThreadContext();
            System.Collections.Generic.Dictionary<object, object> ns = new Dictionary<object, object>();
            ns.Add("OrgID", "1001905067645401");                 //未来测试账套组织
            ns.Add("UserID", "1001906290409403");         //admin --
            ns.Add("Datetime", DateTime.Now);                         //12072308
            ns.Add("CultureName", "zh-CN");                             //中文
            ns.Add("EnterpriseID", "005");                                       //未来测试账套企业编码
            ns.Add("DefaultCultureName", "zh-CN");
            ns.Add("Support_CultureNameList", "zh-CN");        //U9BZ
            thContext.nameValueHas = ns;
            return thContext;
        }

        public class SecondStore
        {
            /// <summary>
            /// 人员便编码
            /// </summary>
            public string OrgCode { get; set; }
            //}
            public string CustomerCode { get; set; }
        }
        //public class PersonDeleteModel
        //{
        //    /// <summary>
        //    /// 人员便编码
        //    /// </summary>
        //    public string PersonCode { get; set; }
        //}


    }
   
}
