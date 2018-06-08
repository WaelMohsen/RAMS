using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Xml;
using System.Xml.Serialization;

namespace OpenIdTester
{
    public partial class TesterForm : System.Web.UI.Page
    {
        #region"Private Members"

        private const string STROPENIDRESPONSE = "STR_OPEN_ID_RESPONSE";

        private const string RESPONSESTRING = "RESPONSESTRING";

        private const string OPENIDMODE = "check_authentication";

        private const string OPENIDRESOURCEMODE = "id_res";

        /// <summary>
        /// Gets or sets the open identifier end point URL.
        /// </summary>
        /// <value>The open identifier end point URL.</value>
        private string OpenIdEndPointUrl { get; set; }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                txt_Results.Text = string.Empty;
                lbl_UserName.Text = "---";

                if (!IsPostBack)
                    if (string.IsNullOrWhiteSpace(Session[STROPENIDRESPONSE]?.ToString()))
                        FillFromOpenId();
                    else
                        SetValueFromSession();

            }
            catch (Exception ex)
            {
                lbl_UserName.Text = "---";
                txt_Results.Text = ex.Message + "\n---\n" + ex.StackTrace;
            }
        }

        protected void btn_Login_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Session[STROPENIDRESPONSE]?.ToString()))
                {
                    if (Request.QueryString["openid.mode"] == OPENIDRESOURCEMODE)
                    {
                        FillFromOpenId();
                    }
                    else
                    {
                        string AbsoluteURL = Request.Url.AbsoluteUri.IndexOf("?") > 0 ? Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.IndexOf("?")) : Request.Url.AbsoluteUri;

                        var url = new StringBuilder();
                        url.Append(WebConfigurationManager.AppSettings["OpenIdEndPointUrl"])
                            .Append("?openid.return_to=")
                            //.Append(AbsoluteURL)
                            .Append(Server.UrlEncode(Request.Url.AbsoluteUri))
                            //.Append((string.IsNullOrWhiteSpace(Request.Url.Query) ? "?" : "&"))
                            .Append("&")
                            .Append(Server.UrlEncode("dnoa.userSuppliedIdentifier=individual"))
                            .Append("&openid.mode=checkid_setup&openid.claimed_id=")
                            .Append(Server.UrlEncode("http://specs.openid.net/auth/2.0/identifier_select"))
                            .Append("&openid.identity=")
                            .Append(Server.UrlEncode("http://specs.openid.net/auth/2.0/identifier_select"));

                        Response.Redirect(url.ToString(), false);
                    }
                }
                else
                {
                    SetValueFromSession();
                }
            }
            catch (Exception ex)
            {
                lbl_UserName.Text = "---";
                txt_Results.Text = ex.Message + "\n---\n" + ex.StackTrace;
            }
        }

        /// <summary>
        /// Fill values from open Id Data
        /// </summary>
        private void FillFromOpenId()
        {
            if (Request.QueryString["openid.mode"] != OPENIDRESOURCEMODE)
                return;

            var openIdMode = Request.QueryString["openid.mode"];

            var requestQueryString = Request.QueryString.ToString();
            requestQueryString = requestQueryString.Replace(openIdMode, OPENIDMODE);

            if (WebConfigurationManager.AppSettings["OpenIdEndPointUrl"] != null)
            {
                OpenIdEndPointUrl = WebConfigurationManager.AppSettings["OpenIdEndPointUrl"];
            }

            var responseQueryString = OpenIdEndPointUrl + "?" + requestQueryString;
            //var request = WebRequest.Create(responseQueryString);
            var request = (HttpWebRequest)HttpWebRequest.Create(responseQueryString);
            request.Method = "GET";


            using (WebResponse response = request.GetResponse())
            {
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream);
                    var responseString = reader.ReadToEnd();


                    if (!string.IsNullOrWhiteSpace(responseString))
                    {
                        var result = ObjectToXml(responseString, typeof(User)) as User;

                        if (result != null)
                        {
                            Session[STROPENIDRESPONSE] = result;
                            Session[RESPONSESTRING] = responseString;
                            SetValueFromSession();
                        }
                        reader.Close();
                        reader.Dispose();
                    }

                }
            }
        }

        /// <summary>
        /// Sets the value from session.
        /// </summary>
        private void SetValueFromSession()
        {
            try
            {
                txt_Results.Text = string.Empty;
                lbl_UserName.Text = "---";
                txt_Results.Text = Session[RESPONSESTRING].ToString();
                var result = Session[STROPENIDRESPONSE] as User;

                if (result == null)
                    return;

                if (result.FirstName != null)
                {
                    lbl_UserName.Text =
                        (result.FirstName ?? "") + @" " +
                        (result.SecondName ?? "");

                    txt_Results.Text = Session[RESPONSESTRING].ToString();
                }
            }
            catch (Exception ex)
            {
                lbl_UserName.Text = "---";
                txt_Results.Text = ex.Message + "\n---\n" + ex.StackTrace;
            }
        }

        /// <summary>
        /// Objects to XML.
        /// </summary>
        /// <param name="xml">The XML.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>Object.</returns>
        private object ObjectToXml(string xml, System.Type objectType)
        {
            StringReader strReader = null;
            XmlTextReader xmlReader = null;
            object obj = null;

            try
            {
                strReader = new StringReader(xml);

                if (objectType == null)
                    return null;

                var serializer = new XmlSerializer(objectType);
                xmlReader = new XmlTextReader(strReader);
                obj = serializer.Deserialize(xmlReader);
            }
            catch (Exception ex)
            {
                lbl_UserName.Text = "---";
                txt_Results.Text = ex.Message + "\n---\n" + ex.StackTrace;
            }
            finally
            {
                xmlReader?.Close();
                strReader?.Close();
            }
            return obj;
        }

        protected void btn_Logout_Click(object sender, EventArgs e)
        {
            try
            {
                txt_Results.Text = string.Empty;
                lbl_UserName.Text = "---";
            }
            catch (Exception ex)
            {
                lbl_UserName.Text = "---";
                txt_Results.Text = ex.Message + "\n---\n" + ex.StackTrace;
            }
        }

    }
}