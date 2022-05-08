using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using QueenIO;
using QueenIO.Tables;
using Project_Queen.GUI.Forms;
using Project_Queen.IO;

namespace Project_Queen.GUI.Controls
{
    public partial class HairEditor : UserControl
    {
        public HairListData hairListData = new HairListData();
        HairData hairData;

        public HairEditor(Relic infile)
        {
            InitializeComponent();
            hairListData.Read(infile.GetDataTable());
            InitialLoad();
        }
        bool Loading = false;

        private void InitialLoad()
        {
            foreach (var item in hairListData.HairDataList)
            {
                treeView1.Nodes.Add(item.Name);
            }
        }

        private void Reset()
        {
            TB_EntryName.Clear();
            TB_Mesh.Clear();
            TB_Thumbnail.Clear();
            Thumbnail_Path.Text = string.Empty;
            Mesh_Path.Text = string.Empty;
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
            hairData = hairListData.HairDataList[treeView1.SelectedNode.Index];
            TB_EntryName.Text = hairData.Name;
            TB_Thumbnail.Text = hairData.Thumbnail.Split('.').Last();
            Thumbnail_Path.Text = Path.GetDirectoryName(hairData.Thumbnail.Replace("/", "\\"));
            TB_Mesh.Text = hairData.Mesh.Split('.').Last();
            Mesh_Path.Text = Path.GetDirectoryName(hairData.Mesh.Replace("/", "\\"));
            Loading = false;
        }

        private void B_Add_Click(object sender, EventArgs e)
        {
            using (TextInput textInput = new TextInput("Enter Name for new Inner entry"))
            {
                textInput.StartPosition = FormStartPosition.CenterParent;
                if (textInput.ShowDialog() == DialogResult.OK)
                {
                    hairListData.HairDataList.Add(new HairData()
                    {
                        Name = textInput.ReturnText,
                        Thumbnail = $"/Game/BasicAssets/Textures/T_Black.T_Black",
                        Mesh = $"/Game/BasicAssets/Meshes/SK_Null.SK_Null"
                    });
                    treeView1.Nodes.Add(textInput.ReturnText);
                }
            }
        }

        private void B_Remove_Click(object sender, EventArgs e)
        {
            hairListData.HairDataList.RemoveAt(treeView1.SelectedNode.Index);
            treeView1.SelectedNode.Remove();
        }

        private void TB_EntryName_TextChanged(object sender, EventArgs e)
        {
            if (Loading || TB_EntryName.Text.Length <= 0 || TB_EntryName.Text == string.Empty || TB_EntryName.Text == null)
                return;

            hairData.Name = TB_EntryName.Text;
            treeView1.SelectedNode.Text = TB_EntryName.Text;
        }

        private void B_Thumbnail_Click(object sender, EventArgs e)
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
            if (Loading || TB_Thumbnail.Text.Length <= 0 || TB_Thumbnail.Text == string.Empty || TB_Thumbnail.Text == null)
                return;
            hairData.Thumbnail = $"{Thumbnail_Path.Text.Replace("\\", "/")}/{TB_Thumbnail.Text}.{TB_Thumbnail.Text}";
        }

        private void B_Mesh_Click(object sender, EventArgs e)
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
            if (Loading || TB_Mesh.Text.Length <= 0 || TB_Mesh.Text == string.Empty || TB_Mesh.Text == null)
                return;
            hairData.Mesh = $"{Mesh_Path.Text.Replace("\\", "/")}/{TB_Mesh.Text}.{TB_Mesh.Text}";
        }
    }
}
