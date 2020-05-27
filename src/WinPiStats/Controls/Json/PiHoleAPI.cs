using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Windows.Data.Json;
using System.ServiceModel;


namespace WinPiStats
{
    public class PiHoleAPI
    {

        private string _piholeaddress;
        private string _apiinterface = @"/admin/api.php?";
        private string querySummaryString = "summary";
        private string piholeAuthKey; 
        private static readonly HttpClient client = new HttpClient();
        


        public PiHoleAPI(string piholeaddress, string authkey)
        {

            this._piholeaddress = piholeaddress;
            this.piholeAuthKey = authkey;
               
        }

        public string Query_Pihole_Domains()
        {

            
            
            return this.Query_Pihole_String(querySummaryString)["domains_being_blocked"].ToString().Trim('"');
            
            



        }

        public string Total_Queries_Today()
        {

            return Query_Pihole_String(querySummaryString)["dns_queries_today"].ToString().Trim('"');


        }

        public bool Is_Pihole_Enabled()
        {
            if (Query_Pihole_String(querySummaryString)["status"].ToString().Trim('"') == "enabled")
                return true;
            else
                return false;





        }

        public void Pihole_Change_State(string command)
        {
            Pihole_Interact(piholeAuthKey, command);
                




        }

        private bool Pihole_Interact(string authkey, string command)
        {
            HttpResponseMessage response = client.GetAsync("http://" + _piholeaddress.Trim('"') + _apiinterface + command + "&auth=" +authkey.Trim('"')).Result;
            var responseData = response.StatusCode;

            if (responseData.ToString() == "200")
                return true;
            else
                return false;


            






        }


        private JsonObject Query_Pihole_String(string querystring)
        {

            HttpResponseMessage response = client.GetAsync("http://" + _piholeaddress.Trim('"') + _apiinterface + querystring).Result;

            var stringData = response.Content.ReadAsStringAsync().Result;
            

            var rootObject = JsonObject.Parse(stringData);

            return rootObject;




        }









    }
}
