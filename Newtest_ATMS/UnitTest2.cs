using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Configuration;

namespace Newtest_ATMS
{
    [TestClass]
    public class UnitTest2

    {
        string token;
        [TestMethod]
        public string GenerateToken()
        {

            try
            {
                var client = new RestClient("http://bil-s-app33-3.corpnet.liox.org/AtlasServerB/ApiInterface/CallBackTMS/6342");

                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);

                JObject obj1 = JsonConvert.DeserializeObject<JObject>(response.Content.ToString());

                token = "Bearer " + obj1["resultdata"].ToString();

                return token;
            }

            catch (Exception)
            {
                Console.WriteLine("batch is not getting created");
                return token;

            }


        }


        [TestMethod]
        public void GenerateJsonFiles()
        {

            var jsonlink = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"JsonResult\projects-list-default-response.json");
            var jsondata = File.ReadAllText(jsonlink);

            JArray jsonArray = JArray.Parse(jsondata);

            for (int i = 0; i < jsonArray.Count; i++)
            {

                jsonArray[i]["id"] = "12121334";
                jsonArray[i]["uid"] = "8zYKGCku06Ot3yEjz7C4T" + i;
                jsonArray[i]["internalId"] = jsonArray[i]["id"] + "-" + i;
                jsonArray[i]["name"] = " load test" + i + "";
                jsonArray[i]["dateCreated"] = jsonArray[i]["dateCreated"];
                jsonArray[i]["dateDue"] = jsonArray[i]["dateDue"];
            }

            var jsonwritepath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"JsonResult\");

            File.WriteAllText(jsonwritepath + "updated.json", jsonArray.ToString());

        }
        [TestMethod]
        public void GenerateJsonFiles2()
        {

            string jsonwritecontent1 = "";

            var jsonwritepath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"JsonResult\updated1.json");
            File.WriteAllText(jsonwritepath, string.Empty);

            //var value =  Convert.ToInt32( ConfigurationManager.AppSettings["finalcount"]);
           // int finalcount = 10;
            File.AppendAllText(jsonwritepath, jsonwritecontent1 + "[" + "\n");
            int finalcountvalue = 0;
            var Finalcount= ConfigurationManager.AppSettings["finalcount"];
            if(Finalcount!=null)
            {
                
                if(int.TryParse(Finalcount , out finalcountvalue))
                {
                    for (int i = 0; i <= finalcountvalue; i++)
                    {


                       
                        string random = RnadomNumberGenerator(i);
                        var jsonlink1 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"JsonResult\File2.json");
                        var jsondata = File.ReadAllText(jsonlink1);
                        JObject obj1 = JsonConvert.DeserializeObject<JObject>(jsondata);


                        obj1["id"] = obj1["id"].ToString() + i;
                        obj1["internalId"] = obj1["id"].ToString();
                        string name = obj1["name"].ToString().Replace("[Amazon Confidential] - Marketing Taglines 1", " Load mocked ATMS -") + obj1["id"] + "-" + i;
                        obj1["name"] = name.ToString();
                        obj1["uid"] = random;



                        jsonwritecontent1 = JsonConvert.SerializeObject(obj1, Formatting.Indented);


                        if (i == finalcountvalue)
                        {
                            File.AppendAllText(jsonwritepath, jsonwritecontent1);
                        }
                        else
                        {
                            File.AppendAllText(jsonwritepath, jsonwritecontent1 + "," + "\n");
                        }





                    }

                }
            }

            File.AppendAllText(jsonwritepath, jsonwritecontent1 + "]");




        }


        public string RnadomNumberGenerator(int incrementvalue)
        {
            var chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            int length = 22;
            Random random = new Random(incrementvalue);

            var result = new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
            return result;
        }

        
        public string RnadomNumberGeneratorlanguages()
        {
       
            var list = new List<string> { "cs_cz",
    "nl_nl",
    "pl_pl",
    "pt_pt",
    "tr_tr" };
            var rnd = new Random();
            Console.WriteLine(list[rnd.Next(0, list.Count)]);
            return rnd.ToString();

        }

    }
}
