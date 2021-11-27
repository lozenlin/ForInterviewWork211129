using Common.Data.Domain.Models;
using Common.Services.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

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
        protected string errMsg = "";

        public EmployeeDataAccess(FIWContext fiwCtx)
        {
            if (fiwCtx == null)
                throw new ArgumentException("fiwCtx");
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

            }
            catch(Exception ex)
            {
                errMsg = ex.Message;
            }

            return entities;
        }
    }
}
