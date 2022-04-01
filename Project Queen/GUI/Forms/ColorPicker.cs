using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Project_Queen.IO.Objects;

namespace Project_Queen.GUI.Forms
{
    public partial class ColorPicker : Form
    {
        public ColorPicker()
        {
            InitializeComponent();
            InitialLoad();
        }
        public ColorPicker(string incolor)
        {
            InitializeComponent();
            InitialLoad();
            LoadCurrentColor(incolor);
        }
        public ColorPicker(string[] paletteLimit)
        {
            InitializeComponent();
            InitialLoad(paletteLimit);
        }
        public ColorPicker(string incolor, string[] paletteLimit)
        {
            InitializeComponent();
            InitialLoad(paletteLimit);
            LoadCurrentColor(incolor);
        }

        List<Palette> colours = new List<Palette>();
        SpecialColorsList specialColors = new SpecialColorsList();
        public Palette.Colour ReturnColor;
        public SpecialColor ReturnSpecial;
        public string ReturnTag;
        
        private void InitialLoad(string[] paletteLimit = null)
        {
            if (File.Exists("Assets\\ColourList.json"))
                colours = JsonConvert.DeserializeObject<List<Palette>>(File.ReadAllText("Assets\\ColourList.json"));
            if (File.Exists("Assets\\SpecialColourList.json"))
                specialColors = JsonConvert.DeserializeObject<SpecialColorsList>(File.ReadAllText("Assets\\SpecialColourList.json"));

            foreach (Palette palette in colours)
            {
                if (paletteLimit != null)
                {
                    if (paletteLimit.Contains(palette.Name))
                        comboBox1.Items.Add(palette.Name);
                    else
                        continue;
                }
                else
                    comboBox1.Items.Add(palette.Name);
            }

            foreach (SpecialPalette specialPalette in specialColors.SpecialPalettes)
            {
                if (paletteLimit != null)
                {
                    if (paletteLimit.Contains(specialPalette.Name))
                        comboBox1.Items.Add(specialPalette.Name);
                    else
                        continue;
                }
                else
                    comboBox1.Items.Add(specialPalette.Name);
            }

            comboBox1.SelectedIndex = comboBox1.Items.IndexOf("StandardColor_Gray1");
        }

        private void LoadCurrentColor(string incolor)
        {
            int paletteindex;
            int colorindex;
            bool IsSpecial = false;
            try
            {
                paletteindex = colours.FindIndex(x => x.Name == incolor.Split('.')[0]);
                colorindex = colours[paletteindex].colours.FindIndex(x => x.Name == incolor.Split('.')[1]);
            }
            catch
            {
                paletteindex = specialColors.SpecialPalettes.FindIndex(x => x.Name == incolor.Split('.')[0]);
                colorindex = specialColors.SpecialPalettes[paletteindex].Colors.FindIndex(x => x.ColorName == incolor.Split('.')[1]);
                IsSpecial = true;
            }

            comboBox1.SelectedIndex = comboBox1.Items.IndexOf(incolor.Split('.')[0]);

            if (IsSpecial)
            {
                PictureBox picture = this.Controls[this.Controls.IndexOfKey($"SpecialBox{colorindex + 1}")] as PictureBox;
                picture.BorderStyle = BorderStyle.Fixed3D;
            }
            else
            {
                PictureBox picture = this.Controls[this.Controls.IndexOfKey($"pictureBox{colorindex + 1}")] as PictureBox;
                picture.BorderStyle = BorderStyle.Fixed3D;
            }
            
        }

        private void Reset()
        {
            foreach (Control control in this.Controls)
            {
                if (control is PictureBox)
                {
                    PictureBox picture = control as PictureBox;
                    if (picture.BorderStyle == BorderStyle.Fixed3D)
                        picture.BorderStyle = BorderStyle.None;
                    if (picture.Image != null)
                    {
                        picture.Image.Dispose();
                        picture.Image = null;
                    }
                    if (picture.Name.Contains("SpecialBox"))
                    {
                        picture.Visible = false;
                    }
                    picture.BackColor = SystemColors.Control;
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Palette currentpalette = null;
            SpecialPalette currentSpecial = null;
            Reset();

            try
            {
                currentpalette = colours[colours.IndexOf(colours.First(x => x.Name == comboBox1.Text))];
            }
            catch
            {
                currentSpecial = specialColors.SpecialPalettes[specialColors.SpecialPalettes.IndexOf(specialColors.SpecialPalettes.First(x => x.Name == comboBox1.Text))];
            }
            
            if (currentpalette != null)
            {
                foreach (Control control in this.Controls)
                {
                    if (control is PictureBox)
                    {
                        PictureBox picture = control as PictureBox;
                        if (picture.Name.Contains("SpecialBox"))
                            continue;
                        int boxnum = int.Parse(control.Name.Replace("pictureBox", ""));
                        picture.BackColor = currentpalette.colours[boxnum - 1].ToColor();
                    }
                }
            }
            else if (currentSpecial != null)
            {
                for (int i = 0; i < 4; i++)
                {
                    string thumbnail = Path.GetExtension(currentSpecial.Colors[i].Thumbnail).Substring(1);
                    PictureBox picture = this.Controls.Find($"SpecialBox{i+1}", true).First() as PictureBox;

                    picture.Visible = true;
                    picture.Image = new Bitmap($"Assets\\SpecialPalette\\{thumbnail}.png");
                }
            }
            
        }

        private void ColorBox_Click(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            if (pb.BackColor == SystemColors.Control)
                return;

            Palette currentpalette = colours[colours.IndexOf(colours.First(x => x.Name == comboBox1.Text))];
            int boxnum = int.Parse(pb.Name.Replace("pictureBox",""));
            ReturnColor = currentpalette.colours[boxnum - 1];
            ReturnTag = $"{currentpalette.Name}.{currentpalette.colours[boxnum - 1].Name}.false";
            DialogResult = DialogResult.OK;
            Close();
        }

        private void SpecialBox_Click(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            //if (pb.BackColor == SystemColors.Control)
            //    return;

            SpecialPalette currentSpecial = specialColors.SpecialPalettes[specialColors.SpecialPalettes.IndexOf(specialColors.SpecialPalettes.First(x => x.Name == comboBox1.Text))];
            int boxnum = int.Parse(pb.Name.Replace("SpecialBox", ""));
            ReturnSpecial = currentSpecial.Colors[boxnum - 1];
            ReturnTag = $"{currentSpecial.Name}.{currentSpecial.Colors[boxnum - 1].ColorName}.true";
            DialogResult = DialogResult.Yes;
            Close();
        }
    }
}
