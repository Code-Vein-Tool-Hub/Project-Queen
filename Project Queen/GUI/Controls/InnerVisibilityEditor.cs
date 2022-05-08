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
using QueenIO.Structs;
using QueenIO.Tables;

namespace Project_Queen.GUI.Controls
{
    public partial class InnerVisibilityEditor : UserControl
    {
        public InnerPartsVisibilityByOuter VisibiltyList = new InnerPartsVisibilityByOuter();
        PartsVisibilityByOuter VisParts;
        public InnerVisibilityEditor(Relic infile)
        {
            InitializeComponent();
            VisibiltyList.Read(infile.GetDataTable());
            InitialLoad();
        }
        bool Loading = false;

        private void InitialLoad()
        {
            foreach (var item in VisibiltyList.partsVisibilities)
            {
                treeView1.Nodes.Add(item.Name);
            }
            Mesh_Path.Text = String.Empty;
            treeView1.Focus();
            treeView1.SelectedNode = treeView1.Nodes[0];
            VisParts = VisibiltyList.partsVisibilities[treeView1.SelectedNode.Index];
        }

        private void Reset(bool ResetList = false)
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;
            checkBox8.Checked = false;
            checkBox9.Checked = false;
            
            if (ResetList)
            {
                Mesh_Path.Text = String.Empty;
                TB_Mesh.Clear();
                treeView2.Nodes.Clear();
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

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Loading = true;
            Reset(true);
            Enable();
            VisParts = VisibiltyList.partsVisibilities[treeView1.SelectedNode.Index];
            TB_Mesh.Text = VisParts.InnerKey.Split('.').Last();
            Mesh_Path.Text = Path.GetDirectoryName(VisParts.InnerKey.Replace("/", "\\"));
            foreach (var outer in VisParts.InnerPartsVisibilityList)
            {
                treeView2.Nodes.Add(PartsVisibilityByOuter.KeyToName[outer.Name]);
            }
            Loading = false;
        }

        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Loading = true;
            Reset();
            checkBox1.Checked = VisParts.InnerPartsVisibilityList[treeView2.SelectedNode.Index].HidePartsA;
            checkBox2.Checked = VisParts.InnerPartsVisibilityList[treeView2.SelectedNode.Index].HidePartsB;
            checkBox3.Checked = VisParts.InnerPartsVisibilityList[treeView2.SelectedNode.Index].HidePartsC;
            checkBox4.Checked = VisParts.InnerPartsVisibilityList[treeView2.SelectedNode.Index].HidePartsD;
            checkBox5.Checked = VisParts.InnerPartsVisibilityList[treeView2.SelectedNode.Index].HidePartsE;
            checkBox6.Checked = VisParts.InnerPartsVisibilityList[treeView2.SelectedNode.Index].HidePartsF;
            checkBox7.Checked = VisParts.InnerPartsVisibilityList[treeView2.SelectedNode.Index].HidePartsG;
            checkBox8.Checked = VisParts.InnerPartsVisibilityList[treeView2.SelectedNode.Index].HidePartsH;
            checkBox9.Checked = VisParts.InnerPartsVisibilityList[treeView2.SelectedNode.Index].HideRightArm;
            Loading = false;
        }

        private void Add_Click(object sender, EventArgs e)
        {
            using (TextInput textInput = new TextInput("Enter Name for new Inner entry"))
            {
                textInput.StartPosition = FormStartPosition.CenterParent;
                if (textInput.ShowDialog() == DialogResult.OK)
                {
                    VisibiltyList.partsVisibilities.Add(new PartsVisibilityByOuter(true)
                    {
                        Name = textInput.ReturnText,
                        InnerKey = $"/Game/BasicAssets/Meshes/SK_Null.SK_Null",
                    });
                    treeView1.Nodes.Add(textInput.ReturnText);
                }
            }
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null || treeView1.SelectedNode.Index <= 17)
                return;

            VisibiltyList.partsVisibilities.RemoveAt(treeView1.SelectedNode.Index);
            treeView1.SelectedNode.Remove();
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
            if (Loading || TB_Mesh.Text.Length <= 0 || TB_Mesh.Text == string.Empty || TB_Mesh.Text == null)
                return;
            VisParts.InnerKey = $"{Mesh_Path.Text.Replace("\\", "/")}/{TB_Mesh.Text}.{TB_Mesh.Text}";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (Loading)
                return;

            VisParts.InnerPartsVisibilityList[treeView2.SelectedNode.Index].HidePartsA = checkBox1.Checked;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (Loading)
                return;

            VisParts.InnerPartsVisibilityList[treeView2.SelectedNode.Index].HidePartsB = checkBox2.Checked;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (Loading)
                return;

            VisParts.InnerPartsVisibilityList[treeView2.SelectedNode.Index].HidePartsC = checkBox3.Checked;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (Loading)
                return;

            VisParts.InnerPartsVisibilityList[treeView2.SelectedNode.Index].HidePartsD = checkBox4.Checked;
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (Loading)
                return;

            VisParts.InnerPartsVisibilityList[treeView2.SelectedNode.Index].HidePartsE = checkBox5.Checked;
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (Loading)
                return;

            VisParts.InnerPartsVisibilityList[treeView2.SelectedNode.Index].HidePartsF = checkBox6.Checked;
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (Loading)
                return;

            VisParts.InnerPartsVisibilityList[treeView2.SelectedNode.Index].HidePartsG = checkBox7.Checked;
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (Loading)
                return;

            VisParts.InnerPartsVisibilityList[treeView2.SelectedNode.Index].HidePartsH = checkBox8.Checked;
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (Loading)
                return;

            VisParts.InnerPartsVisibilityList[treeView2.SelectedNode.Index].HideRightArm = checkBox9.Checked;
        }
    }
}
