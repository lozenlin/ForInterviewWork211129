using Common.Data.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Services
{
    /// <summary>
    /// 部門管理
    /// </summary>
    /// <history>
    /// 2021/11/27, lozenlin, add
    /// </history>
    public interface IDepartmentService
    {
        /// <summary>
        /// 取得資料清單
        /// </summary>
        /// <history>
        /// 2021/11/27, lozenlin, add
        /// </history>
        public List<Department> GetList();
    }
}
