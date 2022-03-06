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
        public Palette.Colour ReturnColor;
        public string ReturnTag;
        
        private void InitialLoad(string[] paletteLimit = null)
        {
            if (File.Exists("Assets\\ColourList.json"))
                colours = JsonConvert.DeserializeObject<List<Palette>>(File.ReadAllText("Assets\\ColourList.json"));
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
            comboBox1.SelectedIndex = comboBox1.Items.IndexOf("StandardColor_Gray1");
        }

        private void LoadCurrentColor(string incolor)
        {
            int paletteindex = colours.FindIndex(x => x.Name == incolor.Split('.')[0]);
            int colorindex = colours[paletteindex].colours.FindIndex(x => x.Name == incolor.Split('.')[1]);
            comboBox1.SelectedIndex = comboBox1.Items.IndexOf(incolor.Split('.')[0]);
            PictureBox picture = this.Controls[this.Controls.IndexOfKey($"pictureBox{colorindex + 1}")] as PictureBox;
            picture.BorderStyle = BorderStyle.Fixed3D;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Palette currentpalette = colours[colours.IndexOf(colours.First(x => x.Name == comboBox1.Text))];
            foreach (Control control in this.Controls)
            {
                if (control is PictureBox)
                {
                    PictureBox picture = control as PictureBox;
                    if (picture.BorderStyle == BorderStyle.Fixed3D)
                        picture.BorderStyle = BorderStyle.None;
                    int boxnum = int.Parse(control.Name.Replace("pictureBox", ""));
                    picture.BackColor = currentpalette.colours[boxnum - 1].ToColor();
                }  
            }
        }

        private void ColorBox_Click(object sender, EventArgs e)
        {
            Palette currentpalette = colours[colours.IndexOf(colours.First(x => x.Name == comboBox1.Text))];
            PictureBox pb = sender as PictureBox;
            int boxnum = int.Parse(pb.Name.Replace("pictureBox",""));
            ReturnColor = currentpalette.colours[boxnum - 1];
            ReturnTag = $"{currentpalette.Name}.{currentpalette.colours[boxnum - 1].Name}";
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
