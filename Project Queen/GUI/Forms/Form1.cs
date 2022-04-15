using Newtonsoft.Json;
using Project_Queen.GUI.Controls;
using Project_Queen.IO.Objects;
using QueenIO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Numerics;
using System.Windows.Forms;
using UAssetAPI.PropertyTypes;
using UAssetAPI.StructTypes;

namespace Project_Queen
{
    public partial class Form1 : Form
    {
        private Control MainControl;
        public Relic relic = new Relic();
        public Form1()
        {
            InitializeComponent();
            Startup startup = new Startup();
            MainControl = startup;
            panel1.Controls.Add(MainControl);
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
            if (MainControl != null)
                MainControl.Dispose();
            MainControl = null;

            relic = Blood.Open(inpath);
            if (relic.FilePath.Contains("DT_InnerList_"))
            {
                InnerEditor innerEditor = new InnerEditor(relic);
                MainControl = innerEditor;
            }
            else if (relic.FilePath.Contains("DT_OuterMaskList_") || relic.FilePath.Contains("DT_InnerFrameList_"))
            {
                MaskEditor maskEditor = new MaskEditor(relic);
                MainControl = maskEditor;
            }
            else if (relic.FilePath.Contains("DT_HairList_"))
            {
                HairEditor hairEditor = new HairEditor(relic);
                MainControl = hairEditor;
            }
            else if (relic.FilePath.Contains("DT_AccessoryPreset"))
            {
                AccessoryEditor accessoryEditor = new AccessoryEditor(relic);
                MainControl = accessoryEditor;
            }
            else if (relic.FilePath.Contains("DT_InnerPartsVisibilityByOuter"))
            {
                InnerVisibilityEditor innerVisibilityEditor = new InnerVisibilityEditor(relic);
                MainControl = innerVisibilityEditor;
            }
            else
            {
                return;
            }

            this.Text = $"Project Queen Editor - {Path.GetFileNameWithoutExtension(inpath)}";
            SaveFile.Enabled = true;
            SaveFileAs.Enabled = true;
            MainControl.Dock = DockStyle.Fill;
            this.Size = new Size(MainControl.Width + 16, MainControl.Height + 64);
            panel1.Controls.Add(MainControl);
        }

        private void Save(string outname)
        {
            if (panel1.Controls[0].GetType() == typeof(InnerEditor))
            {
                relic.WriteDataTable(((InnerEditor)panel1.Controls[0]).InnerList.Make());
            }
            else if (panel1.Controls[0].GetType() == typeof(MaskEditor))
            {
                relic.WriteDataTable(((MaskEditor)panel1.Controls[0]).MaskListData.Make());
            }
            else if (panel1.Controls[0].GetType() == typeof(HairEditor))
            {
                relic.WriteDataTable(((HairEditor)panel1.Controls[0]).hairListData.Make());
            }
            else if (panel1.Controls[0].GetType() == typeof(AccessoryEditor))
            {
                relic.WriteDataTable(((AccessoryEditor)panel1.Controls[0]).accessoryList.Make());
            }
            else if (panel1.Controls[0].GetType() == typeof(InnerVisibilityEditor))
            {
                relic.WriteDataTable(((InnerVisibilityEditor)panel1.Controls[0]).VisibiltyList.Make());
            }
            Blood.Save(relic, outname);
        }

        private void SaveFile_Click(object sender, EventArgs e)
        {
            Save(relic.FilePath);
        }

        private void SaveFileAs_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "uasset File|*.uasset";
                saveFileDialog.FileName = Path.GetFileNameWithoutExtension(relic.FilePath);

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Save(saveFileDialog.FileName);
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

        private void PhraseSpecialColors(string inpath)
        {
            Relic relic = Blood.Open(inpath);
            var colors = relic.GetDataTable();
            SpecialColorsList specialColorsList = new SpecialColorsList();

            foreach (var palette in colors.Table.Data)
            {
                SpecialPalette Pale = new SpecialPalette() { Name = palette.Name.Value.Value };
                var colorlist = (ArrayPropertyData)palette.Value[1];
                foreach (StructPropertyData color in colorlist.Value)
                {
                    SpecialColor specialColor = new SpecialColor();
                    specialColor.Read(color);
                    Pale.Colors.Add(specialColor);
                }
                specialColorsList.SpecialPalettes.Add(Pale);
            }

            string json = JsonConvert.SerializeObject(specialColorsList, Formatting.Indented);
            File.WriteAllText("Output\\SpecialColourList.json", json);
        }

        private void makeColorsJsonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "uasset File|*.uasset";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    PhraseSpecialColors(openFileDialog.FileName);
                }
            }
        }

        private void projectQueenOnGithubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/Code-Vein-Tool-Hub/Project-Queen");
        }

        private void projectQueenWikiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/Code-Vein-Tool-Hub/Project-Queen/wiki");
        }

        private void queenIOOnGithubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/Code-Vein-Tool-Hub/QueenIO");
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
