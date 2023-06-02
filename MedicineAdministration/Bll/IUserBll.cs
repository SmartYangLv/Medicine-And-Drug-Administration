using MedicineAdministration.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicineAdministration.Bll
{
    /// <summary>
    /// 业务逻辑层（接口）
    /// </summary>
    public  interface IUserBll
    {
        /// <summary>
        /// 最小长度
        /// </summary>
        int UserNoMinLength { get; }
        /// <summary>
        /// 最大长度
        /// </summary>
        int UserNoMaxLength { get; }
        /// <summary>
        /// 是否登录
        /// </summary>
        bool HasLoggedIn {get; }
        /// <summary>
        /// 是否注册
        /// </summary>
        bool HasSignedUp { get; }
        /// <summary>
        /// 错误信息提示
        /// </summary>
        string Message { get; }
        /// <summary>
        /// 检查是否存在
        /// </summary>
        /// <param name="UserNo"></param>
        /// <returns></returns>
        bool CheckExist(string UserNo);
        /// <summary>
        /// 检查是否不存在
        /// </summary>
        /// <param name="UserNo"></param>
        /// <returns></returns>
        bool CheckNotExist(string UserNo);
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="UserNo"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        User  LogIn(string UserNo,string Password);
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="UserNo"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        User SingUp(string UserNo, string Password);
   }
}
