using Common.Data.Domain.Models;
using Common.Services.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Services.Impl
{
    public class EmployeeService : IEmployeeService
    {
        protected IEmployeeDataAccess _empDao = null;
        protected ILogger<EmployeeService> _logger;
        protected string dbErrMsg = "";

        /// <summary>
        /// 員工管理
        /// </summary>
        /// <history>
        /// 2021/11/27, lozenlin, add
        /// </history>
        public EmployeeService(IEmployeeDataAccess empDao, ILogger<EmployeeService> logger)
        {
            if (empDao == null)
                throw new ArgumentException("empDao");

            if (logger == null)
                throw new ArgumentException("logger");

            _empDao = empDao;
            _logger = logger;

        }

        /// <summary>
        /// DB command 執行後的錯誤訊息
        /// </summary>
        /// <history>
        /// 2021/11/27, lozenlin, add
        /// </history>
        public string GetDbErrMsg()
        {
            return dbErrMsg;
        }

        /// <summary>
        /// 取得資料清單
        /// </summary>
        /// <history>
        /// 2021/11/27, lozenlin, add
        /// </history>
        public List<Employee> GetList()
        {
            List<Employee> entities = null;

            entities = _empDao.GetList();
            dbErrMsg = _empDao.GetErrMsg();

            return entities;
        }
    }
}
