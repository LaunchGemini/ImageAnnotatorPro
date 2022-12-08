
﻿/*
    Date: 2020/10/19
    Title: C#控制元件picturebox實現影象拖拽和縮放
    Link: https://www.itread01.com/article/1537588121.html
    Title: 
    Link: 
*/

#define Use_FolderBrowserDialog_NewType // 是否使用 FolderBrowserDialog_NewType

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Reflection; // picturebox圖像縮放
using System.IO; // For FileInfo
using System.Media; // For SystemSounds
using System.Diagnostics; // For Trace
using System.Xml.Serialization;
using Painter2.SaveSetting;
using clsLanguage;
using static Painter2.FileSystem.FileSystem;
using System.Threading;

#if Use_FolderBrowserDialog_NewType
    using FolderBrowserDialog_NewType;
#endif

using Painter_DLL; // (20201019) Jeff Revised!

namespace Painter2
{
    public partial class Form1 : Form
    {
        private int Initial_pictureBox1Width = 1100, Initial_pictureBox1Height = 700;

        /// <summary>
        /// 繪圖區
        /// </summary>
        Graphics g { get; set; }
        /// <summary>
        /// 紀錄滑鼠是否被按下
        /// </summary>
        bool isMouseDown { get; set; } = false;
        //List<Point> points = new List<Point>(); // 紀錄滑鼠軌跡的陣列。
        //List<Pen> ListPen = new List<Pen>(); // 紀錄不同滑鼠軌跡段落之顏色及大小

        cls_LabelImage LabelImage = new cls_LabelImage();
        /// <summary>
        /// 標註工具類型
        /// </summary>
        DrawType drawType { get; set; } = DrawType.penPoint;

        /// <summary>
        /// 批次載入之資料夾路徑
        /// </summary>
        string folder_LoadBatch { get; set; } = "";

        /// <summary>
        /// 各影像所在之路徑
        /// </summary>
        List<string> path_Images { get; set; } = new List<string>();

        /// <summary>
        /// 當前影像之index
        /// </summary>
        int index_Image { get; set; } = 0;

        private cls_SaveSetting saveSetting = new cls_SaveSetting();

        public Form1()
        {
            InitializeComponent();

            this.pictureBox_ImageShowForm.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.pictureBox_ImageShowForm_MouseWheel);
            this.panel_DispImage.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.panel_DispImage_MouseWheel);

            g = pictureBox_ImageShowForm.CreateGraphics(); // 取得繪圖區物件

            #region 語言切換

            Language = clsLanguage.clsLanguage.GetLanguage();
            if (Language == "Chinese")
                中文ToolStripMenuItem.Checked = true;
            else if (Language == "English")
                英文ToolStripMenuItem.Checked = true;

            /* 特殊字元先刪除 (因為無法存入INI檔) */
            if (結束ToolStripMenuItem.Text == "結束(✖)")
                結束ToolStripMenuItem.Text = 結束ToolStripMenuItem.Text.Substring(0, 2);
            else if (結束ToolStripMenuItem.Text == "Quit(✖)")
                結束ToolStripMenuItem.Text = 結束ToolStripMenuItem.Text.Substring(0, 4);

            clsLanguage.clsLanguage.SetLanguateToControls(this, true);

            /* 特殊字元補回 (因為無法存入INI檔) */
            結束ToolStripMenuItem.Text += "(✖)";

            #endregion

            #region 調整版面到最大

            int sw = Screen.PrimaryScreen.Bounds.Width;
            int sh = Screen.PrimaryScreen.Bounds.Height;

            // Form
            this.WindowState = FormWindowState.Maximized;
            this.Left = 0;
            this.Top = 0;
            this.Width = sw;
            this.Height = sh;

            // 影像顯示
            //panel_DispImage.Width = this.Width - 200;
            //panel_DispImage.Width = this.Width - 205 - panel_BatchImages.Width;
            panel_DispImage.Height = this.Height - 160;
            //pictureBox_ImageShowForm.Width = panel_DispImage.Width;
            //pictureBox_ImageShowForm.Height = panel_DispImage.Height;

            // 影像資訊顯示
            this.panel_Info.Top = this.panel_DispImage.Top + this.panel_DispImage.Height + 5;

            // 資訊顯示
            panel_BatchImages.Top = panel_DispImage.Top;
            panel_BatchImages.Left = this.Width - panel_BatchImages.Width - 10;
            panel_BatchImages.Height = panel_Info.Top + panel_Info.Height - panel_BatchImages.Top;
            
            listViewImages.Height = panel_BatchImages.Height - 70;

            label_Version.Left = panel_BatchImages.Left - 5;
            label_VersionNum.Left = label_Version.Left + 70;
            label_VersionNum.Text = Application.ProductVersion;

            // 顏色快捷列表
            this.groupBox_ColorList.Height = this.groupBox_ColorList.Height + 15;
            this.panel_ColorList.Height = this.panel_ColorList.Height + 15;

            #endregion

            #region Icon 背景顏色設定為透明

            clsStaticTool.Control_DispImg_Transparent(this.button_Recovery, false);
            clsStaticTool.Control_DispImg_Transparent(this.button_Redo, false);
            clsStaticTool.Control_DispImg_Transparent(this.button_SavePath, false);

            #endregion

            #region 控制項提示視窗

            ToolTip toolTip_penPoint = new ToolTip();
            toolTip_penPoint.ForeColor = Color.DeepSkyBlue;
            toolTip_penPoint.SetToolTip(this.radioButton_penPoint, "點擊滑鼠左鍵拖曳進行連續點繪製");
            toolTip_penPoint.InitialDelay = 0;
            toolTip_penPoint.ToolTipTitle = "筆刷";

            ToolTip toolTip_eraser = new ToolTip();
            toolTip_eraser.ForeColor = Color.DeepSkyBlue;
            toolTip_eraser.SetToolTip(this.radioButton_eraser, "點擊滑鼠左鍵拖曳進行連續點擦除");
            toolTip_eraser.InitialDelay = 0;
            toolTip_eraser.ToolTipTitle = "橡皮擦";

            ToolTip toolTip_rectangle = new ToolTip();
            toolTip_rectangle.ForeColor = Color.DeepSkyBlue;
            toolTip_rectangle.SetToolTip(this.radioButton_rectangle, "於欲繪製矩形框頂點處，點擊滑鼠左鍵拖曳進行矩形框繪製");
            toolTip_rectangle.InitialDelay = 0;
            toolTip_rectangle.ToolTipTitle = "矩形框";

            ToolTip toolTip_rectangle_fill = new ToolTip();
            toolTip_rectangle_fill.ForeColor = Color.DeepSkyBlue;
            toolTip_rectangle_fill.SetToolTip(this.radioButton_rectangle_fill, "於欲繪製實心矩形頂點處，點擊滑鼠左鍵拖曳進行實心矩形繪製");
            toolTip_rectangle_fill.InitialDelay = 0;
            toolTip_rectangle_fill.ToolTipTitle = "實心矩形";

            ToolTip toolTip_circle = new ToolTip();
            toolTip_circle.ForeColor = Color.DeepSkyBlue;
            toolTip_circle.SetToolTip(this.radioButton_circle, "於欲繪製圓環中心點，點擊滑鼠左鍵拖曳進行圓環繪製");
            toolTip_circle.InitialDelay = 0;
            toolTip_circle.ToolTipTitle = "圓環";

            ToolTip toolTip_circle_fill = new ToolTip();
            toolTip_circle_fill.ForeColor = Color.DeepSkyBlue;
            toolTip_circle_fill.SetToolTip(this.radioButton_circle_fill, "於欲繪製實心圓中心點，點擊滑鼠左鍵拖曳進行實心圓繪製");
            toolTip_circle_fill.InitialDelay = 0;
            toolTip_circle_fill.ToolTipTitle = "實心圓";

            ToolTip toolTip_ellipse = new ToolTip();
            toolTip_ellipse.ForeColor = Color.DeepSkyBlue;
            toolTip_ellipse.SetToolTip(this.radioButton_ellipse, "於欲繪製橢圓環中心點，點擊滑鼠左鍵拖曳進行橢圓環繪製");
            toolTip_ellipse.InitialDelay = 0;
            toolTip_ellipse.ToolTipTitle = "橢圓環";

            ToolTip toolTip_ellipse_fill = new ToolTip();
            toolTip_ellipse_fill.ForeColor = Color.DeepSkyBlue;
            toolTip_ellipse_fill.SetToolTip(this.radioButton_ellipse_fill, "於欲繪製實心橢圓中心點，點擊滑鼠左鍵拖曳進行實心橢圓繪製");
            toolTip_ellipse_fill.InitialDelay = 0;
            toolTip_ellipse_fill.ToolTipTitle = "實心橢圓";

            ToolTip toolTip_selectRect = new ToolTip();
            toolTip_selectRect.ForeColor = Color.DeepSkyBlue;
            toolTip_selectRect.SetToolTip(this.radioButton_selectRect, "於欲擷取矩形ROI頂點處，點擊滑鼠左鍵拖曳進行擷取");
            toolTip_selectRect.InitialDelay = 0;
            toolTip_selectRect.ToolTipTitle = "矩形ROI";

            #endregion

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ArrayCursor = Enum.GetNames(typeof(enu_CursorImage));
            cbx_Cursor.Items.Clear();
            foreach (string s in ArrayCursor)
                cbx_Cursor.Items.Add(s);
            if (cbx_Cursor.Items.Count > 0)
                cbx_Cursor.SelectedIndex = 0;

            if (cls_SaveSetting.Load(out this.saveSetting) == false)
                this.saveSetting.Save();

            this.Update_Module(this.saveSetting.Index_Module);

            this.groupBox_ColorList.Visible = this.saveSetting.B_ColorList;
            this.Update_Dynamic_radioButton();

            if (this.saveSetting.B_External_Open)
                this.button_LoadBatchImages_Click(null, null);
        }

        /// <summary>
        /// 更新 操作模式
        /// </summary>
        /// <param name="index_Module"></param>
        private void Update_Module(int index_Module = 0)
        {
            bool b_Double_Dir = (index_Module == 1) ? true : false;
            this.panel_Dir2.Enabled = this.panel_Dir2.Visible = b_Double_Dir;
            this.button_LoadBatchImages2.Enabled = this.button_LoadBatchImages2.Visible = b_Double_Dir;

            if (index_Module == 0) // Single_Dir
            {
                this.panel_DispImage.Width = this.Width - 220 - this.panel_BatchImages.Width;
            }
            else if (index_Module == 1) // Double_Dir
            {
                this.panel_DispImage.Width = (this.Width - 220 - this.panel_BatchImages.Width) / 2;

                this.panel_Dir2.Top = this.panel_DispImage.Top;
                this.panel_Dir2.Left = this.panel_DispImage.Left + this.panel_DispImage.Width + 5;
                this.panel_Dir2.Width = this.panel_DispImage.Width;
                this.panel_Dir2.Height = this.panel_DispImage.Height;

                this.pictureBox_Dir2.Width = this.panel_Dir2.Width;
                this.pictureBox_Dir2.Height = this.panel_Dir2.Height;

                this.button_LoadBatchImages2.Top = this.panel_Info.Top;
                this.button_LoadBatchImages2.Left = this.panel_BatchImages.Left - this.button_LoadBatchImages2.Width - 5;
            }

            this.pictureBox_ImageShowForm.Width = this.panel_DispImage.Width;
            this.pictureBox_ImageShowForm.Height = this.panel_DispImage.Height;

            // 取得初始 pictureBox_ImageShowForm 資訊
            this.Initial_pictureBox1Width = this.pictureBox_ImageShowForm.Width;
            this.Initial_pictureBox1Height = this.pictureBox_ImageShowForm.Height;

            this.LoadImage_bmp = new Bitmap(this.Initial_pictureBox1Width, this.Initial_pictureBox1Height);
            this.pictureBox_ImageShowForm.Image = this.LoadImage_bmp;
        }

        /// <summary>
        /// 更新【顏色快捷列表】
        /// </summary>
        private void Update_Dynamic_radioButton()
        {
            this.panel_ColorList.Controls.Clear();

            //Point loc_1st = new Point(5, 20);
            Point loc_1st = new Point(3, 0);
            int dx = 40, dy = 40;
            int row = 5, col = 4;
            for (int index = 0; index < this.saveSetting.ColorList.Count; index++)
            {
                int x = 0, y = 0;
                y = index / col;
                x = index - y * col;

                // RadioButton 宣告及屬性設定
                RadioButton rbt = new RadioButton();
                rbt.Appearance = System.Windows.Forms.Appearance.Button;
                rbt.AutoSize = true;
                rbt.BackColor = this.saveSetting.ColorList[index];
                rbt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                rbt.Font = new System.Drawing.Font("微軟正黑體", 14.25F);
                rbt.Location = new System.Drawing.Point(loc_1st.X + dx * x, loc_1st.Y + dy * y);
                rbt.Name = "Dynamic_radioButton_" + index.ToString();
                rbt.Size = new System.Drawing.Size(35, 34);
                rbt.Text = "   ";
                rbt.UseVisualStyleBackColor = false;
                rbt.Click += (sender1, ex) => this.Dynamic_radioButton_Click(sender1, ex);

                this.panel_ColorList.Controls.Add(rbt);
            }
        }

        /// <summary>
        /// 【顏色快捷列表】 Click事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dynamic_radioButton_Click(object sender, EventArgs e)
        {
            if (this.rbt_SetColor.Checked) // 【標註顏色】
                this.button_SetColor.BackColor = (sender as RadioButton).BackColor;
            else // 【轉換顏色】
                this.button_Color_changed.BackColor = (sender as RadioButton).BackColor;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 判斷是否已儲存
            if (LabelImage.b_saved == false)
            {
                if (LabelImage.UnSaved_ProceedAnyway() == false)
                    e.Cancel = true;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.saveSetting.B_External_Open)
            {
                this.saveSetting.B_External_Open = false;
                this.saveSetting.Save();
            }
        }

        private void pictureBox_ImageShowForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.radioButton_DrawImg.CheckedChanged -= new System.EventHandler(this.radioButton_CheckedChanged);
                radioButton_DrawImg.Checked = true;
                this.radioButton_DrawImg.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
                Switch_button_dispImg();

                isMouseDown = true; // 滑鼠被按下後設定旗標值。

                Point p_Image = CoordinateTrans_Cursor2Image(e.Location, LoadImage_bmp); // 滑鼠游標座標轉換為影像座標
                //points.Add(p_Image); // 將點加入到 points 陣列當中。
                //ListPen.Add(new Pen(button_SetColor.BackColor, trackBar_width.Value));
                LabelImage.points.Add(p_Image);
                cls_LabelImage.cls_DrawTypeInfo drawTypeInfo = new cls_LabelImage.cls_DrawTypeInfo();
                drawTypeInfo.cls_DrawTypeInfo_Constructor(drawType, button_SetColor.BackColor, trackBar_width.Value);
                LabelImage.drawTypeInfo.Add(drawTypeInfo);

                /*
                float w = ListPen[points.Count - 1].Width;
                // 影像座標上的寬 轉為 繪圖區的寬
                int index = int.Parse(trackBar_zoom.Value.ToString());
                w = (float)(w * ZoomRatios[index] / 100);

                //g.DrawRectangle(new Pen(button_SetColor.BackColor, w), e.X - w / 2, e.Y - w / 2, w, w);
                g.FillRectangle(new SolidBrush(button_SetColor.BackColor), e.X - w / 2, e.Y - w / 2, w, w);
                */
                pictureBox_ImageShowForm.Invalidate();
            }
        }

        private void pictureBox_ImageShowForm_MouseMove(object sender, MouseEventArgs e)
        {
            Point p_Image = CoordinateTrans_Cursor2Image(e.Location, LoadImage_bmp); // 滑鼠游標座標轉換為影像座標

            if (isMouseDown) // 如果滑鼠被按下
            {
                //points.Add(p_Image); // 將點加入到 points 陣列當中。
                //ListPen.Add(new Pen(button_SetColor.BackColor, trackBar_width.Value));
                if (drawType == DrawType.penPoint || drawType == DrawType.eraser)
                {
                    this.LabelImage.points.Add(p_Image);
                    cls_LabelImage.cls_DrawTypeInfo drawTypeInfo = new cls_LabelImage.cls_DrawTypeInfo();
                    drawTypeInfo.cls_DrawTypeInfo_Constructor(drawType, button_SetColor.BackColor, trackBar_width.Value);
                    this.LabelImage.drawTypeInfo.Add(drawTypeInfo);
                }
                else
                {
                    int index = this.LabelImage.points.Count - 1;
                    this.LabelImage.drawTypeInfo[index].SetParam(this.LabelImage.points[index], p_Image);
                }

                /*
                float w = ListPen[points.Count - 1].Width;
                // 影像座標上的寬 轉為 繪圖區的寬
                int index = int.Parse(trackBar_zoom.Value.ToString());
                w = (float)(w * ZoomRatios[index] / 100);

                //g.DrawRectangle(new Pen(button_SetColor.BackColor, w), e.X - w / 2, e.Y - w / 2, w, w);
                g.FillRectangle(new SolidBrush(button_SetColor.BackColor), e.X - w / 2, e.Y - w / 2, w, w);
                */
                pictureBox_ImageShowForm.Invalidate();
                //pictureBox_ImageShowForm.Refresh();
            }

            #region 顯示資訊

            // 顯示滑鼠游標座標資訊
            //label_Coordinate.Text = "(" + String.Format("{0:0}", e.X) + ", " + String.Format("{0:0}", e.Y) + ")";
            // 顯示影像座標
            label_Coordinate.Text = "(" + String.Format("{0:0}", p_Image.X) + ", " + String.Format("{0:0}", p_Image.Y) + ")";
            label_Coordinate_Cursor.Text = "(" + String.Format("{0:0}", Cursor.Position.X) + ", " + String.Format("{0:0}", Cursor.Position.Y) + ")";

            // 顯示【[R, G, B]:】及【灰階值:】
            if (LoadImage_bmp != null && p_Image.X >= 0 && p_Image.X < LoadImage_bmp.Width && p_Image.Y >= 0 && p_Image.Y < LoadImage_bmp.Height)
            {
                Color c = LoadImage_bmp.GetPixel(p_Image.X, p_Image.Y);
                System.Drawing.Imaging.PixelFormat Format = LoadImage_bmp.PixelFormat;
                if (Format == System.Drawing.Imaging.PixelFormat.Format8bppIndexed) // 灰階影像
                {
                    txt_GrayValue.Text = c.R.ToString();
                    txt_RGBValue.Text = "";
                }
                else
                {
                    txt_RGBValue.Text = "[" + c.R + ", " + c.G + ", " + c.B + "]";
                    txt_GrayValue.Text = "";
                }
            }
            else
            {
                txt_RGBValue.Text = "";
                txt_GrayValue.Text = "";
            }

            #endregion
        }

        private void pictureBox_ImageShowForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                isMouseDown = false; // 滑鼠已經沒有被按下了。
                //points.Add(new Point(-1, -1)); // 滑鼠放開時，插入一個斷點 (-1,-1)，以代表前後兩點之間有斷開。
                //ListPen.Add(new Pen(button_SetColor.BackColor, trackBar_width.Value));

                this.LabelImage.Add_1_BreakPoint();
                this.Update_cbx_LabelledColor();

                pictureBox_ImageShowForm.Invalidate();
            }
        }

        private void pictureBox_ImageShowForm_DoubleClick(object sender, EventArgs e)
        {
            trackBar_zoom.Value = 3;
        }

        private void pictureBox_ImageShowForm_MouseWheel(object sender, MouseEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control)
            {
                pictureBox_ImageShowForm.Cursor = Cursors.SizeAll; // 改變游標類型
                b_MouseEvent = true;
                if (e.Delta < 0)
                {
                    //button_zoomIn_Click(null, null); // 放大
                    button_zoomOut_Click(null, null); // 缩小
                }
                else if (e.Delta > 0)
                {
                    //button_zoomOut_Click(null, null); // 缩小
                    button_zoomIn_Click(null, null); // 放大
                }
            }
        }

        private void panel_DispImage_MouseWheel(object sender, MouseEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control)
            {
                panel_DispImage.Cursor = Cursors.SizeAll; // 改變游標類型
                b_MouseEvent = true;
                if (e.Delta < 0)
                {
                    //button_zoomIn_Click(null, null); // 放大
                    button_zoomOut_Click(null, null); // 缩小
                }
                else if (e.Delta > 0)
                {
                    //button_zoomOut_Click(null, null); // 缩小
                    button_zoomIn_Click(null, null); // 放大
                }
            }
        }

        private void panel_DispImage_MouseHover(object sender, EventArgs e)
        {
            if (this.b_MouseEvent)
            {
                this.b_MouseEvent = false;
                panel_DispImage.Cursor = Cursors.Default;
            }
        }

        private bool b_MouseEvent { get; set; } = false;
        /// <summary>
        /// 發生於滑鼠指標停留在控制項上一段時間時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox_ImageShowForm_MouseHover(object sender, EventArgs e)
        {
            if (this.b_MouseEvent)
            {
                this.b_MouseEvent = false;
                UpdateCursor(pictureBox_ImageShowForm);
            }
        }

        /// <summary>
        /// 滑鼠游標座標轉換為影像座標
        /// Note: PictureBox 的 SizeMode 必須為 StretchImage
        /// </summary>
        /// <param name="p_Cursor"></param>
        /// <param name="bmp"></param>
        /// <returns></returns>
        private Point CoordinateTrans_Cursor2Image(Point p_Cursor, Bitmap bmp)
        {
            Point p_Image = new Point(-1, -1);

            if (bmp != null)
            {
                // 法1
                p_Image.X = (int)(((double)p_Cursor.X / pictureBox_ImageShowForm.Width) * bmp.Width + 0.5);
                p_Image.Y = (int)(((double)p_Cursor.Y / pictureBox_ImageShowForm.Height) * bmp.Height + 0.5);

                // 法2
                //int index = int.Parse(trackBar_zoom.Value.ToString());
                //p_Image.X = (int)(p_Cursor.X / (ZoomRatios[index] * 0.01) + 0.5);
                //p_Image.Y = (int)(p_Cursor.Y / (ZoomRatios[index] * 0.01) + 0.5);
            }

            return p_Image;
        }

        private Bitmap LoadImage_bmp = null;
        /// <summary>
        /// 【載入影像】
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoadImg_Click(object sender, EventArgs e)
        {
            // 判斷是否已儲存
            if (LabelImage.b_saved == false)
            {
                if (LabelImage.UnSaved_ProceedAnyway() == false)
                    return;
            }

            OpenFileDialog OpenImgDilg = new OpenFileDialog();
            //OpenImgDilg.Filter = "TIFF Image|*.tif|JPeg Image|*.jpg|PNG Image|*.png|Bitmap Image|*.bmp";
            if (OpenImgDilg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            string path = OpenImgDilg.FileName;
            this.path_Images.Clear();
            this.path_Images.Add(path);
            this.index_Image = 0;

            this.List_Batch_ChangeColor = new List<cls_Batch_ChangeColor>();
            for (int i = 0; i < this.path_Images.Count; i++)
                this.List_Batch_ChangeColor.Add(new cls_Batch_ChangeColor());

            this.Load_1_Img(path);

            this.Update_listViewImages();
        }

        /// <summary>
        /// 【批次載入】
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_LoadBatchImages_Click(object sender, EventArgs e)
        {
            if (sender != null)
            {
                // 判斷是否已儲存
                if (LabelImage.b_saved == false)
                {
                    if (LabelImage.UnSaved_ProceedAnyway() == false)
                        return;
                }

                #if Use_FolderBrowserDialog_NewType
                    FolderBrowserDialog_New Dilg = new FolderBrowserDialog_New();
                    Dilg.DirectoryPath = this.folder_LoadBatch; // 初始路徑
                    if (Dilg.ShowDialog(this) != DialogResult.OK)
                        return;
                    this.folder_LoadBatch = Dilg.DirectoryPath;
                #else
                    FolderBrowserDialog Dilg = new FolderBrowserDialog();
                    Dilg.SelectedPath = this.folder_LoadBatch; // 初始路徑
                    if (Dilg.ShowDialog() != DialogResult.OK)
                        return;
                    this.folder_LoadBatch = Dilg.SelectedPath;
                #endif
            }
            else if (this.saveSetting.B_External_Open)
            {
                if (Directory.Exists(this.saveSetting.Extra_dirX))
                    this.folder_LoadBatch = this.saveSetting.Extra_dirX;
                else
                {
                    SystemSounds.Exclamation.Play();
                    MessageBox.Show("【批次載入】路徑不存在!", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (string.IsNullOrEmpty(this.folder_LoadBatch))
            {
                SystemSounds.Exclamation.Play();
                MessageBox.Show("路徑無效!", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.folder_LoadBatch = "";
                return;
            }

            this.path_Images.Clear();
            //path_Images = Directory.GetFiles(folder_LoadBatch, "*.*", SearchOption.TopDirectoryOnly).Where(f => f.ToLower().EndsWith("bmp") || f.ToLower().EndsWith("jpg") || f.ToLower().EndsWith("png") || f.ToLower().EndsWith("tif")).ToList();

            if (this.saveSetting.B_Load_AllImageFormat) // 載入所有類型影像檔案格式
                this.path_Images = Directory.GetFiles(this.folder_LoadBatch, "*.*", SearchOption.TopDirectoryOnly).Where(f => this.Path_IsImageFormat(f)).ToList();
            else
                this.path_Images = Directory.GetFiles(this.folder_LoadBatch, "*.*", SearchOption.TopDirectoryOnly).Where(f => f.ToLower().EndsWith(this.saveSetting.ImageFormat_Load.ToString())).ToList();

            //path_Images = Directory.GetFiles(folder_LoadBatch, "*.*", SearchOption.AllDirectories).Where(f => f.ToLower().EndsWith(this.saveSetting.ImageFormat_Load.ToString())).ToList(); // 所有子資料夾下檔案

            this.List_Batch_ChangeColor = new List<cls_Batch_ChangeColor>();
            for (int i = 0; i < this.path_Images.Count; i++)
                this.List_Batch_ChangeColor.Add(new cls_Batch_ChangeColor());

            this.index_Image = 0;
            if (this.path_Images.Count > 0)
            {
                //this.Load_1_Img(this.path_Images[this.index_Image]);
                if (this.InvokeRequired)
                    this.BeginInvoke(new Action(() => this.Load_1_Img(this.path_Images[this.index_Image])));
                else
                    this.Load_1_Img(this.path_Images[this.index_Image]);
            }

            //this.Update_listViewImages();
            if (this.InvokeRequired)
                this.BeginInvoke(new Action(() => this.Update_listViewImages()));
            else
                this.Update_listViewImages();
        }

        /// <summary>
        /// 【批次載入2】
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_LoadBatchImages2_Click(object sender, EventArgs e)
        {
            #if Use_FolderBrowserDialog_NewType
                FolderBrowserDialog_New Dilg = new FolderBrowserDialog_New();
                Dilg.DirectoryPath = this.saveSetting.Folder_LoadBatch2; // 初始路徑
                if (Dilg.ShowDialog(this) != DialogResult.OK)
                    return;
                this.saveSetting.Folder_LoadBatch2 = Dilg.DirectoryPath;
            #else
                FolderBrowserDialog Dilg = new FolderBrowserDialog();
                Dilg.SelectedPath = this.saveSetting.Folder_LoadBatch2; // 初始路徑
                if (Dilg.ShowDialog() != DialogResult.OK)
                    return;
                this.saveSetting.Folder_LoadBatch2 = Dilg.SelectedPath;
            #endif

            this.Load_Image2();
        }

        /// <summary>
        /// 判斷檔案路徑是否為影像檔
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool Path_IsImageFormat(string path)
        {
            bool b_status_ = false;
            foreach (string f in Enum.GetNames(typeof(enu_ImageFormat)))
            {
                if (path.ToLower().EndsWith(f))
                {
                    b_status_ = true;
                    break;
                }
            }
            return b_status_;
        }

        /// <summary>
        /// 取出檔案路徑之名稱 (含 或 不含 副檔名)
        /// </summary>
        /// <param name="path">檔案路徑</param>
        /// <param name="b_extension">是否包含副檔名</param>
        /// <returns></returns>
        public string GetImageName_FromPath(string path, bool b_extension = false)
        {
            int Method = 2;
            if (Method == 1)
            {
                int i1 = path.LastIndexOf("\\");
                if (b_extension)
                    return path.Substring(i1 + 1);
                else
                {
                    int i2 = path.LastIndexOf(".");
                    return path.Substring(i1 + 1, (i2 - 1) - i1);
                }
            }
            else
            {
                if (b_extension)
                    return Path.GetFileName(path);
                else
                    return Path.GetFileNameWithoutExtension(path);
            }
        }

        /// <summary>
        /// 取出檔案路徑之副檔名 (轉成 enu_ImageFormat類型)
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public enu_ImageFormat Get_enu_ImageFormat_FromPath(string path)
        {
            enu_ImageFormat imageFormat = enu_ImageFormat.bmp;
            string extension = Path.GetExtension(path).Substring(1);
            try
            {
                imageFormat = (enu_ImageFormat)Enum.Parse(typeof(enu_ImageFormat), extension);
            }
            catch
            { }
            return imageFormat;
        }

        /// <summary>
        /// 載入單張影像，並且顯示影像及其資訊
        /// </summary>
        /// <param name="path"></param>
        private void Load_1_Img(string path)
        {
            string imageName = this.GetImageName_FromPath(path);
            this.B_LabelXML_Exist = clsStaticTool.LoadXML(saveSetting.Folder_Save + "\\label\\" + imageName + ".xml", out LabelImage);
            this.List_Batch_ChangeColor[this.index_Image].B_LabelXML_Exist = this.B_LabelXML_Exist;
            this.List_Batch_ChangeColor[this.index_Image].B_FinishJudge_LabelXML_Exist = true;
            if (this.B_LabelXML_Exist)
            {
                this.radioButton_DrawImg.CheckedChanged -= new System.EventHandler(this.radioButton_CheckedChanged);
                radioButton_DrawImg.Checked = true;
                this.radioButton_DrawImg.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
                this.Switch_button_dispImg();
            }
            else
            {
                this.radioButton_OrigImg.CheckedChanged -= new System.EventHandler(this.radioButton_CheckedChanged);
                radioButton_OrigImg.Checked = true;
                this.radioButton_OrigImg.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
                this.Switch_button_dispImg();
                LabelImage = new cls_LabelImage();
                LabelImage.cls_LabelImage_Constructor(imageName, this.Get_enu_ImageFormat_FromPath(path));
            }
            this.LoadImage_bmp = new Bitmap(path);

            // 調整pictureBox大小以符合載入影像尺寸 (Note: SizeMode=StretchImage下要自行設定)
            //pictureBox_ImageShowForm.Width = LoadImage_bmp.Width;
            //pictureBox_ImageShowForm.Height = LoadImage_bmp.Height;
            this.Initial_pictureBox1Width = this.LoadImage_bmp.Width;
            this.Initial_pictureBox1Height = this.LoadImage_bmp.Height;
            this.pictureBox_ImageShowForm.Image = this.LoadImage_bmp;

            // 縮放倍率回到 100%
            //if (this.trackBar_zoom.Value != 3)
            //    this.trackBar_zoom.Value = 3;
            //else
            //    this.trackBar_zoom_ValueChanged(null, null);
            // 固定縮放倍率
            this.trackBar_zoom_ValueChanged(null, null);

            //g = Graphics.FromImage(LoadImage_bmp);
            //g = Graphics.FromImage(pictureBox_ImageShowForm.Image);

            this.Update_ImgInfo(path);
            this.Update_cbx_LabelledColor();

            // Double_Dir
            if (this.saveSetting.Index_Module == 1)
                this.Load_Image2();
        }

        /// <summary>
        /// 載入單張影像 (【批次載入2】)
        /// </summary>
        private void Load_Image2()
        {
            if (this.path_Images.Count == 0)
                return;

            try
            {
                string path = this.path_Images[this.index_Image];
                string imageName_ext = this.GetImageName_FromPath(path, true);
                string path_image2 = this.saveSetting.Folder_LoadBatch2 + "//" + imageName_ext;
                if (File.Exists(path_image2))
                {
                    Bitmap image2 = new Bitmap(path_image2);
                    this.pictureBox_Dir2.Image = image2;
                    //image2.Dispose(); // 會有例外狀況!
                }
                else
                {
                    this.pictureBox_Dir2.Image = null;
                    MessageBox.Show("【批次載入2】路徑資料夾不存在此影像", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                this.pictureBox_Dir2.Image = null;
                Trace.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        /// 更新 影像尺寸 & 影像大小
        /// </summary>
        /// <param name="path"></param>
        private void Update_ImgInfo(string path)
        {
            // 影像尺寸
            icon_ImageSize.Visible = true;
            label_Size.Visible = true;
            string str;
            if (Language == "Chinese")
                str = "像素";
            else
                str = "Pixel";
            label_Size.Text = LoadImage_bmp.Width.ToString() + " × " + LoadImage_bmp.Height.ToString() + str;
            // 影像大小
            icon_Memory.Visible = true;
            FileInfo F = new FileInfo(path);
            label_Memory.Visible = true;
            double kb = F.Length / Math.Pow(1024, 1);
            if (Language == "Chinese")
                str = "大小";
            else
                str = "Memory";
            if (kb < 1024)
                label_Memory.Text = str + ": " + kb.ToString("#0.0") + "KB";
            else
                label_Memory.Text = str + ": " + (F.Length / Math.Pow(1024, 2)).ToString("#0.0") + "MB";
        }

        private void Select_index_Image()
        {
            this.listViewImages.Items[index_Image].Focused = true;
            this.listViewImages.Items[index_Image].Selected = true;
            //this.listViewImages.Items[index_Image].BackColor = Color.Blue;
            this.listViewImages.Items[index_Image].EnsureVisible();
        }

        /// <summary>
        /// 【上一張】
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_PreviousImage_Click(object sender, EventArgs e)
        {
            if (index_Image == 0)
                return;

            // 判斷是否已儲存
            if (LabelImage.b_saved == false)
            {
                if (LabelImage.UnSaved_ProceedAnyway() == false)
                    return;
            }

            this.listViewImages.SelectedIndexChanged -= new System.EventHandler(this.listViewImages_SelectedIndexChanged);

            this.listViewImages.Items[index_Image].Selected = false;
            index_Image--;
            this.Load_1_Img(path_Images[index_Image]);

            Select_index_Image();

            this.listViewImages.SelectedIndexChanged += new System.EventHandler(this.listViewImages_SelectedIndexChanged);
        }

        /// <summary>
        /// 【下一張】
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_NextImage_Click(object sender, EventArgs e)
        {
            if (this.index_Image >= (path_Images.Count - 1))
                return;

            // 判斷是否已儲存
            if (LabelImage.b_saved == false)
            {
                if (LabelImage.UnSaved_ProceedAnyway() == false)
                    return;
            }

            this.listViewImages.SelectedIndexChanged -= new System.EventHandler(this.listViewImages_SelectedIndexChanged);

            // 消除目前選取狀態
            this.listViewImages.Items[this.index_Image].Selected = false;
            this.index_Image++;
            this.Load_1_Img(path_Images[this.index_Image]);

            this.Select_index_Image();

            this.listViewImages.SelectedIndexChanged += new System.EventHandler(this.listViewImages_SelectedIndexChanged);
        }

        /// <summary>
        /// 更新 listViewImages
        /// </summary>
        public void Update_listViewImages()
        {
            imageList.Images.Clear();

            this.listViewImages.BeginUpdate(); // 資料更新,UI暫時掛起,直到EndUpdate繪製控制元件,可以有效避免閃爍並大大提高載入速度
            this.listViewImages.Items.Clear();

            for (int i = 0; i < path_Images.Count; i++)
            {
                string path = path_Images[i];
                // 顯示影像檔名
                ListViewItem lvi = new ListViewItem(this.GetImageName_FromPath(path, true));
                // 顯示影像
                Bitmap img = new Bitmap(path);
                //img.MakeTransparent();
                imageList.Images.Add(img);
                lvi.ImageIndex = i;
                //lvi.Focused = true;

                this.listViewImages.Items.Add(lvi);
            }

            //this.listViewImages.CheckBoxes = true;
            this.listViewImages.EndUpdate(); // 結束資料處理,UI介面一次性繪製

            if (this.listViewImages.Items.Count > 0)
            {
                //this.listViewImages.Items[0].Checked = true;
                this.listViewImages.Items[0].Focused = true;
                this.listViewImages.SelectedIndexChanged -= new System.EventHandler(this.listViewImages_SelectedIndexChanged);
                this.listViewImages.Items[0].Selected = true;
                this.listViewImages.Items[0].EnsureVisible();
                this.listViewImages.SelectedIndexChanged += new System.EventHandler(this.listViewImages_SelectedIndexChanged);
            }
        }

        private void listViewImages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listViewImages.SelectedIndices.Count <= 0)
                return;

            // 判斷是否已儲存
            if (LabelImage.b_saved == false)
            {
                if (LabelImage.UnSaved_ProceedAnyway() == false)
                {
                    this.listViewImages.SelectedIndexChanged -= new System.EventHandler(this.listViewImages_SelectedIndexChanged);

                    // 消除目前選取狀態
                    this.listViewImages.Items[this.listViewImages.SelectedIndices[0]].Focused = false;
                    this.listViewImages.Items[this.listViewImages.SelectedIndices[0]].Selected = false;

                    // 復原影像選取狀態
                    Select_index_Image();

                    this.listViewImages.SelectedIndexChanged += new System.EventHandler(this.listViewImages_SelectedIndexChanged);

                    return;
                }
            }

            //this.listViewImages.Items[index_Image].Selected = false;
            index_Image = this.listViewImages.SelectedIndices[0];
            Load_1_Img(path_Images[index_Image]);

            //Select_index_Image();
        }

        /// <summary>
        /// 顯示影像切換
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rbtn = sender as RadioButton;
            if (rbtn.Checked == false) return;

            Switch_button_dispImg();

            pictureBox_ImageShowForm.Invalidate();
        }

        /// <summary>
        /// 切換 button_dispImg 顯示之文字及影像
        /// </summary>
        private void Switch_button_dispImg()
        {
            if (radioButton_OrigImg.Checked) // 【原圖】
            {
                //if (Language == "Chinese")
                //    button_dispImg.Text = "原圖";
                //else
                //    button_dispImg.Text = "OrigImg";
                button_dispImg.Text = radioButton_OrigImg.Text;

                this.button_dispImg.Image = global::Painter2.Properties.Resources.原圖_24;
            }
            else //【標註影像】
            {
                //button_dispImg.Text = "標註影像";
                button_dispImg.Text = radioButton_DrawImg.Text;

                this.button_dispImg.Image = global::Painter2.Properties.Resources.標註影像_24;
            }
        }

        /// <summary>
        /// 顯示【原圖】/【標註影像】切換
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_dispImg_Click(object sender, EventArgs e)
        {
            if (radioButton_OrigImg.Checked)
                radioButton_DrawImg.Checked = true;
            else
                radioButton_OrigImg.Checked = true;
        }

        /// <summary>
        /// 【調整顯示透明度】啟用切換
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox_Alpha_CheckedChanged(object sender, EventArgs e)
        {
            this.nud_Alpha.Enabled = this.checkBox_Alpha.Checked;
            if (this.checkBox_Alpha.Checked == false)
            {
                this.nud_Alpha.ValueChanged -= new System.EventHandler(this.nud_Alpha_ValueChanged);
                this.nud_Alpha.Value = 255;
                this.nud_Alpha.ValueChanged += new System.EventHandler(this.nud_Alpha_ValueChanged);
            }
            pictureBox_ImageShowForm.Invalidate();
        }

        /// <summary>
        /// 【調整顯示透明度】數值更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nud_Alpha_ValueChanged(object sender, EventArgs e)
        {
            pictureBox_ImageShowForm.Invalidate();
        }

        /// <summary>
        /// 【游標類型】
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbx_Cursor_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCursor(pictureBox_ImageShowForm);
            //this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// 標註工具類型切換
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton_Tool_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rbtn = sender as RadioButton;
            if (rbtn.Checked == false) return;

            string tag = rbtn.Tag.ToString();
            this.drawType = (DrawType)(Enum.Parse(typeof(DrawType), tag));
        }

        private void pictureBox_ImageShowForm_Paint(object sender, PaintEventArgs e)
        {
            /*
            if (b_MouseEvent != true)
                g.Clear(System.Drawing.SystemColors.Control);
            */
            //this.pictureBox_ImageShowForm.Paint -= new System.Windows.Forms.PaintEventHandler(this.pictureBox_ImageShowForm_Paint);
            //pictureBox_ImageShowForm.Image = LoadImage_bmp;
            //this.pictureBox_ImageShowForm.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_ImageShowForm_Paint);

            g = e.Graphics;
            if (radioButton_DrawImg.Checked) // 標註影像
            {
                //Redraw_Label(g, (float)(ZoomRatios[int.Parse(trackBar_zoom.Value.ToString())] / 100));
                this.LabelImage.Redraw_Label(g, this.LoadImage_bmp, (float)(ZoomRatios[int.Parse(trackBar_zoom.Value.ToString())] / 100), false, this.isMouseDown, this.checkBox_Alpha.Checked, int.Parse(this.nud_Alpha.Value.ToString()));
            }
            g = pictureBox_ImageShowForm.CreateGraphics(); // 取得繪圖區物件
        }

        private void Redraw_Label(Graphics g_, float zoomRatio = 1)
        {
            //g_.Clear(System.Drawing.SystemColors.Control); // 清除標註

            /*
            for (int i = 0; i < points.Count - 1; i++)
            {
                if (points[i].X >= 0 && points[i + 1].X >= 0)
                    g_.DrawLine(ListPen[i + 1], points[i], points[i + 1]);
            }
            */
            /*
            for (int i = 0; i < points.Count; i++)
            {
                if (points[i].X >= 0)
                {
                    //g_.DrawRectangle(ListPen[i], new Rectangle(points[i], new Size(1, 1)));

                    float w = ListPen[i].Width;
                    // 影像座標上的寬 轉為 繪圖區的寬
                    w *= zoomRatio;
                    Pen p = new Pen(ListPen[i].Color, w);
                    //g_.DrawRectangle(p, points[i].X * zoomRatio - w / 2, points[i].Y * zoomRatio - w / 2, w, w);
                    g_.FillRectangle(new SolidBrush(ListPen[i].Color), points[i].X * zoomRatio - w / 2, points[i].Y * zoomRatio - w / 2, w, w);
                }
            }
            */