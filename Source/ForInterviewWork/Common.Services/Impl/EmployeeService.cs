using Common.Data.Domain.Models;
using Common.Services.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Services.Impl
{
    public class EmployeeService : IEmployeeService
    {
        protected IEmployeeDataAccess _empDao = null;

        /// <summary>
        /// 員工管理
        /// </summary>
        /// <history>
        /// 2021/11/27, lozenlin, add
        /// </history>
        public EmployeeService(IEmployeeDataAccess empDao)
        {
            if (empDao == null)
                throw new ArgumentException("empDao");
        }

        /// <summary>
        /// 取得資料清單
        /// </summary>
        /// <history>
        /// 2021/11/27, lozenlin, add
        /// </history>
        public List<Employee> GetList()
        {
            List<Employee> entities = null;


            return entities;
        }
    }
}
