using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Project_Queen.IO.Objects
{
    public class Palette
    {
        public string Name { get; set; }
        public List<Colour> colours { get; set; } = new List<Colour>();

        public class Colour
        {
            public string Name { get; set; }
            public Vector3 Color { get; set; }

            public Color ToColor()
            {
                Color c = System.Drawing.Color.FromArgb(Convert.ToInt32(Color.X * 255), Convert.ToInt32(Color.Y * 255), Convert.ToInt32(Color.Z * 255));
                return c;
            }
        }
    }
}
