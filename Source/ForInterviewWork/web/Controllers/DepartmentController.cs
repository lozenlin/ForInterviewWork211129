using Common.Data.Domain.Models;
using Common.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            List<Department> entities = _deptSvc.GetList();

            return View();
        }
    }
}
