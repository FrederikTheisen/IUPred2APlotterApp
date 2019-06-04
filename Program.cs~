using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Linq;

namespace IUPred2aPlotterApp
{
    class Program
    {
        static List<Protein> Proteins = new List<Protein>();

        static void Main(string[] args)
        {
            ReadDataFile();

            Print();
        }

        static void ReadDataFile()
        {
            var assembly = Assembly.GetExecutingAssembly();

            var dataFile = "IUPred2aPlotterApp.IUPredData.data.txt";

            using (Stream stream = assembly.GetManifestResourceStream(dataFile))
            using (StreamReader reader = new StreamReader(stream))
            {
                string line;

                Protein prot = new Protein();
                bool read = false;

                var iupred = new List<float>();
                var anchor = new List<float>();
                var seq = "";

                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Trim() == "" && read)
                    {
                        prot.IUPred = iupred.ToArray();
                        prot.Anchor = anchor.ToArray();
                        prot.Sequence = seq;

                        Proteins.Add(prot);

                        read = false;
                    } 
                    else if (line != "" && line[0] == '>' && !read)
                    {
                        prot = new Protein(line);

                        iupred = new List<float>();
                        anchor = new List<float>();
                        seq = "";

                        read = true;
                    }
                    else if (read && line[0] != '#')
                    {
                        var dat = line.Split("\t");

                        seq += dat[1];

                        iupred.Add(float.Parse(dat[2].Replace('.', ',')));
                        anchor.Add(float.Parse(dat[3].Replace('.', ',')));
                    }
                }
            }
        }
    
        static void Print()
        {
            int i = 0;

            foreach (var p in Proteins)
            {
                string name = p.Name;
                string dat = p.StringData().Replace(',','.');
                Console.WriteLine(name + "\t" + dat);

                i++;

                if (i > 20000) break;
            }
        }
    }
}
