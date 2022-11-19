
﻿/*
    Date: 2020/08/26
    Title: [源码] 【文件夹选择对话框】类似OpenFileDialog样式的FolderBrowserDialog
    Link: http://bbs.cskin.net/thread-1849-1-1.html
*/

using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FolderBrowserDialog_NewType
{
    #region Editor

    /// <summary>
    /// FolderBrowser 的设计器基类
    /// </summary>
    public class FolderNameEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            FolderBrowserDialog_New browser = new FolderBrowserDialog_New();
            if (value != null)
            {
                browser.DirectoryPath = string.Format("{0}", value);
            }
            if (browser.ShowDialog(null) == DialogResult.OK)
                return browser.DirectoryPath;
            return value;
        }
    }

    #endregion

    #region FolderBrowserDialog_New Base

    /// <summary>
    /// Vista 样式的选择文件对话框的基类
    /// </summary>
    [Description("提供一个Vista样式的选择文件对话框")]
    [Editor(typeof(FolderNameEditor), typeof(UITypeEditor))]
    public class FolderBrowserDialog_New : Component
    {
        /// <summary>
        /// 初始化 FolderBrowser 的新实例
        /// </summary>
        public FolderBrowserDialog_New()
        {
        }

        #region Public Property
        /// <summary>
        /// 获取在 FolderBrowser 中选择的文件夹路径
        /// </summary>
        public string DirectoryPath { get; set; }
        /// <summary>
        /// 向用户显示 FolderBrowser 的对话框
        /// </summary>
        /// <param name="owner">任何实现 System.Windows.Forms.IWin32Window（表示将拥有模式对话框的顶级窗口）的对象。</param>
        /// <returns></returns>
        public DialogResult ShowDialog(IWin32Window owner)
        {
            IntPtr hwndOwner = owner != null ? owner.Handle : GetActiveWindow();
            IFileOpenDialog dialog = (IFileOpenDialog)new FileOpenDialog();
            try
            {
                IShellItem item;
                if (!string.IsNullOrEmpty(DirectoryPath))
                {
                    IntPtr idl;
                    uint atts = 0;
                    if (SHILCreateFromPath(DirectoryPath, out idl, ref atts) == 0)
                    {
                        if (SHCreateShellItem(IntPtr.Zero, IntPtr.Zero, idl, out item) == 0)
                        {
                            dialog.SetFolder(item);
                        }
                    }
                }
                dialog.SetOptions(FOS.FOS_PICKFOLDERS | FOS.FOS_FORCEFILESYSTEM);
                uint hr = dialog.Show(hwndOwner);
                if (hr == ERROR_CANCELLED)
                    return DialogResult.Cancel;

                if (hr != 0)
                    return DialogResult.Abort;
                dialog.GetResult(out item);
                string path;
                item.GetDisplayName(SIGDN.SIGDN_FILESYSPATH, out path);
                DirectoryPath = path;
                return DialogResult.OK;
            }
            finally
            {
                Marshal.ReleaseComObject(dialog);
            }
        }
        #endregion

        #region BaseType
        [DllImport("shell32.dll")]
        private static extern int SHILCreateFromPath([MarshalAs(UnmanagedType.LPWStr)] string pszPath, out IntPtr ppIdl, ref uint rgflnOut);
        [DllImport("shell32.dll")]
        private static extern int SHCreateShellItem(IntPtr pidlParent, IntPtr psfParent, IntPtr pidl, out IShellItem ppsi);
        [DllImport("user32.dll")]
        private static extern IntPtr GetActiveWindow();
        private const uint ERROR_CANCELLED = 0x800704C7;
        [ComImport]
        [Guid("DC1C5A9C-E88A-4dde-A5A1-60F82A20AEF7")]
        private class FileOpenDialog
        {
        }
        [ComImport]
        [Guid("42f85136-db7e-439c-85f1-e4075d135fc8")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        private interface IFileOpenDialog
        {
            [PreserveSig]
            uint Show([In] IntPtr parent); // IModalWindow
            void SetFileTypes();  // not fully defined
            void SetFileTypeIndex([In] uint iFileType);
            void GetFileTypeIndex(out uint piFileType);
            void Advise(); // not fully defined
            void Unadvise();
            void SetOptions([In] FOS fos);
            void GetOptions(out FOS pfos);
            void SetDefaultFolder(IShellItem psi);
            void SetFolder(IShellItem psi);