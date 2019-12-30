using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using netDxf.Entities;


namespace DXFToKBridge
{
    class kText: kChildRuleInterface
    {

        private kTextParameters _parameters;
        private bool _forceGroup;
        private bool _inTree;
        private string _quantity;
        private string _designExp;
        private string _name;


        public object parameters
        {
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
        public kText(string text, netDxf.Vector3 position, double height)
        {
            _parameters = new kTextParameters(text, position, height);
            _quantity = "1";
            _name = name;
            _designExp = "'Text'";
            _forceGroup = true;
            _inTree = true;
        }
        public kText(string text, netDxf.Vector3 position, double height, TextAlignment alignment) 
        {
            _parameters = new kTextParameters(text, position, height, alignment);
            _quantity = "1";
            _name = name;
            _designExp = "'Text'";
            _forceGroup = true;
            _inTree = true;
        }


    }
}
