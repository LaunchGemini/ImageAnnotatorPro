
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