using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXFToKBridge
{
    class kRule
    {
        public kEmptyParameters parameters = new kEmptyParameters();
        public string body = "1.0";
        public List<string> flags = new List<string>();
        public string dataType = "number";
        public string Category = "geometry";
        public string name = "";

        public kRule(string name, string Category, string body, string dataType, bool isParameter)
        {
            this.name = name;
            this.Category = Category;
            this.body = body;
            this.dataType = dataType;
            this.flags = new List<string>();
            if (isParameter)
            {
                flags.Add("parameter");
                flags.Add("cached");
            }
            else
            {
                flags.Add("cached");
            }
        }
    }
}
