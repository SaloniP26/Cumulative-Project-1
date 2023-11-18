using Cumulative_Project.Models;
using MySql.Data.MySqlClient;
using Microsoft.Ajax.Utilities;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Xml.Linq;

namespace Cumulative_Project.Controllers
{
    public class StudentDataController : ApiController
    {
        private SchoolDbContext School = new SchoolDbContext();

        [HttpGet]
        [Route("api/StudentData/ListStudents")]

        public IEnumerable<Student> ListStudents()
        {
            MySqlConnection Conn = School.AccessDatabase();

            Conn.Open();
            MySqlCommand cmd = Conn.CreateCommand();

            string query = "SELECT * FROM students";

            cmd.CommandText = query;

            MySqlDataReader ResultSet = cmd.ExecuteReader();

            List<Student> Students = new List<Student>();

            while (ResultSet.Read())
            {
                {
                    int StudentId = Convert.ToInt32(ResultSet["studentid"]);
                    string FirstName = ResultSet["studentfname"].ToString();
                    string LastName = ResultSet["studentlname"].ToString();
                    string StudentNumber = ResultSet["studentnumber"].ToString();
                    DateTime EnrolDate = Convert.ToDateTime(ResultSet["enroldate"]);

                    Student NewStudent = new Student();
                    NewStudent.StudentId = StudentId;
                    NewStudent.FirstName = FirstName;
                    NewStudent.LastName = LastName;
                    NewStudent.StudentNumber = StudentNumber;
                    NewStudent.EnrolDate = EnrolDate;

                    Students.Add(NewStudent);
                };
            }
            Conn.Close();

            return Students;
        }

        [HttpGet]
        [Route("api/StudentData/FindStudent/{Studentid}")]
        public Student Findstudent(int Studentid)
        {
            Student NewStudent = new Student();

            MySqlConnection Conn = School.AccessDatabase();

            Conn.Open();
            MySqlCommand cmd = Conn.CreateCommand();

            string query = "SELECT * FROM Students where studentid = " + Studentid;

            cmd.CommandText = query;

            MySqlDataReader ResultSet = cmd.ExecuteReader();

            while (ResultSet.Read())
            {
                int StudentId = Convert.ToInt32(ResultSet["studentid"]);
                string FirstName = ResultSet["studentfname"].ToString();
                string LastName = ResultSet["studentlname"].ToString();
                string StudentNumber = ResultSet["studentnumber"].ToString();
                DateTime EnrolDate = Convert.ToDateTime(ResultSet["enroldate"]);

                NewStudent.StudentId = StudentId;
                NewStudent.FirstName = FirstName;
                NewStudent.LastName = LastName;
                NewStudent.StudentNumber = StudentNumber;
                NewStudent.EnrolDate = EnrolDate;
            }

            return NewStudent;
        }
    }
}