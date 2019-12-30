using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using netDxf;

namespace DXFToKBridge
{
    class kPolyline : kChildRuleInterface
    {

        private kPolylineParameters _parameters;
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
        public kPolyline(netDxf.Entities.Polyline poly, String name)
        {
            _parameters = new kPolylineParameters(poly);
            _name = name;
            _quantity = "1";
            _designExp = "'Polyline'";
            _forceGroup = true;
            _inTree = false;
        }

        public kPolyline(netDxf.Entities.LwPolyline lwpoly, String name)
        {
            _parameters = new kPolylineParameters(lwpoly);
            _name = name;
            _quantity = "1";
            _designExp = "'Polyline'";
            _forceGroup = true;
        }
    }
}
