using System;
using System.IO;
using System.Reflection;

namespace IUPred2aPlotterApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadDataFile();
        }

        static void ReadDataFile()
        {
            var assembly = Assembly.GetExecutingAssembly();

            var dataFile = "IUPred2aPlotterApp.IUPredData.data.txt";

            using (Stream stream = assembly.GetManifestResourceStream(dataFile))
            using (StreamReader reader = new StreamReader(stream))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    string[] dat = new string[6];
                    int i = 0;

                    foreach (var d in line.Split(' '))
                    {
                        dat[i] = d.Trim();

                        i++;
                    }
                }
            }
        }
    }
}
