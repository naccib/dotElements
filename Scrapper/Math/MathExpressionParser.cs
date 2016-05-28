using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scrapper;
using ZedGraph;
using info.lundin.math;
using System.Globalization;

namespace Scrapper.Math
{
    static class MathExpressionParser
    {
        public static double Parse(string expr, ListBox l)
        {
            ExpressionParser parser = new ExpressionParser();
            parser.Values.Add("pi", System.Math.PI);
            parser.Values.Add("e", System.Math.E);

            if(l.Items.Count > 0)
            {
                foreach(string item in l.Items)
                {
                    if(!parser.Values.ContainsKey(GetRVar(item).Name))
                    {
                        parser.Values.Add(GetRVar(item).Name, GetRVar(item).Value);
                    }
                }
            }
        
            return parser.Parse(expr);
        }

        private static ResultVar GetRVar(string str)
        {
            string[] arr = str.Replace(" ", "").Split(new char[] { '=' });
            try
            {
                return new ResultVar(arr[0], Convert.ToDouble(arr[1]));
            }
            catch
            {
                MessageBox.Show("Could not get RVAR");
                return null;
            }
        }
    }

    public class ChemistryExpressionParser
    {
        private Dictionary<string, double> MolarMap = new Dictionary<string, double>();

        public ChemistryExpressionParser()
        {
            string[] raw = System.IO.File.ReadAllLines("molarmap.map");
            foreach(string line in raw)
            {
                string[] data = line.Replace(" ", "").Replace("amu", "").Split(new char[] { ':' });
                if (!string.IsNullOrWhiteSpace(data[1])) {

                    int intLspacePos = line.IndexOf(" ") + 1;
                    int intRspacePos = line.LastIndexOf(" ");

                    string strNumber = line.Substring(intLspacePos, intRspacePos - intLspacePos);
                    double dblNumber = Convert.ToDouble(strNumber, CultureInfo.InvariantCulture);
                }
                else {
                    MessageBox.Show("ERRR");
                }
            }
        }

        public double MolarMass(string expr)
        {
            MessageBox.Show(MolarMap["He"].ToString());
            return 0;
        }
    }
}
