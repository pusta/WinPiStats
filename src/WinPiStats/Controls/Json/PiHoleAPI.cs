using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Windows.Data.Json;
using System.ServiceModel;


namespace WinPiStats.Controls.Json
{
    public class PiHoleAPI
    {

        private string _piholeaddress;
        private string _apiinterface = @"/admin/api.php?";
        private string querySummaryString = "summary";
        private string piholeAuthKey;
        private string piholeURL;
        private string piholeauthURL;
        private static readonly HttpClient client = new HttpClient();
        


        public PiHoleAPI(string piholeaddress, string authkey)
        {

            this._piholeaddress = piholeaddress;
            this.piholeAuthKey = authkey;
            this.piholeURL = "http://" + _piholeaddress.Trim('"') + _apiinterface;
            this.piholeauthURL = "&auth=" + authkey.Trim('"');


        }

        public string Query_Pihole_Domains()
        {

            
            
            return this.Query_Pihole_String(querySummaryString)["domains_being_blocked"].ToString().Trim('"');
            
            
        }

        public string Total_Queries_Today()
        {

            return Query_Pihole_String(querySummaryString)["dns_queries_today"].ToString().Trim('"');


        }

        public string Ads_Blocked()
        {

            return Query_Pihole_String(querySummaryString)["ads_blocked_today"].ToString().Trim('"');

        }

        public string Ads_Percent_Blocked()

        {

            return Query_Pihole_String(querySummaryString)["ads_percentage_today"].ToString().Trim('"');


        }

        public bool Is_Pihole_Enabled()
        {
            if (Query_Pihole_String(querySummaryString)["status"].ToString().Trim('"') == "enabled")
                return true;
            else
                return false;


        }

        public string topItems()
        {
            string topItemsFinal= " ";
            var topItems = Query_Pihole_Authenticated("topItems")["top_queries"].ToString().Trim('"').Trim('{').Trim('}');
            //return Query_Pihole_Authenticated("topItems")["top_queries"].ToString().Trim('"');
            var splitItmes = topItems.Split(',');

            foreach (var word in splitItmes)
            {
                topItemsFinal = topItemsFinal + Environment.NewLine + word;
            }

            return topItemsFinal;
        }

        public string Most_Recent_Blocked()
        {

            return PiHole_Query_Text("recentBlocked");



        }



        public void Pihole_Change_State(string command)
        {
            Pihole_Interact(command);
                


        }

        private bool Pihole_Interact(string command)
        {
            // HttpResponseMessage response = client.GetAsync("http://" + _piholeaddress.Trim('"') + _apiinterface + command + "&auth=" +authkey.Trim('"')).Result;
            HttpResponseMessage response = client.GetAsync(piholeURL + command + piholeauthURL).Result;
            var responseData = response.StatusCode;

            if (responseData.ToString() == "200")
                return true;
            else
                return false;
            

        }


        private JsonObject Query_Pihole_String(string querystring)
        {

            //HttpResponseMessage response = client.GetAsync("http://" + _piholeaddress.Trim('"') + _apiinterface + querystring).Result;

            HttpResponseMessage response = client.GetAsync(piholeURL + querystring).Result;


            var stringData = response.Content.ReadAsStringAsync().Result;
            

            var rootObject = JsonObject.Parse(stringData);

            return rootObject;


        }


        private JsonObject Query_Pihole_Authenticated(string querystring)
        {

            //HttpResponseMessage response = client.GetAsync("http://" + _piholeaddress.Trim('"') + _apiinterface + querystring).Result;

            HttpResponseMessage response = client.GetAsync(piholeURL + querystring + piholeauthURL).Result;


            var stringData = response.Content.ReadAsStringAsync().Result;


            var rootObject = JsonObject.Parse(stringData);

            return rootObject;


        }

        private string PiHole_Query_Text(string querystring)
        {

            HttpResponseMessage response = client.GetAsync(piholeURL + querystring + piholeauthURL).Result;
            return response.Content.ReadAsStringAsync().Result;






        }













    }
}
