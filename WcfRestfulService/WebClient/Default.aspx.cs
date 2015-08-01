using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebClient.Properties;
using BE;
using System.Data;
namespace WebClient
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            InitializeDataSourceEmptyData();
        }

        private void InitializeDataSourceEmptyData()
        {
            // Create a DataTable object named dtPerson.
            DataTable dtPerson = new DataTable();

            // Add four columns to the DataTable.
            dtPerson.Columns.Add("orderID");
            dtPerson.Columns.Add("TargetAudienceName");
            dtPerson.Columns.Add("TargetAudienceID");


            // Specify PersonID column as an auto increment column
            // and set the starting value and increment.
            dtPerson.Columns["orderID"].AutoIncrement = true;
            dtPerson.Columns["orderID"].AutoIncrementSeed = 1;
            dtPerson.Columns["orderID"].AutoIncrementStep = 1;

            // Set PersonID column as the primary key.
            DataColumn[] dcKeys = new DataColumn[1];
            dcKeys[0] = dtPerson.Columns["orderID"];
            dtPerson.PrimaryKey = dcKeys;





            // Get the DataTable from ViewState.
            DataTable dtPersons = dtPerson;

            // Convert the DataTable to DataView.
            DataView dvPerson = new DataView(dtPersons);




            // Bind the GridView control.
            gvPerson.DataSource = dvPerson;
            gvPerson.DataBind();

        }

        private void initTargetAudienceData(TargetAudienceList dataList)
        {
            // Create a DataTable object named dtPerson.
            DataTable dtPerson = new DataTable();

            // Add four columns to the DataTable.
            dtPerson.Columns.Add("orderID");
            dtPerson.Columns.Add("TargetAudienceName");
            dtPerson.Columns.Add("TargetAudienceID");


            // Specify PersonID column as an auto increment column
            // and set the starting value and increment.
            dtPerson.Columns["orderID"].AutoIncrement = true;
            dtPerson.Columns["orderID"].AutoIncrementSeed = 1;
            dtPerson.Columns["orderID"].AutoIncrementStep = 1;

            // Set PersonID column as the primary key.
            DataColumn[] dcKeys = new DataColumn[1];
            dcKeys[0] = dtPerson.Columns["orderID"];
            dtPerson.PrimaryKey = dcKeys;

            foreach (TargetAudience targetaudinece in dataList)
            {
                // Add new rows into the DataTable.
                dtPerson.Rows.Add(null, targetaudinece.ID, targetaudinece.Name);

            }
            // Get the DataTable from ViewState.
            DataTable dtPersons = dtPerson;

            // Convert the DataTable to DataView.
            DataView dvPerson = new DataView(dtPersons);




            // Bind the GridView control.
            gvPerson.DataSource = dvPerson;
            gvPerson.DataBind();

        }

        
        
        
        protected void BT_GetProducts(object sender, EventArgs e)
        {
            Uri servicePath = new Uri("http://localhost:50813/HttpService.svc/MyHttpGetData/10");
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage wcfResponse = client.GetAsync(servicePath).Result)
                {
                    using (HttpContent stream = wcfResponse.Content)
                    {
                        var data = stream.ReadAsStringAsync();
                        LBL_Products.Text = data.Result;

                    }
                }
            }
        }

        protected void BT_SaveTragetAudiences(object sender, EventArgs e)
        {
            Uri servicePath = new Uri(string.Format("{0}{1}{2}",
               Properties.Resources.FaceBookBaseURLService, // https://graph.facebook.com
               Properties.Resources.FaceBookAccountID, // Api Account ID
               Properties.Resources.SaveTargetAudience // Service 
               )); // Values to return

            var values = new Dictionary<string, string>
            {
               { "name", TargetAudinceName.Text },        
               {"access_token", Properties.Resources.TokenID}
            };

            if (RBT_SelectedTAType.SelectedValue == "CUSTOM")
            {
                values.Add("subtype", "CUSTOM");
            }
            else
            {
                values.Add("subtype", "LOOKALIKE");
            }

            var content = new FormUrlEncodedContent(values);


            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage wcfResponse = client.PostAsync(servicePath, content).Result)
                {
                    using (HttpContent stream = wcfResponse.Content)
                    {
                        var data = stream.ReadAsStringAsync();

                    }
                }
            }
        }
        protected void BT_GetTragetAudiences(object sender, EventArgs e)
        {
            LBL_getTargetAuidence.Text = string.Empty;
            TargetAudienceList targetAudiences;

            Uri servicePath = new Uri(string.Format("{0}{1}{2}{3}{4}",
                Properties.Resources.FaceBookBaseURLService, // https://graph.facebook.com
                Properties.Resources.FaceBookAccountID, // Api Account ID
                Properties.Resources.GetTargetAudiecne, // Service 
                Properties.Resources.TokenModifierAndID,// Token ~ Session
                "&fields=id,name")); // Values to return



            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage wcfResponse = client.GetAsync(servicePath).Result)
                {
                    using (HttpContent stream = wcfResponse.Content)
                    {
                        var data = stream.ReadAsStringAsync();
                        targetAudiences = new TargetAudienceList(data.Result);
                        initTargetAudienceData(targetAudiences);
                    }
                }
            }

        }


    }
}