using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Newtest_ATMS
{
    class Loadjson
    {

        [TestMethod]
        public void GenerateJsonFiles2()
        {
            for (int i = 0; i > 20; i++)
            {
                var jsonlink1 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"JsonResult\File2.json");
                var jsondata = File.ReadAllText(jsonlink1);
                JObject obj1 = JsonConvert.DeserializeObject<JObject>(jsondata);
                string newvalue = obj1["id"].ToString() + i;

            }
        }
    }
}