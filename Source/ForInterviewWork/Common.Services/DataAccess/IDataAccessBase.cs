using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Services.DataAccess
{
    /// <summary>
    /// 資料存取共用底層
    /// </summary>
    /// <history>
    /// 2021/11/27, lozenlin, add
    /// </history>
    public interface IDataAccessBase
    {
        /// <summary>
        /// 執行後的錯誤訊息
        /// </summary>
        /// <history>
        /// 2021/11/27, lozenlin, add
        /// </history>
        string GetErrMsg();
        int GetSqlErrNumber();
        int GetSqlErrState();
    }
}
