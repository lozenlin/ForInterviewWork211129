using Common.Data.Domain.Models;
using Common.Data.Domain.QueryParam;
using Common.Services.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Services.Impl
{
    /// <summary>
    /// 部門管理
    /// </summary>
    /// <history>
    /// 2021/11/27, lozenlin, add
    /// </history>
    public class DepartmentService : ServiceBase, IDepartmentService
    {
        protected IDepartmentDataAccess _deptDao = null;

        public DepartmentService(IDepartmentDataAccess deptDao, ILogger<EmployeeService> logger)
            : base(logger)
        {
            if (deptDao == null)
                throw new ArgumentException("deptDao");

            _deptDao = deptDao;
        }

        /// <summary>
        /// 取得管理用資料清單
        /// </summary>
        /// <history>
        /// 2021/11/27, lozenlin, add
        /// 2021/11/28, lozenlin, modify, 改為取得管理用資料清單
        /// </history>
        public List<DepartmentForManage> GetListForManage(DeptListQueryParams param)
        {
            List<DepartmentForManage> entities = null;

            entities = _deptDao.GetListForManage(param);
            dbErrMsg = _deptDao.GetErrMsg();

            return entities;
        }
    }
}
