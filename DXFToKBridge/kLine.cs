using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using netDxf;

namespace DXFToKBridge
{
    class kLine: kChildRuleInterface
    {
        private kLineParameters _parameters;
        private bool _forceGroup;
        private string _quantity;
        private string _designExp;
        private string _name;
        private bool _inTree;


        public object parameters {
            get
            {
                return _parameters;
            }
           }

        public string designExp
        {
            get
            {
                return _designExp;
            }
            set
            {
                _designExp = value;
            }
        }

        public string quantity { get => _quantity; set => _quantity = value; }
        public string name { get => _name; set => _name = value; }
        public bool forceGroup { get => _forceGroup; set => _forceGroup = value; }
        public bool inTree { get => _inTree; set => _inTree = value; }
        public kLine(Vector3 start, Vector3 end, String name)
        {
            _parameters = new kLineParameters(start, end);
            _name = name;
            _quantity = "1";
            _designExp = "'Line'";
            _forceGroup = true;
            _inTree = false;
        }
    }
}
