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

        /// <summary>
        /// 刪除資料
        /// </summary>
        /// <history>
        /// 2021/11/28, lozenlin, add
        /// </history>
        public bool DeleteData(DeptParams param)
        {
            bool result = false;

            result = _deptDao.DeleteData(param.DeptId);
            dbErrMsg = _deptDao.GetErrMsg();

            if(!result && _deptDao.GetSqlErrNumber() == 50000 && _deptDao.GetSqlErrState() == 2)
            {
                param.IsThereEmployeesOfDept = true;
            }

            return result;
        }

        /// <summary>
        /// 取得最大排序編號
        /// </summary>
        /// <history>
        /// 2021/11/28, lozenlin, add
        /// </history>
        public int GetMaxSortNo()
        {
            int result = 0;

            result = _deptDao.GetMaxSortNo();
            dbErrMsg = _deptDao.GetErrMsg();

            return result;
        }

        /// <summary>
        /// 新增資料
        /// </summary>
        /// <history>
        /// 2021/11/28, lozenlin, add
        /// </history>
        public bool InsertData(DeptParams param)
        {
            InsertResult insResult = new InsertResult() { IsSuccess = false };

            Department entity = new Department()
            {
                DeptName = param.DeptName,
                SortNo = param.SortNo,
                PostAccount = param.PostAccount,
                PostDate = DateTime.Now
            };

            insResult = _deptDao.InsertData(entity);
            dbErrMsg = _deptDao.GetErrMsg();

            if (insResult.IsSuccess)
            {
                param.DeptId = (int)insResult.NewId;
            }
            else if(_deptDao.GetSqlErrNumber() == 50000 && _deptDao.GetSqlErrState() == 2)
            {
                param.HasDeptNameBeenUsed = true;
            }

            return insResult.IsSuccess;
        }

        /// <summary>
        /// 取得管理用資料
        /// </summary>
        /// <history>
        /// 2021/11/28, lozenlin, add
        /// </history>
        public DepartmentForManage GetDataForManage(int deptId)
        {
            DepartmentForManage entity = null;

            entity = _deptDao.GetDataForManage(deptId);
            dbErrMsg = _deptDao.GetErrMsg();

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
            bool result = false;

            result = _deptDao.UpdateData(param);
            dbErrMsg = _deptDao.GetErrMsg();

            if (!result && _deptDao.GetSqlErrNumber() == 50000 && _deptDao.GetSqlErrState() == 2)
            {
                param.HasDeptNameBeenUsed = true;
            }

            return result;
        }

    }
}
