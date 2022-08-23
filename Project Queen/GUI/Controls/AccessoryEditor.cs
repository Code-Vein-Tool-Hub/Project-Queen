using Newtonsoft.Json;
using Project_Queen.GUI.Forms;
using Project_Queen.IO;
using Project_Queen.IO.Objects;
using QueenIO;
using QueenIO.Tables;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Windows.Forms;

namespace Project_Queen.GUI.Controls
{
    public partial class AccessoryEditor : UserControl
    {
        public AccessoryListData accessoryList = new AccessoryListData();
        AccessoryData accessoryData;
        List<Palette> colourTable = new List<Palette>();
        SpecialColorsList specialColorsTable = new SpecialColorsList();
        PaletteList InnerPalettes = new PaletteList();

        public AccessoryEditor(Relic infile)
        {
            InitializeComponent();
            accessoryList.Read(infile.GetDataTable());
            InitinalLoad(Path.GetFileNameWithoutExtension(infile.FilePath));

        }
        bool Loading = false;

        private void InitinalLoad(string Name)
        {
            foreach (var item in accessoryList.Accessories)
            {
                treeView1.Nodes.Add(item.Name);
            }
            if (File.Exists("Assets\\ColourList.json"))
                colourTable = JsonConvert.DeserializeObject<List<Palette>>(File.ReadAllText("Assets\\ColourList.json"));
            if (File.Exists("Assets\\PaletteList.json"))
            {
                List<PaletteList> palettes = JsonConvert.DeserializeObject<List<PaletteList>>(File.ReadAllText("Assets\\PaletteList.json"));
                if (Name.Contains("DT_AccessoryPresetExtension"))
                    InnerPalettes = palettes.FirstOrDefault(x => x.Name == "HairColorMesh");
                else
                    InnerPalettes = palettes.FirstOrDefault(x => x.Name == "AttachmentColor");
            }
            if (File.Exists("Assets\\SpecialColourList.json"))
                specialColorsTable = JsonConvert.DeserializeObject<SpecialColorsList>(File.ReadAllText("Assets\\SpecialColourList.json"));
        }

        private void Reset()
        {
            TB_EntryName.Clear();
            TB_Mesh.Clear();
            TB_Thumbnail.Clear();
            TB_CheckFlag.Clear();
            TB_AttachName.Clear();
            Thumbnail_Path.Text = String.Empty;
            Mesh_Path.Text = String.Empty;
            NUD_Cost.Value = 0;
            NUD_Anim.Value = 0;
            CB_Spa.Checked = false;
            CB_ScaleNeg.Checked = false;
            CB_Transformable.Checked = false;
            CB_Slots.SelectedIndex = 0;
            #region Transform Boxes
            NUD_Root_R_X.Value = 0;
            NUD_Root_R_Y.Value = 0;
            NUD_Root_R_Z.Value = 0;
            NUD_Root_S_X.Value = 0;
            NUD_Root_S_Y.Value = 0;
            NUD_Root_S_Z.Value = 0;
            NUD_Root_T_X.Value = 0;
            NUD_Root_T_Y.Value = 0;
            NUD_Root_T_Z.Value = 0;

            NUD_Ori_R_X.Value = 0;
            NUD_Ori_R_Y.Value = 0;
            NUD_Ori_R_Z.Value = 0;
            NUD_Ori_S_X.Value = 0;
            NUD_Ori_S_Y.Value = 0;
            NUD_Ori_S_Z.Value = 0;
            NUD_Ori_T_X.Value = 0;
            NUD_Ori_T_Y.Value = 0;
            NUD_Ori_T_Z.Value = 0;

            NUD_Mesh_R_X.Value = 0;
            NUD_Mesh_R_Y.Value = 0;
            NUD_Mesh_R_Z.Value = 0;
            NUD_Mesh_S_X.Value = 0;
            NUD_Mesh_S_Y.Value = 0;
            NUD_Mesh_S_Z.Value = 0;
            NUD_Mesh_T_X.Value = 0;
            NUD_Mesh_T_Y.Value = 0;
            NUD_Mesh_T_Z.Value = 0;
            #endregion
            EnableColour1.Checked = false;
            EnableColour2.Checked = false;
            EnableColour3.Checked = false;
            pictureBox1.BackColor = SystemColors.Control;
            pictureBox2.BackColor = SystemColors.Control;
            pictureBox3.BackColor = SystemColors.Control;
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
        }

        private void Enable()
        {
            this.ForAllControls(c =>
           {
               if (c.Enabled == false)
                   c.Enabled = true;
           });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (TextInput textInput = new TextInput("Enter Name for new Inner entry"))
            {
                textInput.StartPosition = FormStartPosition.CenterParent;
                if (textInput.ShowDialog() == DialogResult.OK)
                {
                    accessoryList.Accessories.Add(new AccessoryData()
                    {
                        Name = textInput.ReturnText,
                        Thumbnail = $"/Game/BasicAssets/Textures/T_Black.T_Black",
                        Mesh = $"/Game/BasicAssets/Meshes/SK_Null.SK_Null",
                        MaxColor = $"EAvatarCustomizeAccessoryColorSlot::Slot3"
                    });
                    treeView1.Nodes.Add(textInput.ReturnText);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            accessoryList.Accessories.RemoveAt(treeView1.SelectedNode.Index);
            treeView1.SelectedNode.Remove();
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

        private void SetAccessoryColor(int index, string Tag)
        {
            string palette = Tag.Split('.')[0];
            string color = Tag.Split('.')[1];
            bool IsSpecial = bool.Parse(Tag.Split('.')[2]);
            switch (index)
            {
                case 1:
                    accessoryData.Color_1 = new ColorData(palette, color, IsSpecial) { Name = "Color", StructType = "AvatarCustomizeDataTableAccessoryColor" };
                    break;
                case 2:
                    accessoryData.Color_2 = new ColorData(palette, color, IsSpecial) { Name = "Color", StructType = "AvatarCustomizeDataTableAccessoryColor" };
                    break;
                case 3:
                    accessoryData.Color_3 = new ColorData(palette, color, IsSpecial) { Name = "Color", StructType = "AvatarCustomizeDataTableAccessoryColor" };
                    break;
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Loading = true;
            Reset();
            Enable();
            accessoryData = accessoryList.Accessories[treeView1.SelectedNode.Index];
            TB_EntryName.Text = accessoryData.Name;
            TB_Thumbnail.Text = accessoryData.Thumbnail.Split('.').Last();
            Thumbnail_Path.Text = Path.GetDirectoryName(accessoryData.Thumbnail.Replace("/", "\\"));
            TB_Mesh.Text = accessoryData.Mesh.Split('.').Last();
            Mesh_Path.Text = Path.GetDirectoryName(accessoryData.Mesh.Replace("/", "\\"));
            TB_CheckFlag.Text = accessoryData.CheckFlag.Value;
            TB_AttachName.Text = accessoryData.AttachRowName;
            CB_Spa.Checked = accessoryData.SpaEnable;
            CB_Transformable.Checked = accessoryData.Transformable;
            CB_ScaleNeg.Checked = accessoryData.ScaleNegate;
            NUD_Cost.Value = accessoryData.Cost;
            NUD_Anim.Value = accessoryData.AnimClass;

            #region Transform
            NUD_Root_R_X.Value = (decimal)accessoryData.RootTransform.Rotation.X;
            NUD_Root_R_Y.Value = (decimal)accessoryData.RootTransform.Rotation.Y;
            NUD_Root_R_Z.Value = (decimal)accessoryData.RootTransform.Rotation.Z;
            NUD_Root_T_X.Value = (decimal)accessoryData.RootTransform.Translation.X;
            NUD_Root_T_Y.Value = (decimal)accessoryData.RootTransform.Translation.Y;
            NUD_Root_T_Z.Value = (decimal)accessoryData.RootTransform.Translation.Z;
            NUD_Root_S_X.Value = (decimal)accessoryData.RootTransform.Scale3D.X;
            NUD_Root_S_Y.Value = (decimal)accessoryData.RootTransform.Scale3D.Y;
            NUD_Root_S_Z.Value = (decimal)accessoryData.RootTransform.Scale3D.Z;

            NUD_Ori_R_X.Value = (decimal)accessoryData.OrientTransform.Rotation.X;
            NUD_Ori_R_Y.Value = (decimal)accessoryData.OrientTransform.Rotation.Y;
            NUD_Ori_R_Z.Value = (decimal)accessoryData.OrientTransform.Rotation.Z;
            NUD_Ori_T_X.Value = (decimal)accessoryData.OrientTransform.Translation.X;
            NUD_Ori_T_Y.Value = (decimal)accessoryData.OrientTransform.Translation.Y;
            NUD_Ori_T_Z.Value = (decimal)accessoryData.OrientTransform.Translation.Z;
            NUD_Ori_S_X.Value = (decimal)accessoryData.OrientTransform.Scale3D.X;
            NUD_Ori_S_Y.Value = (decimal)accessoryData.OrientTransform.Scale3D.Y;
            NUD_Ori_S_Z.Value = (decimal)accessoryData.OrientTransform.Scale3D.Z;

            NUD_Mesh_R_X.Value = (decimal)accessoryData.MeshTransform.Rotation.X;
            NUD_Mesh_R_Y.Value = (decimal)accessoryData.MeshTransform.Rotation.Y;
            NUD_Mesh_R_Z.Value = (decimal)accessoryData.MeshTransform.Rotation.Z;
            NUD_Mesh_T_X.Value = (decimal)accessoryData.MeshTransform.Translation.X;
            NUD_Mesh_T_Y.Value = (decimal)accessoryData.MeshTransform.Translation.Y;
            NUD_Mesh_T_Z.Value = (decimal)accessoryData.MeshTransform.Translation.Z;
            NUD_Mesh_S_X.Value = (decimal)accessoryData.MeshTransform.Scale3D.X;
            NUD_Mesh_S_Y.Value = (decimal)accessoryData.MeshTransform.Scale3D.Y;
            NUD_Mesh_S_Z.Value = (decimal)accessoryData.MeshTransform.Scale3D.Z;
            #endregion

            CB_Slots.SelectedIndex = CB_Slots.Items.IndexOf(accessoryData.MaxColor.Replace("EAvatarCustomizeAccessoryColorSlot::", ""));
            pictureBox1.Tag = $"{accessoryData.Color_1.ColorPaletteRowName}.{accessoryData.Color_1.ColorName}.{accessoryData.Color_1.IsSpecialColor.ToString().ToLower()}";
            pictureBox2.Tag = $"{accessoryData.Color_2.ColorPaletteRowName}.{accessoryData.Color_2.ColorName}.{accessoryData.Color_2.IsSpecialColor.ToString().ToLower()}";
            pictureBox3.Tag = $"{accessoryData.Color_3.ColorPaletteRowName}.{accessoryData.Color_3.ColorName}.{accessoryData.Color_3.IsSpecialColor.ToString().ToLower()}";

            if (accessoryData.Color_1.ColorPaletteRowName != "None")
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
            if (accessoryData.Color_2.ColorPaletteRowName != "None")
            {
                if (((string)pictureBox2.Tag).Contains(".true"))
                {
                    string thumbnail = Path.GetExtension(GetSpecialColor((string)pictureBox2.Tag).Thumbnail).Substring(3);
                    pictureBox2.Image = new Bitmap($"Assets\\SpecialPalette\\{thumbnail}.png");
                }
                else
                {
                    pictureBox2.BackColor = GetColor((string)pictureBox2.Tag).ToColor();
                }
                EnableColour2.Checked = true;
            }
            if (accessoryData.Color_3.ColorPaletteRowName != "None")
            {
                if (((string)pictureBox3.Tag).Contains(".true"))
                {
                    string thumbnail = Path.GetExtension(GetSpecialColor((string)pictureBox3.Tag).Thumbnail).Substring(4);
                    pictureBox3.Image = new Bitmap($"Assets\\SpecialPalette\\{thumbnail}.png");
                }
                else
                {
                    pictureBox3.BackColor = GetColor((string)pictureBox3.Tag).ToColor();
                }
                EnableColour3.Checked = true;
            }

            Loading = false;
        }

        private void TB_EntryName_TextChanged(object sender, EventArgs e)
        {
            if (Loading || TB_EntryName.Text.Length <= 0 || TB_EntryName.Text == string.Empty || TB_EntryName.Text == null)
                return;

            accessoryData.Name = TB_EntryName.Text;
            treeView1.SelectedNode.Text = TB_EntryName.Text;
        }

        private void TB_Thumbnail_TextChanged(object sender, EventArgs e)
        {
            if (Loading || TB_Thumbnail.Text.Length <= 0 || TB_Thumbnail.Text == string.Empty || TB_Thumbnail.Text == null)
                return;
            accessoryData.Thumbnail = $"{Thumbnail_Path.Text.Replace("\\", "/")}/{TB_Thumbnail.Text}.{TB_Thumbnail.Text}";
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
                    Thumbnail_Path.Text = $"\\Game{Path.GetDirectoryName(infile).Substring(infile.LastIndexOf("Content") + 7)}";
                    TB_Thumbnail.Text = Path.GetFileNameWithoutExtension(infile);
                }
            }
        }

        private void TB_Mesh_TextChanged(object sender, EventArgs e)
        {
            if (Loading || TB_Mesh.Text.Length <= 0 || TB_Mesh.Text == string.Empty || TB_Mesh.Text == null)
                return;
            accessoryData.Mesh = $"{Mesh_Path.Text.Replace("\\", "/")}/{TB_Mesh.Text}.{TB_Mesh.Text}";
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

        private void TB_CheckFlag_TextChanged(object sender, EventArgs e)
        {
            if (Loading)
                return;

            if (TB_CheckFlag.Text.Length <= 0 || TB_CheckFlag.Text == string.Empty || TB_CheckFlag.Text == null)
                accessoryData.CheckFlag.Value = null;
            else
                accessoryData.CheckFlag.Value = TB_CheckFlag.Text;
        }

        private void TB_AttachName_TextChanged(object sender, EventArgs e)
        {
            if (Loading)
                return;

            if (TB_AttachName.Text.Length <= 0 || TB_AttachName.Text == string.Empty || TB_AttachName.Text == null)
                accessoryData.AttachRowName = null;
            else
                accessoryData.AttachRowName = TB_AttachName.Text;
        }

        private void NUD_Cost_ValueChanged(object sender, EventArgs e)
        {
            if (Loading)
                return;
            accessoryData.Cost = Convert.ToInt32(NUD_Cost.Value);
        }

        private void NUD_Anim_ValueChanged(object sender, EventArgs e)
        {
            if (Loading)
                return;
            accessoryData.AnimClass = Convert.ToInt32(NUD_Anim.Value);
        }

        private void CB_Spa_CheckedChanged(object sender, EventArgs e)
        {
            if (Loading)
                return;
            accessoryData.SpaEnable = CB_Spa.Checked;
        }

        private void CB_Transformable_CheckedChanged(object sender, EventArgs e)
        {
            if (Loading)
                return;
            accessoryData.Transformable = CB_Transformable.Checked;
        }

        private void CB_ScaleNeg_CheckedChanged(object sender, EventArgs e)
        {
            if (Loading)
                return;
            accessoryData.ScaleNegate = CB_ScaleNeg.Checked;
        }

        private void SetTransform(Transform transform, string Set, string axis, decimal value)
        {
            float _value = Convert.ToSingle(value);
            if (Set == "R")
            {
                switch (axis)
                {
                    case "X":
                        transform.Rotation = new Quaternion()
                        {
                            W = transform.Rotation.W,
                            X = _value,
                            Y = transform.Rotation.Y,
                            Z = transform.Rotation.Z,
                        };
                        break;
                    case "Y":
                        transform.Rotation = new Quaternion()
                        {
                            W = transform.Rotation.W,
                            X = transform.Rotation.X,
                            Y = _value,
                            Z = transform.Rotation.Z,
                        };
                        break;
                    case "Z":
                        transform.Rotation = new Quaternion()
                        {
                            W = transform.Rotation.W,
                            X = transform.Rotation.X,
                            Y = transform.Rotation.Y,
                            Z = _value,
                        };
                        break;
                }
            }
            else if (Set == "T")
            {
                switch (axis)
                {
                    case "X":
                        transform.Translation = new Vector3()
                        {
                            X = _value,
                            Y = transform.Translation.Y,
                            Z = transform.Translation.Z,
                        };
                        break;
                    case "Y":
                        transform.Translation = new Vector3()
                        {
                            X = transform.Translation.X,
                            Y = _value,
                            Z = transform.Translation.Z,
                        };
                        break;
                    case "Z":
                        transform.Translation = new Vector3()
                        {
                            X = transform.Translation.X,
                            Y = transform.Translation.Y,
                            Z = _value,
                        };
                        break;
                }
            }
            else if (Set == "S")
            {
                switch (axis)
                {
                    case "X":
                        transform.Scale3D = new Vector3()
                        {
                            X = _value,
                            Y = transform.Scale3D.Y,
                            Z = transform.Scale3D.Z,
                        };
                        break;
                    case "Y":
                        transform.Scale3D = new Vector3()
                        {
                            X = transform.Scale3D.X,
                            Y = _value,
                            Z = transform.Scale3D.Z,
                        };
                        break;
                    case "Z":
                        transform.Scale3D = new Vector3()
                        {
                            X = transform.Scale3D.X,
                            Y = transform.Scale3D.Y,
                            Z = _value,
                        };
                        break;
                }
            }
        }

        private void NUD_Transform_ValueChanged(object sender, EventArgs e)
        {
            if (Loading)
                return;
            NumericUpDown numericUpDown = sender as NumericUpDown;
            string[] details = numericUpDown.Name.Split('_');

            Transform transform;
            switch (details[1])
            {
                case "Root":
                    transform = accessoryData.RootTransform;
                    break;
                case "Ori":
                    transform = accessoryData.OrientTransform;
                    break;
                case "Mesh":
                    transform = accessoryData.MeshTransform;
                    break;
                default:
                    transform = accessoryData.RootTransform;
                    break;
            }
            SetTransform(transform, details[2], details[3], numericUpDown.Value);
        }

        private void CB_Slots_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Loading)
                return;
            accessoryData.MaxColor = $"EAvatarCustomizeAccessoryColorSlot::{CB_Slots.Text}";
        }

        private void EnableColour_CheckedChanged(object sender, EventArgs e)
        {
            if (Loading)
                return;

            Loading = true;
            CheckBox checkBox = sender as CheckBox;
            int checknum = int.Parse(checkBox.Name.Replace("EnableColour", ""));
            PictureBox picture = groupBox6.Controls[groupBox6.Controls.IndexOfKey($"pictureBox{checknum}")] as PictureBox;
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
                SetAccessoryColor(checknum, (string)picture.Tag);
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
                SetAccessoryColor(checknum, "None.None.false");
                try { picture.Image.Dispose(); } catch { }
                picture.Image = null;
                picture.BackColor = SystemColors.Control;
            }
            Loading = false;
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
                    SetAccessoryColor(int.Parse(pictureBox.Name.Replace("pictureBox", "")), colorPicker.ReturnTag);
                }
                else if (result == DialogResult.Yes)
                {
                    string thumbnail = Path.GetExtension(colorPicker.ReturnSpecial.Thumbnail).Substring(1);
                    pictureBox.Image = new Bitmap($"Assets\\SpecialPalette\\{thumbnail}.png");
                    pictureBox.Tag = colorPicker.ReturnTag;
                    SetAccessoryColor(int.Parse(pictureBox.Name.Replace("pictureBox", "")), colorPicker.ReturnTag);
                }
            }
        }
    }
}
