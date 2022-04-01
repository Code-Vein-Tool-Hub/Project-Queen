using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using UAssetAPI;
using UAssetAPI.PropertyTypes;
using UAssetAPI.StructTypes;

namespace Project_Queen.IO.Objects
{
    public class SpecialColorsList
    {
        public List<SpecialPalette> SpecialPalettes { get; set; } = new List<SpecialPalette>();
    }

    public class SpecialPalette
    {
        public string Name { get; set; }
        public List<SpecialColor> Colors { get; set; } = new List<SpecialColor>();
    }

    public class SpecialColor
    {
        public string ColorName { get; set; }
        public string Thumbnail { get; set; }
        public float Emmision { get; set; }
        public float Metallic { get; set; }
        public float Roughness { get; set; }
        public string Texture { get; set; }
        public Vector4 Color { get; set; } = new Vector4(1, 1, 1, 1);

        public void Read(StructPropertyData data)
        {
            ColorName = ((NamePropertyData)data.Value[0]).Value.Value.Value;
            if (((SoftObjectPropertyData)data.Value[1]).Value.Number > 0)
                Thumbnail = $"{((SoftObjectPropertyData)data.Value[1]).Value.Value.Value}_{((SoftObjectPropertyData)data.Value[1]).Value.Number - 1}";
            else
                Thumbnail = ((SoftObjectPropertyData)data.Value[1]).Value.Value.Value;
            Emmision = ((FloatPropertyData)data.Value[2]).Value;
            Metallic = ((FloatPropertyData)data.Value[3]).Value;
            Roughness = ((FloatPropertyData)data.Value[4]).Value;
            Texture = ((SoftObjectPropertyData)data.Value[5]).Value.Value.Value;
            LinearColorPropertyData linearcolor = ((LinearColorPropertyData)((StructPropertyData)data.Value[6]).Value[0]);
            Color = new Vector4(linearcolor.Value.R, linearcolor.Value.G, linearcolor.Value.B, linearcolor.Value.A);
        }
    }
}
