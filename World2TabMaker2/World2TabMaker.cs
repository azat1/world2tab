using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Media.Imaging;

namespace World2TabMaker
{
    class World2TabConverter
    {
        internal static async void Convert(string file)
        {
            Stream s = new FileStream(file,FileMode.Open);
            StreamReader reader = new StreamReader(s, Encoding.ASCII);
            string sa1 = reader.ReadLine();
            string sb1 = reader.ReadLine();
            string sa2 = reader.ReadLine();
            string sb2 = reader.ReadLine();
            string sc1 = reader.ReadLine();
            string sc2 = reader.ReadLine();
            if (sa1==null || sb1 == null || sa2 == null || sb2 == null || sc1 == null || sc2 == null)
            {
                
                MessageBox.Show("Error!");
            }
            s.Dispose();
            double a1 = double.Parse(sa1,CultureInfo.InvariantCulture);
            double a2 = double.Parse(sa2, CultureInfo.InvariantCulture);
            double b1 = double.Parse(sb1, CultureInfo.InvariantCulture);
            double b2 = double.Parse(sb2, CultureInfo.InvariantCulture);
            double c1 = double.Parse(sc1, CultureInfo.InvariantCulture);
            double c2 = double.Parse(sc2, CultureInfo.InvariantCulture);
            string rastername = Path.ChangeExtension(file,null);
            switch (Path.GetExtension( file))
            {
                case ".jgw":
                    {
                        rastername = rastername+".jpg";
                    }
                    break;
                case ".bpw":
                    {
                        rastername = rastername + ".bmp";

                    }
                    break;
                case ".tfw":
                    {
                        rastername = rastername + ".tif";

                    }
                    break;
                case ".gfw":
                    {
                        rastername = rastername + ".gif";

                    }
                    break;
            }
            string shortname = Path.GetFileName(rastername);
            BitmapImage image = new BitmapImage(new Uri(rastername));
            int w = image.PixelWidth;
            int h = image.PixelHeight;
            string tabname = Path.ChangeExtension(file, ".tab");
            s = new FileStream(tabname, FileMode.Create);
            StreamWriter sw = new StreamWriter(s, Encoding.GetEncoding(1251));
            double wx1 = a1 * (w - 1) + b1 * 0 + c1;
            double wy1 = a2 * (w - 1) + b2 * 0 + c2;
            double wx2 = a1 * (w - 1) + b1 * (h-1) + c1;
            double wy2 = a2 * (w - 1) + b2 * (h - 1) + c2;

            sw.WriteLine("!table");
            sw.WriteLine("!version 300");
            sw.WriteLine("!charset WindowsCyrillic");
            sw.WriteLine("");
            sw.WriteLine("Definition table");
            sw.WriteLine("File \"" + shortname + "\"");
            sw.WriteLine("Type \"RASTER\"");
            sw.WriteLine($"({c1.ToString("F10",CultureInfo.InvariantCulture)}, {c2.ToString("F10", CultureInfo.InvariantCulture)})(0, 0) Label \"Point 1\"");
            sw.WriteLine($"({wx1.ToString("F10", CultureInfo.InvariantCulture)}, {wy1.ToString("F10", CultureInfo.InvariantCulture)})({w-1}, 0) Label \"Point 2\"");
            sw.WriteLine($"({wx2.ToString("F10", CultureInfo.InvariantCulture)}, {wy2.ToString("F10", CultureInfo.InvariantCulture)})({w-1}, {h-1}) Label \"Point 3\"");
            sw.WriteLine("CoordSys NonEarth Units \"m\"");
            sw.WriteLine("Units \"m\"");
            sw.Dispose();

        }
    }
}
