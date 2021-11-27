using Common.Data.Domain.Models;
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
        /// 取得資料清單
        /// </summary>
        /// <history>
        /// 2021/11/27, lozenlin, add
        /// </history>
        public List<Department> GetList()
        {
            List<Department> entities = null;

            entities = _deptDao.GetList();
            dbErrMsg = _deptDao.GetErrMsg();

            return entities;
        }
    }
}
