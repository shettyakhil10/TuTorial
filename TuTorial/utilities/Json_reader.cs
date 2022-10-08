using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace TuTorial.utilities
{
    public class Json_reader
    {
        public Json_reader()
        {

        }
        public DataModel Extractdata()
        {
            string Myjsonstring = File.ReadAllText("utilities/testdata.json");
            DataModel dm = JsonSerializer.Deserialize<DataModel>(Myjsonstring);
            return dm;
        }

        public DataModel[] ExtractdataArray()
        {
            string Myjsonstring = File.ReadAllText("utilities/testdata.json");
            DataModel [] dm = JsonSerializer.Deserialize<DataModel[]>(Myjsonstring);
            return dm;
        }
    }

    public class DataModel
    {
        public string username { get; set; }
        public string password { get; set; }
        public string [] products { get; set; }
        public string username_wrong { get; set; }
        public string password_wrong { get; set; }
    }
}
