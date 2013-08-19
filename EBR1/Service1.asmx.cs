using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.Runtime.Serialization;


namespace EBR1
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://www.vigrasoft.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {

  
        int formfiledid;
        
        
        [WebMethod]
        public string getFormFields(int formfieldid)
        {

            SqlConnection sqlconn = new SqlConnection("server=warreneb-vaio\\sqlexpress;uid=dub;pwd=raddad;database=ebr");
            SqlCommand sqlcomm = new SqlCommand("Select * from FormFields where rowid = " + formfieldid,sqlconn );
            SqlDataAdapter da = new SqlDataAdapter(sqlcomm);

            DataTable dt = new DataTable();

            DataSet ds = new DataSet();

            ds.DataSetName = "myDataSetName";

            da.Fill(ds, "FormData");

            da.Dispose();

            sqlconn.Close();


            string json = JsonConvert.SerializeObject(ds);

            return json; 
            
            
              
            
            
            
            
            
            
            
            
            
       
        }
    }
}