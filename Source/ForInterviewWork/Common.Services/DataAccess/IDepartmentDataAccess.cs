using Common.Data.Domain.Models;
using Common.Data.Domain.QueryParam;
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
        /// 取得管理用資料清單
        /// </summary>
        /// <history>
        /// 2021/11/27, lozenlin, add
        /// 2021/11/28, lozenlin, modify, 改為取得管理用資料清單
        /// </history>
        public List<DepartmentForManage> GetListForManage(DeptListQueryParams param);
        /// <summary>
        /// 刪除資料
        /// </summary>
        /// <history>
        /// 2021/11/28, lozenlin, add
        /// </history>
        public bool DeleteData(int deptId);
    }
}
