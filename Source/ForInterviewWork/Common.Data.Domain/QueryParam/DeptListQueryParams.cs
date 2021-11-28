using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Data.Domain.QueryParam
{
    /// <summary>
    /// 取得部門清單用的查詢條件
    /// </summary>
    /// <history>
    /// 2021/11/28, lozenlin, add
    /// </history>
    public class DeptListQueryParams
    {
        public string Kw = "";
        public PagedListQueryParams PagedParams;

        public DeptListQueryParams()
        {
            PagedParams = new PagedListQueryParams();
        }
    }
}
