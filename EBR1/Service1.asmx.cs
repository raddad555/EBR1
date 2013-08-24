using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Net.Mail;

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

        public class IdnMailInfo
        {
            public string emailad
            {
                get
                {
                    return emailad;
                }
                set
                {

                    if (emailad == "warren@blackwelltechnologies")
                    {
                        emailad = "warren@blackwelltechnologies";
                    }
                    else
                        throw new ArgumentOutOfRangeException();
                }

            }

        }
            public int RowId { get; set; }
            public string MailAttach { get; set; }

            public MailAddress Mailadd = new MailAddress("warren@blackwelltechnologies");



            [WebMethod]
            public string getFormFields(int formfieldid)
            {

                SqlConnection sqlconn = new SqlConnection("server=warreneb-vaio\\sqlexpress;uid=dub;pwd=raddad;database=ebr");
                SqlCommand sqlcomm = new SqlCommand("Select * from FormFields where rowid = " + formfieldid, sqlconn);
                SqlDataAdapter da = new SqlDataAdapter(sqlcomm);

                
                DataTable dt = new DataTable();
                
                DataSet ds = new DataSet();

                ds.DataSetName = "myDataSetName";

                da.Fill(ds, "FormData");


                                //Object myadd = dt.Rows[1][2];
               

               Object md = ds.Tables[0].Rows[0][2];
            string myemail =  md.ToString();
                da.Dispose();

                sqlconn.Close();



                //o.ItemArray.ElementAt(2).ToString();


                string json = JsonConvert.SerializeObject(ds);

                

               string[] minfo = json.Split(':');
                

                try
                {

                    
                    
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("smtp.comcast.net");
                    mail.From = new MailAddress("wblackwell555@comcast.net");
                    mail.To.Add("wblackwell@maxrecall.com");
                    mail.To.Add("wblackwell555@comcast.net");
                    mail.To.Add("dudouble@gmail.com");
                    mail.Subject = "VirgaSoftware Demo";
                    mail.Body = "EBR has a home for you";
                    System.Net.Mail.Attachment attachment;
                    attachment = new System.Net.Mail.Attachment("c:\\temp\\eula1025.txt");
                    mail.Attachments.Add(attachment);

                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("wblackwell555@comcast.net", "raddad555");
                    //SmtpServer.EnableSsl = true;

                    SmtpServer.Send(mail);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

                return json;
                //{"FormData":[{"rowId":2,"fieldName":"Warren","description":"wblackwell@maxrecall.com"}]}
               
            }
        }
    }


