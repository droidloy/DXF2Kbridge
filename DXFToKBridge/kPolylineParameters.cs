using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using netDxf.Entities;

namespace DXFToKBridge
{
    class kPolylineParameters
    {
        public string vertices;

        public kPolylineParameters(netDxf.Entities.LwPolyline lwpoly)
        {
            vertices = "[";

            //int i = 0;

            //foreach (LwPolylineVertex vert in lwpoly.Vertexes)
            //{
                
            //    vertices += "p(" + vert.Position.X.ToString() + "*this.scaleFactor," + vert.Position.Y.ToString() + "*this.scaleFactor," + vert.Position.Z.ToString() + "*this.scaleFactor,R.world.transform)";

            //    if (i < (poly.Vertexes.Count - 1))
            //    {
            //        vertices += "," + System.Environment.NewLine;
            //    }
            //    i++;
            //}
            vertices += "]";
        }

        public kPolylineParameters(netDxf.Entities.Polyline poly)
        {
            vertices = "[";

            int i = 0;
            
            foreach (PolylineVertex vert in poly.Vertexes)
            {
                vertices += "p(" + vert.Position.X.ToString() + "*this.scaleFactor," + vert.Position.Y.ToString() + "*this.scaleFactor," + vert.Position.Z.ToString() + "*this.scaleFactor)";

                if (i < (poly.Vertexes.Count - 1))
                {
                    vertices += "," + System.Environment.NewLine;
                }
                i++;
            }
            vertices += "]";
        }
    }
}
