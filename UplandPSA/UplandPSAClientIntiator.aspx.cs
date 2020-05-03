using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tenrox.Server.Framework.Core;
using Tenrox.Shared.Utilities;
using Tenrox.Web.Asp.Core.Common;

namespace Tenrox.Web.Asp.Entry.Common
{
    public partial class UplandPSAClientIntiator : TenroxBasePage

    {
        protected void Page_Init(object sender, EventArgs e)
        {
            lastVisitedPage = "Entity/Common/UplandPSAClientIntiator.aspx";
            LicenseCode = ((int)LicenseModules.LOGIN).ToString();
            SecurityCode = "Can_log_into_the_system";

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //UserToken userToken = new UserToken()
            //{
            //    AuthenticatedGuid = Session["authGuid"].ToString()
            //    , ForceTenrox = true
            //    , IPAddress = string.Empty
            //    , Password = string.Empty
            //    , UserName = CoreServices.LoginName
            //    , OrgName = CoreServices.OrganizationName
            //    , UniqueId = CoreServices.UserUniqueId
            //};
            if(Session["APIPassword"] != null)
            {
                string password = Session["APIPassword"].ToString();
                string username = CoreServices.LoginName;
                string strApiUrl = $"{Request.Url.Scheme}://{Request.Url.Authority}/tenterprise/api/token";
                HttpClient httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Add("OrgName", CoreServices.OrganizationName);
                StringContent stringContent = new StringContent($"grant_type=password&username={CoreServices.LoginName}&password={password}");
                var response = httpClient.PostAsync(strApiUrl, stringContent);
                response.Wait();
                var jsonResult = response.Result.Content.ReadAsStringAsync();
                jsonResult.Wait();
                var jsonObject = JsonConvert.DeserializeObject<dynamic>(jsonResult.Result);
                token.Value = jsonObject["access_token"].ToString();
                orgname.Value = CoreServices.OrganizationName;
            }
        }
    }
}