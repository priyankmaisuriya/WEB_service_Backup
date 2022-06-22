using System;
using System.Collections.Generic;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

/// <summary>
/// Summary description for demowebservice
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.ComponentModel.ToolboxItem(false)]
[System.Web.Script.Services.ScriptService]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class demowebservice : System.Web.Services.WebService
{

    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Exocube"].ConnectionString);
    MySqlConnection mycon = new MySqlConnection(ConfigurationManager.ConnectionStrings["MyExocube"].ConnectionString);
    SqlCommand cmd;
    MySqlCommand mycmd;
    SqlDataReader rdr;
    MySqlDataReader myrdr;
    DataTable dt;

    public demowebservice()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    //display employee 
    [WebMethod]
    public string DisplayAllEmployee()
    {
        SqlDataReader rdr;
        DataTable dt = new DataTable();
        String resultJSON = "";
        JavaScriptSerializer js = new JavaScriptSerializer();
        try
        {
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            //Open the Connection
            con.Open();
            //Execute command
            cmd = new SqlCommand("select * from Employee_info", con);

            //Read data
            rdr = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(rdr);
            con.Close();
            //Create object of JavaScriptSerializer 
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            //Create Dictionary for storing data in key and value format
            List<Dictionary<String, Object>> tableRows = new List<Dictionary<string, object>>();
            //create object of dictionary
            Dictionary<String, Object> row;
            //Retrieving all data
            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    row.Add(col.ColumnName, dr[col].ToString());
                }
                tableRows.Add(row);
            }
            //Get the result into Json format
            resultJSON = serializer.Serialize(new { empdata = tableRows }).ToString();
        }
        catch (Exception ex)
        {
            resultJSON = ex.Message.ToString();
        }
        return resultJSON;
    }

    [WebMethod]
    public string ProcedureDisplayAllEmployee()
    {
        SqlDataReader rdr;
        DataTable dt = new DataTable();
        String resultJSON = "";
        JavaScriptSerializer js = new JavaScriptSerializer();
        try
        {
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            //Open the Connection
            con.Open();
            //Execute command
            cmd = new SqlCommand("disempinfo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            //Read data
            rdr = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(rdr);
            con.Close();
            //Create object of JavaScriptSerializer 
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            //Create Dictionary for storing data in key and value format
            List<Dictionary<String, Object>> tableRows = new List<Dictionary<string, object>>();
            //create object of dictionary
            Dictionary<String, Object> row;
            //Retrieving all data
            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    row.Add(col.ColumnName, dr[col].ToString());
                }
                tableRows.Add(row);
            }
            //Get the result into Json format
            resultJSON = serializer.Serialize(new { empdata = tableRows }).ToString();
        }
        catch (Exception ex)
        {
            resultJSON = ex.Message.ToString();
        }
        return resultJSON;
    }

    //insert of employee
    [WebMethod]
    public Boolean AddEmployee(string firstname, string lastname, string gender, DateTime dob, string city, DateTime dateofjoining, int salary)
    {
        string cs = ConfigurationManager.ConnectionStrings["Exocube"].ConnectionString;
        using (SqlConnection con = new SqlConnection(cs))
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Employee_info(FirstName,LastName,Gender,DateOfBirth,City,DateOfJoining,Salary) values (@firstname,@lastname,@gender,@dob, @city, @dateofjoining, @salary)", con);
            cmd.Parameters.AddWithValue("@firstname", firstname);
            cmd.Parameters.AddWithValue("@lastname", lastname);
            cmd.Parameters.AddWithValue("@gender", gender);
            cmd.Parameters.AddWithValue("@dob", dob);
            cmd.Parameters.AddWithValue("@city", city);
            cmd.Parameters.AddWithValue("@dateofjoining", dateofjoining);
            cmd.Parameters.AddWithValue("@salary", salary);

            int i = 0;
            i = cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    //insert of employee
    [WebMethod]
    public Boolean ProcedureAddEmployee(string FirstName, string LastName, string Gender, DateTime DateOfBirth, string City, DateTime DateOfJoining, int Salary)
    {
        string cs = ConfigurationManager.ConnectionStrings["Exocube"].ConnectionString;
        using (SqlConnection con = new SqlConnection(cs))
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insempinfo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FirstName", FirstName);
            cmd.Parameters.AddWithValue("@LastName", LastName);
            cmd.Parameters.AddWithValue("@Gender", Gender);
            cmd.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            cmd.Parameters.AddWithValue("@City", City);
            cmd.Parameters.AddWithValue("@DateOfJoining", DateOfJoining);
            cmd.Parameters.AddWithValue("@Salary", Salary);

            int i = 0;
            i = cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    //insert of employee
    [WebMethod]
    public Boolean AddJsonConfig(string json_value)
    {
        string cs = ConfigurationManager.ConnectionStrings["MyExocube"].ConnectionString;
        using (MySqlConnection mycon = new MySqlConnection(cs))
        {
            mycon.Open();
            MySqlCommand mycmd = new MySqlCommand("insert into Json_Configure_Table(json_value,updated_datetime) values (@json_value, CURRENT_TIMESTAMP())", mycon);
            mycmd.Parameters.AddWithValue("@json_value", json_value);

            int i = 0;
            i = mycmd.ExecuteNonQuery();
            mycon.Close();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    [WebMethod]
    public string DisplayJsonConfig()
    {
        MySqlDataReader myrdr;
        DataTable dt = new DataTable();
        String resultJSON = "";
        JavaScriptSerializer js = new JavaScriptSerializer();
        try
        {
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            //Open the Connection
            mycon.Open();
            //Execute command
            mycmd = new MySqlCommand("select * from Json_Configure_Table", mycon);

            //Read data
            myrdr = mycmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(myrdr);
            mycon.Close();
            //Create object of JavaScriptSerializer 
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            //Create Dictionary for storing data in key and value format
            List<Dictionary<String, Object>> tableRows = new List<Dictionary<string, object>>();
            //create object of dictionary
            Dictionary<String, Object> row;
            //Retrieving all data
            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    row.Add(col.ColumnName, dr[col].ToString());
                }
                tableRows.Add(row);
            }
            //Get the result into Json format
            resultJSON = serializer.Serialize(new { jsondata = tableRows }).ToString();
        }
        catch (Exception ex)
        {
            resultJSON = ex.Message.ToString();
        }
        return resultJSON;
    }

    [WebMethod]
    public string DisplayAllDatabase()
    {
        SqlDataReader rdr;
        DataTable dt = new DataTable();
        String resultJSON = "";
        JavaScriptSerializer js = new JavaScriptSerializer();
        try
        {
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            //Open the Connection
            con.Open();
            //Execute command
            cmd = new SqlCommand("select name from sys.Databases WHERE database_id > 4", con);
            //Read data
            rdr = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(rdr);
            con.Close();
           
            JavaScriptSerializer serializer = new JavaScriptSerializer();
        
            List<Dictionary<String, Object>> tableRows = new List<Dictionary<string, object>>();
         
            Dictionary<String, Object> row;
        
            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    row.Add(col.ColumnName, dr[col].ToString());
                }
                tableRows.Add(row);
            }
            //Get the result into Json format
            resultJSON = serializer.Serialize(tableRows);
            //resultJSON = JsonConvert.SerializeObject(tableRows, Newtonsoft.Json.Formatting.Indented);

        }
        catch (Exception ex)
        {
            resultJSON = ex.Message.ToString();
        }
        return resultJSON;
    }

    [WebMethod]
    public string demodb()
    {
        SqlDataReader rdr;
        DataTable dt = new DataTable();
        String resultJSON = "";
        JavaScriptSerializer js = new JavaScriptSerializer();
        try
        {
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            //Open the Connection
            con.Open();
            //Execute command
            cmd = new SqlCommand("select name from sys.Databases WHERE database_id > 4", con);
            //Read data
            rdr = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(rdr);
            con.Close();

            JavaScriptSerializer serializer = new JavaScriptSerializer();

            List<String> tableRows = new List<string>();

            foreach (DataRow dr in dt.Rows)
            {
               
                foreach (DataColumn col in dt.Columns)
                {
                    tableRows.Add(dr[col].ToString());
                }
               
            }
            //Get the result into Json format
            resultJSON = serializer.Serialize(new { tableRows});
            //resultJSON = JsonConvert.SerializeObject(tableRows, Newtonsoft.Json.Formatting.Indented);

        }
        catch (Exception ex)
        {
            resultJSON = ex.Message.ToString();
        }
        return resultJSON;
    }

    [WebMethod]
    public string DisplayAllTables(string db_name)
    {
        SqlDataReader rdr;
        DataTable dt = new DataTable();
        String resultJSON = "";
        JavaScriptSerializer js = new JavaScriptSerializer();
        try
        {
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            //Open the Connection
            con.Open();
            //Execute command
            cmd = new SqlCommand("SELECT TABLE_NAME FROM " + db_name + ".INFORMATION_SCHEMA.tables where TABLE_TYPE = 'BASE TABLE'", con);
            cmd.Parameters.AddWithValue("@db_name", db_name);
            //Read data
            rdr = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(rdr);
            con.Close();
            //Create object of JavaScriptSerializer 
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            //Create Dictionary for storing data in key and value format
            List<Dictionary<String, Object>> tableRows = new List<Dictionary<string, object>>();
            //create object of dictionary
            Dictionary<String, Object> row;
            //Retrieving all data
            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    row.Add(col.ColumnName, dr[col].ToString());
                }
                tableRows.Add(row);
            }
            //Get the result into Json format
            resultJSON = serializer.Serialize(new { tbldata = tableRows }).ToString();
        }
        catch (Exception ex)
        {
            resultJSON = ex.Message.ToString();
        }
        return resultJSON;
    }

    [WebMethod]
    public string DisplayAllColumns(string db_name, string TABLE_NAME)
    {
        SqlDataReader rdr;
        DataTable dt = new DataTable();
        String resultJSON = "";
        JavaScriptSerializer js = new JavaScriptSerializer();
        try
        {
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            //Open the Connection
            con.Open();
            //Execute command
            cmd = new SqlCommand("SELECT COLUMN_NAME FROM " + db_name + ".INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = @TABLE_NAME", con);
            cmd.Parameters.AddWithValue("@db_name", db_name);
            cmd.Parameters.AddWithValue("@TABLE_NAME", TABLE_NAME);
            //Read data
            rdr = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(rdr);
            con.Close();
            //Create object of JavaScriptSerializer 
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            //Create Dictionary for storing data in key and value format
            List<Dictionary<String, Object>> tableRows = new List<Dictionary<string, object>>();
            //create object of dictionary
            Dictionary<String, Object> row;
            //Retrieving all data
            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    row.Add(col.ColumnName, dr[col].ToString());
                }
                tableRows.Add(row);
            }
            //Get the result into Json format
            resultJSON = serializer.Serialize(new { coldata = tableRows }).ToString();
        }
        catch (Exception ex)
        {
            resultJSON = ex.Message.ToString();
        }
        return resultJSON;
    }
}
