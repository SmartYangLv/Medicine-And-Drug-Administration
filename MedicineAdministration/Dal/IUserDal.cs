using MedicineAdministration.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicineAdministration.Dal
{
    /// <summary>
    /// 数据访问层（接口）
    /// </summary>
    public interface IUserDal
    {
        /// <summary>
        /// 插入用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        int insert(User  user);
        /// <summary>
        /// 查询用户
        /// </summary>
        /// <param name="UserNo"></param>
        /// <returns></returns>
        User Selet(string UserNo);
        /// <summary>
        /// 查询用户计数
        /// </summary>
        /// <param name="UserNo"></param>
        /// <returns></returns>
        int SelectCount(string UserNo);
        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        int Update(User user);
    }
}
