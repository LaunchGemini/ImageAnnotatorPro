
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
