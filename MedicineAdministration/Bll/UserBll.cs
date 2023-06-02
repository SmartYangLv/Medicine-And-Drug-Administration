using MedicineAdministration.Dal;
using MedicineAdministration.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MedicineAdministration.Bll
{
    /// <summary>
    /// 业务逻辑层
    /// </summary>
    public class UserBll : IUserBll
    {
        /// <summary>
        /// 用户（数据访问层）
        /// </summary>
        private IUserDal UserDal { get; set; }
        /// <summary>
        /// 登录失败次数上限
        /// </summary>
        private int LogInFailCountMax => 3;
        /// <summary>
        /// 用户名最小长度
        /// </summary>
        public int UserNoMinLength => 7;
        /// <summary>
        /// 用户名最大长度
        /// </summary>
        public int UserNoMaxLength => 10;
        /// <summary>
        /// 是否完成登录
        /// </summary>
        public bool HasLoggedIn { get; private set; }
        /// <summary>
        /// 是否完成注册
        /// </summary>
        public bool HasSignedUp { get; private set; }
        /// <summary>
        /// 信息
        /// </summary>
        public string Message { get; private set; }
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        private byte[] Md5 (string plainText)
        {
            byte[] plainBytes= Encoding.Default.GetBytes(plainText);
            MD5 md5=new MD5CryptoServiceProvider();
            byte[] cryptedBytes=md5.ComputeHash(plainBytes);
            return cryptedBytes;
        }
        /// <summary>
        /// 检查Md5值是否相同
        /// </summary>
        /// <param name="md5"></param>
        /// <param name="otherPlainText"></param>
        private bool Md5Equal(byte[] md5, string otherPlainText)
            => md5.SequenceEqual(this.Md5(otherPlainText));
        /// <summary>
        /// 用户不存在
        /// </summary>
        /// <param name="user"></param>
        /// <exception cref="ApplicationException"></exception>
        private void HandleUserNotExist(User  user)
        {
            if(user ==null )
            {
                string errorMessage = "用户不存在！";
                throw new ApplicationException (errorMessage);
            }
        }
        /// <summary>
        /// 用户被冻结
        /// </summary>
        /// <param name="user"></param>
        /// <exception cref="ApplicationException"></exception>
        private void HandleUserNotActivated(User user)
        {
            if((bool)!user.IsActivated)
            {
                string errorMessage = "用户已被冻结，需要手机验证！";
                throw new ApplicationException (errorMessage);
            }
        }
        /// <summary>
        /// 用户登录失败次数过多
        /// </summary>
        /// <param name="user"></param>
        private void HandleUserLoginFailTooManyTims(User user)
        {
            if (user .LoginFailCount >=this.LogInFailCountMax)
            {
                user.IsActivated = false;
                this.UserDal.Update(user );
            }
        }
        /// <summary>
        /// 用户登录失败
        /// </summary>
        /// <param name="user"></param>
        private void HandleUserLoginFail(User user)
        {
            user.LoginFailCount++;
            this.UserDal .Update(user);
        }
        /// <summary>
        /// 用户密码错误
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <exception cref="ApplicationException"></exception>
        private void HandleUserPasswordNotMatch(User user ,string password)
        {
            bool isPasswordMatch = this.Md5Equal(user.Password,password );
            if(!isPasswordMatch)
            {
                this.HandleUserLoginFail(user);
                this.HandleUserLoginFailTooManyTims (user);
                string errorMessage = (bool)user.IsActivated ?
                    $"密码错误，请重新输入！\n 您还有{this.LogInFailCountMax - user.LoginFailCount}此机会！"
                    : $"密码错误已达{this.LogInFailCountMax}次上限！";
                throw new ApplicationException (errorMessage);
            }
        }
        /// <summary>
        /// 用户登录成功
        /// </summary>
        /// <param name="user"></param>
        private void HandleUserLoginOK(User user)
        {
            if(user.LoginFailCount != 0)
            {
                user.LoginFailCount = 0;
                this .UserDal .Update(user);
            }
            this.HasLoggedIn = true;
            this.Message = "登录成功";

        }
        /// <summary>
        /// 检查是否存在
        /// </summary>
        /// <param name="UserNo"></param>
        /// <returns></returns>
        public bool CheckExist(string UserNo)
           =>this .UserDal .SelectCount (UserNo)==1;
        /// <summary>
        /// 检查是否不存在
        /// </summary>
        /// <param name="UserNo"></param>
        /// <returns></returns>
        public bool CheckNotExist(string UserNo)
             =>!this.CheckExist(UserNo);
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="UserNo"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public User LogIn(string UserNo, string Password)
        {
            this.HasLoggedIn =false;
            User user = this.UserDal.Selet(UserNo);
            try
            {
                this.HandleUserNotExist(user);
                this.HandleUserNotActivated(user);
                this.HandleUserPasswordNotMatch(user, Password);
                this.HandleUserLoginOK(user);
            }
            catch (ApplicationException ex)
            {
                this .Message = ex.Message;
            }
            catch (Exception )
            {
                this.Message = "登录失败!";
            }
            return user;
        }
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="UserNo"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public User SingUp(string UserNo, string Password)
        {
            this.HasSignedUp = false;
            User user = new User()
            {
                NO = UserNo,
                Password = Md5(Password),
                IsActivated = true
            };
            try
            {
                this.UserDal.insert(user);
                this.HasSignedUp = true;
                this.Message = "注册失败!";
            }
            catch (ApplicationException ex)
            {
                this.Message = $"{ex.Message}\n注册失败！";
            }
            catch (Exception)
            {
                this.Message = "注册失败!";
            }
            return user;
        }
        public UserBll()
        {
            this.UserDal=new UserDal();
        }
    }
}
