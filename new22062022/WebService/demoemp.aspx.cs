using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class demoemp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.BindGrid();
        this.Bindlabel();
    }

    protected void submit_Click(object sender, EventArgs e)
    {
        WebServiceDemo.demowebservice service = new WebServiceDemo.demowebservice();
        string fname = txtfname.Text.ToString();
        string lname = txtlname.Text.ToString();
        string gender = txtgender.Text.ToString();
        DateTime dob = DateTime.Parse(txtdob.Text.ToString());
        string city = txtgender.Text.ToString();
        DateTime doj = DateTime.Parse(txtdoj.Text.ToString());
        int salary = int.Parse(txtsalary.Text.ToString());

        service.AddEmployee(fname,lname,gender,dob,city,doj,salary);
        lblclear.Text = "Data Successfully";
        clear();
        BindGrid();
    }

    private void BindGrid()
    {
        WebServiceDemo.demowebservice service = new WebServiceDemo.demowebservice();
        GridView1.DataSource = service.DisplayAllEmployee();
        GridView1.DataBind();
    }
    private void Bindlabel()
    {
        WebServiceDemo.demowebservice service = new WebServiceDemo.demowebservice();
        lbltext.Text = service.DisplayAllEmployee();
        lbltext.DataBind();
    }

    public void clear()
    {
        txtfname.Text = "";
        txtlname.Text = "";
        txtgender.Text = "";
        txtdob.Text = "";
        txtcity.Text = "";
        txtdoj.Text = "";
        txtsalary.Text = "";
    }

}