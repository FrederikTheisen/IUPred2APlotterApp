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



        public void Smooth(float window = 5f)
        {
            int start = (int)((window - 1) / 2);

            var tmp = new float[IUPred.Length];

            for (int i = 0; i <= IUPred.Length - 1; i++)
            {
                float sum = 0;
                int weigth = 0;

                for (int l = -start; l <= start; l++)
                {
                    if (i + l >= 0 && i + l <= IUPred.Length - 1)
                    {
                        sum += IUPred[i + l];
                        weigth++;
                    }
                }

                tmp[i] = sum / weigth;
            }

            IUPred = tmp;
        }
    }
}
