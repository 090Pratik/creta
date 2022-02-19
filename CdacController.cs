using Creta.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Creta.Controllers
{
    public class CdacController : Controller
    {
        // GET: Cdac
        public ActionResult Index()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Cdac;Integrated Security=True";
            cn.Open();
            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = cn;
            cmdInsert.CommandType = System.Data.CommandType.Text;
            cmdInsert.CommandText = "select * from Cdac";
            List<CdacCrud> crd = new List<CdacCrud>();
            try
            {
                SqlDataReader dr = cmdInsert.ExecuteReader();
                while (dr.Read())
                {
                    crd.Add(new CdacCrud { StudentId = (int)dr["StudentId"], Name = dr["Name"].ToString(), JavaMarks = (int)dr["JavaMarks"], DotNetMarks = (int)dr["DotNetMarks"] });
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }
            return View(crd);
        }

        // GET: Cdac/Details/5
        public ActionResult Details(int id)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Cdac;Integrated Security=True";
            cn.Open();
            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = cn;
            cmdInsert.CommandType = System.Data.CommandType.Text;
            cmdInsert.CommandText = "select * from Cdac where StudentId = @StudentId";
            cmdInsert.Parameters.AddWithValue("@StudentId", id);
            SqlDataReader dr = cmdInsert.ExecuteReader();
            CdacCrud crd = null;
            if (dr.Read())
            {
                crd = new CdacCrud { StudentId = (int)dr["StudentId"], Name = dr["Name"].ToString(), JavaMarks = (int)dr["JavaMarks"], DotNetMarks = (int)dr["DotNetMarks"] };
            }
            else
            {
                ViewBag.ErrorMessage = "Not Found";
            }
            cn.Close();

            return View(crd);
        }

        // GET: Cdac/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Cdac/Create
        [HttpPost]
        public ActionResult Create(CdacCrud crd)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Cdac;Integrated Security=True";
            cn.Open();
            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = cn;
            cmdInsert.CommandType = System.Data.CommandType.Text;
            cmdInsert.CommandText = "insert into Cdac values(@StudentId,@Name,@JavaMarks,@DotNetMarks)";
            cmdInsert.Parameters.AddWithValue("@StudentId", crd.StudentId);
            cmdInsert.Parameters.AddWithValue("@Name", crd.Name);
            cmdInsert.Parameters.AddWithValue("@JavaMarks", crd.JavaMarks);
            cmdInsert.Parameters.AddWithValue("@DotNetMarks", crd.DotNetMarks);

            try
            {
                // TODO: Add insert logic here
                cmdInsert.ExecuteNonQuery();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            finally
            {
                cn.Close();
            }
        }

        // GET: Cdac/Edit/5
        public ActionResult EditStd(int id=1)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Cdac;Integrated Security=True";
            cn.Open();
            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = cn;
            cmdInsert.CommandType = System.Data.CommandType.Text;
            cmdInsert.CommandText = "select * from Cdac where StudentId = @StudentId";
            cmdInsert.Parameters.AddWithValue("@StudentId", id);
            SqlDataReader dr = cmdInsert.ExecuteReader();
            CdacCrud crd = null;
            if (dr.Read())
            {
                crd = new CdacCrud { StudentId = (int)dr["StudentId"], Name = dr["Name"].ToString(), JavaMarks = (int)dr["JavaMarks"], DotNetMarks = (int)dr["DotNetMarks"] };
            }
            else
            {
                ViewBag.ErrorMessage = "Not Found";
            }
            cn.Close();
            return View(crd);
        }

        // POST: Cdac/Edit/5
        [HttpPost]
        public ActionResult EditStd (CdacCrud obj, int id=1)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Cdac;Integrated Security=True";
            cn.Open();
            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = cn;
            cmdInsert.CommandType = System.Data.CommandType.Text;
            cmdInsert.CommandText = "update Cdac set Name=@Name, JavaMarks=@JavaMarks, DotNetMarks=@DotNetMarks  where StudentId=@Id ";
            cmdInsert.Parameters.AddWithValue("@Id", id);
            cmdInsert.Parameters.AddWithValue("@Name", obj.Name);
            cmdInsert.Parameters.AddWithValue("@JavaMarks", obj.JavaMarks);
            cmdInsert.Parameters.AddWithValue("@DotNetMarks", obj.DotNetMarks);


            try
            {
                // TODO: Add update logic here
                cmdInsert.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            cn.Close();

            return RedirectToAction("Index");
        }

        // GET: Cdac/Delete/5
        public ActionResult Delete(int id=1)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Cdac;Integrated Security=True";
            cn.Open();
            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = cn;
            cmdInsert.CommandType = System.Data.CommandType.Text;
            cmdInsert.CommandText = "select * from Cdac where StudentId = @StudentId";
            cmdInsert.Parameters.AddWithValue("@StudentId", id);
            SqlDataReader dr = cmdInsert.ExecuteReader();
            CdacCrud crd = null;
            if (dr.Read())
            {
                crd = new CdacCrud { StudentId = (int)dr["StudentId"], Name = dr["Name"].ToString(), JavaMarks = (int)dr["JavaMarks"], DotNetMarks = (int)dr["DotNetMarks"] };
            }
            else
            {
                ViewBag.ErrorMessage = "Not Found";
            }
            cn.Close();
            return View(crd);

        }

        // POST: Cdac/Delete/5
        [HttpPost]
        public ActionResult Delete(int id,CdacCrud crd)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Cdac;Integrated Security=True";
            cn.Open();
            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = cn;
            cmdInsert.CommandType = System.Data.CommandType.Text;
            cmdInsert.CommandText = "delete from Cdac  where studentId=@Id ";
            cmdInsert.Parameters.AddWithValue("@Id", id);

            try
            {
                // TODO: Add delete logic here
                cmdInsert.ExecuteNonQuery();
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }

            finally
            {
                cn.Close();
            }
        }
    }
}
