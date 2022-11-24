
﻿namespace Painter2
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel_DispImage = new System.Windows.Forms.Panel();
            this.pictureBox_ImageShowForm = new System.Windows.Forms.PictureBox();
            this.pictureBox_Dir2 = new System.Windows.Forms.PictureBox();
            this.groupBox_ColorList = new System.Windows.Forms.GroupBox();
            this.rbt_Color_changed = new System.Windows.Forms.RadioButton();
            this.rbt_SetColor = new System.Windows.Forms.RadioButton();
            this.panel_ColorList = new System.Windows.Forms.Panel();
            this.button_ChangeColor = new System.Windows.Forms.Button();
            this.checkBox_ChangeColor_All = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbx_Cursor = new System.Windows.Forms.ComboBox();
            this.label_widthValue = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.trackBar_width = new System.Windows.Forms.TrackBar();
            this.label_width_Max = new System.Windows.Forms.Label();
            this.label_width_Min = new System.Windows.Forms.Label();
            this.button_SetColor = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.button_ClearAll = new System.Windows.Forms.Button();
            this.label_Coordinate = new System.Windows.Forms.Label();
            this.label_Coordinate_Cursor = new System.Windows.Forms.Label();
            this.colorDialog_SetColor = new System.Windows.Forms.ColorDialog();
            this.radioButton_OrigImg = new System.Windows.Forms.RadioButton();
            this.radioButton_DrawImg = new System.Windows.Forms.RadioButton();
            this.button_Clear = new System.Windows.Forms.Button();
            this.label_Size = new System.Windows.Forms.Label();
            this.label_Memory = new System.Windows.Forms.Label();
            this.txt_GrayValue = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txt_RGBValue = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.trackBar_zoom = new System.Windows.Forms.TrackBar();
            this.label_zoom = new System.Windows.Forms.Label();
            this.panel_Info = new System.Windows.Forms.Panel();
            this.icon_Memory = new System.Windows.Forms.Button();
            this.icon_ImageSize = new System.Windows.Forms.Button();
            this.button_zoomOut = new System.Windows.Forms.Button();
            this.icon_Coordinate = new System.Windows.Forms.Label();
            this.button_zoomIn = new System.Windows.Forms.Button();
            this.btnLoadImg = new System.Windows.Forms.Button();
            this.radioButton_penPoint = new System.Windows.Forms.RadioButton();
            this.radioButton_eraser = new System.Windows.Forms.RadioButton();
            this.panel_Tool = new System.Windows.Forms.Panel();
            this.radioButton_selectAnyShape = new System.Windows.Forms.RadioButton();
            this.radioButton_selectRect = new System.Windows.Forms.RadioButton();
            this.radioButton_ellipse_fill = new System.Windows.Forms.RadioButton();
            this.radioButton_ellipse = new System.Windows.Forms.RadioButton();
            this.radioButton_circle_fill = new System.Windows.Forms.RadioButton();
            this.radioButton_circle = new System.Windows.Forms.RadioButton();
            this.radioButton_rectangle_fill = new System.Windows.Forms.RadioButton();
            this.radioButton_rectangle = new System.Windows.Forms.RadioButton();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.listViewImages = new System.Windows.Forms.ListView();
            this.button_LoadBatchImages = new System.Windows.Forms.Button();
            this.button_Save = new System.Windows.Forms.Button();
            this.button_SavePath = new System.Windows.Forms.Button();
            this.button_NextImage = new System.Windows.Forms.Button();
            this.button_PreviousImage = new System.Windows.Forms.Button();
            this.button_Recovery = new System.Windows.Forms.Button();
            this.button_Redo = new System.Windows.Forms.Button();
            this.panel_BatchImages = new System.Windows.Forms.Panel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.檔案ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.結束ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.工具ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.儲存設定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.語言設定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.中文ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.英文ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.標註顏色批次轉換ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.說明ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.快捷鍵ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label_Version = new System.Windows.Forms.Label();
            this.button_dispImg = new System.Windows.Forms.Button();
            this.label_VersionNum = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbx_LabelledColor = new System.Windows.Forms.ComboBox();
            this.checkBox_Alpha = new System.Windows.Forms.CheckBox();
            this.nud_Alpha = new System.Windows.Forms.NumericUpDown();
            this.button_LoadBatchImages2 = new System.Windows.Forms.Button();
            this.panel_Dir2 = new System.Windows.Forms.Panel();
            this.button_Color_changed = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.panel_DispImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ImageShowForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Dir2)).BeginInit();
            this.groupBox_ColorList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_width)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_zoom)).BeginInit();
            this.panel_Info.SuspendLayout();
            this.panel_Tool.SuspendLayout();
            this.panel_BatchImages.SuspendLayout();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Alpha)).BeginInit();
            this.panel_Dir2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_DispImage
            // 
            this.panel_DispImage.AutoScroll = true;
            this.panel_DispImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_DispImage.Controls.Add(this.pictureBox_ImageShowForm);
            this.panel_DispImage.Location = new System.Drawing.Point(185, 25);
            this.panel_DispImage.Name = "panel_DispImage";
            this.panel_DispImage.Size = new System.Drawing.Size(880, 565);
            this.panel_DispImage.TabIndex = 2;
            this.panel_DispImage.MouseHover += new System.EventHandler(this.panel_DispImage_MouseHover);
            // 
            // pictureBox_ImageShowForm
            // 
            this.pictureBox_ImageShowForm.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pictureBox_ImageShowForm.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_ImageShowForm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox_ImageShowForm.Name = "pictureBox_ImageShowForm";
            this.pictureBox_ImageShowForm.Size = new System.Drawing.Size(880, 565);
            this.pictureBox_ImageShowForm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_ImageShowForm.TabIndex = 1;
            this.pictureBox_ImageShowForm.TabStop = false;
            this.pictureBox_ImageShowForm.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_ImageShowForm_Paint);
            this.pictureBox_ImageShowForm.DoubleClick += new System.EventHandler(this.pictureBox_ImageShowForm_DoubleClick);
            this.pictureBox_ImageShowForm.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_ImageShowForm_MouseDown);
            this.pictureBox_ImageShowForm.MouseHover += new System.EventHandler(this.pictureBox_ImageShowForm_MouseHover);
            this.pictureBox_ImageShowForm.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_ImageShowForm_MouseMove);
            this.pictureBox_ImageShowForm.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_ImageShowForm_MouseUp);
            // 
            // pictureBox_Dir2
            // 
            this.pictureBox_Dir2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pictureBox_Dir2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_Dir2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox_Dir2.Name = "pictureBox_Dir2";
            this.pictureBox_Dir2.Size = new System.Drawing.Size(200, 200);
            this.pictureBox_Dir2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Dir2.TabIndex = 2;
            this.pictureBox_Dir2.TabStop = false;
            // 
            // groupBox_ColorList
            // 
            this.groupBox_ColorList.Controls.Add(this.rbt_Color_changed);
            this.groupBox_ColorList.Controls.Add(this.rbt_SetColor);
            this.groupBox_ColorList.Controls.Add(this.panel_ColorList);
            this.groupBox_ColorList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.groupBox_ColorList.Location = new System.Drawing.Point(7, 666);
            this.groupBox_ColorList.Name = "groupBox_ColorList";
            this.groupBox_ColorList.Size = new System.Drawing.Size(165, 245);
            this.groupBox_ColorList.TabIndex = 3;
            this.groupBox_ColorList.TabStop = false;
            this.groupBox_ColorList.Text = "顏色快捷列表";
            this.groupBox_ColorList.Visible = false;
            // 
            // rbt_Color_changed
            // 
            this.rbt_Color_changed.AutoSize = true;
            this.rbt_Color_changed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.rbt_Color_changed.ForeColor = System.Drawing.Color.Black;
            this.rbt_Color_changed.Location = new System.Drawing.Point(60, 20);
            this.rbt_Color_changed.Name = "rbt_Color_changed";
            this.rbt_Color_changed.Size = new System.Drawing.Size(49, 17);
            this.rbt_Color_changed.TabIndex = 248;
            this.rbt_Color_changed.Text = "轉換";
            this.rbt_Color_changed.UseVisualStyleBackColor = true;
            // 
            // rbt_SetColor
            // 
            this.rbt_SetColor.AutoSize = true;
            this.rbt_SetColor.Checked = true;
            this.rbt_SetColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.rbt_SetColor.ForeColor = System.Drawing.Color.Black;
            this.rbt_SetColor.Location = new System.Drawing.Point(10, 20);
            this.rbt_SetColor.Name = "rbt_SetColor";
            this.rbt_SetColor.Size = new System.Drawing.Size(49, 17);
            this.rbt_SetColor.TabIndex = 247;
            this.rbt_SetColor.TabStop = true;
            this.rbt_SetColor.Text = "標註";
            this.rbt_SetColor.UseVisualStyleBackColor = true;
            // 
            // panel_ColorList
            // 
            this.panel_ColorList.Location = new System.Drawing.Point(2, 45);
            this.panel_ColorList.Name = "panel_ColorList";
            this.panel_ColorList.Size = new System.Drawing.Size(161, 194);
            this.panel_ColorList.TabIndex = 0;
            // 
            // button_ChangeColor
            // 
            this.button_ChangeColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_ChangeColor.Location = new System.Drawing.Point(97, 409);
            this.button_ChangeColor.Name = "button_ChangeColor";
            this.button_ChangeColor.Size = new System.Drawing.Size(78, 47);
            this.button_ChangeColor.TabIndex = 193;
            this.button_ChangeColor.Text = "標註顏色轉換";
            this.button_ChangeColor.UseVisualStyleBackColor = true;
            this.button_ChangeColor.Click += new System.EventHandler(this.button_ChangeColor_Click);
            // 
            // checkBox_ChangeColor_All
            // 
            this.checkBox_ChangeColor_All.AutoSize = true;
            this.checkBox_ChangeColor_All.Location = new System.Drawing.Point(101, 457);
            this.checkBox_ChangeColor_All.Name = "checkBox_ChangeColor_All";
            this.checkBox_ChangeColor_All.Size = new System.Drawing.Size(74, 17);
            this.checkBox_ChangeColor_All.TabIndex = 192;
            this.checkBox_ChangeColor_All.Text = "所有顏色";
            this.checkBox_ChangeColor_All.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 16);
            this.label2.TabIndex = 191;
            this.label2.Text = "游標類型";
            // 
            // cbx_Cursor
            // 
            this.cbx_Cursor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_Cursor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_Cursor.FormattingEnabled = true;
            this.cbx_Cursor.Location = new System.Drawing.Point(3, 190);
            this.cbx_Cursor.Name = "cbx_Cursor";
            this.cbx_Cursor.Size = new System.Drawing.Size(100, 21);
            this.cbx_Cursor.TabIndex = 190;
            this.cbx_Cursor.SelectedIndexChanged += new System.EventHandler(this.cbx_Cursor_SelectedIndexChanged);
            // 
            // label_widthValue
            // 
            this.label_widthValue.AutoSize = true;
            this.label_widthValue.BackColor = System.Drawing.Color.Transparent;
            this.label_widthValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_widthValue.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label_widthValue.Location = new System.Drawing.Point(155, 275);
            this.label_widthValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_widthValue.Name = "label_widthValue";
            this.label_widthValue.Size = new System.Drawing.Size(13, 13);
            this.label_widthValue.TabIndex = 189;
            this.label_widthValue.Text = "3";
            this.label_widthValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(125, 181);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 16);
            this.label1.TabIndex = 186;
            this.label1.Text = "線寬";
            // 
            // trackBar_width
            // 
            this.trackBar_width.Location = new System.Drawing.Point(134, 192);
            this.trackBar_width.Maximum = 200;
            this.trackBar_width.Minimum = 1;
            this.trackBar_width.Name = "trackBar_width";
            this.trackBar_width.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar_width.Size = new System.Drawing.Size(45, 104);
            this.trackBar_width.TabIndex = 185;
            this.trackBar_width.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_width.Value = 3;
            this.trackBar_width.Scroll += new System.EventHandler(this.trackBar_width_Scroll);
            // 
            // label_width_Max
            // 
            this.label_width_Max.AutoSize = true;
            this.label_width_Max.BackColor = System.Drawing.Color.Transparent;
            this.label_width_Max.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_width_Max.ForeColor = System.Drawing.Color.Black;
            this.label_width_Max.Location = new System.Drawing.Point(109, 199);
            this.label_width_Max.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_width_Max.Name = "label_width_Max";
            this.label_width_Max.Size = new System.Drawing.Size(25, 13);
            this.label_width_Max.TabIndex = 188;
            this.label_width_Max.Text = "200";
            this.label_width_Max.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_width_Min
            // 
            this.label_width_Min.AutoSize = true;
            this.label_width_Min.BackColor = System.Drawing.Color.Transparent;
            this.label_width_Min.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_width_Min.ForeColor = System.Drawing.Color.Black;
            this.label_width_Min.Location = new System.Drawing.Point(119, 276);
            this.label_width_Min.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_width_Min.Name = "label_width_Min";
            this.label_width_Min.Size = new System.Drawing.Size(13, 13);
            this.label_width_Min.TabIndex = 187;
            this.label_width_Min.Text = "1";
            this.label_width_Min.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_SetColor
            // 
            this.button_SetColor.BackColor = System.Drawing.Color.Black;
            this.button_SetColor.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_SetColor.ForeColor = System.Drawing.Color.Transparent;
            this.button_SetColor.Location = new System.Drawing.Point(115, 366);
            this.button_SetColor.Name = "button_SetColor";
            this.button_SetColor.Size = new System.Drawing.Size(40, 40);
            this.button_SetColor.TabIndex = 184;
            this.button_SetColor.UseVisualStyleBackColor = false;
            this.button_SetColor.BackColorChanged += new System.EventHandler(this.button_SetColor_BackColorChanged);
            this.button_SetColor.Click += new System.EventHandler(this.button_SetColor_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(102, 347);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 16);
            this.label4.TabIndex = 183;
            this.label4.Text = "標註顏色";
            // 
            // button_ClearAll
            // 
            this.button_ClearAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_ClearAll.Location = new System.Drawing.Point(12, 450);
            this.button_ClearAll.Name = "button_ClearAll";
            this.button_ClearAll.Size = new System.Drawing.Size(68, 25);
            this.button_ClearAll.TabIndex = 182;
            this.button_ClearAll.Text = "清空";
            this.button_ClearAll.UseVisualStyleBackColor = true;
            this.button_ClearAll.Click += new System.EventHandler(this.button_ClearAll_Click);
            // 
            // label_Coordinate
            // 
            this.label_Coordinate.AutoSize = true;
            this.label_Coordinate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Coordinate.Location = new System.Drawing.Point(22, 5);
            this.label_Coordinate.Name = "label_Coordinate";
            this.label_Coordinate.Size = new System.Drawing.Size(73, 20);
            this.label_Coordinate.TabIndex = 195;
            this.label_Coordinate.Text = "像素座標";
            // 
            // label_Coordinate_Cursor
            // 
            this.label_Coordinate_Cursor.AutoSize = true;
            this.label_Coordinate_Cursor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Coordinate_Cursor.Location = new System.Drawing.Point(23, 29);
            this.label_Coordinate_Cursor.Name = "label_Coordinate_Cursor";
            this.label_Coordinate_Cursor.Size = new System.Drawing.Size(105, 20);
            this.label_Coordinate_Cursor.TabIndex = 196;
            this.label_Coordinate_Cursor.Text = "滑鼠游標座標";
            this.label_Coordinate_Cursor.Visible = false;
            // 
            // radioButton_OrigImg
            // 
            this.radioButton_OrigImg.AutoSize = true;
            this.radioButton_OrigImg.Checked = true;
            this.radioButton_OrigImg.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.radioButton_OrigImg.Location = new System.Drawing.Point(13, 98);
            this.radioButton_OrigImg.Name = "radioButton_OrigImg";
            this.radioButton_OrigImg.Size = new System.Drawing.Size(52, 21);
            this.radioButton_OrigImg.TabIndex = 197;
            this.radioButton_OrigImg.TabStop = true;
            this.radioButton_OrigImg.Text = "原圖";
            this.radioButton_OrigImg.UseVisualStyleBackColor = true;
            this.radioButton_OrigImg.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButton_DrawImg
            // 
            this.radioButton_DrawImg.AutoSize = true;
            this.radioButton_DrawImg.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.radioButton_DrawImg.Location = new System.Drawing.Point(13, 125);
            this.radioButton_DrawImg.Name = "radioButton_DrawImg";
            this.radioButton_DrawImg.Size = new System.Drawing.Size(78, 21);
            this.radioButton_DrawImg.TabIndex = 198;
            this.radioButton_DrawImg.TabStop = true;
            this.radioButton_DrawImg.Text = "標註影像";
            this.radioButton_DrawImg.UseVisualStyleBackColor = true;
            this.radioButton_DrawImg.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // button_Clear
            // 
            this.button_Clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Clear.Location = new System.Drawing.Point(12, 423);
            this.button_Clear.Name = "button_Clear";
            this.button_Clear.Size = new System.Drawing.Size(68, 25);
            this.button_Clear.TabIndex = 199;
            this.button_Clear.Text = "移除";
            this.button_Clear.UseVisualStyleBackColor = true;
            this.button_Clear.Click += new System.EventHandler(this.button_Clear_Click);
            // 
            // label_Size
            // 
            this.label_Size.AutoSize = true;
            this.label_Size.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Size.Location = new System.Drawing.Point(167, 5);
            this.label_Size.Name = "label_Size";
            this.label_Size.Size = new System.Drawing.Size(73, 20);
            this.label_Size.TabIndex = 200;
            this.label_Size.Text = "影像尺寸";
            this.label_Size.Visible = false;
            // 
            // label_Memory
            // 
            this.label_Memory.AutoSize = true;
            this.label_Memory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Memory.Location = new System.Drawing.Point(338, 5);
            this.label_Memory.Name = "label_Memory";
            this.label_Memory.Size = new System.Drawing.Size(73, 20);
            this.label_Memory.TabIndex = 201;
            this.label_Memory.Text = "影像大小";
            this.label_Memory.Visible = false;
            // 
            // txt_GrayValue
            // 
            this.txt_GrayValue.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txt_GrayValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_GrayValue.Location = new System.Drawing.Point(539, 33);
            this.txt_GrayValue.Name = "txt_GrayValue";
            this.txt_GrayValue.ReadOnly = true;
            this.txt_GrayValue.Size = new System.Drawing.Size(115, 27);
            this.txt_GrayValue.TabIndex = 226;
            this.txt_GrayValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label20.ForeColor = System.Drawing.Color.Black;
            this.label20.Location = new System.Drawing.Point(483, 36);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(57, 19);
            this.label20.TabIndex = 225;
            this.label20.Text = "灰階值:";
            // 
            // txt_RGBValue
            // 
            this.txt_RGBValue.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txt_RGBValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_RGBValue.Location = new System.Drawing.Point(539, 3);
            this.txt_RGBValue.Name = "txt_RGBValue";
            this.txt_RGBValue.ReadOnly = true;
            this.txt_RGBValue.Size = new System.Drawing.Size(115, 27);
            this.txt_RGBValue.TabIndex = 224;
            this.txt_RGBValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(474, 6);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(66, 19);
            this.label19.TabIndex = 223;
            this.label19.Text = "[R, G, B]:";
            // 
            // trackBar_zoom
            // 
            this.trackBar_zoom.LargeChange = 1;
            this.trackBar_zoom.Location = new System.Drawing.Point(741, 4);
            this.trackBar_zoom.Name = "trackBar_zoom";
            this.trackBar_zoom.Size = new System.Drawing.Size(104, 45);
            this.trackBar_zoom.TabIndex = 227;
            this.trackBar_zoom.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_zoom.Value = 3;
            this.trackBar_zoom.ValueChanged += new System.EventHandler(this.trackBar_zoom_ValueChanged);
            // 
            // label_zoom
            // 
            this.label_zoom.AutoSize = true;
            this.label_zoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_zoom.Location = new System.Drawing.Point(660, 5);
            this.label_zoom.Name = "label_zoom";
            this.label_zoom.Size = new System.Drawing.Size(54, 20);
            this.label_zoom.TabIndex = 231;
            this.label_zoom.Text = " 100%";
            // 
            // panel_Info
            // 
            this.panel_Info.BackColor = System.Drawing.SystemColors.Window;
            this.panel_Info.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Info.Controls.Add(this.icon_Memory);
            this.panel_Info.Controls.Add(this.icon_ImageSize);
            this.panel_Info.Controls.Add(this.button_zoomOut);
            this.panel_Info.Controls.Add(this.icon_Coordinate);
            this.panel_Info.Controls.Add(this.txt_RGBValue);
            this.panel_Info.Controls.Add(this.label_Coordinate);
            this.panel_Info.Controls.Add(this.label_zoom);
            this.panel_Info.Controls.Add(this.label_Coordinate_Cursor);
            this.panel_Info.Controls.Add(this.label_Size);
            this.panel_Info.Controls.Add(this.button_zoomIn);
            this.panel_Info.Controls.Add(this.label_Memory);
            this.panel_Info.Controls.Add(this.trackBar_zoom);
            this.panel_Info.Controls.Add(this.label19);
            this.panel_Info.Controls.Add(this.txt_GrayValue);
            this.panel_Info.Controls.Add(this.label20);
            this.panel_Info.Location = new System.Drawing.Point(185, 950);
            this.panel_Info.Name = "panel_Info";
            this.panel_Info.Size = new System.Drawing.Size(880, 65);
            this.panel_Info.TabIndex = 232;
            // 
            // icon_Memory
            // 
            this.icon_Memory.BackgroundImage = global::Painter2.Properties.Resources.FileSize;
            this.icon_Memory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.icon_Memory.FlatAppearance.BorderSize = 0;
            this.icon_Memory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.icon_Memory.Location = new System.Drawing.Point(317, 6);
            this.icon_Memory.Name = "icon_Memory";
            this.icon_Memory.Size = new System.Drawing.Size(20, 20);
            this.icon_Memory.TabIndex = 235;
            this.icon_Memory.UseVisualStyleBackColor = true;
            this.icon_Memory.Visible = false;
            // 
            // icon_ImageSize
            // 
            this.icon_ImageSize.BackgroundImage = global::Painter2.Properties.Resources.ImageSize;
            this.icon_ImageSize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.icon_ImageSize.FlatAppearance.BorderSize = 0;
            this.icon_ImageSize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.icon_ImageSize.Location = new System.Drawing.Point(146, 6);
            this.icon_ImageSize.Name = "icon_ImageSize";
            this.icon_ImageSize.Size = new System.Drawing.Size(20, 20);
            this.icon_ImageSize.TabIndex = 234;
            this.icon_ImageSize.UseVisualStyleBackColor = true;
            this.icon_ImageSize.Visible = false;
            // 
            // button_zoomOut
            // 
            this.button_zoomOut.BackgroundImage = global::Painter2.Properties.Resources.minus2;
            this.button_zoomOut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_zoomOut.FlatAppearance.BorderSize = 0;
            this.button_zoomOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_zoomOut.Location = new System.Drawing.Point(718, 5);
            this.button_zoomOut.Name = "button_zoomOut";
            this.button_zoomOut.Size = new System.Drawing.Size(20, 20);
            this.button_zoomOut.TabIndex = 230;
            this.button_zoomOut.UseVisualStyleBackColor = true;
            this.button_zoomOut.Click += new System.EventHandler(this.button_zoomOut_Click);
            // 
            // icon_Coordinate
            // 
            this.icon_Coordinate.AutoSize = true;
            this.icon_Coordinate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icon_Coordinate.Image = global::Painter2.Properties.Resources.CursorLocation2;
            this.icon_Coordinate.Location = new System.Drawing.Point(2, 6);
            this.icon_Coordinate.Name = "icon_Coordinate";
            this.icon_Coordinate.Size = new System.Drawing.Size(21, 20);
            this.icon_Coordinate.TabIndex = 233;
            this.icon_Coordinate.Text = "   ";
            // 
            // button_zoomIn
            // 
            this.button_zoomIn.BackgroundImage = global::Painter2.Properties.Resources.plus2;
            this.button_zoomIn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_zoomIn.FlatAppearance.BorderSize = 0;
            this.button_zoomIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_zoomIn.Location = new System.Drawing.Point(849, 5);
            this.button_zoomIn.Name = "button_zoomIn";
            this.button_zoomIn.Size = new System.Drawing.Size(20, 20);
            this.button_zoomIn.TabIndex = 229;
            this.button_zoomIn.UseVisualStyleBackColor = true;
            this.button_zoomIn.Click += new System.EventHandler(this.button_zoomIn_Click);
            // 
            // btnLoadImg
            // 
            this.btnLoadImg.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLoadImg.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnLoadImg.Image = global::Painter2.Properties.Resources.picture32;
            this.btnLoadImg.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLoadImg.Location = new System.Drawing.Point(7, 25);
            this.btnLoadImg.Margin = new System.Windows.Forms.Padding(2);
            this.btnLoadImg.Name = "btnLoadImg";
            this.btnLoadImg.Size = new System.Drawing.Size(75, 63);
            this.btnLoadImg.TabIndex = 75;
            this.btnLoadImg.Text = "載入影像";
            this.btnLoadImg.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLoadImg.UseVisualStyleBackColor = true;
            this.btnLoadImg.Click += new System.EventHandler(this.btnLoadImg_Click);
            // 
            // radioButton_penPoint
            // 
            this.radioButton_penPoint.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton_penPoint.AutoSize = true;
            this.radioButton_penPoint.BackgroundImage = global::Painter2.Properties.Resources.Pen;
            this.radioButton_penPoint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.radioButton_penPoint.Checked = true;
            this.radioButton_penPoint.Font = new System.Drawing.Font("微軟正黑體", 14.25F);
            this.radioButton_penPoint.Location = new System.Drawing.Point(5, 5);
            this.radioButton_penPoint.Name = "radioButton_penPoint";
            this.radioButton_penPoint.Size = new System.Drawing.Size(35, 34);
            this.radioButton_penPoint.TabIndex = 234;
            this.radioButton_penPoint.TabStop = true;
            this.radioButton_penPoint.Tag = "penPoint";
            this.radioButton_penPoint.Text = "   ";
            this.radioButton_penPoint.UseVisualStyleBackColor = true;
            this.radioButton_penPoint.CheckedChanged += new System.EventHandler(this.radioButton_Tool_CheckedChanged);
            // 
            // radioButton_eraser
            // 
            this.radioButton_eraser.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton_eraser.AutoSize = true;
            this.radioButton_eraser.BackgroundImage = global::Painter2.Properties.Resources.eraser2;
            this.radioButton_eraser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.radioButton_eraser.Font = new System.Drawing.Font("微軟正黑體", 14.25F);
            this.radioButton_eraser.Location = new System.Drawing.Point(45, 5);
            this.radioButton_eraser.Name = "radioButton_eraser";
            this.radioButton_eraser.Size = new System.Drawing.Size(35, 34);
            this.radioButton_eraser.TabIndex = 235;
            this.radioButton_eraser.Tag = "eraser";
            this.radioButton_eraser.Text = "   ";
            this.radioButton_eraser.UseVisualStyleBackColor = true;
            this.radioButton_eraser.CheckedChanged += new System.EventHandler(this.radioButton_Tool_CheckedChanged);
            // 
            // panel_Tool
            // 
            this.panel_Tool.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Tool.Controls.Add(this.radioButton_selectAnyShape);
            this.panel_Tool.Controls.Add(this.radioButton_selectRect);
            this.panel_Tool.Controls.Add(this.radioButton_ellipse_fill);
            this.panel_Tool.Controls.Add(this.radioButton_ellipse);
            this.panel_Tool.Controls.Add(this.radioButton_circle_fill);
            this.panel_Tool.Controls.Add(this.radioButton_circle);
            this.panel_Tool.Controls.Add(this.radioButton_rectangle_fill);
            this.panel_Tool.Controls.Add(this.radioButton_rectangle);
            this.panel_Tool.Controls.Add(this.radioButton_eraser);
            this.panel_Tool.Controls.Add(this.radioButton_penPoint);
            this.panel_Tool.Location = new System.Drawing.Point(7, 215);
            this.panel_Tool.Name = "panel_Tool";
            this.panel_Tool.Size = new System.Drawing.Size(85, 205);
            this.panel_Tool.TabIndex = 233;
            // 
            // radioButton_selectAnyShape
            // 
            this.radioButton_selectAnyShape.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton_selectAnyShape.AutoSize = true;
            this.radioButton_selectAnyShape.BackgroundImage = global::Painter2.Properties.Resources.任意範圍選取;
            this.radioButton_selectAnyShape.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.radioButton_selectAnyShape.Font = new System.Drawing.Font("微軟正黑體", 14.25F);
            this.radioButton_selectAnyShape.Location = new System.Drawing.Point(45, 165);
            this.radioButton_selectAnyShape.Name = "radioButton_selectAnyShape";
            this.radioButton_selectAnyShape.Size = new System.Drawing.Size(35, 34);
            this.radioButton_selectAnyShape.TabIndex = 243;
            this.radioButton_selectAnyShape.Tag = "";
            this.radioButton_selectAnyShape.Text = "   ";
            this.radioButton_selectAnyShape.UseVisualStyleBackColor = true;
            // 
            // radioButton_selectRect
            // 
            this.radioButton_selectRect.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton_selectRect.AutoSize = true;
            this.radioButton_selectRect.BackgroundImage = global::Painter2.Properties.Resources.矩形選取;
            this.radioButton_selectRect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.radioButton_selectRect.Font = new System.Drawing.Font("微軟正黑體", 14.25F);
            this.radioButton_selectRect.Location = new System.Drawing.Point(5, 165);
            this.radioButton_selectRect.Name = "radioButton_selectRect";
            this.radioButton_selectRect.Size = new System.Drawing.Size(35, 34);
            this.radioButton_selectRect.TabIndex = 242;
            this.radioButton_selectRect.Tag = "selectRect";
            this.radioButton_selectRect.Text = "   ";
            this.radioButton_selectRect.UseVisualStyleBackColor = true;
            this.radioButton_selectRect.CheckedChanged += new System.EventHandler(this.radioButton_Tool_CheckedChanged);
            // 
            // radioButton_ellipse_fill
            // 
            this.radioButton_ellipse_fill.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton_ellipse_fill.AutoSize = true;
            this.radioButton_ellipse_fill.BackgroundImage = global::Painter2.Properties.Resources.ellipse_fill_32;
            this.radioButton_ellipse_fill.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.radioButton_ellipse_fill.Font = new System.Drawing.Font("微軟正黑體", 14.25F);
            this.radioButton_ellipse_fill.Location = new System.Drawing.Point(45, 125);
            this.radioButton_ellipse_fill.Name = "radioButton_ellipse_fill";
            this.radioButton_ellipse_fill.Size = new System.Drawing.Size(35, 34);
            this.radioButton_ellipse_fill.TabIndex = 241;
            this.radioButton_ellipse_fill.Tag = "ellipse_fill";
            this.radioButton_ellipse_fill.Text = "   ";
            this.radioButton_ellipse_fill.UseVisualStyleBackColor = true;
            this.radioButton_ellipse_fill.CheckedChanged += new System.EventHandler(this.radioButton_Tool_CheckedChanged);
            // 
            // radioButton_ellipse
            // 
            this.radioButton_ellipse.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton_ellipse.AutoSize = true;
            this.radioButton_ellipse.BackgroundImage = global::Painter2.Properties.Resources.ellipse_32;
            this.radioButton_ellipse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.radioButton_ellipse.Font = new System.Drawing.Font("微軟正黑體", 14.25F);
            this.radioButton_ellipse.Location = new System.Drawing.Point(5, 125);
            this.radioButton_ellipse.Name = "radioButton_ellipse";
            this.radioButton_ellipse.Size = new System.Drawing.Size(35, 34);
            this.radioButton_ellipse.TabIndex = 240;
            this.radioButton_ellipse.Tag = "ellipse";
            this.radioButton_ellipse.Text = "   ";
            this.radioButton_ellipse.UseVisualStyleBackColor = true;
            this.radioButton_ellipse.CheckedChanged += new System.EventHandler(this.radioButton_Tool_CheckedChanged);
            // 
            // radioButton_circle_fill
            // 
            this.radioButton_circle_fill.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton_circle_fill.AutoSize = true;
            this.radioButton_circle_fill.BackgroundImage = global::Painter2.Properties.Resources.circle_fill;
            this.radioButton_circle_fill.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.radioButton_circle_fill.Font = new System.Drawing.Font("微軟正黑體", 14.25F);
            this.radioButton_circle_fill.Location = new System.Drawing.Point(45, 85);