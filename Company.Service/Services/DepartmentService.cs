﻿using Company.Data.Models;
using Company.Reposatory.Interfaces;
using Company.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public void Add(Department department)
        {
            var mappedDepartment = new Department
            {
                Code = department.Code,
                Name = department.Name,
                CreateAt = DateTime.Now,
            };

            _departmentRepository.Add(mappedDepartment);
        }

        public void Delete(Department department)
        {
            _departmentRepository.Delete(department);
        }

        public IEnumerable<Department> GetAll()
        {
            var departments = _departmentRepository.GetAll();
            return departments;

        }

        public Department GetById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            var department = _departmentRepository.GetById(id.Value);
            if (department == null)
            {
                return null;
            }

            return department;
        }

        public void Update(Department department)
        {
            
            _departmentRepository.Update(department);
            

        }
    }
}
