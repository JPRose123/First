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
                PersonIDOSVClient client = new PersonIDOSVClient();
                UFSoft.UBF.Exceptions.MessageBase[] retMessages; ; //异常信息
                object context; //上下文
                OptType = "CreatePerson";//操作类型
                //构建联系对象类
                Person ct = new Person();
                ct.OrgCode = "101";
                ct.ContactCode = "Junior";
                ct.HROrgCode = "";
                ct.EmployeeCategoryCode = "Y01";
                ct.PersonCode = "Junior";
                ct.LastName = "袁";
                ct.FirstName = "军";
                ct.BusinessOrgCode = "101";
                ct.DeptCode = "20";
                ct.PositionCode = null;
                ct.JobCode = "ZW06";
                ct.Sex = "0";
                ct.CertificateType = "362201199501102657";
                ct.Country = null;
                ct.StartDate = "2021-01-10";
                ct.DimissionDate = "2022-01-10";
                ct.OwnerOrgCode = "101";
                ct.CreateOrgCode = "101";
                ct.WorkingOrgCode = "101";
                ct.AssgnBeginDate = "2021-01-10";
                ct.ResponsibilityType = null;
                  ct.SuperiorPositionCode = null;
                ct.SuperiorWorkOrgCode = "101";
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

        public class Person
        {
            /// <summary>
            /// 组织编码
            /// </summary>
            public string OrgCode { get; set; }
            /// <summary>
            /// 联系对象编码
            /// </summary>
            public string ContactCode { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string HROrgCode { get; set; }
            /// <summary>
            /// 	员工类别（员工工作记录） 必填  
            /// </summary>
            public string EmployeeCategoryCode { get; set; }
            /// <summary>
            /// 人员编码（联系对象）(	（员工工作记录）-员工编号)	LinkMan
            /// </summary>
            public string PersonCode { get; set; }
            /// <summary>
            /// 姓
            /// </summary>
            public string LastName { get; set; }
            /// <summary>
            /// 名
            /// </summary>
            public string FirstName { get; set; }
            /// <summary>
            /// 		现任业务组织(员工工作记录)（	员工任职记录	）
            /// </summary>
            public string BusinessOrgCode { get; set; }
            /// <summary>
            /// 	现任部门(员工工作记录)
            /// </summary>
            public string DeptCode { get; set; }
            /// <summary>
            /// 	现任岗位（员工工作记录）
            /// </summary>
            public string PositionCode { get; set; }
            /// <summary>
            /// 	现任职务（员工工作记录） Job对象
            /// </summary>
            public string JobCode { get; set; }
            /// <summary>
            /// 性别
            /// </summary>
            public string Sex { get; set; }
            /// <summary>
            /// 	证件类别(证件号码)必填
            /// </summary>
            public string CertificateType { get; set; }
            /// <summary>
            /// 国籍
            /// </summary>
            public string Country { get; set; }
            /// <summary>
            /// 就业日期 必填
            /// </summary>
            public string StartDate { get; set; }
            /// <summary>
            /// 	离职日期（员工工作记录）
            /// </summary>
            public string DimissionDate { get; set; }
            /// <summary>
            /// 	工作人事组织（员工工作记录）
            /// </summary>
            public string OwnerOrgCode { get; set; }
            /// <summary>
            /// 	创建组织（员工工作记录）
            /// </summary>
            public string CreateOrgCode { get; set; }
            /// <summary>
            /// 	工作人事组织（员工工作记录）
            /// </summary>
            public string WorkingOrgCode { get; set; }
            /// <summary>
            /// 	入职日期（员工工作记录）
            /// </summary>
            public string AssgnBeginDate { get; set; }
            /// <summary>
            /// 	责任类型（	员工工作汇报关系）
            /// </summary>
            public string ResponsibilityType { get; set; }
            /// <summary>
            /// 	上级岗位（	员工工作汇报关系）
            /// </summary>
            public string SuperiorPositionCode { get; set; }
            /// <summary>
            /// 	上级工作人事组织（	员工工作汇报关系）
            /// </summary>
            public string SuperiorWorkOrgCode { get; set; }

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
