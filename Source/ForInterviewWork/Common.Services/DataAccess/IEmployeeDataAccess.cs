using System;
using System.Collections.Generic;
using System.Text;
using Common.Data.Domain.Models;

namespace Common.Services.DataAccess
{
    /// <summary>
    /// 員工資料存取
    /// </summary>
    /// <history>
    /// 2021/11/27, lozenlin, add
    /// </history>
    public interface IEmployeeDataAccess
    {
        /// <summary>
        /// 取得資料清單
        /// </summary>
        /// <history>
        /// 2021/11/27, lozenlin, add
        /// </history>
        public List<Employee> GetList();
        /// <summary>
        /// 執行後的錯誤訊息
        /// </summary>
        /// <history>
        /// 2021/11/27, lozenlin, add
        /// </history>
        public string GetErrMsg();
    }
}
