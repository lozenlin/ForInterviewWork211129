using Common.Data.Domain.Models;
using Common.Services.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Common.DataAccess.EFCore
{
    /// <summary>
    /// 部門資料存取
    /// </summary>
    /// <history>
    /// 2021/11/27, lozenlin, add
    /// </history>
    public class DepartmentDataAccess : DataAccessBase, IDepartmentDataAccess
    {
        public DepartmentDataAccess(FIWContext fiwCtx, ILogger<EmployeeDataAccess> logger)
            : base(fiwCtx, logger)
        {

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

            try
            {
                entities = (from d in _fiwCtx.Department
                            select d).ToList();
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
