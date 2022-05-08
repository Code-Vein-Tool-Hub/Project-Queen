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
using QueenIO;
using QueenIO.Tables;
using Project_Queen.GUI.Forms;
using Project_Queen.IO;

namespace Project_Queen.GUI.Controls
{
    public partial class MaskEditor : UserControl
    {
        public MaskListData MaskListData = new MaskListData();
        MaskData maskData;

        public MaskEditor(Relic infile)
        {
            InitializeComponent();
            MaskListData.Read(infile.GetDataTable());
            InitialLoad();
        }
        bool Loading = false;

        private void InitialLoad()
        {
            foreach (var item in MaskListData.Masks)
            {
                treeView1.Nodes.Add(item.Name);
            }
        }

        private void Reset()
        {
            TB_EntryName.Clear();
            TB_Thumbnail.Clear();
            TB_Mesh.Clear();
            TB_CheckFlag.Clear();
            Thumbnail_Path.Text = string.Empty;
            Mesh_Path.Text = string.Empty;
            NUD_X.Value = 0;
            NUD_Y.Value = 0;
            NUD_Z.Value = 0;
            CB_HideFace.Checked = false;
            CB_HideHair.Checked = false;
        }

        private void Enable()
        {
            this.ForAllControls(c =>
            {
                if (c.Enabled == false)
                    c.Enabled = true;
            });
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Loading = true;
            Reset();
            Enable();
            maskData = MaskListData.Masks[treeView1.SelectedNode.Index];
            TB_EntryName.Text = maskData.Name;
            TB_Thumbnail.Text = maskData.Thumbnail.Split('.').Last();
            Thumbnail_Path.Text = Path.GetDirectoryName(maskData.Thumbnail.Replace("/", "\\"));
            TB_Mesh.Text = maskData.Mesh.Split('.').Last();
            Mesh_Path.Text = Path.GetDirectoryName(maskData.Mesh.Replace("/", "\\"));
            TB_CheckFlag.Text = maskData.CheckFlagSymbol.Value;
            CB_HideFace.Checked = maskData.FaceHide;
            CB_HideHair.Checked = maskData.HairHide;
            NUD_X.Value = (decimal)maskData.ScenarioOffset.X;
            NUD_Y.Value = (decimal)maskData.ScenarioOffset.Y;
            NUD_Z.Value = (decimal)maskData.ScenarioOffset.Z;
            Loading = false;
        }

        private void Add_Click(object sender, EventArgs e)
        {
            using (TextInput textInput = new TextInput("Enter Name for new Inner entry"))
            {
                textInput.StartPosition = FormStartPosition.CenterParent;
                if (textInput.ShowDialog() == DialogResult.OK)
                {
                    MaskListData.Masks.Add(new MaskData()
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
            MaskListData.Masks.RemoveAt(treeView1.SelectedNode.Index);
            treeView1.SelectedNode.Remove();
        }

        private void TB_EntryName_TextChanged(object sender, EventArgs e)
        {
            if (Loading || TB_EntryName.Text.Length <= 0 || TB_EntryName.Text == string.Empty || TB_EntryName.Text == null)
                return;

            maskData.Name = TB_EntryName.Text;
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
                    Thumbnail_Path.Text = $"\\Game{Path.GetDirectoryName(infile).Substring(infile.LastIndexOf("Content") + 7)}";
                    TB_Thumbnail.Text = Path.GetFileNameWithoutExtension(infile);
                }
            }
        }

        private void TB_Thumbnail_TextChanged(object sender, EventArgs e)
        {
            if (Loading || TB_EntryName.Text.Length <= 0 || TB_EntryName.Text == string.Empty || TB_EntryName.Text == null)
                return;
            maskData.Thumbnail = $"{Thumbnail_Path.Text.Replace("\\", "/")}/{TB_Thumbnail.Text}.{TB_Thumbnail.Text}";
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

        private void TB_Mesh_TextChanged(object sender, EventArgs e)
        {
            if (Loading || TB_EntryName.Text.Length <= 0 || TB_EntryName.Text == string.Empty || TB_EntryName.Text == null)
                return;
            maskData.Thumbnail = $"{Thumbnail_Path.Text.Replace("\\", "/")}/{TB_Thumbnail.Text}.{TB_Thumbnail.Text}";
        }

        private void TB_CheckFlag_TextChanged(object sender, EventArgs e)
        {
            if (Loading)
                return;

            if (TB_CheckFlag.Text.Length <= 0 || TB_CheckFlag.Text == string.Empty || TB_CheckFlag.Text == null)
                maskData.CheckFlagSymbol.Value = null;
            else
                maskData.CheckFlagSymbol.Value = TB_CheckFlag.Text;
        }

        private void NUD_X_ValueChanged(object sender, EventArgs e)
        {
            if (Loading)
                return;
            maskData.ScenarioOffset.X = (float)NUD_X.Value;
        }

        private void NUD_Y_ValueChanged(object sender, EventArgs e)
        {
            if (Loading)
                return;
            maskData.ScenarioOffset.Y = (float)NUD_Y.Value;
        }

        private void NUD_Z_ValueChanged(object sender, EventArgs e)
        {
            if (Loading)
                return;
            maskData.ScenarioOffset.Z = (float)NUD_Z.Value;
        }

        private void CB_HideFace_CheckedChanged(object sender, EventArgs e)
        {
            if (Loading)
                return;
            maskData.FaceHide = CB_HideFace.Checked;
        }

        private void CB_HideHair_CheckedChanged(object sender, EventArgs e)
        {
            if (Loading)
                return;
            maskData.HairHide = CB_HideHair.Checked;
        }
    }
}
