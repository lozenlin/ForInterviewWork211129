using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Data.Domain.QueryParam
{
    /// <summary>
    /// 
    /// </summary>
    /// <history>
    /// 2021/11/28, lozenlin, add
    /// </history>
    public class PagedListQueryParams
    {
        public int BeginNum;
        public int EndNum;
        public string SortField = "";
        public bool IsSortDesc = false;
        public int RowCount;

        /// <summary>
        /// 開頭先跳過多少量
        /// </summary>
        public int GetSkipCount()
        {
            int skipCount = BeginNum - 1;

            if (skipCount < 0)
                skipCount = 0;

            return skipCount;
        }

        /// <summary>
        /// 要抓取多少量
        /// </summary>
        public int GetTakeCount()
        {
            int takeCount = EndNum - BeginNum + 1;

            if (takeCount < 0 || BeginNum <= 0)
                takeCount = 0;

            return takeCount;
        }
    }
}
