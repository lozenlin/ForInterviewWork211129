using Common.Data.Domain.Models;
using Common.Services.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DataAccess.EFCore
{
    /// <summary>
    /// 資料存取共用底層
    /// </summary>
    /// <history>
    /// 2021/11/27, lozenlin, add
    /// </history>
    public class DataAccessBase : IDataAccessBase
    {
        protected FIWContext _fiwCtx = null;
        protected ILogger<DataAccessBase> _logger;
        protected string errMsg = "";
        protected int sqlErrNumber = 0;
        protected int sqlErrState = 0;

        public DataAccessBase(FIWContext fiwCtx, ILogger<DataAccessBase> logger)
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
        /// sql error number
        /// </summary>
        /// <history>
        /// 2021/11/28, lozenlin, add
        /// </history>
        public int GetSqlErrNumber()
        {
            return sqlErrNumber;
        }

        /// <summary>
        /// sql error state
        /// </summary>
        /// <history>
        /// 2021/11/28, lozenlin, add
        /// </history>
        public int GetSqlErrState()
        {
            return sqlErrState;
        }

    }
}
