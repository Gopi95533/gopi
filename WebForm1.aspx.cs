using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace DropdownlistEx
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private void GetCountries()
        {
          
           // SqlConnection con = new SqlConnection("data source=GOPI;database=ddldemo;integrated security=yes");
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constr"].ToString());
            SqlDataAdapter da = new SqlDataAdapter("select * from country ", con);
            DataSet ds = new DataSet();
            da.Fill(ds,"country");
            DropDownList1.DataSource = ds;
            DropDownList1.DataTextField = "countryname";
            DropDownList1.DataValueField= "countryid";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, "select Coumtry");
        }
        private void GetStates()
        {
           
            //SqlConnection con = new SqlConnection("data source=GOPI;database=ddldemo;integrated security=yes");
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constr"].ToString());
            string query ="select s.stateid,s.statename from country c inner join state s on c.countryid=s.countryid Where c.countryname='"+DropDownList1.SelectedItem.ToString()+"'";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "state");
            DropDownList2.DataSource = ds;
            DropDownList2.DataTextField = "statename";
            DropDownList2.DataValueField = "stateid";
            DropDownList2.DataBind();
            DropDownList2.Items.Insert(0, "select State");
        }
        private void GetCitys()
        {
           
          // SqlConnection con = new SqlConnection("data source=GOPI;database=ddldemo;integrated security=yes");
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constr"].ToString());
            string query ="select c.cityid,c.cityname from state s inner join city c on s.stateid=c.stateid where s.statename='"+DropDownList2.SelectedItem.ToString()+"'";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "city");
            DropDownList3.DataSource = ds;
            DropDownList3.DataTextField = "cityname";
            DropDownList3.DataValueField = "cityid";
            DropDownList3.DataBind();
            DropDownList3.Items.Insert(0, "select City");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack) 
            {
                GetCountries();

            }

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetStates();

        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetCitys();

        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
           
           //SqlConnection con = new SqlConnection("data source=GOPI;database=ddldemo;integrated security=yes");
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Constr"].ToString());
            string query = "select e1.eno,e1.ename,e1.salary from emp e1 inner join city c on e1.cityid=c.cityid where c.cityname='" + DropDownList3.SelectedItem.ToString() + "'";
            SqlDataAdapter da = new SqlDataAdapter(query, con);

            DataSet ds = new DataSet();
            da.Fill(ds, "emp");
            GridView1.DataSource = ds;
            GridView1.DataBind();

        }
    }
}