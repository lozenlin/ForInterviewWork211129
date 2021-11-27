using Common.Data.Domain.Models;
using Common.Services.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Logging;

namespace Common.DataAccess.EFCore
{
    /// <summary>
    /// 員工資料存取
    /// </summary>
    /// <history>
    /// 2021/11/27, lozenlin, add
    /// </history>
    public class EmployeeDataAccess : IEmployeeDataAccess
    {
        protected FIWContext _fiwCtx = null;
        protected ILogger<EmployeeDataAccess> _logger;
        protected string errMsg = "";

        public EmployeeDataAccess(FIWContext fiwCtx, ILogger<EmployeeDataAccess> logger)
        {
            if (fiwCtx == null)
                throw new ArgumentException("fiwCtx");

            if (logger == null)
                throw new ArgumentException("logger");

            _fiwCtx = fiwCtx;
            _logger = logger;
        }

        /// <summary>
        /// 執行後的錯誤訊息
        /// </summary>
        /// <history>
        /// 2021/11/27, lozenlin, add
        /// </history>
        public string GetErrMsg()
        {
            return errMsg;
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

            try
            {
                entities = (from e in _fiwCtx.Employee
                            select e).ToList();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "");
                errMsg = ex.Message;
            }

            return entities;
        }
    }
}
