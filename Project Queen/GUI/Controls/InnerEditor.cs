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
using Project_Queen.GUI.Forms;
using Project_Queen.IO;
using Project_Queen.IO.Objects;
using QueenIO;
using QueenIO.Tables;
using Newtonsoft.Json;

namespace Project_Queen.GUI.Controls
{
    public partial class InnerEditor : UserControl
    {
        public InnerList InnerList = new InnerList();
        List<Palette> colourTable = new List<Palette>();
        SpecialColorsList specialColorsTable = new SpecialColorsList();
        PaletteList InnerPalettes = new PaletteList();
        InnerData innerData;
        string[] HidePartsNames = new string[] { "HidePartsA", "HidePartsB", "HidePartsC", "HidePartsD", "HidePartsE", "HidePartsF", "HidePartsG", "HidePartsH" };
        public InnerEditor(Relic infile)
        {
            InitializeComponent();
            InnerList.Read(infile.GetDataTable());
            InitialLoad();
        }
        bool Loading = false;

        #region Main Functions
        private void InitialLoad()
        {
            foreach (var item in InnerList.Inners)
            {
                treeView1.Nodes.Add(item.Name);
            }
            if (File.Exists("Assets\\ColourList.json"))
                colourTable = JsonConvert.DeserializeObject<List<Palette>>(File.ReadAllText("Assets\\ColourList.json"));
            if (File.Exists("Assets\\PaletteList.json"))
            {
                List<PaletteList> palettes = JsonConvert.DeserializeObject<List<PaletteList>>(File.ReadAllText("Assets\\PaletteList.json"));
                InnerPalettes = palettes.FirstOrDefault(x => x.Name == "InnerColor");
            }
            if (File.Exists("Assets\\SpecialColourList.json"))
                specialColorsTable = JsonConvert.DeserializeObject<SpecialColorsList>(File.ReadAllText("Assets\\SpecialColourList.json"));
            Thumbnail_Path.Text = string.Empty;
            Mesh_Path.Text = string.Empty;
            treeView1.Focus();
            treeView1.SelectedNode = treeView1.Nodes[0];
            innerData = InnerList.Inners[treeView1.SelectedNode.Index];
        }

        private void Add_Click(object sender, EventArgs e)
        {
            using (TextInput textInput = new TextInput("Enter Name for new Inner entry"))
            {
                textInput.StartPosition = FormStartPosition.CenterParent;
                if (textInput.ShowDialog() == DialogResult.OK)
                {
                    InnerList.Inners.Add(new InnerData() 
                    { 
                        Name = textInput.ReturnText, 
                        Thumbnail = $"/Game/BasicAssets/Textures/T_Black.T_Black",
                        Mesh = $"/Game/BasicAssets/Meshes/SK_Null.SK_Null"
                    });
                    treeView1.Nodes.Add(textInput.ReturnText);
                }
            }
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null || treeView1.SelectedNode.Index <= 7)
                return;

            InnerList.Inners.RemoveAt(treeView1.SelectedNode.Index);
            treeView1.SelectedNode.Remove();
        }

        private void Reset()
        {
            //This makes sure all data from preview entry is removed so there's no bleed over data.
            TB_EntryName.Clear();
            TB_Thumbnail.Clear();
            Thumbnail_Path.Text= string.Empty;
            TB_Mesh.Clear();
            Mesh_Path.Text = string.Empty;
            EnableColour1.Checked = false;
            EnableColour2.Checked = false;
            EnableColour3.Checked = false;
            EnableColour4.Checked = false;
            EnableColour5.Checked = false;
            EnableColour6.Checked = false;
            EnableColour7.Checked = false;

            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
            }
            if (pictureBox2.Image != null)
            {
                pictureBox2.Image.Dispose();
                pictureBox2.Image = null;
            }
            if (pictureBox3.Image != null)
            {
                pictureBox3.Image.Dispose();
                pictureBox3.Image = null;
            }
            if (pictureBox4.Image != null)
            {
                pictureBox4.Image.Dispose();
                pictureBox4.Image = null;
            }
            if (pictureBox5.Image != null)
            {
                pictureBox5.Image.Dispose();
                pictureBox5.Image = null;
            }
            if (pictureBox6.Image != null)
            {
                pictureBox6.Image.Dispose();
                pictureBox6.Image = null;
            }
            if (pictureBox7.Image != null)
            {
                pictureBox7.Image.Dispose();
                pictureBox7.Image = null;
            }

            pictureBox1.BackColor = DefaultBackColor;
            pictureBox2.BackColor = DefaultBackColor;
            pictureBox3.BackColor = DefaultBackColor;
            pictureBox4.BackColor = DefaultBackColor;
            pictureBox5.BackColor = DefaultBackColor;
            pictureBox6.BackColor = DefaultBackColor;
            pictureBox7.BackColor = DefaultBackColor;
            treeView2.Nodes.Clear();
            ResetHide();
        }

        private void ResetHide()
        {
            comboBox1.Text = string.Empty;
            TB_HideThumbnail.Clear();
            //comboBox1.Items.Clear();
            HideThumbnail_Path.Text = string.Empty;
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            CheckBox checkBox = this.Controls.Find($"EnableColour{pictureBox.Name.Replace("pictureBox", "")}", true).FirstOrDefault() as CheckBox;
            if (!checkBox.Checked)
                return;
            if (pictureBox.Image != null)
            {
                pictureBox.Image.Dispose();
                pictureBox.Image = null;
            }

            using (ColorPicker colorPicker = new ColorPicker(pictureBox.Tag as string, InnerPalettes.GetNames().ToArray()))
            {
                colorPicker.StartPosition = FormStartPosition.CenterParent;
                var result = colorPicker.ShowDialog();
                if (result == DialogResult.OK)
                {
                    pictureBox.BackColor = colorPicker.ReturnColor.ToColor();
                    pictureBox.Tag = colorPicker.ReturnTag;
                    SetInnerColor(int.Parse(pictureBox.Name.Replace("pictureBox", "")) - 1, colorPicker.ReturnTag);
                }
                else if (result == DialogResult.Yes)
                {
                    string thumbnail = Path.GetExtension(colorPicker.ReturnSpecial.Thumbnail).Substring(1);
                    pictureBox.Image = new Bitmap($"Assets\\SpecialPalette\\{thumbnail}.png");
                    pictureBox.Tag = colorPicker.ReturnTag;
                    SetInnerColor(int.Parse(pictureBox.Name.Replace("pictureBox", "")) - 1, colorPicker.ReturnTag);
                }
            }
        }

        private Palette.Colour GetColor(string Tag)
        {
            string palette = Tag.Split('.')[0];
            string color = Tag.Split('.')[1];
            bool IsSpecial = bool.Parse(Tag.Split('.')[2]);
            if (!IsSpecial)
            {
                return colourTable[colourTable.FindIndex(x => x.Name == palette)]
                    .colours.First(x => x.Name == color);
            }
            return null;
        }

        private SpecialColor GetSpecialColor(string Tag)
        {
            string palette = Tag.Split('.')[0];
            string color = Tag.Split('.')[1];
            bool IsSpecial = bool.Parse(Tag.Split('.')[2]);
            if (IsSpecial)
            {
                return specialColorsTable.SpecialPalettes[specialColorsTable.SpecialPalettes.FindIndex(x => x.Name == palette)]
                    .Colors.First(x => x.ColorName == color);
            }
            return null;
        }

        private void SetInnerColor(int index, string Tag)
        {
            string palette = Tag.Split('.')[0];
            string color = Tag.Split('.')[1];
            bool IsSpecial = bool.Parse(Tag.Split('.')[2]);
            switch (index)
            {
                case 0:
                    innerData.Color_0 = new ColorData(palette, color, IsSpecial);
                    break;
                case 1:
                    innerData.Color_1 = new ColorData(palette, color, IsSpecial);
                    break;
                case 2:
                    innerData.Color_2 = new ColorData(palette, color, IsSpecial);
                    break;
                case 3:
                    innerData.Color_3 = new ColorData(palette, color, IsSpecial);
                    break;
                case 4:
                    innerData.Color_4 = new ColorData(palette, color, IsSpecial);
                    break;
                case 5:
                    innerData.Color_5 = new ColorData(palette, color, IsSpecial);
                    break;
                case 6:
                    innerData.Color_6 = new ColorData(palette, color, IsSpecial);
                    break;
            }
        }

        #endregion

        #region UI Interacts
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Loading = true;
            Reset();
            innerData = InnerList.Inners[treeView1.SelectedNode.Index];
            TB_EntryName.Text = innerData.Name;
            TB_Thumbnail.Text = innerData.Thumbnail.Split('.').Last();
            Thumbnail_Path.Text = Path.GetDirectoryName(innerData.Thumbnail.Replace("/","\\"));
            TB_Mesh.Text = innerData.Mesh.Split('.').Last();
            Mesh_Path.Text = Path.GetDirectoryName(innerData.Mesh.Replace("/", "\\"));

            foreach (var hideoption in innerData.HidePartsInfoDetails.HideParts)
            {
                treeView2.Nodes.Add(hideoption.HidePartsName);
            }
            pictureBox1.Tag = $"{innerData.Color_0.ColorPaletteRowName}.{innerData.Color_0.ColorName}.{innerData.Color_0.IsSpecialColor.ToString().ToLower()}";
            pictureBox2.Tag = $"{innerData.Color_1.ColorPaletteRowName}.{innerData.Color_1.ColorName}.{innerData.Color_1.IsSpecialColor.ToString().ToLower()}";
            pictureBox3.Tag = $"{innerData.Color_2.ColorPaletteRowName}.{innerData.Color_2.ColorName}.{innerData.Color_2.IsSpecialColor.ToString().ToLower()}";
            pictureBox4.Tag = $"{innerData.Color_3.ColorPaletteRowName}.{innerData.Color_3.ColorName}.{innerData.Color_3.IsSpecialColor.ToString().ToLower()}";
            pictureBox5.Tag = $"{innerData.Color_4.ColorPaletteRowName}.{innerData.Color_4.ColorName}.{innerData.Color_4.IsSpecialColor.ToString().ToLower()}";
            pictureBox6.Tag = $"{innerData.Color_5.ColorPaletteRowName}.{innerData.Color_5.ColorName}.{innerData.Color_5.IsSpecialColor.ToString().ToLower()}";
            pictureBox7.Tag = $"{innerData.Color_6.ColorPaletteRowName}.{innerData.Color_6.ColorName}.{innerData.Color_6.IsSpecialColor.ToString().ToLower()}";

            if (innerData.Color_0.ColorPaletteRowName != "None")
            {
                if (((string)pictureBox1.Tag).Contains(".true"))
                {
                    string thumbnail = Path.GetExtension(GetSpecialColor((string)pictureBox1.Tag).Thumbnail).Substring(1);
                    pictureBox1.Image = new Bitmap($"Assets\\SpecialPalette\\{thumbnail}.png");
                }
                else
                {
                    pictureBox1.BackColor = GetColor((string)pictureBox1.Tag).ToColor();
                }
                EnableColour1.Checked = true;
            }
            if (innerData.Color_1.ColorPaletteRowName != "None")
            {
                if (((string)pictureBox2.Tag).Contains(".true"))
                {
                    string thumbnail = Path.GetExtension(GetSpecialColor((string)pictureBox2.Tag).Thumbnail).Substring(1);
                    pictureBox2.Image = new Bitmap($"Assets\\SpecialPalette\\{thumbnail}.png");
                }
                else
                {
                    pictureBox2.BackColor = GetColor((string)pictureBox2.Tag).ToColor();
                }
                EnableColour2.Checked = true;
            }
            if (innerData.Color_2.ColorPaletteRowName != "None")
            {
                if (((string)pictureBox3.Tag).Contains(".true"))
                {
                    string thumbnail = Path.GetExtension(GetSpecialColor((string)pictureBox3.Tag).Thumbnail).Substring(3);
                    pictureBox3.Image = new Bitmap($"Assets\\SpecialPalette\\{thumbnail}.png");
                }
                else
                {
                    pictureBox3.BackColor = GetColor((string)pictureBox3.Tag).ToColor();
                }
                EnableColour3.Checked = true;
            }
            if (innerData.Color_3.ColorPaletteRowName != "None")
            {
                if (((string)pictureBox4.Tag).Contains(".true"))
                {
                    string thumbnail = Path.GetExtension(GetSpecialColor((string)pictureBox4.Tag).Thumbnail).Substring(4);
                    pictureBox4.Image = new Bitmap($"Assets\\SpecialPalette\\{thumbnail}.png");
                }
                else
                {
                    pictureBox4.BackColor = GetColor((string)pictureBox4.Tag).ToColor();
                }
                EnableColour4.Checked = true;
            }
            if (innerData.Color_4.ColorPaletteRowName != "None")
            {
                if (((string)pictureBox5.Tag).Contains(".true"))
                {
                    string thumbnail = Path.GetExtension(GetSpecialColor((string)pictureBox5.Tag).Thumbnail).Substring(5);
                    pictureBox5.Image = new Bitmap($"Assets\\SpecialPalette\\{thumbnail}.png");
                }
                else
                {
                    pictureBox5.BackColor = GetColor((string)pictureBox5.Tag).ToColor();
                }
                EnableColour5.Checked = true;
            }
            if (innerData.Color_5.ColorPaletteRowName != "None")
            {
                if (((string)pictureBox6.Tag).Contains(".true"))
                {
                    string thumbnail = Path.GetExtension(GetSpecialColor((string)pictureBox6.Tag).Thumbnail).Substring(6);
                    pictureBox6.Image = new Bitmap($"Assets\\SpecialPalette\\{thumbnail}.png");
                }
                else
                {
                    pictureBox6.BackColor = GetColor((string)pictureBox6.Tag).ToColor();
                }
                EnableColour6.Checked = true;
            }
            if (innerData.Color_6.ColorPaletteRowName != "None")
            {
                if (((string)pictureBox7.Tag).Contains(".true"))
                {
                    string thumbnail = Path.GetExtension(GetSpecialColor((string)pictureBox7.Tag).Thumbnail).Substring(7);
                    pictureBox7.Image = new Bitmap($"Assets\\SpecialPalette\\{thumbnail}.png");
                }
                else
                {
                    pictureBox7.BackColor = GetColor((string)pictureBox7.Tag).ToColor();
                }
                EnableColour7.Checked = true;
            }
            Loading = false;
        }

        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Loading = true;
            ResetHide();
            HidePartsData hidePartsData = innerData.HidePartsInfoDetails.HideParts[treeView2.SelectedNode.Index];
            comboBox1.Text = hidePartsData.HidePartsName;
            TB_HideThumbnail.Text = hidePartsData.Thumbnail.Split('.').Last();
            HideThumbnail_Path.Text = Path.GetDirectoryName(hidePartsData.Thumbnail.Replace("/", "\\"));
            Loading = false;
        }

        private void TB_EntryName_TextChanged(object sender, EventArgs e)
        {
            if (Loading || TB_EntryName.Text.Length <= 0 || TB_EntryName.Text == string.Empty || TB_EntryName.Text == null)
                return;

            innerData.Name = TB_EntryName.Text;
            treeView1.SelectedNode.Text = TB_EntryName.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "uasset File|*.uasset";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string infile = openFileDialog.FileName;
                    Relic relic = Blood.Open(infile);
                    if (!Common.VerifyFile(relic, "Texture2D"))
                    {
                        MessageBox.Show("Selected File is not an Texture2D Asset", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    Thumbnail_Path.Text =  $"\\Game{Path.GetDirectoryName(infile).Substring(infile.LastIndexOf("Content") + 7)}";
                    TB_Thumbnail.Text = Path.GetFileNameWithoutExtension(infile);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "uasset File|*.uasset";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string infile = openFileDialog.FileName;
                    Relic relic = Blood.Open(infile);
                    if (!Common.VerifyFile(relic, "SkeletalMesh"))
                    {
                        MessageBox.Show("Selected File is not an SkeletalMesh Asset", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    Mesh_Path.Text = $"\\Game{Path.GetDirectoryName(infile).Substring(infile.LastIndexOf("Content") + 7)}";
                    TB_Mesh.Text = Path.GetFileNameWithoutExtension(infile);
                }
            }
        }

        private void TB_Thumbnail_TextChanged(object sender, EventArgs e)
        {
            if (Loading || TB_EntryName.Text.Length <= 0 || TB_EntryName.Text == string.Empty || TB_EntryName.Text == null)
                return;
            innerData.Thumbnail = $"{Thumbnail_Path.Text.Replace("\\", "/")}/{TB_Thumbnail.Text}.{TB_Thumbnail.Text}";
        }

        private void TB_Mesh_TextChanged(object sender, EventArgs e)
        {
            if (Loading || TB_Mesh.Text.Length <= 0 || TB_Mesh.Text == string.Empty || TB_Mesh.Text == null)
                return;
            innerData.Mesh = $"{Mesh_Path.Text.Replace("\\", "/")}/{TB_Mesh.Text}.{TB_Mesh.Text}";
        }

        private void EnableColour_CheckedChanged(object sender, EventArgs e)
        {
            if (Loading)
                return;

            Loading = true;
            CheckBox checkBox = sender as CheckBox;
            int checknum = int.Parse(checkBox.Name.Replace("EnableColour", "")) - 1;
            PictureBox picture = groupBox3.Controls[groupBox3.Controls.IndexOfKey($"pictureBox{checknum+1}")] as PictureBox;
            if (checkBox.Checked)
            {
                if ((string)picture.Tag == "None.None.false")
                {
                    // if we're adding a new color load the color picker
                    using (ColorPicker colorPicker = new ColorPicker(InnerPalettes.GetNames().ToArray()))
                    {
                        colorPicker.StartPosition = FormStartPosition.CenterParent;
                        if (colorPicker.ShowDialog() == DialogResult.OK)
                        {
                            picture.Tag = colorPicker.ReturnTag;
                        }
                        else
                        {
                            //if user cancels out for some stupid reason, catch to save them from their own stupidity
                            picture.Tag = $"StandardColor_Gray1.palette_stg_monotone00.false";
                        }
                    }
                }
                SetInnerColor(checknum, (string)picture.Tag);
                if (((string)picture.Tag).Contains(".true"))
                {
                    string thumbnail = Path.GetExtension(GetSpecialColor((string)picture.Tag).Thumbnail).Substring(1);
                    picture.Image = new Bitmap($"Assets\\SpecialPalette\\{thumbnail}.png");
                }
                else
                {
                    picture.BackColor = GetColor((string)picture.Tag).ToColor();
                }
                
            }
            else
            {
                SetInnerColor(checknum, "None.None.false");
                try { picture.Image.Dispose(); } catch { }
                picture.Image = null;
                picture.BackColor = SystemColors.Control;
            }
            Loading = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string Message = "Hide Parts require an entry in the DT_InnerPartsVisibilityByOuter Table to function properly" +
                "\r\nWould you like to add a new entry based on the current info?" +
                "\r\n*Both the Entry Name and Mesh path with be used*";
            using (MessageBoxEx messageBoxEx = new MessageBoxEx(Message, "Notice"))
            {
                messageBoxEx.StartPosition = FormStartPosition.CenterParent;
                if (messageBoxEx.ShowDialog() == DialogResult.OK)
                {
                    Relic relic = new Relic();
                    using (OpenFileDialog openFileDialog = new OpenFileDialog())
                    {
                        openFileDialog.Filter = "uasset File|DT_InnerPartsVisibilityByOuter.uasset";
                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            relic = Blood.Open(openFileDialog.FileName);
                        }
                    }

                    InnerPartsVisibilityByOuter innerPartsVisibilityByOuter = new InnerPartsVisibilityByOuter();
                    innerPartsVisibilityByOuter.Read(relic.GetDataTable());
                    if (treeView1.SelectedNode.Index <= 7 || innerPartsVisibilityByOuter.partsVisibilities.FirstOrDefault(x => x.Name == innerData.Name) != null )
                    {
                        MessageBox.Show("Entry name already exists", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    innerPartsVisibilityByOuter.partsVisibilities.Add(new QueenIO.Structs.PartsVisibilityByOuter(true) { Name = innerData.Name, InnerKey = innerData.Mesh });

                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "uasset File|*.uasset";
                        saveFileDialog.FileName = "DT_InnerPartsVisibilityByOuter";
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            relic.WriteDataTable(innerPartsVisibilityByOuter.Make());
                            Blood.Save(relic, saveFileDialog.FileName);
                        }
                    }
                }
            }
        }


        #endregion

        private void TB_HideThumbnail_TextChanged(object sender, EventArgs e)
        {
            if (Loading || TB_HideThumbnail.Text.Length <= 0 || TB_HideThumbnail.Text == string.Empty || TB_HideThumbnail.Text == null)
                return;
            innerData.HidePartsInfoDetails.HideParts[treeView2.SelectedNode.Index].Thumbnail =
                $"{HideThumbnail_Path.Text.Replace("\\","/")}/{TB_HideThumbnail.Text}.{TB_HideThumbnail.Text}";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "uasset File|*.uasset";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string infile = openFileDialog.FileName;
                    Relic relic = Blood.Open(infile);
                    if (!Common.VerifyFile(relic, "Texture2D"))
                    {
                        MessageBox.Show("Selected File is not an Texture2D Asset", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    HideThumbnail_Path.Text = $"\\Game{Path.GetDirectoryName(infile).Substring(infile.LastIndexOf("Content") + 7)}";
                    TB_HideThumbnail.Text = Path.GetFileNameWithoutExtension(infile);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (treeView2.Nodes.Count >= 8)
            {
                MessageBox.Show("Entry contains the max number of hide parts", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            foreach (string HidePart in HidePartsNames)
            {
                if (treeView2.Nodes.Contains(treeView2.Nodes.Cast<TreeNode>().FirstOrDefault(x => x.Text == HidePart)))
                    continue;

                treeView2.Nodes.Add(HidePart);
                innerData.HidePartsInfoDetails.HideParts.Add(new HidePartsData() { HidePartsName = HidePart, Thumbnail = "/Game/BasicAssets/Textures/T_Black.T_Black" });
                return;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            innerData.HidePartsInfoDetails.HideParts.RemoveAt(treeView2.SelectedNode.Index);
            treeView2.SelectedNode.Remove();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Loading)
                return;

            innerData.HidePartsInfoDetails.HideParts[treeView2.SelectedNode.Index].HidePartsName = comboBox1.Text;
            treeView2.SelectedNode.Text = comboBox1.Text;
        }
    }
}
