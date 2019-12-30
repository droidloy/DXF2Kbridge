using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXFToKBridge
{
    class kLineParameters
    {
        public string p0;
        public string p1;

        public kLineParameters(netDxf.Vector3 start, netDxf.Vector3 end)
        {
            p0 = "p(" + start.X.ToString() + "*this.scaleFactor," + start.Y.ToString() + "*this.scaleFactor," + start.Z.ToString() + "*this.scaleFactor,R.world.transform)";
            p1 = "p(" + end.X.ToString() + "*this.scaleFactor," + end.Y.ToString() + "*this.scaleFactor," + end.Z.ToString() + "*this.scaleFactor,R.world.transform)";
        }
    }
}
