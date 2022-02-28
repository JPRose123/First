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

        private void CreateContact_Click(object sender, EventArgs e)
        {
            // ReturnData ret = new ReturnData();
            string Json = string.Empty;
            string OptType = string.Empty;
            try
            {
                ContactIDOSVClient client = new ContactIDOSVClient();
                UFSoft.UBF.Exceptions.MessageBase[] retMessages; ; //异常信息
                object context; //上下文
                OptType = "CreateContact";//操作类型
                //构建联系对象类
                Contact ct = new Contact();
                ct.Code = "Test00101";
                ct.Name = "张理";
                ct.ContactType = 0;
                ct.Title = "袁";
                ct.Department = "销售部";
                ct.EnterpriseKey = "101";
                ct.Gender = 0;
                ct.LocationCode = "BeiJingCN";
                ct.IsEmployeeContact = true;
                ct.PersonName = new PersonName();
                ct.PersonName.DisplayName = "科比";
                ct.PersonName.FirstName = "乔";
                ct.PersonName.LastName = "斯";
                ct.PersonName.MiddleName = "布";
                ct.PersonName.NickName = "jack";
                ct.Email = new ContactEmail();
                ct.Email.EmailAddr = "582773757@qq.com";
                ct.Mobil = new ContactMobil();
                ct.Mobil.MobilNum = "18718218662";
                ct.Mobil.Country = "01";
                ct.Phone = new ContactPhone();
                ct.Phone.PhoneNum = "8534490";
                ct.Phone.Country = "01";
                ct.Phone.Ext = "02";
                ct.Phone.Territory = "03";
                ct.Fax = new ContactFax();
                ct.Fax.FaxNum = "8534490";
                ct.URL = new ContactURL();
                ct.URL.URLAddr = "www.baidu.com";
                ct.IM = new ContactIM();
                ct.IM.IMAddress = "58277395788";
                ct.BeepPager = new ContactBeepPager();
                ct.BeepPager.BP = "88";
                ct.BeepPager.Exchange = "889";
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

        public class Contact
          {
            public string Code { get; set; }
            public string Name { get; set; }

            public int ContactType { get; set; }
            public bool IsEmailNotify { get; set; } 
            public bool IsMessageNotify { get; set; }
            public bool IsOrgContact { get; set; }
            public bool IsCustomerContact { get; set; } 
            public bool IsSupplierContact { get; set; }
            public bool IsEmployeeContact { get; set; } 
            public string Title { get; set; }
            public string Department { get; set; }
            public string EnterpriseKey { get; set; }

            public PersonName PersonName { get; set; }
            public int Gender { get; set; }
            public string LocationCode { get; set; }
            public ContactEmail Email { get; set; }
            public ContactMobil Mobil { get; set; }
            public ContactPhone Phone { get; set; }
            public ContactFax Fax { get; set; }
            public ContactBeepPager BeepPager { get; set; }
            public ContactURL URL { get; set; }
            public ContactIM IM { get; set; }
            public byte[] Seal { get; set; }

        }
        public class ContactIM
        {
            public string IMAddress { get; set; }
        }
        public class ContactURL
        {
            public string URLAddr { get; set; }
        }
        public class ContactBeepPager
        {
            public string BP { get; set; }
            public string Exchange { get; set; }
        }
        public class ContactFax
        {
            public string FaxNum { get; set; }
        }
        public class ContactPhone
        {
            public string MobilNum { get; set; }
            public string Country { get; set; }
            public string Ext { get; set; }
            public string Territory { get; set; }
            public string PhoneNum { get; set; }
        }
        public class ContactMobil
        {
            public string MobilNum { get; set; }
            public string Country { get; set; }
        }
        public class ContactEmail
        {
            public string EmailAddr { get; set; }
        }
        public class PersonName
        {
            public string DisplayName { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string MiddleName { get; set; }
            public string NickName { get; set; }
        }



    }
   
}
