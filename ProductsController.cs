using ProductsMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ProductsMVC.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ModuleEndExam;Integrated Security=True;";
            cn.Open();

            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = cn;
            cmdInsert.CommandType = System.Data.CommandType.StoredProcedure;
            cmdInsert.CommandText = "SelectProcedure";
            List<Product> Prod = new List<Product>();
            try
            {
                SqlDataReader dr = cmdInsert.ExecuteReader();
                while (dr.Read())
                {
                    Prod.Add(new Product { ProductId = (int)dr["ProductId"], ProductName = dr["ProductName"].ToString(), Rate = dr.GetDecimal(2), Description = dr["Description"].ToString(), CategoryName = dr["CategoryName"].ToString() });

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
            
            return View(Prod);
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id = 101)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ModuleEndExam;Integrated Security=True;";
            cn.Open();
            
            SqlCommand cmdEdit = new SqlCommand();
            cmdEdit.CommandType = System.Data.CommandType.StoredProcedure;
            cmdEdit.CommandText = "UpdateProcedure";
            cmdEdit.Parameters.AddWithValue("@ProductID", id);

            SqlDataReader dr = cmdEdit.ExecuteReader();
            Product prod = null;
            try
            {
                while (dr.Read())
                {
                    prod = new Product { ProductId = (int)dr["ProductId"], ProductName=(string)dr["ProductName"], Rate=(decimal)dr["Rate"], Description=(string)dr["Description"], CategoryName=(string)dr["CategoryName"]};

                }
                dr.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }

            return View(prod);
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit( Product Prod, int id=101)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ModuleEndExam;Integrated Security=True;";
            cn.Open();

            SqlCommand cmdEdit = new SqlCommand();
            cmdEdit.Connection = cn;
            cmdEdit.CommandType = System.Data.CommandType.Text;
            cmdEdit.CommandText = "update Product set ProductName = @ProductName, Rate = @Rate, Description = @Description, CategoryName = @CategoryName where ProductID = @ProductId";
            cmdEdit.Parameters.AddWithValue("@ProductID", id);
            cmdEdit.Parameters.AddWithValue("@ProductName", Prod.ProductName);
            cmdEdit.Parameters.AddWithValue("@Rate", Prod.Rate);
            cmdEdit.Parameters.AddWithValue("@Description", Prod.Description);
            cmdEdit.Parameters.AddWithValue("@CategoryName", Prod.CategoryName);


            try
            {
                cmdEdit.ExecuteNonQuery();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                
            }
            finally
            {
                cn.Close();
            }
            return View();
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Products/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
