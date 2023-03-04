using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedicineAdministration
{
    public partial class SMS : Form
    {
        private string THE_UID = "yanglv1"; //用户名
        private string THE_KEY = "51B6F822FB98DA2F24DDACAC9FC03132"; //接口秘钥
        public SMS()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string number = txt_Num.Text.Trim();
            string smsText = textBox1.Text.Trim();
            string PostUrl = GetPostUrl(number, smsText);

            string result = PostSmsInfo(PostUrl);

            string t = GetResult(result);
        }
        public string GetPostUrl(string phonenumber, string smsText)
        {
            string posturl = "http://utf8.sms.webchinese.cn/?Uid=" + THE_UID + "&key=" + THE_KEY + "&smsMob=" + phonenumber + "&smsText=" + smsText;
            //string posturl = "http://gbk.api.smschinese.cn/?Uid=本站用户名&Key=接口安全秘钥&smsMob=手机号码&smsText=验证码:8888";
            //string posturl = "http://gbk.api.smschinese.cn/?Uid=THE_UID&Key=THE_KEY&smsMob=number&smsText=验证码:8888";
            return posturl;
        }
        public string PostSmsInfo(string url)
        {
            //调用时只需要把拼成的URL传给该函数即可。判断返回值即可
            string strRet = null;

            if (url == null || url.Trim().ToString() == "")
            {
                return strRet;
            }
            string targeturl = url.Trim().ToString();
            try
            {
                HttpWebRequest hr = (HttpWebRequest)WebRequest.Create(targeturl);
                hr.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1)";
                hr.Method = "GET";
                hr.Timeout = 30 * 60 * 1000;
                WebResponse hs = hr.GetResponse();
                Stream sr = hs.GetResponseStream();
                StreamReader ser = new StreamReader(sr, Encoding.Default);
                strRet = ser.ReadToEnd();
            }
            catch (Exception ex)
            {
                strRet = null;
            }
            return strRet;
        }
        /// <summary>
        /// 确认返回信息 
        /// </summary>
        /// <param name="strRet"></param>
        /// <returns></returns>
        public string GetResult(string strRet)
        {
            int result = 0;
            try
            {
                result = int.Parse(strRet);
                switch (result)
                {
                    case -1:
                        strRet = "没有该用户账户";
                        break;
                    case -2:
                        strRet = "接口密钥不正确,不是账户登陆密码";
                        break;
                    case -21:
                        strRet = "MD5接口密钥加密不正确";
                        break;
                    case -3:
                        strRet = "短信数量不足";
                        break;
                    case -11:
                        strRet = "该用户被禁用";
                        break;
                    case -14:
                        strRet = "短信内容出现非法字符";
                        break;
                    case -4:
                        strRet = "手机号格式不正确";
                        break;
                    case -41:
                        strRet = "手机号码为空";
                        break;
                    case -42:
                        strRet = "短信内容为空";
                        break;
                    case -51:
                        strRet = "短信签名格式不正确,接口签名格式为：【签名内容】";
                        break;
                    case -6:
                        strRet = "IP限制";
                        break;
                    default:
                        strRet = "发送短信数量：" + result;
                        break;
                }
            }
            catch (Exception ex)
            {
                strRet = ex.Message;
            }
            return strRet;
        }

    }
}

