using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
    public static class StudentProcessor
    {
        public static int CreateStudent(int studentID, string firstName, string lastName, string birthDate, string phone, string email, string course)
        {
            //map student model from front-end to back-end model
            StudentModel data = new StudentModel
            {
                StudentID = studentID,
                FirstName = firstName,
                LastName = lastName,
                BirthDate = birthDate,
                Phone = phone,
                Email = email,
                Course = course
            };
            //parameterized sql to pass to SaveData return function
            string sql = @"insert into dbo.Students (StudentID, Firstname, LastName, BirthDate, Phone, Email, Course)
                            values (@StudentID, @Firstname, @Lastname, @BirthDate, @Phone, @Email, @Course);";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<StudentModel> LoadStudents()
        {
            string sql = @"select StudentID, Firstname, LastName, BirthDate, Phone, Email, Course from dbo.Students;";

            return SqlDataAccess.LoadData<StudentModel>(sql);
        }
    }
}
