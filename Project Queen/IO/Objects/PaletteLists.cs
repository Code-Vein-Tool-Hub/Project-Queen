using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Queen.IO.Objects
{
    public class PaletteList
    {
        public string Name { get; set; }
        public List<Palette> Palettes { get; set; } = new List<Palette>();

        public List<string> GetNames()
        {
            List<string> names = new List<string>();
            foreach (var item in Palettes)
                names.Add(item.Name);
            return names;
        }

        public class Palette
        {
            public bool IsSpecial { get; set; } = false;
            public string Name { get; set; }
        }
    }
}
