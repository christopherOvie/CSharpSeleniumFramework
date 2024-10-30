using Newtonsoft.Json.Linq;
using System;
//using System.Collections.Generic;
using System.IO;
/*using System.Linq;
using System.Text;
using System.Threading.Tasks;*/

namespace CSharpSeleniumFramework.utilities
{
    public class jsonreader
    {

        public jsonreader()
        {
           
        }

        public string extractData(String tokenName)
        {
         var myJsonString =  File.ReadAllText("utilities.testData.json");
         var jsonObject =   JToken.Parse(myJsonString);
           return jsonObject.SelectToken(tokenName).Value<String>();
        }
    }
}
