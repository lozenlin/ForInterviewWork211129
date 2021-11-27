using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Services
{
    /// <summary>
    /// 服務層共用底層
    /// </summary>
    /// <history>
    /// 2021/11/27, lozenlin, add
    /// </history>
    public interface IServiceBase
    {
        /// <summary>
        /// DB command 執行後的錯誤訊息
        /// </summary>
        /// <history>
        /// 2021/11/27, lozenlin, add
        /// </history>
        public string GetDbErrMsg();
    }
}
