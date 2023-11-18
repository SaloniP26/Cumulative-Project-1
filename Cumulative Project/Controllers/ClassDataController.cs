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
    public class ClassDataController : ApiController
    {
        private SchoolDbContext School = new SchoolDbContext();

        [HttpGet]
        [Route("api/ClassData/ListClasses")]

        public IEnumerable<Class> ListClasses()
        {
            MySqlConnection Conn = School.AccessDatabase();

            Conn.Open();
            MySqlCommand cmd = Conn.CreateCommand();

            string query = "SELECT * FROM Classes";

            cmd.CommandText = query;

            MySqlDataReader ResultSet = cmd.ExecuteReader();

            List<Class> Classes = new List<Class>();

            while (ResultSet.Read())
            {
                {
                    int ClassId = Convert.ToInt32(ResultSet["classid"]);
                    string ClassCode = ResultSet["classcode"].ToString();
                    int TeacherId = Convert.ToInt32(ResultSet["teacherid"]);
                    DateTime StartDate = Convert.ToDateTime(ResultSet["startdate"]);
                    DateTime FinishDate = Convert.ToDateTime(ResultSet["finishdate"]);
                    string ClassName = ResultSet["classname"].ToString();

                    Class NewClass = new Class();
                    NewClass.ClassId = ClassId;
                    NewClass.ClassCode = ClassCode;
                    NewClass.TeacherId = TeacherId;
                    NewClass.StartDate = StartDate;
                    NewClass.FinishDate = FinishDate;
                    NewClass.ClassName = ClassName;

                    Classes.Add(NewClass);
                };
            }
            Conn.Close();

            return Classes;
        }

        [HttpGet]
        [Route("api/ClassData/FindClass/{Classid}")]
        public Class Findclass(int Classid)
        {
            Class NewClass = new Class();

            MySqlConnection Conn = School.AccessDatabase();

            Conn.Open();
            MySqlCommand cmd = Conn.CreateCommand();

            string query = "SELECT * FROM Classes where classid = " + Classid;

            cmd.CommandText = query;

            MySqlDataReader ResultSet = cmd.ExecuteReader();

            while (ResultSet.Read())
            {
                int ClassId = Convert.ToInt32(ResultSet["classid"]);
                string ClassCode = ResultSet["classcode"].ToString();
                int TeacherId = Convert.ToInt32(ResultSet["teacherid"]);
                DateTime StartDate = Convert.ToDateTime(ResultSet["startdate"]);
                DateTime FinishDate = Convert.ToDateTime(ResultSet["finishdate"]);
                string ClassName = ResultSet["classname"].ToString();

                NewClass.ClassId = ClassId;
                NewClass.ClassCode = ClassCode;
                NewClass.TeacherId = TeacherId;
                NewClass.StartDate = StartDate;
                NewClass.FinishDate = FinishDate;
                NewClass.ClassName = ClassName;
            }

            return NewClass;
        }
    }
}