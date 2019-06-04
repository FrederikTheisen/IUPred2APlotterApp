using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Linq;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;

namespace IUPred2aPlotterApp
{
    class Program
    {
        static List<Protein> Proteins = new List<Protein>();

        static void Main(string[] args)
        {
            ReadDataFile();

            //Print();

            Smooth();

            Plot();
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

                if (i > 20) break;
            }
        }

        static void Smooth()
        {
            foreach (var p in Proteins) p.Smooth();
        }
    
        static void Plot()
        {
            var model = new PlotModel { Title = "Scatte   rSeries" };
            model.Axes.Add(new CustomLinearAxis { Position = AxisPosition.Bottom, Minimum = 1, Maximum = 335, MajorStep = 50, MaximumValue = 335 } );
            model.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Minimum = 0, Maximum = 1 });


            var xaxis = new LinearAxis();
            int i = 0;

            foreach (var p in Proteins)
            {
                var series = new LineSeries { LineStyle = LineStyle.Solid, Color = OxyColor.FromArgb(5, 0, 0, 0), StrokeThickness = 5 };

                int x = 1;

                foreach (var v in p.IUPred)
                {
                    series.Points.Add(new DataPoint(x, v));
                    x++;
                }

                model.Series.Add(series);

                i++;

                if (i > 2000) break;
            }

            using (var stream = File.Create("Output.pdf"))
            {
                var pdfExporter = new PdfExporter { Width = 600, Height = 400 };
                pdfExporter.Export(model, stream);
            }
        }
    }
}
