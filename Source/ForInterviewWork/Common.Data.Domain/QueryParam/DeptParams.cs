using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Data.Domain.QueryParam
{
    /// <summary>
    /// 異動部門用的參數
    /// </summary>
    /// <history>
    /// 2021/11/28, lozenlin, add
    /// </history>
    public class DeptParams
    {
        public int DeptId;
        public string DeptName;
        public int SortNo;
        public string PostAccount;
        /// <summary>
        /// return:部門名稱是否重覆
        /// </summary>
        public bool HasDeptNameBeenUsed = false;
        /// <summary>
        /// return:部門已有帳號使用
        /// </summary>
        public bool IsThereEmployeesOfDept = false;
    }
}
