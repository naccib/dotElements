using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Windows.UI.Popups;

namespace WindowsApp1
{
    static class Parser
    {
        public static string JSONFilePath = @"elemento.json";
        private static bool Initialized = false;
        public static Elemento[] Elementos;

        public static void Initialize()
        {
            if (Initialized)
                return;

            try
            {
                string JSONString = File.ReadAllText(JSONFilePath);
                Elementos = Newtonsoft.Json.JsonConvert.DeserializeObject<Elemento[]>(JSONString);

                Initialized = true;
            }
            catch
            {

            }
        }
    }
}
