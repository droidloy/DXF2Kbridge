using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using netDxf;
using netDxf.Entities;

namespace DXFToKBridge
{ 
    class kTextParameters
    {
        public string text;
        public string position;
        public string height;

        public kTextParameters(string text, Vector3 position, double Height, TextAlignment alignment )
        {
            this.text = text;
            if (alignment == TextAlignment.TopCenter)
            {

                this.position = "{origin: p(" + position.X.ToString() + "*this.scaleFactor - (child.width/2.0)," + position.Y.ToString() + "*this.scaleFactor  + (child.height/2.0)," + position.Z.ToString() + "*this.scaleFactor)}";

            }
            else if ((alignment == TextAlignment.MiddleLeft)||(alignment == TextAlignment.BaselineLeft))
            {
                this.position = "{origin: p(" + position.X.ToString() + "*this.scaleFactor," + position.Y.ToString() + "*this.scaleFactor," + position.Z.ToString() + "*this.scaleFactor)}";
            }
            else
            {
                this.position = "{origin: p(" + position.X.ToString() + "*this.scaleFactor," + position.Y.ToString() + "*this.scaleFactor," + position.Z.ToString() + "*this.scaleFactor)}";
            }
            this.height = Height.ToString() + "*this.scaleFactor";
        }

        public kTextParameters(string text, Vector3 position, double Height)
        {
            this.text = text;
            this.position = "{origin: p(" + position.X.ToString() + "*this.scaleFactor," + position.Y.ToString() + "*this.scaleFactor," + position.Z.ToString() + "*this.scaleFactor)}";
            this.height = Height.ToString() + "*this.scaleFactor";
        }

        //{
        //        "text": "this.textAttr",
        //        "position": "{origin: p(-child.width/2.0,-child.height/2.0,0,R.world.transform)}"
        //    },
    }
}
