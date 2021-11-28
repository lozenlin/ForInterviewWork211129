using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace web.Models.ViewModels
{
    /// <summary>
    /// 部門編輯VM
    /// </summary>
    /// <history>
    /// 2021/11/28, lozenlin, add
    /// </history>
    public class DepartmentViewModel
    {
        public int DeptId { get; set; }
        [DisplayName("部門名稱")]
        [Required]
        public string DeptName { get; set; }
        [DisplayName("排序編號")]
        [Required]
        public int SortNo { get; set; }
        [DisplayName("建立者")]
        public string PostAccount { get; set; }
        [DisplayName("建立日期")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        public DateTime? PostDate { get; set; }
        [DisplayName("更新者")]
        public string MdfAccount { get; set; }
        [DisplayName("更新日期")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        public DateTime? MdfDate { get; set; }
    }
}
