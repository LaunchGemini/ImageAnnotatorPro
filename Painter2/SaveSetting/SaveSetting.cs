
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.IO; // For FileInfo
using System.Diagnostics; // For Trace
using System.Xml.Serialization;
using System.Drawing;
using System.ComponentModel;

using Painter_DLL; // (20201019) Jeff Revised!

namespace Painter2.SaveSetting
{
    /// <summary>
    /// 操作模式
    /// </summary>
    public enum enu_Module
    {
        Single_Dir,
        Double_Dir
    }

    [Serializable]
    public class cls_SaveSetting