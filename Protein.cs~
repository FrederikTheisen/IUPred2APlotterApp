using System;
namespace IUPred2aPlotterApp
{
    public class Protein
    {
        public string Name { get; set; }
        public string Sequence { get; set; }
        public float[] IUPred { get; set; }
        public float[] Anchor { get; set; }

        public Protein(string seq, float[] iupred, float[] anchor)
        {

        }

        public Protein() { }

        public Protein(string line)
        {
            Name = line.Substring(1);
        }

        public void Read()
        {

        }

        public string StringData()
        {
            string dat = "";

            foreach (var v in IUPred)
            {
                dat += "\t" + v.ToString();
            }

            dat.Trim();

            return dat;
        }
    }
}
