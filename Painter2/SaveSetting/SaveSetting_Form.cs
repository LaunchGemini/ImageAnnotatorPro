
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Media; // For SystemSounds

using Painter_DLL; // (20201019) Jeff Revised!

namespace Painter2.SaveSetting
{
    public partial class SaveSetting_Form : Form
    {
        private Dictionary<string, Label> Dictionary_Label { get; set; } = new Dictionary<string, Label>();

        /// <summary>
        /// ON 時，控制項啟用
        /// </summary>
        private Dictionary<string, List<Control>> Dict_ON_Enabled { get; set; } = new Dictionary<string, List<Control>>();
        /// <summary>
        /// OFF 時，控制項啟用