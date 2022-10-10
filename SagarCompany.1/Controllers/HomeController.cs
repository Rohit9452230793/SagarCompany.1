using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SagarCompany._1.Models;

namespace SagarCompany._1.Controllers
{
    public class HomeController : Controller
    {
        SqlConnection con = new SqlConnection(@"Data Source=suryasonkar;Initial Catalog=SSSAAA;Integrated Security=True");

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registration(Models.RegistrationCls obj)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand
                ("[Proc_InsertUpdateDeleteOrSelect]", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "1");
            cmd.Parameters.AddWithValue("@Branchcode", obj.BranchCode);
            cmd.Parameters.AddWithValue("@BrachName", obj.Brachname);
            cmd.Parameters.AddWithValue("@ShortName", obj.shortName);
            cmd.Parameters.AddWithValue("@Address", obj.Address);
            cmd.Parameters.AddWithValue("@City", obj.City);
            cmd.Parameters.AddWithValue("@PinCode", obj.pinCode);
            cmd.Parameters.AddWithValue("@Zone", obj.Zone);
            cmd.Parameters.AddWithValue("@ContactPerson", obj.ContactPerson);
            cmd.Parameters.AddWithValue("@EmailId", obj.EmailId);
            cmd.Parameters.AddWithValue("@Hub", obj.Hub);
            cmd.Parameters.AddWithValue("@Vender", obj.Vender);
            cmd.Parameters.AddWithValue("@Active", obj.Active);
            cmd.Parameters.AddWithValue("@S_id", obj.S_id);



            SqlDataAdapter SqlData = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            SqlData.Fill(dt);
            if (dt != null && dt.Rows.Count > 0)
            {
                ViewBag.msg = System.Convert.ToString(dt.Rows[0]["msg"]);
            }
            else
            {
                ViewBag.msg = "Record Not Submitted";
            }
            return View();
        }






        [HttpPost]
        public ActionResult Edit(int S_id)
        {

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand
                 ("[Proc_InsertUpdateDeleteOrSelect]", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "2");
            cmd.Parameters.AddWithValue("@S_id", S_id);

            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlData.Fill(dt);
            RegistrationCls obj = new RegistrationCls();
            if (dt != null && dt.Rows.Count > 0)
            {
                obj.S_id = S_id;
                obj.BranchCode = dt.Rows[0]["BranchCode"].ToString();
                obj.Brachname = dt.Rows[0]["Brachname"].ToString();
                obj.shortName = dt.Rows[0]["shortName"].ToString();
                obj.Address = dt.Rows[0]["Address"].ToString();
                obj.City = dt.Rows[0]["City"].ToString();
                obj.pinCode = dt.Rows[0]["pinCode"].ToString();
                obj.Zone = dt.Rows[0]["Zone"].ToString();
                obj.ContactPerson = dt.Rows[0]["ContactPerson"].ToString();
                obj.EmailId = dt.Rows[0]["EmailId"].ToString();
                obj.Hub = dt.Rows[0]["Hub"].ToString();
                obj.Vender = dt.Rows[0]["Vender"].ToString();
                obj.Active = dt.Rows[0]["Active"].ToString();

            }
            return View(obj);
        }





        [HttpGet]
        public ActionResult Display()

        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand
               ("[Proc_InsertUpdateDeleteOrSelect]", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "3");
            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlData.Fill(dt);
            ViewBag.data = dt;
            return View();
        }






        public ActionResult Delete(int S_id)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand
                ("[Proc_InsertUpdateDeleteOrSelect]", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action"," 4");
            cmd.Parameters.AddWithValue("@S_id", "S_id");
            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlData.Fill(dt);
               RegistrationCls obj = new RegistrationCls();
             return Redirect("/Home/Display");
        }
    }
}