using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBotSuitTools.Commons
{
    class LogError
    {
        public void erroLog(string file, string pregunta, Exception ex, string web)
        {
            string filePath = Path.GetFullPath("..\\..\\..\\ChatBotSuitTools\\Commons\\LogErrores\\" + file);

            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine("La pregunta correspondiente a la FAQ: " + pregunta + Environment.NewLine + "Presento las siguientes diferencias: " + 
                Environment.NewLine + "Arc: " + ex.Message + 
                Environment.NewLine + "Web: " + web + "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
            }
        }
    }
}
