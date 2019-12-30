using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using netDxf;
using netDxf.Entities;
using Newtonsoft.Json;
using System.IO;

namespace DXFToKBridge
{
    class Program
    {
        static void Main(string[] args)
        {

            string strPath = args[0];

            string designName = args[1];

            if (!File.Exists(strPath))
            {
                Environment.Exit(-1);
            }

            string dxfFile = strPath;

            string outputFileName = Path.GetDirectoryName(strPath) + "\\" + designName + ".design.json";

            kDesign outputDesign = new kDesign(designName);

            DxfDocument dxf = DxfDocument.Load(dxfFile);

            kRule scaleFactor = new kRule("scaleFactor", "Input", "1.0", "number", true);

            outputDesign.rules.Add(scaleFactor);


            //Line objects
            int lineCount = dxf.Lines.Count();

            Console.WriteLine("Number of line objects found: {0:D}",lineCount);

            string lineNameStart = "line_";
            int index = 0;
            foreach (Line line in dxf.Lines)
            {
                kLine ln = new kLine(line.StartPoint, line.EndPoint, lineNameStart + index.ToString());
                outputDesign.rules.Add(ln);
                index++;
            }


            //Polyline objects
            int polyCount = dxf.Polylines.Count();

            Console.WriteLine("Number of polyline objects found: {0:D}", polyCount);

            string polyNameStart = "poly_";
            index = 0;
            foreach (Polyline poly in dxf.Polylines)
            {
                kPolyline polyChild = new kPolyline(poly, polyNameStart + index.ToString());
                outputDesign.rules.Add(polyChild);
                index++;
            }


            //LW Polyline objects
            int lwpolyCount = dxf.LwPolylines.Count();

            Console.WriteLine("Number of lwpolyline objects found: {0:D}", lwpolyCount);

            string lwpolyNameStart = "lwpoly_";
            index = 0;
            foreach (LwPolyline lwpoly in dxf.LwPolylines)
            {
                kPolyline polyChild = new kPolyline(lwpoly, lwpolyNameStart + index.ToString());
                outputDesign.rules.Add(polyChild);
                index++;
            }


            //MText Objects
            int mTextCount = dxf.MTexts.Count();

            Console.WriteLine("Number of mtext objects found: {0:D}", mTextCount);

            string mTextStart = "mtext_";
            string mTextParameterStart = "mtext_param_";
            index = 0;
            foreach(MText mtext in dxf.MTexts.Take(20))
            {
                
                string txtParameterName = mTextParameterStart + index.ToString();
                string txtParameterRule = "this." + txtParameterName + "";
             
                kRule txtParameter = new kRule(mTextParameterStart + index.ToString(), "Input", "\"" + mtext.Value + "\"", "string", true);
                outputDesign.rules.Add(txtParameter);
                kText mtxtChild = new kText(txtParameterRule,mtext.Position,mtext.Height);
                mtxtChild.name = mTextStart + index.ToString();
                outputDesign.rules.Add(mtxtChild);

                index++;
            }


            //Text Objects
            int textCount = dxf.Texts.Count();

            Console.WriteLine("Number of text objects found: {0:D}", textCount);

            string textStart = "text_";
            string textParameterStart = "text_param_";
            index = 0;
            foreach (Text text in dxf.Texts)
            {

                string txtParameterName = textParameterStart + index.ToString();
                string txtParameterRule = "this." + txtParameterName;
                string kbridgeText = AddEscapeCharacters(text.Value);

                kRule txtParameter = new kRule(textParameterStart + index.ToString(), "Input", "\"" + kbridgeText + "\"", "string", true);
                outputDesign.rules.Add(txtParameter);
                kText txtChild = new kText(txtParameterRule, text.Position, text.Height, text.Alignment);
                txtChild.name = textStart + index.ToString();
                outputDesign.rules.Add(txtChild);

                index++;
            }

            File.WriteAllText(outputFileName, JsonConvert.SerializeObject(outputDesign, Formatting.Indented));

            Console.WriteLine("Design document written to: " + outputFileName);

        }

        /// <summary>
        /// This adds escape characters for kbridge to an input string.
        /// Rewrite this using regex or something to make it more efficient.
        /// </summary>
        /// <param name="inString"></param>
        /// <returns></returns>
        static string AddEscapeCharacters(string inString)
        {
            return inString.Replace("\"", @"\\\""");
        }
    }
}
