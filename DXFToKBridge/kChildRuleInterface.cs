using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXFToKBridge
{
    interface kChildRuleInterface
    {
        object parameters
        {
            get;
        }

        string designExp
        {
            get;
            set;
        }

        string quantity
        {
            get;
            set;
        }

        string name
        {
            get;
            set;
        }

        Boolean forceGroup
        {
            get;
            set;
        }

        Boolean inTree
        {
            get;
            set;
        }

    }


}
