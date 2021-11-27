using Common.Data.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Services.DataAccess
{
    /// <summary>
    /// 部門資料存取
    /// </summary>
    /// <history>
    /// 2021/11/27, lozenlin, add
    /// </history>
    public interface IDepartmentDataAccess : IDataAccessBase
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
