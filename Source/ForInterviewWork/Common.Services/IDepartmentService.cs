using Common.Data.Domain.Models;
using Common.Data.Domain.QueryParam;
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
    public interface IDepartmentService : IServiceBase
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
        public bool DeleteData(DeptParams param);
        /// <summary>
        /// 取得最大排序編號
        /// </summary>
        /// <history>
        /// 2021/11/28, lozenlin, add
        /// </history>
        public int GetMaxSortNo();
        /// <summary>
        /// 新增資料
        /// </summary>
        /// <history>
        /// 2021/11/28, lozenlin, add
        /// </history>
        public bool InsertData(DeptParams param);

    }
}
