using Microsoft.Ajax.Utilities;
using MySql.Data.MySqlClient;
using Cumulative_Project.Models;
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
    public class TeacherDataController : ApiController
    {
        private SchoolDbContext School = new SchoolDbContext();

        [HttpGet]
        [Route("api/TeacherData/ListTeachers")]

        public IEnumerable<Teacher> ListTeachers()
        {
            MySqlConnection Conn = School.AccessDatabase();

            Conn.Open();
            MySqlCommand cmd = Conn.CreateCommand();

            string query = "SELECT * FROM Teachers";

            cmd.CommandText = query;

            MySqlDataReader ResultSet = cmd.ExecuteReader();

            List<Teacher> Teachers = new List<Teacher>();

            while (ResultSet.Read())
            {
                {
                    int Id = Convert.ToInt32(ResultSet["teacherid"]);
                    string Name = ResultSet["teacherfname"].ToString();
                    string LastName = ResultSet["teacherlname"].ToString();
                    DateTime HireDate = Convert.ToDateTime(ResultSet["hiredate"]);
                    Decimal Salary = Convert.ToDecimal(ResultSet["salary"]);

                    Teacher NewTeacher = new Teacher();
                    NewTeacher.Id = Id;
                    NewTeacher.Name = Name;
                    NewTeacher.LastName = LastName;
                    NewTeacher.HireDate = HireDate;
                    NewTeacher.Salary = Salary;

                    //string TeacherName = ResultSet["teacherid"] + " " + ResultSet["teacherfname"]+ " " + ResultSet["hiredate"]+ " " + ResultSet["salary"];
                    Teachers.Add(NewTeacher);
                };
            }
            Conn.Close();

            return Teachers;
        }

        [HttpGet]
        [Route("api/TeacherData/Findteacher/{id}")]
        public Teacher Findteacher(int id)
        {
            Teacher NewTeacher = new Teacher();

            MySqlConnection Conn = School.AccessDatabase();

            Conn.Open();
            MySqlCommand cmd = Conn.CreateCommand();

            string query = "SELECT * FROM Teachers where teacherid = " + id;

            cmd.CommandText = query;

            MySqlDataReader ResultSet = cmd.ExecuteReader();

            while (ResultSet.Read())
            {
                int Id = Convert.ToInt32(ResultSet["teacherid"]);
                string Name = ResultSet["teacherfname"].ToString();
                string LastName = ResultSet["teacherlname"].ToString();
                DateTime HireDate = Convert.ToDateTime(ResultSet["hiredate"]);
                Decimal Salary = Convert.ToDecimal(ResultSet["salary"]);

                NewTeacher.Id = Id;
                NewTeacher.Name = Name;
                NewTeacher.LastName = LastName;
                NewTeacher.HireDate = HireDate;
                NewTeacher.Salary = Salary;
            }

            return NewTeacher;
        }
    }
}