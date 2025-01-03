﻿using StudentsManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagamentShared.StudentRepository
{
    public interface IStudentRepository
    {
        Task<Student> AddStudentAsync(Student student);
        Task<Student> GetStudentByIdAsync(int id);
        Task<List<Student>> GetStudentsAsync();
        Task<Student> UpdateStudentAsync(Student student);
        Task<bool> DeleteStudentAsync(int id);
    }
}
