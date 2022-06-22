using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public partial class targetdata : System.Web.UI.Page
{
    
         
    string sdatabase, sschema, stname, stsolution, strgshaname, strgtblname, sgraincolumn;
    string scolname, sfunc, strgcolname, strgfunc;
    string scollist, tcollist;
    string fscolname, fsopr, fstcolname, fstopr;
    string sfilter, tfilter;
    string srow, jsondata;
    string jsonconfig, finaljsondata;
    string table_name, target_schema, column_name, source_function, target_function, filter_condition, grain_cols, sample_row;
    ///string getStateName;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            for (int j = 1; j < TotalNumberAdded; ++j)
            {
                addcontroller(j++);
            }
            btnadd.Click += new EventHandler(btnadd_Click);

            Binddropdown();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        sdatabase = ddsourcedatabase.SelectedValue.ToString();
        sschema = ddsourceschema.SelectedValue.ToString();
        stname = ddsourcetablename.SelectedValue.ToString();
        stsolution = ddtargetsolution.SelectedValue.ToString();
        strgshaname = ddtargetschemaname.SelectedValue.ToString();
        strgtblname = ddtargettablename.SelectedValue.ToString();
        sgraincolumn = ddgarincolumn.SelectedValue.ToString();


        scolname = ddsourcecolumnname.SelectedValue.ToString();
        sfunc = ddsourcefunction.SelectedValue.ToString();
        strgcolname = ddtargetcolumnname.SelectedValue.ToString();
        strgfunc = ddtargetfunction.SelectedValue.ToString();

        scollist = llbsourcecolumnlist.Text.ToString();
        tcollist = llbtargetcolumnlist.Text.ToString();

        fscolname = ddfsourcecolumnname.SelectedValue.ToString();
        fsopr = ddsourceoperator.SelectedValue.ToString();
        fstcolname = ddftargetcolumnname.SelectedValue.ToString();
        fstopr = ddtargetoperator.SelectedValue.ToString();

        sfilter = txtsourcefilter.Text.ToString();
        tfilter = txttargetfilter.Text.ToString();

        srow = txtsamplerow.Text.ToString();


        table_name = "\"table_name \": \"" + stname + "\"";
        target_schema = "\"target_schema \": \"" + strgshaname + "\"";
        column_name = "\"column_name \": [\"" + scolname + "\"]";
        source_function = "\"source_function \": [{\"" + sfunc + "\"}]";
        target_function = "\"target_function \": {\"" + strgfunc + "\"}";
        filter_condition = "\"filter_condition \": [\"" + sfilter + "\"]";
        grain_cols = "\"grain_cols \": [\"" + sgraincolumn + "\"]";
        sample_row = "\"sample_row \": \"" + srow + "\"";

        jsonconfig = "{" + table_name + "," + target_schema + "," + column_name + "," + source_function + "," + filter_condition + "," + grain_cols + "," + sample_row + "}";

        System.Console.WriteLine(jsonconfig);
        lblresult.Text = jsonconfig;

    }

    protected void btnadd_Click(object sender, EventArgs e)
    {
        TotalNumberAdded++;
        addcontroller(TotalNumberAdded);
    }

    public void addcontroller(int controller)
    {
        for (int j = 1; j < controller; j++)
        {
            string dcontroller = controller.ToString();
            var newPanel = new Panel();
            var newLabel = new Label();
            var newddl = new DropDownList();
            newLabel.Text = Label8.Text + j;

            WebServiceDemo.demowebservice service = new WebServiceDemo.demowebservice();
            string jsondata = service.demodb();
            object tableRows = JsonConvert.DeserializeObject<object>(jsondata.Replace("{\"tableRows\":[", "[").Replace("]}", "]").Replace("{", "[").Replace("}", "]"));
            JToken[] jArray = ((tableRows as JArray) as JToken).ToArray();
            List<ListItem> items = new List<ListItem>();

            for (int i = 0; i < jArray.Length; i++)
            {
                items.Add(new ListItem { Value = jArray[i].ToString() });
            }
            newddl.DataSource = items;
            //ddsourcecolumnname.DataTextField = "Text";
            newddl.DataValueField = "Value";
            newddl.DataBind();
            newddl.ID = ddsourcecolumnname + dcontroller;
            //newddl.AutoPostBack = true;
            GB.Controls.Add(newLabel);
            GB.Controls.Add(newddl);
            
            //form1.Controls.Add(newPanel);
        }
    }

    protected int TotalNumberAdded
    {
        get { return (int)(ViewState["TotalNumberAdded"] ?? 0); }
        set { ViewState["TotalNumberAdded"] = value; }
    }

    protected void ddsourcecolumnname_DataBound(object sender, EventArgs e)
    {
        ddsourcecolumnname.Items.Insert(0, "--Select source column name--");
    }
    private void Binddropdown()
    {
        WebServiceDemo.demowebservice service = new WebServiceDemo.demowebservice();
        string jsondata = service.demodb();
        object tableRows = JsonConvert.DeserializeObject<object>(jsondata.Replace("{\"tableRows\":[", "[").Replace("]}", "]").Replace("{", "[").Replace("}", "]"));

        JToken[] jArray = ((tableRows as JArray) as JToken).ToArray();
        List<ListItem> items = new List<ListItem>();
        for (int i = 0; i < jArray.Length; i++)
        {
            items.Add(new ListItem { Value = jArray[i].ToString() });
        }
        ddsourcecolumnname.DataSource = items;
        //ddsourcecolumnname.DataTextField = "Text";
        ddsourcecolumnname.DataValueField = "Value";
        ddsourcecolumnname.DataBind();
    }


}