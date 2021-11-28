using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.Models
{
    /// <summary>
    /// 給 js client 的資料結構
    /// </summary>
    /// <history>
    /// 2021/11/28, lozenlin, add
    /// </history>
    public class ClientResult
    {
        /// <summary>
        /// boolean of result
        /// </summary>
        public bool b { get; set; }

        /// <summary>
        /// error message
        /// </summary>
        public string err { get; set; }

        /// <summary>
        /// object of data
        /// </summary>
        public object o { get; set; }
    }
}
