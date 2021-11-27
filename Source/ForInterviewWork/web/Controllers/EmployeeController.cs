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
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _empSvc;
        private readonly ILogger<HomeController> _logger;

        public EmployeeController(IEmployeeService empSvc, ILogger<HomeController> logger)
        {
            if (empSvc == null)
                throw new ArgumentException("empSvc");

            if (logger == null)
                throw new ArgumentException("logger");

            _empSvc = empSvc;
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<Employee> entities = _empSvc.GetList();

            return View();
        }
    }
}
