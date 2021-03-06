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
    public class EmployeeDataAccess : DataAccessBase, IEmployeeDataAccess
    {

        public EmployeeDataAccess(FIWContext fiwCtx, ILogger<EmployeeDataAccess> logger)
            : base(fiwCtx, logger)
        {
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
