using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Reflection;
using System.Collections.Generic;

namespace Newtest_ATMS

{
     
         
    [TestClass]
    public class UnitTest1
    {

        int count = 5;
        UnitTest2 obj1 = new UnitTest2();
        string Realtoken = "";
        public UnitTest1()
        {
            Realtoken = obj1.GenerateToken();
            
        }
        string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"FilesFolder\New_MXliff.mxliff");

        string path2 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"FilesFolder\second_new.mxliff");



        string path3 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"FilesFolder\third_new.mxliff");
        string path4 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"FilesFolder\Fourth_new.mxliff");
        string path5 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"FilesFolder\Fifth_new.mxliff");
        string path6 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"FilesFolder\sixth_new.mxliff");
        string path7 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"FilesFolder\Response.txt");








        
        string name = "QA-Load -API -" + DateTime.Now + " Project No-";
        [TestMethod]
        public void OneprojectMultiplejobs()
        {

            string sourcelanguage = "nl-NL";
            string targetlanguage1 = "fr-FR";

            string targetlanguage2 = "de-DE";
            string targetlanguage3 = "zh-CN";


            var client1 = new RestClient("https://staging.atms.a2z.com/web/api/v4/project/create?sourceLang=" + sourcelanguage + "&targetLang=" + targetlanguage1 + "&targetLang=" + targetlanguage2 + "&targetLang=" + targetlanguage3 + "&dateDue=2022-11-28T06:55:05.810Z&name=QA_Project-Fri, 28 Oct 2022 06:55:05 GMT&machineTranslateSettings=141&client=4&businessUnit=15&domain&subDomain&note&workflowStep=34");

            var request1 = new RestRequest(Method.POST);
            request1.AddHeader("Authorization", Realtoken);
            IRestResponse responselang = client1.Execute(request1);
            Console.WriteLine(responselang.Content);











            //string projectname = "QA_Project-Fri";
            //DateTime dateDue = Convert.ToDateTime("2022-11-28T06:55:05.810Z");



            //var client = new RestClient("https://staging.atms.a2z.com/web/api/v4/project/create?sourceLang=" + sourcelanguage + "&targetLang=" + targetlanguage1 + "&dateDue=2022-11-28T06:55:05.810Z&name=QA_Project-Fri, 28 Oct 2022 06:55:05 GMT&machineTranslateSettings=141&client=4&businessUnit=15&domain&subDomain&note&workflowStep=34");

            //var request = new RestRequest(Method.POST);
            //request.AddHeader("Authorization", Realtoken);
            //IRestResponse response = client.Execute(request);
            //Console.WriteLine(response.Content);
            if (responselang.Content != null && responselang.Content != "")
            {

                for (int i = 0; i < count; i++)
                {
                    JObject obj = JsonConvert.DeserializeObject<JObject>(responselang.Content.ToString());
                    string projectID = obj["id"].ToString();

                    var jobclient = new RestClient("https://staging.atms.a2z.com/web/api/v9/job/create?project=" + projectID + "&targetLang=" + targetlanguage1 + "&targetLang=" + targetlanguage2 + "&targetLang=" + targetlanguage3 + "");

                    request1 = new RestRequest(Method.POST);
                    request1.AddHeader("Authorization", Realtoken);
                    request1.AddFile("file", path);
                    IRestResponse response1 = jobclient.Execute(request1);
                    Console.WriteLine(response1.Content);


                }
            }





        }

        [TestMethod]
        public void OneprojectOnejob()
        {




            string sourcelanguage = "nl-NL";
            string targetlanguage = "fr-FR";
            //string projectname = "QA_Project-Fri";
            string dateDue = DateTime.UtcNow.AddHours(3).ToString("s") + "Z";
            //string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"FilesFolder\New_MXliff.mxliff");


            for (int i = 1; i < count; i++)
            {

                var client = new RestClient("https://staging.atms.a2z.com/web/api/v4/project/create?sourceLang=" + sourcelanguage + "&targetLang=" + targetlanguage + "&dateDue=2022-11-28T06:55:05.810Z&name=" + name +  i + "&machineTranslateSettings=141&client=4&businessUnit=15&domain&subDomain&note&workflowStep=34");

                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", Realtoken);
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);
                if (response.Content != null && response.Content != "")
                {


                    JObject obj = JsonConvert.DeserializeObject<JObject>(response.Content.ToString());
                    string projectID = obj["id"].ToString();

                    var jobclient = new RestClient("https://staging.atms.a2z.com/web/api/v9/job/create?project=" + projectID + "&targetLang=" + targetlanguage + "");

                    request = new RestRequest(Method.POST);
                    request.AddHeader("Authorization", Realtoken);


                    request.AddFile("file", path);

                    IRestResponse response1 = jobclient.Execute(request);
                    Console.WriteLine(response1.Content);



                }
            }

        }

        [TestMethod]
        public void OneprojectOneUpdatedjob()
        {




            string sourcelanguage = "nl-NL";
            string targetlanguage1 = "fr-FR";

            string targetlanguage2 = "de-DE";
            string targetlanguage3 = "zh-CN";
            string targetlanguage4 = "it-IT";
            string targetlanguage5 = "ja-JP";
            string targetlanguage6 = "pl-PL";


            //string projectname = "QA_Project-Fri";
            // string dateDue = DateTime.UtcNow.AddHours(3).ToString("s") + "Z";
            //string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"FilesFolder\New_MXliff.mxliff");
            File.WriteAllText(path7, string.Empty);

            for (int i = 1; i < count; i++)
            {

                var client1 = new RestClient("https://staging.atms.a2z.com/web/api/v4/project/create?sourceLang=" + sourcelanguage + "&targetLang=" + targetlanguage1 + "&targetLang=" + targetlanguage2 + "&targetLang=" + targetlanguage3 + "&targetLang=" + targetlanguage4 + "&targetLang=" + targetlanguage5 + "&targetLang=" + targetlanguage6 +"&dateDue=2022-11-28T06:55:05.810Z&name="+ name + i +"&machineTranslateSettings=141&client=4&businessUnit=15&domain&subDomain&note&workflowStep=34");

                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", Realtoken);
                IRestResponse response = client1.Execute(request);
                Console.WriteLine(response.Content);
                string ResponseCode = (response.Content);
               

                File.AppendAllText(path7, ResponseCode +Environment.NewLine);
                
                if (response.Content != null && response.Content != "")
                {


                    JObject obj = JsonConvert.DeserializeObject<JObject>(response.Content.ToString());
                    string projectID = obj["id"].ToString();

                    var jobclient = new RestClient("https://staging.atms.a2z.com/web/api/v9/job/create?project=" + projectID + "&targetLang=" + targetlanguage1 + "&targetLang=" + targetlanguage2 + "&targetLang=" + targetlanguage3 + "&targetLang=" + targetlanguage4 + "&targetLang=" + targetlanguage5 + "&targetLang=" + targetlanguage6 +"");

                    request = new RestRequest(Method.POST);
                    request.AddHeader("Authorization", Realtoken);


                    request.AddFile("file", path);
                    //request.AddFile("file", path2);


                    IRestResponse response1 = jobclient.Execute(request);
                    //IRestResponse response2 = jobclient.Execute(request);

                    //part2

                    jobclient = new RestClient("https://staging.atms.a2z.com/web/api/v9/job/create?project=" + projectID + "&targetLang=" + targetlanguage1 + "&targetLang=" + targetlanguage2 + "");

                    request = new RestRequest(Method.POST);
                    request.AddHeader("Authorization", Realtoken);


                    //request.AddFile("file", path);
                    request.AddFile("file", path2);


                    response1 = jobclient.Execute(request);


                    //part3
                    jobclient = new RestClient("https://staging.atms.a2z.com/web/api/v9/job/create?project=" + projectID + "&targetLang=" + targetlanguage3 + "&targetLang=" + targetlanguage4 + "&targetLang=" + targetlanguage5 + "&targetLang=" + targetlanguage6 + "&targetLang=" + targetlanguage2 + "");

                    request = new RestRequest(Method.POST);
                    request.AddHeader("Authorization", Realtoken);


                    //request.AddFile("file", path);
                    request.AddFile("file", path4);


                    response1 = jobclient.Execute(request);
                    //part4

                    jobclient = new RestClient("https://staging.atms.a2z.com/web/api/v9/job/create?project=" + projectID + "&targetLang=" + targetlanguage3 + "&targetLang=" + targetlanguage4 + "&targetLang=" + targetlanguage5 + "&targetLang=" + targetlanguage6 + "&targetLang=" + targetlanguage2 + "");

                    request = new RestRequest(Method.POST);
                    request.AddHeader("Authorization", Realtoken);


                    //request.AddFile("file", path);
                    request.AddFile("file", path4);


                    response1 = jobclient.Execute(request);

                    //part5
                    jobclient = new RestClient("https://staging.atms.a2z.com/web/api/v9/job/create?project=" + projectID + "&targetLang=" + targetlanguage3 + "&targetLang=" + targetlanguage4 + "&targetLang=" + targetlanguage5 + "&targetLang=" + targetlanguage6 + "&targetLang=" + targetlanguage2 + "");

                    request = new RestRequest(Method.POST);
                    request.AddHeader("Authorization", Realtoken);


                    //request.AddFile("file", path);
                    request.AddFile("file", path5);


                    response1 = jobclient.Execute(request);

                    //part6
                    jobclient = new RestClient("https://staging.atms.a2z.com/web/api/v9/job/create?project=" + projectID + "&targetLang=" + targetlanguage3 + "&targetLang=" + targetlanguage4 + "&targetLang=" + targetlanguage5 + "&targetLang=" + targetlanguage6 + "");

                    request = new RestRequest(Method.POST);
                    request.AddHeader("Authorization", Realtoken);


                    //request.AddFile("file", path);
                    request.AddFile("file", path6);


                    response1 = jobclient.Execute(request);
                    Console.WriteLine(response1.Content);

                   
                    
                       




                }
            }

        }




    }
}
