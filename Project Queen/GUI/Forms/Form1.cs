using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;

using Project_Queen.GUI.Controls;
using Project_Queen.IO.Objects;
using QueenIO;

using UAssetAPI;
using UAssetAPI.PropertyTypes;
using UAssetAPI.StructTypes;
using Newtonsoft.Json;


namespace Project_Queen
{
    public partial class Form1 : Form
    {
        private Control MainControl;
        public Relic relic = new Relic();
        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "uasset File|*.uasset";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    OpenFile(openFileDialog.FileName);
                }
            }
        }

        private void OpenFile(string inpath)
        {
            if (panel1.Controls.Count > 0)
                panel1.Controls[0].Dispose();
            panel1.Controls.Clear();

            relic = Blood.Open(inpath);
            if (relic.FilePath.Contains("DT_InnerList_"))
            {
                SaveFile.Enabled = true;
                SaveFileAs.Enabled = true;

                InnerEditor innerEditor = new InnerEditor(relic);
                MainControl = innerEditor;
                MainControl.Dock = DockStyle.Fill;
                this.Size = new Size(MainControl.Width + 16, MainControl.Height + 64);
                panel1.Controls.Add(MainControl);
            }
        }

        private void SaveFile_Click(object sender, EventArgs e)
        {
            if (panel1.Controls[0].GetType() == typeof(InnerEditor))
            {
                relic.WriteDataTable(((InnerEditor)panel1.Controls[0]).InnerList.Make());
            }
            Blood.Save(relic, relic.FilePath);
        }

        private void SaveFileAs_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "uasset File|*.uasset";
                saveFileDialog.FileName = Path.GetFileNameWithoutExtension(relic.FilePath);

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (panel1.Controls[0].GetType() == typeof(InnerEditor))
                    {
                        relic.WriteDataTable(((InnerEditor)panel1.Controls[0]).InnerList.Make());
                    }
                    Blood.Save(relic, saveFileDialog.FileName);
                }
            }
        }

        private void PhrasePalettes(string inpath)
        {
            Relic relic = Blood.Open(inpath);
            var colors = relic.GetDataTable();
            List<PaletteList> paletteLists = new List<PaletteList>();

            foreach (var palette in colors.Table.Data)
            {
                PaletteList Pale = new PaletteList() { Name = palette.Name.Value.Value.Replace("(0)", "") };
                var colorlist = (ArrayPropertyData)palette.Value[0];
                foreach (StructPropertyData color in colorlist.Value)
                {
                    PaletteList.Palette palette1 = new PaletteList.Palette();
                    palette1.Name = ((NamePropertyData)color.Value[1]).Value.Value.Value;
                    palette1.IsSpecial = ((BoolPropertyData)color.Value[0]).Value;
                    Pale.Palettes.Add(palette1);
                }
                paletteLists.Add(Pale);
            }

            string json = JsonConvert.SerializeObject(paletteLists, Formatting.Indented);
            File.WriteAllText("Output\\ColourList.json", json);
        }

        private void PhraseColors(string inpath)
        {
            Relic relic = Blood.Open(inpath);
            var colors = relic.GetDataTable();
            List<Palette> colours = new List<Palette>();

            foreach (var palette in colors.Table.Data)
            {
                Palette Pale = new Palette() { Name = palette.Name.Value.Value.Replace("(0)", "") };
                var colorlist = (ArrayPropertyData)palette.Value[1];
                foreach (StructPropertyData color in colorlist.Value)
                {
                    Palette.Colour colour = new Palette.Colour();
                    colour.Name = ((NamePropertyData)color.Value[0]).Value.Value.Value;
                    PropertyData propertyData = ((StructPropertyData)color.Value[1]).Value[0];
                    LinearColor linearColor = ((LinearColorPropertyData)propertyData).Value;
                    colour.Color = new Vector3() { X = linearColor.R, Y = linearColor.G, Z = linearColor.B };
                    Pale.colours.Add(colour);
                }
                colours.Add(Pale);
            }

            string json = JsonConvert.SerializeObject(colours, Formatting.Indented);
            File.WriteAllText("Output\\ColourList.json", json);
        }

        private void makeColorsJsonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "uasset File|*.uasset";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    PhrasePalettes(openFileDialog.FileName);
                }
            }
        }

        
    }
}
