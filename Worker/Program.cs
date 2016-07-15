using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using HtmlAgilityPack;
using System.Threading;
using System.IO;
using Newtonsoft.Json;

namespace Worker
{
    class Program
    {
        public const string OutElemFiles = "elemento.json";
        public const string URLFormat = "http://www.chemicalelements.com/elements/{0}.html";

        static void Main(string[] args)
        {
            Console.WriteLine("Getting elements...");
            Elemento[] elementos = getAllElements();
            Console.WriteLine("Parsing to JSON...");
            string json = JsonConvert.SerializeObject(elementos);
            Console.WriteLine("Writing to file {0}", OutElemFiles);
            File.WriteAllText(OutElemFiles, json);
            Console.WriteLine("Done!");
        }

        static Elemento[] getAllElements()
        {
            List<Elemento> l = new List<Elemento>();
            for(int i = 0; i < 119; ++i)
            {
                try
                {
                    l.Add(AgilityParser.Parse(getHtml(AgilityParser.GetElement(i + 1))));
                    Console.WriteLine("Just parsed {0}", i);
                } catch
                {
                    Console.WriteLine("Could not parse {0}", i);
                }
            }

            Console.WriteLine("Found {0} elements", l.Count);
            return l.ToArray();
        } 

        static string getHtml(string s)
        {
            WebClient w = new WebClient();
            string SourceCode = w.DownloadString(string.Format(URLFormat, s));
            return SourceCode;
        }
    }

    public static class AgilityParser
    {
        public static Elemento Parse(string HTML)
        {
            string[] HTMLArray = HTML.Split(new char[] { '\n' });
            Elemento elemento = new Elemento();

            Logger.LogData("HTML Scrapping Started");

            foreach (string line in HTMLArray)
            {
                if (line.Contains("Name:"))
                {
                    elemento.Name = ReplaceAll(line);
                }

                if (line.Contains("Symbol:"))
                {
                    elemento.Symbol = ReplaceAll(line);
                }

                if (line.Contains("Atomic Number:"))
                {
                    elemento.ANumber = ReplaceAll(line);
                }

                if (line.Contains("Atomic Mass:"))
                {
                    elemento.AMass = ReplaceAll(line);
                }

                if (line.Contains("Melting Point:"))
                {
                    elemento.MP = ReplaceAll(line).Replace("deg;", "º");
                }

                if (line.Contains("Boiling Point:"))
                {
                    elemento.BP = ReplaceAll(line).Replace("deg;", "º");
                }

                if (line.Contains("Number of Protons/Electrons:"))
                {
                    elemento.NoPE = ReplaceAll(line);
                }

                if (line.Contains("Number of Neutrons:"))
                {
                    elemento.NoN = ReplaceAll(line);
                }

                if (line.Contains("Crystal Structure:"))
                {
                    elemento.CrystalGeo = ReplaceAll(line);
                }

                if (line.Contains("Density @"))
                {
                    elemento.Density = ReplaceAll(line);
                }

                if (line.Contains("Color:"))
                {
                    elemento.Color = ReplaceAll(line);
                }

                if (line.Contains("Classification:"))
                {
                    if (line.Contains("Non-metal"))
                    {
                        elemento.Classification = "Non-Metal";
                    }
                    else
                    {
                        elemento.Classification = "Metal";
                    }
                }

                if (line.Contains("Number of Energy Levels:"))
                {
                    Int32.TryParse(line.Replace("<br><strong>Number of Energy Levels:</strong> ", ""), out elemento.EnergyLVLNumber);
                    //MessageBox.Show(elemento.EnergyLVLNumber.ToString());
                }

                try
                {
                    if (line.Contains("First Energy Level:"))
                    {
                        elemento.EnergyLevels[0] = line.Replace("<br><strong>First Energy Level:</strong> ", "");
                    }

                    if (line.Contains("Second Energy Level:"))
                    {
                        elemento.EnergyLevels[1] = line.Replace("<br><strong>Second Energy Level:</strong> ", "");
                    }

                    if (line.Contains("Third Energy Level:"))
                    {
                        elemento.EnergyLevels[2] = line.Replace("<br><strong>Third Energy Level:</strong> ", "");
                    }

                    if (line.Contains("Fourth Energy Level:"))
                    {
                        elemento.EnergyLevels[3] = line.Replace("<br><strong>Fourth Energy Level:</strong> ", "");
                    }

                    if (line.Contains("Fifth Energy Level:"))
                    {
                        elemento.EnergyLevels[4] = line.Replace("<br><strong>Fifth Energy Level:</strong> ", "");
                    }

                    if (line.Contains("Sixth Energy Level:"))
                    {
                        elemento.EnergyLevels[5] = line.Replace("<br><strong>Sixth Energy Level:</strong> ", "");
                    }

                    if (line.Contains("Seventh Energy Level:"))
                    {
                        elemento.EnergyLevels[6] = line.Replace("<br><strong>Seventh Energy Level:</strong> ", "");
                    }
                }
                catch (Exception x)
                {
                    Logger.LogData("Trivial ERROR: " + x.Message);
                    //MessageBox.Show("An Error Ocurred :[\n\n\n\nDetails: " + x.Message, "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }

            // ler html
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(HTML);

            List<string> tempList = new List<string>();

            foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//font"))
            {
                if (node.InnerText != "Isotope" && node.InnerText != "Half Life" && node.InnerText.Length < 15)
                {
                    tempList.Add(node.InnerText);
                }
            }

            foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//img"))
            {
                if (node.GetAttributeValue("ALT", "error").Contains("[Bohr Model of"))
                {
                    elemento.AtomicStructureImage = "http://www.chemicalelements.com/" + node.GetAttributeValue("SRC", "error").Replace("..", "");
                }
            }

            for (int i = 0; i < tempList.Count / 2; ++i)
            {
                if (i % 2 == 0)
                {
                    elemento.Isotopes[tempList[i]] = tempList[i + 1];
                }
                else
                {
                    elemento.Isotopes[tempList[i + 1]] = tempList[i];
                }
            }

            // MessageBox.Show(elemento.GetBasicElemString());
            // MessageBox.Show(elemento.GetIsotopes());


            Logger.LogData(elemento.GetBasicElemString());
            Logger.LogData("END OF PROCESSING", true);

            return elemento;
        }

        private static string ReplaceAll(string str)
        {
            return str.Replace("<br><strong>Name:</strong>", "").Replace("<br><strong>Symbol:</strong>", "").Replace("<br><strong>Atomic Number:</strong>", "").
                Replace("<br><strong>Atomic Mass:</strong>", "").Replace("<br><strong>Melting Point:</strong>", "").Replace("<br><strong>Boiling Point:</strong>", "").
                Replace("<br><strong>Number of Protons/Electrons:</strong>", "").Replace("<br><strong>Number of Neutrons:</strong>", "").Replace("<br><strong>Crystal Structure:</strong>", "").
                Replace("<br><strong>Density @ 293 K:</strong>", "").Replace("<sup>3</sup>", "").Replace("<br><strong>Color:</strong>", "");
        }

        public static string GetElement(object arg)
        {
            string[] Elements = "h,he,li,be,b,c,n,o,f,ne,na,mg,al,si,p,s,cl,ar,k,ca,sc,ti,v,cr,mn,fe,co,ni,cu,zn,ga,ge,as,se,br,kr,rb,sr,y,zr,nb,mo,tc,ru,rh,pd,ag,cd,in,sn,sb,te,i,xe,cs,ba,la,ce,pr,nd,pm,sm,eu,gd,tb,dy,ho,er,tm,yb,lu,hf,ta,w,re,os,ir,pt,au,hg,ti,pb,bi,po,at,rn,fr,ra,ac,th,pa,u,np,pu,am,cm,bk,cf,es,fm,md,no,lr,rf,db,sg,bh,mt,ds,rg".Split(new char[] { ',' });
            try
            {
                if (arg is string)
                {
                    string elemName = (string)arg;
                    return elemName[0].ToString();
                }
                else
                {
                    return Elements[(int)arg];
                }
            }
            catch
            {
                return "h";
            }
        }

        public static bool CheckInternetConnection()
        {
            try
            {
                using (WebClient w = new WebClient())
                {
                    using (var stream = w.OpenRead("http://www.google.com"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }

        }
    }

    public class Elemento
    {
        // basico
        public string Name, Symbol, ANumber, AMass, MP, BP, NoPE, NoN, Classification, Density, Color, CrystalGeo;

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

    public static class Logger
    {
        private static string logString = null;

        public static string GetLogData()
        {
            return logString;
        }

        public static void LogData(string log, bool separator = false)
        {
            if (string.IsNullOrEmpty(logString))
                logString = "";

            if (!separator)
                logString += log + "\n";
            else
                logString += ("####### " + log + " #######" + "\n").PadRight(20);
        }

        public static void ClearLog()
        {
            logString = null;
        }
    }
}
