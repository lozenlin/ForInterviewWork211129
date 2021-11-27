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
    }
}
