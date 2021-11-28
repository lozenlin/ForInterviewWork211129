using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Data.Domain.Models
{
    /// <summary>
    /// 管理用部門資料
    /// </summary>
    public class DepartmentForManage
    {
        public int DeptId { get; set; }
        public string DeptName { get; set; }
        public int? SortNo { get; set; }
        public string PostAccount { get; set; }
        public DateTime? PostDate { get; set; }
        public string MdfAccount { get; set; }
        public DateTime? MdfDate { get; set; }
        public int EmpTotal { get; set; }
        public int RowNum { get; set; }
    }
}
