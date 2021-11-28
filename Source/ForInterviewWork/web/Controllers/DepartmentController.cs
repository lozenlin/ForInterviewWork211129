using Common.Data.Domain.Models;
using Common.Data.Domain.QueryParam;
using Common.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web.Models;

namespace web.Controllers
{
    /// <summary>
    /// 部門管理
    /// </summary>
    /// <history>
    /// 2021/11/27, lozenlin, add
    /// </history>
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _deptSvc;
        private readonly ILogger<HomeController> _logger;


        public DepartmentController(IDepartmentService deptSvc, ILogger<HomeController> logger)
        {
            if (deptSvc == null)
                throw new ArgumentException("deptSvc");

            if (logger == null)
                throw new ArgumentException("logger");

            _deptSvc = deptSvc;
            _logger = logger;
        }

        public IActionResult Index()
        {
            DeptListQueryParams param = new DeptListQueryParams()
            {
                Kw = ""
            };

            param.PagedParams = new PagedListQueryParams()
            {
                BeginNum = 0,
                EndNum = 0,
                SortField = "",
                IsSortDesc = false
            };

            // 取得總筆數
            _deptSvc.GetListForManage(param);

            // 設定分頁控制項(未來),取得起迄編號
            ViewData["RowCount"] = param.PagedParams.RowCount;

            param.PagedParams.BeginNum = 1;
            param.PagedParams.EndNum = 9999999;

            List<DepartmentForManage> entities = _deptSvc.GetListForManage(param);

            return View(entities);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var cr = new ClientResult()
            {
                b = false,
                err = ""
            };

            DeptParams param = new DeptParams() { DeptId = id };
            bool result = _deptSvc.DeleteData(param);
            cr.b = result;

            if (!result)
            {
                if (param.IsThereEmployeesOfDept)
                {
                    cr.err = "不允許刪除已有員工的部門資料!";
                }
                else
                    cr.err = _deptSvc.GetDbErrMsg();
            }

            return Json(cr);
        }
    }
}
