using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Services.Impl
{
    /// <summary>
    /// 服務層共用底層
    /// </summary>
    /// <history>
    /// 2021/11/27, lozenlin, add
    /// </history>
    public class ServiceBase : IServiceBase
    {
        protected ILogger<ServiceBase> _logger;
        protected string dbErrMsg = "";

        public ServiceBase(ILogger<ServiceBase> logger)
        {
            if (logger == null)
                throw new ArgumentException("logger");

            _logger = logger;

        }

        /// <summary>
        /// DB command 執行後的錯誤訊息
        /// </summary>
        /// <history>
        /// 2021/11/27, lozenlin, add
        /// </history>
        public string GetDbErrMsg()
        {
            return dbErrMsg;
        }
    }
}
