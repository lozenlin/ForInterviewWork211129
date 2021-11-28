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
using web.Models.ViewModels;

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

        public IActionResult Index(string kw)
        {
            DeptListQueryParams param = new DeptListQueryParams()
            {
                Kw = kw ?? ""
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

            ViewData["kwIn"] = kw ?? "";

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

        [HttpGet]
        public IActionResult Create()
        {
            DepartmentViewModel deptVM = new DepartmentViewModel()
            {
                SortNo = _deptSvc.GetMaxSortNo() + 10
            };

            ViewData["Title"] = "新增部門";

            return View("Config", deptVM);
        }

        [HttpPost]
        public IActionResult Create(DepartmentViewModel deptVM)
        {
            if (!ModelState.IsValid)
            {
                return View("Config");
            }

            DeptParams param = new DeptParams()
            {
                DeptName = deptVM.DeptName.Trim(),
                SortNo = deptVM.SortNo,
                PostAccount = "admin"
            };

            bool result = _deptSvc.InsertData(param);

            if (!result)
            {
                if (param.HasDeptNameBeenUsed)
                {
                    TempData["toShowErrMsg"] = "新增失敗! 原因:名稱重覆";
                }
                else
                {
                    TempData["toShowErrMsg"] = "新增失敗!";
                }

                return View("Config");
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            DepartmentForManage dept = _deptSvc.GetDataForManage(id);
            DepartmentViewModel deptVM = null;

            if (dept != null)
            {
                deptVM = new DepartmentViewModel()
                {
                    DeptId = dept.DeptId,
                    DeptName = dept.DeptName,
                    SortNo = dept.SortNo.Value,
                    PostAccount = dept.PostAccount,
                    PostDate = dept.PostDate,
                    MdfAccount = dept.MdfAccount,
                    MdfDate = dept.MdfDate
                };
            }
            else
            {
                deptVM = new DepartmentViewModel();
            }

            ViewData["Title"] = "修改部門";

            return View("Config", deptVM);
        }

        [HttpPost]
        public IActionResult Edit(DepartmentViewModel deptVM)
        {
            if (!ModelState.IsValid)
            {
                return View("Config");
            }

            DeptParams param = new DeptParams()
            {
                DeptId = deptVM.DeptId,
                DeptName = deptVM.DeptName.Trim(),
                SortNo = deptVM.SortNo,
                PostAccount = "admin"
            };

            bool result = _deptSvc.UpdateData(param);

            if (!result)
            {
                if (param.HasDeptNameBeenUsed)
                {
                    TempData["toShowErrMsg"] = "更新失敗! 原因:名稱重覆";
                }
                else
                {
                    TempData["toShowErrMsg"] = "更新失敗!";
                }

                return View("Config");
            }


            return RedirectToAction("Index");
        }
    }
}
