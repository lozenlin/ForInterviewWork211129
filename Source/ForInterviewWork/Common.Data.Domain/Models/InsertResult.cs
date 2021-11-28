using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Data.Domain.Models
{
    /// <summary>
    /// 新增資料的回傳結果
    /// </summary>
    /// <history>
    /// 2021/11/28, lozenlin, add
    /// </history>
    public class InsertResult
    {
        public bool IsSuccess { get; set; }
        public object NewId { get; set; }
    }
}
