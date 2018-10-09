using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using youxi;
using System.IO;

namespace youxiApp
{
    public partial class Form1 : Form
    {
        private youxiControl youxiControl = new youxiControl();
        private youxiNext youxiNext = new youxiNext();
        private youxiScore youxiScore = new youxiScore();

        public Form1()
        {
            InitializeComponent();
            youxiControl.Top = menuStripMain.Height + 2;
            youxiControl.Left = 2;
            youxiControl.Parent = this;
            youxiControl.ImageList = imageList1;
            
            youxiNext.Parent = this;
            youxiNext.Top = youxiControl.Top;
            youxiNext.Left = youxiControl.Left + youxiControl.Width + 4;
            youxiControl.TetrisNext = youxiNext;

            youxiScore.Parent = this;
            youxiScore.Top = youxiNext.Top + youxiNext.Height + 4;
            youxiScore.Left = youxiNext.Left;
            youxiControl.TetrisScore = youxiScore;

            style1ToolStripMenuItem.Image = imageList1.Images[0];
            style2ToolStripMenuItem.Image = imageList2.Images[0];
            style3ToolStripMenuItem.Image = imageList3.Images[0];
            youxiControl.ProgressBar = progressBarReview;
            openFileDialog1.FileName = Path.GetDirectoryName(Application.ExecutablePath) +
                @"\sample.trf";
            saveFileDialog1.FileName = Path.GetDirectoryName(Application.ExecutablePath) +
                @"\sample.trf";
        }

        private void buttonReplay_Click(object sender, EventArgs e)
        {
            youxiControl.Replay(true, false);
        }

        private void buttonReview_Click(object sender, EventArgs e)
        {
            youxiControl.Review();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            youxiControl.ReviewSpeed = trackBarReviewSpeed.Value;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;
            if (Path.GetExtension(saveFileDialog1.FileName) == string.Empty)
                saveFileDialog1.FileName = 
                    Path.ChangeExtension(saveFileDialog1.FileName, ".trf");
            youxiControl.SaveToFile(saveFileDialog1.FileName);
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
            if (!File.Exists(openFileDialog1.FileName)) return;
            youxiControl.LoadFromFile(openFileDialog1.FileName);
        }

        private void replayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonReplay_Click(buttonReplay, new EventArgs());
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {                                                                    
            buttonSave_Click(buttonSave, new EventArgs());
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonLoad_Click(buttonLoad, new EventArgs());
        }

        private void reviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonReview_Click(buttonReview, new EventArgs());
        }

        private void exiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void keyBoardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("左移: Left、A\r\n右移: Right、D\r\n" +
                "下移: Down、S\r\n变换: Up、W\r\n变化2: Back、F\r\n直下: Space、J、Enter",
                "按键说明");
        }

        private void blogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://blog.sina.com.cn/u/589d32f5010008ls");
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("俄罗斯方块\r\n设计: 落雪飞花\r\n" +
                "日期: 2008-04-24\r\n联系: guanxijing@126.com", "关于本程序");
        }

        private void style1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sender == style1ToolStripMenuItem)
                youxiControl.ImageList = imageList1;
            else if (sender == style2ToolStripMenuItem)
                youxiControl.ImageList = imageList2;
            if (sender == style3ToolStripMenuItem)
                youxiControl.ImageList = imageList3;
        }

        private void replayExtendedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            youxiControl.Replay(true, true);
        }

        private void Formyouxi_Load(object sender, EventArgs e)
        {

        }
    }
}

