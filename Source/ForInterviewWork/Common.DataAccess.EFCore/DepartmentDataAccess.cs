using Common.Data.Domain.Models;
using Common.Services.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Common.Data.Domain.QueryParam;
using Common.DataAccess.EFCore.ExtensionMethods;

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
        /// 取得管理用資料清單
        /// </summary>
        /// <history>
        /// 2021/11/27, lozenlin, add
        /// 2021/11/28, lozenlin, modify, 改為取得管理用資料清單
        /// </history>
        public List<DepartmentForManage> GetListForManage(DeptListQueryParams param)
        {
            _logger.LogDebug("GetListForManage(param)");
            List<DepartmentForManage> entities = null;

            try
            {
                var tempQuery = from d in _fiwCtx.Department
                                select new DepartmentForManage()
                                {
                                    DeptId = d.DeptId,
                                    DeptName = d.DeptName,
                                    SortNo = d.SortNo,
                                    PostAccount = d.PostAccount,
                                    PostDate = d.PostDate,
                                    MdfAccount = d.MdfAccount,
                                    MdfDate = d.MdfDate,
                                    EmpTotal = d.Employee.Count()
                                };

                // Query conditions

                if (param.Kw != "")
                {
                    tempQuery = tempQuery.Where(obj => obj.DeptName.Contains(param.Kw));
                }

                // total
                param.PagedParams.RowCount = tempQuery.Count();

                // sorting
                if (param.PagedParams.SortField != "")
                {
                    tempQuery = tempQuery.OrderBy(param.PagedParams.SortField, param.PagedParams.IsSortDesc);
                }
                else
                {
                    // default
                    tempQuery = tempQuery.OrderBy(obj => obj.SortNo);
                }

                // paging
                int skipCount = param.PagedParams.GetSkipCount();
                int takeCount = param.PagedParams.GetTakeCount();

                if (skipCount > 0)
                {
                    tempQuery = tempQuery.Skip(skipCount);
                }

                if (takeCount >= 0)
                {
                    tempQuery = tempQuery.Take(takeCount);
                }

                // result
                entities = tempQuery.ToList();
                int rowNum = 1;

                foreach (var entity in entities)
                {
                    entity.RowNum = skipCount + rowNum;
                    rowNum++;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "");
                errMsg = ex.Message;
            }

            return entities;
        }
    }
}
