using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsApp1
{
    public class Elemento
    {
        // basico
        public string Name { get; set; }
        public string Symbol { get; set; }
        public string AMass { get; set; }
        public string MP { get; set; }
        public string BP { get; set; }
        public string NoN { get; set; }
        public string NoPE { get; set; }
        public string Classification { get; set; }
        public string Density { get; set; }
        public string ANumber { get; set; }
        public string Color { get; set; }
        public string CrystalGeo { get; set; }
        public string ImagePath
        {
            get
            {
                return Classification == "Metal" ? @"/Assets/horse-128.png" : @"/Assets/water-128.png";
            }
        }

        // avancado
        public Dictionary<string, string> Isotopes = new Dictionary<string, string>();
        public string AtomicStructureImage;

        public int EnergyLVLNumber;
        public string[] EnergyLevels = new string[6];

        public string GetBasicElemString()
        {
            return string.Format("Name: {0}\nSymbol: {1}\nAtomic Number: {2}\nAtomic Mass: {3}\nMelting Point: {4}\nBoiling Point: {5}\nNoPE: {6}\nNoN: {7}\nClassification: {8}\nDensity: {9}\nColor: {10}\nCrystal S.: {11}", new object[] { Name, Symbol, ANumber, AMass, MP, BP, NoPE, NoN, Classification, Density, Color, CrystalGeo });
        }

        public string GetIsotopes()
        {
            string text = "";

            foreach (KeyValuePair<string, string> pair in this.Isotopes)
            {
                text += string.Format("{0} : {1}\n", pair.Key, pair.Value);
            }

            return text;
        }
    }

    public class ElementProperty
    {
        public string PName { get; set; }
        public string PValue { get; set; }

        public ElementProperty(string name, string value) { PName = name; PValue = value; }
    }
}
