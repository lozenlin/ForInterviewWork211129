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

        /// <summary>
        /// 刪除資料
        /// </summary>
        /// <history>
        /// 2021/11/28, lozenlin, add
        /// </history>
        public bool DeleteData(int deptId)
        {
            _logger.LogDebug("DeleteData(deptId)");

            try
            {
                // 檢查所屬員工數量
                if (_fiwCtx.Employee.Any(emp => emp.DeptId == deptId))
                {
                    sqlErrNumber = 50000;
                    sqlErrState = 2;
                    return false;
                }

                Department entity = _fiwCtx.Department.Find(deptId);
                _fiwCtx.Department.Remove(entity);
                _fiwCtx.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "");
                errMsg = ex.Message;
                return false;
            }

            return true;
        }

        /// <summary>
        /// 取得最大排序編號
        /// </summary>
        /// <history>
        /// 2021/11/28, lozenlin, add
        /// </history>
        public int GetMaxSortNo()
        {
            _logger.LogDebug("GetMaxSortNo()");
            int result = 0;

            try
            {
                result = _fiwCtx.Department.Max(obj => obj.SortNo) ?? 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "");
                errMsg = ex.Message;
                return -1;
            }

            return result;
        }

        /// <summary>
        /// 新增資料
        /// </summary>
        /// <history>
        /// 2021/11/28, lozenlin, add
        /// </history>
        public InsertResult InsertData(Department entity)
        {
            _logger.LogDebug("InsertData(entity)");
            InsertResult insResult = new InsertResult() { IsSuccess = false };

            try
            {
                //檢查重覆名稱
                if(_fiwCtx.Department.Any(dept=>dept.DeptName == entity.DeptName))
                {
                    sqlErrNumber = 50000;
                    sqlErrState = 2;
                    return insResult;
                }

                _fiwCtx.Department.Add(entity);
                _fiwCtx.SaveChanges();
                insResult.NewId = entity.DeptId;

                insResult.IsSuccess = true;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "");
                errMsg = ex.Message;
                return insResult;
            }

            return insResult;
        }

        /// <summary>
        /// 取得管理用資料
        /// </summary>
        /// <history>
        /// 2021/11/28, lozenlin, add
        /// </history>
        public DepartmentForManage GetDataForManage(int deptId)
        {
            _logger.LogDebug("GetDataForManage(deptId)");
            DepartmentForManage entity = null;

            try
            {
                entity = (from d in _fiwCtx.Department
                          where d.DeptId == deptId
                          select new DepartmentForManage()
                          {
                              DeptId = d.DeptId,
                              DeptName = d.DeptName,
                              SortNo = d.SortNo,
                              PostAccount = d.PostAccount,
                              PostDate = d.PostDate,
                              MdfAccount = d.MdfAccount,
                              MdfDate = d.MdfDate
                          }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "");
                errMsg = ex.Message;
                return null;
            }

            return entity;
        }

        /// <summary>
        /// 更新資料
        /// </summary>
        /// <history>
        /// 2021/11/28, lozenlin, add
        /// </history>
        public bool UpdateData(DeptParams param)
        {
            _logger.LogDebug("UpdateData(param)");

            try
            {
                // 檢查重覆名稱
                if (_fiwCtx.Department.Any(dept => dept.DeptName == param.DeptName && dept.DeptId != param.DeptId))
                {
                    sqlErrNumber = 50000;
                    sqlErrState = 2;
                    return false;
                }

                Department entity = _fiwCtx.Department.Find(param.DeptId);
                entity.DeptName = param.DeptName;
                entity.SortNo = param.SortNo;
                entity.MdfAccount = param.PostAccount;
                entity.MdfDate = DateTime.Now;

                _fiwCtx.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "");
                errMsg = ex.Message;
                return false;
            }

            return true;
        }

    }
}
