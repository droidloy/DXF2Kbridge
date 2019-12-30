using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXFToKBridge
{
    class kDesign
    {
        public List<string> mixins = new List<string>();
        public List<object> rules = new List<object>();
        public string visibility = "public";
        public string name;

        public kDesign(string name)
        {

            mixins = new List<string>();
            rules = new List<object>();
            mixins.Add("BaseAssembly");
            visibility = "public";
            this.name = name;
        }
    }
}
