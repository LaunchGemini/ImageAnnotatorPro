
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