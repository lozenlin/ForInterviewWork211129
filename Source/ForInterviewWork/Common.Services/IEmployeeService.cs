using System;
using System.Collections.Generic;
using System.Text;
using Common.Data.Domain.Models;

namespace Common.Services
{
    /// <summary>
    /// 員工管理
    /// </summary>
    /// <history>
    /// 2021/11/27, lozenlin, add
    /// </history>
    public interface IEmployeeService
    {
        /// <summary>
        /// 取得資料清單
        /// </summary>
        /// <history>
        /// 2021/11/27, lozenlin, add
        /// </history>
        public List<Employee> GetList();
        /// <summary>
        /// DB command 執行後的錯誤訊息
        /// </summary>
        /// <history>
        /// 2021/11/27, lozenlin, add
        /// </history>
        public string GetDbErrMsg();
    }
}
