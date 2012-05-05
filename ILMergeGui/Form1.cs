#region Header

/* ----------   ---   -------------------------------------------------------------------------------
 * Purpose:           Gui for Microsoft's ILMerge.
 * By:                G.W. van der Vegt (wim@vander-vegt.nl)
 * Based on:          VB version by igoramadas (devv.com) at http://ilmergegui.codeplex.com/
 * Depends:           Nothing (well except ILMerge.exe).
 * ----------   ---   -------------------------------------------------------------------------------
 * dd-mm-yyyy - who - description
 * ----------   ---   -------------------------------------------------------------------------------
 * 04-05-2012 - veg - Added Relative Paths to Assembly List (relative to primary).
 *                  - Added shortend Display values to Assembly List.
 *                  - Search for all Windows .Net Frameworks (x86, x64) in
 *                    C:\Windows\Microsoft.NET and
 *                    C:\Program Files\Reference Assemblies.
 *                    C:\Program Files (x86)\Reference Assemblies.
 *                  - Dynamically build Framework Combobox.
 *                  - Added Delete to Assembly Listbox.
 *                  - Added Drag&Drop to Assembly Listbox.
 *                  - Re-added checks on outputpath/assembly collisions.
 *                  - Added autocompletion to editoboxes.
 *                  - Disable merge button when only a single assembly is present.
 *                  - Show logfile (if present and generated) after merge.
 *                  - Debugged DynaInvoke/
 *                  - Renamed methods in DynaInvoke.
 *                  - Disabled Slow Method in DynaInvoke.
 *                  - ILMerge path changes according to x86 or x64 architecture.
 *                  - Improved error message of IlMerge.Merge() (using the inner exception).
 *                  - Added Diagnostic output for ILMerge() method and property access.
 *                  - Clear filename of OpenDialog.
 *                  - Changed linklabels
 *                  - Removed donate.
 *                  - Debugged MakeRelativePath (same paths returned empty string).
 * 05-05-2012 - veg - Added menubar
 *                  - Added saving and restoring of settings in xml format.
 * ----------   ---   ------------------------------------------------------------------------------- */

#endregion Header

namespace ILMergeGui
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Windows.Forms;
    using System.Xml;
    using System.Xml.Linq;

    using ILMergeGui.Properties;
    using Microsoft.Win32;
    using System.Drawing;

    //! TODO Make sure dialogs are cleaned before re-use
    //! TODO Add commandline options (cfg & /Merge).
    //! TODO Generate ILMerge.exe Commandline 
    //
    //! TODO Find out what ILMerge commandline options actually mean.
    //
    //! TODO Detect CF Framework (C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework)
    //! TODO Detect MicroFramework (MicroFrameworkPK_v4_1).
    //       HKEY_CURRENT_USER\Software\Microsoft\VisualStudio\10.0_Config\MSBuild\SafeImports
    //       HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Installer\Folders (scan for keys with \ReferenceAssembly\Micrososft\Framework)
    //       HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Installer\UserData\S-1-5-18\Components\14A3CECB2D8CDD549B5B500B9419DD8B   06CB6B5FEBFB8C64592234F1A39D5C3E
    //       HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Installer\UserData\S-1-5-18\Components\20D9905CA04002C46AA268E18E602954   C19BEE65E0D80E340B3348E8D3F2A593 (Arm)
    //       HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Installer\UserData\S-1-5-18\Components\33FEA56D2D876AA409FE8D29504C4941   325D13E28C59BD44097CE0F472F4EC95 (Thumb)
    //       HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Installer\UserData\S-1-5-18\Components\4F5BF0F9A63E3F34C97EA3E33BB60492   4D0ABD3C1BE9C944C85FFCA0F1F6F7A4 (Porting kit)
    //
    //       x86 = C:\Windows\Microsoft.NET\Framework
    //       x64 = C:\Windows\Microsoft.NET\Framework64
    //
    //! TODO Windows Communication Foundation
    //! TODO Windows Presentation Foundation
    //! TODO Windows Workflow Foundation
    //! TODO Advanced Settings?
    //! TODO List special features under v3.0 as Windows Workflow Foundationn.
    //! TODO Support for Version 1/1.1
    //
    //! TODO http://stackoverflow.com/questions/199080/how-to-detect-what-net-framework-versions-and-service-packs-are-installed
    //! TODO http://support.microsoft.com/kb/318785/en-us
    //
    //public bool AllowMultipleAssemblyLevelAttributes { set; get; }
    //public bool AllowWildCards { set; get; }
    //public bool AllowZeroPeKind { set; get; }
    //public string AttributeFile { set; get; }
    //public bool Closed { set; get; }
    //public string ExcludeFile { set; get; }
    //public int FileAlignment { set; get; }
    //public bool Internalize { set; get; }
    //public bool PreserveShortBranches { set; get; }
    //public bool PublicKeyTokens { set; get; }
    //public bool StrongNameLost { get; }
    //public System.Version Version { set; get; }
    //public bool XmlDocumentation { set; get; }
    //public void AllowDuplicateType(string typeName)
    //public void SetSearchDirectories(string[] dirs)

    public partial class Form1 : Form
    {
        #region Fields

        /// <summary>
        /// Storage for Available DotNet Frameworks.
        /// </summary>
        private List<DotNet> frameworks = null;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Constructor.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Name of the ILMerge Assembly.
        /// </summary>
        public String ilMerge
        {
            get
            {
                return "ILMerge";
            }
        }

        /// <summary>
        /// Path of the ILMerge Executable.
        /// </summary>
        public String iLMergePath
        {
            get;
            private set;
        }

        /// <summary>
        /// Filename of the Primary Assembly (exe).
        /// </summary>
        public String Primary
        {
            get;
            set;
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Enumerate available x86 and x64 DotNet Framework Versions.
        /// </summary>
        /// <returns>A list of DotNet version</returns>
        public static List<DotNet> InstalledDotNetVersions()
        {
            List<DotNet> versions = new List<DotNet>();

            //TODO This needs an own routine to decode the SP (as it's part of the version and the installed key is missing anyway).
            RegistryKey ICKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Active Setup\Installed Components");
            if (ICKey != null)
            {
                GetDotNetVersion(ICKey.OpenSubKey("{78705f0d-e8db-4b2d-8193-982bdda15ecd}"), "{78705f0d-e8db-4b2d-8193-982bdda15ecd}", versions);
                GetDotNetVersion(ICKey.OpenSubKey("{FDC11A6F-17D1-48f9-9EA3-9051954BAA24}"), "{FDC11A6F-17D1-48f9-9EA3-9051954BAA24}", versions);
            }

            RegistryKey NDPKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP");
            if (NDPKey != null)
            {
                string[] subkeys = NDPKey.GetSubKeyNames();
                foreach (string subkey in subkeys)
                {
                    GetDotNetVersion(NDPKey.OpenSubKey(subkey), subkey, versions);
                    GetDotNetVersion(NDPKey.OpenSubKey(subkey).OpenSubKey("Client"), subkey, versions);
                    GetDotNetVersion(NDPKey.OpenSubKey(subkey).OpenSubKey("Full"), subkey, versions);
                }
            }

            return versions;
        }

        /// <summary> 
        /// Creates a relative path from one file or folder to another. 
        /// 
        /// See http://stackoverflow.com/questions/275689/how-to-get-relative-path-from-absolute-path
        /// </summary> 
        /// <param name="fromPath">Contains the directory that defines the start of the relative path.</param> 
        /// <param name="toPath">Contains the path that defines the endpoint of the relative path.</param> 
        /// <returns>The relative path from the start directory to the end path.</returns> 
        /// <exception cref="ArgumentNullException">One of the strings is empty</exception> 
        public static String MakeRelativePath(String fromPath, String toPath)
        {
            if (String.IsNullOrEmpty(fromPath))
                throw new ArgumentNullException("fromPath");
            if (String.IsNullOrEmpty(toPath))
                throw new ArgumentNullException("toPath");

            Uri fromUri = new Uri(fromPath);
            Uri toUri = new Uri(toPath);

            Uri relativeUri = fromUri.MakeRelativeUri(toUri);
            String relativePath = Uri.UnescapeDataString(relativeUri.ToString());

            if (String.IsNullOrEmpty(relativePath))
            {
                return Path.GetFileName(toPath);
            }
            else
            {
                return relativePath.Replace('/', Path.DirectorySeparatorChar);
            }
        }

        /// <summary>
        /// Search for DotNet version and path information.
        /// </summary>
        /// <param name="parentKey">The Registry Key.</param>
        /// <param name="subVersionName">The sub version Name.</param>
        /// <param name="versions">The list of DotNet versions.</param>
        private static void GetDotNetVersion(RegistryKey parentKey, string subVersionName, List<DotNet> versions)
        {
            if (parentKey != null)
            {
                string installed = Convert.ToString(parentKey.GetValue("Install"));
                if (installed == "1")
                {
                    string version = Convert.ToString(parentKey.GetValue("Version"));
                    if (string.IsNullOrEmpty(version))
                    {
                        if (subVersionName.StartsWith("v"))
                            version = subVersionName.Substring(1);
                        else
                            version = subVersionName;
                    }
                    Version ver = new Version(version);

                    String x64syspath = String.Empty;
                    String x86syspath = String.Empty;

                    String x64pfpath = String.Empty;
                    String x86pfpath = String.Empty;

                    if (Environment.Is64BitOperatingSystem)
                    {
                        x64syspath = Convert.ToString(parentKey.GetValue("InstallPath"));
                    }
                    else
                    {
                        x86syspath = Convert.ToString(parentKey.GetValue("InstallPath"));
                    }

                    //Test for x64 directory names.
                    if (Environment.Is64BitOperatingSystem)
                    {
                        x64syspath = TestDotnetPath(
                            ver,
                            x64syspath,
                            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows),
                                                          @"Microsoft.NET\Framework64\"));

                        x64pfpath = TestDotnetPath(
                            ver,
                            x64pfpath,
                            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles),
                                                      @"Reference Assemblies\Microsoft\Framework\"));
                    }

                    //Test for x86 directory names.
                    x86syspath = TestDotnetPath(
                         ver,
                         x86syspath,
                         Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows),
                                                       @"Microsoft.NET\Framework\"));

                    //Test for x86 directory names.
                    x86pfpath = TestDotnetPath(
                        ver,
                        x86pfpath,
                        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86),
                                                      @"Reference Assemblies\Microsoft\Framework\"));

                    String pattern = ".NET Framework {0}";

                    if (parentKey.GetValue("SP") != null)
                    {
                        pattern += " Service Pack " + Convert.ToString(parentKey.GetValue("SP"));
                    }

                    //HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Client
                    String type = parentKey.Name.Substring(parentKey.Name.LastIndexOf('\\') + 1);

                    if (type.Equals(subVersionName))
                    {
                        versions.Add(
                            new DotNet()
                            {
                                name = String.Format(pattern, subVersionName),
                                version = ver,
                                x86WindowsPath = x86syspath.TrimEnd(Path.DirectorySeparatorChar),
                                x86ProgramFilesPath = x86pfpath.TrimEnd(Path.DirectorySeparatorChar),
                                x64WindowsPath = x64syspath.TrimEnd(Path.DirectorySeparatorChar),
                                x64ProgramFilesPath = x64pfpath.TrimEnd(Path.DirectorySeparatorChar),
                            });

                        // String.Format(pattern, subVersionName), ver);
                    }
                    else
                    {
                        versions.Add(new DotNet()
                            {
                                name = String.Format(pattern, subVersionName + " " + type),
                                version = ver,
                                x86WindowsPath = x86syspath.TrimEnd(Path.DirectorySeparatorChar),
                                x86ProgramFilesPath = x86pfpath.TrimEnd(Path.DirectorySeparatorChar),
                                x64WindowsPath = x64syspath.TrimEnd(Path.DirectorySeparatorChar),
                                x64ProgramFilesPath = x64pfpath.TrimEnd(Path.DirectorySeparatorChar),
                            });
                    }
                }
            }
        }

        private static String TestDotnetPath(Version ver, String frameworkpath, String basepath)
        {
            if (String.IsNullOrEmpty(frameworkpath))
            {
                String path = Path.Combine(basepath, String.Format("v{0}.{1}", ver.Major, ver.Minor));
                if (Directory.Exists(path))
                {
                    return path;
                }
            }

            if (String.IsNullOrEmpty(frameworkpath))
            {
                String path = Path.Combine(basepath, String.Format("v{0}.{1}.{2}", ver.Major, ver.Minor, ver.Build));
                if (Directory.Exists(path))
                {
                    return path;
                }
            }

            return frameworkpath;
        }

        private void ButAddFile_Click(object sender, EventArgs e)
        {
            openFile1.CheckFileExists = true;
            openFile1.Multiselect = true;
            openFile1.FileName = String.Empty;
            openFile1.Filter = ".NET Assembly|*.dll;*.exe";

            if (openFile1.ShowDialog() == DialogResult.OK)
            {
                ProcessFiles(openFile1.FileNames);
            }
        }

        private void ButKeyFile_Click(object sender, EventArgs e)
        {
            SelectKeyFile();
        }

        private void ButLogFile_Click(object sender, EventArgs e)
        {
            SelectLogFile();
        }

        private void ButMerge_Click(object sender, EventArgs e)
        {
            //! Locate ILMerge.exe on disk ro registry.
            //! Load ILMerge.exe dynamically.
            //! c:\Program Files (x86)\Microsoft\ILMerge\ILMerge.exe

            //! HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Installer\UserData\S-1-5-21-822211721-2317658140-2171821640-1000\Components\F995DC6782BCD301ECDB40AF0BEFB501
            //! FB8E12458022DA64AB4CCF9364EE3B15=C:\Program Files (x86)\Microsoft\ILMerge\ILMerge.exe
            //! or
            //! HKEY_CURRENT_USER\Software\Microsoft\Installer\Assemblies\C:|Program Files (x86)|Microsoft|ILMerge|ILMerge.exe
            //! just enumerate HKEY_CURRENT_USER\Software\Microsoft\Installer\Assemblies until a key ends in |ILMerge.exe

            Debug.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFilesX86));
            Debug.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFiles));

            //! TODO Nicely find ILMerge.
            if (!DynaInvoke.PreLoadAssembly(iLMergePath, ilMerge))
            {
                return;
            }

            List<String> arrAssemblies = new List<String>();

            PreMerge();

            if (!Directory.Exists(Path.GetDirectoryName(TxtOutputAssembly.Text)))
            {
                MessageBox.Show(Resources.Error_NoOutputPath, Resources.Error_Term, MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtOutputAssembly.Focus();

                return;
            }
            else
            {
                TxtOutputAssembly.Text = TxtOutputAssembly.Text.Trim();
            }

            if (File.Exists(TxtKeyFile.Text) && !File.Exists(TxtKeyFile.Text))
            {
                MessageBox.Show(Resources.Error_KeyFileNotExists, Resources.Error_Term, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            for (Int32 i = 0; i < ListAssembly.Items.Count; i++)
            {
                if (ListAssembly.Items[i].ToString().ToLower().Equals(TxtOutputAssembly.Text.ToLower()))
                {
                    MessageBox.Show(Resources.Error_OutputConflict, Resources.Error_Term, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtOutputAssembly.Focus();

                    return;
                }
            }

            if (File.Exists(TxtOutputAssembly.Text))
            {
                try
                {
                    FileInfo objFile = new FileInfo(TxtOutputAssembly.Text);
                    objFile.Attributes = FileAttributes.Normal;
                    objFile.Delete();
                    objFile = null;
                }
                catch (Exception)
                {
                    MessageBox.Show(Resources.Error_OutputPathInUse, Resources.Error_Term, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (ListAssembly.SelectedItem == null)
            {
                for (Int32 i = 0; i < ListAssembly.Items.Count; i++)
                {
                    if (Path.GetExtension(ListAssembly.Items[i].ToString()).ToLower() == ".exe")
                    {
                        ListAssembly.SelectedIndex = i;
                        i = ListAssembly.Items.Count;
                    }
                }
            }

            if (ListAssembly.SelectedItem == null)
            {
                ListAssembly.SelectedIndex = 0;
            }

            arrAssemblies.Add(Primary);
            for (Int32 i = 0; i < ListAssembly.Items.Count; i++)
            {
                if (!arrAssemblies.Contains(ListAssembly.Items[i].ToString()))
                {
                    arrAssemblies.Add(ListAssembly.Items[i].ToString());
                }
            }

            Console.WriteLine("ILMerge.{0}={1}", "CopyAttributes", DynaInvoke.SetProperty<Boolean>(iLMergePath, ilMerge, "CopyAttributes", ChkCopyAttributes.Checked));
            Console.WriteLine("ILMerge.{0}={1}", "UnionMerge", DynaInvoke.SetProperty<Boolean>(iLMergePath, ilMerge, "UnionMerge", ChkUnionDuplicates.Checked));

            if (ChkSignKeyFile.Checked)
            {
                Console.WriteLine("ILMerge.{0}={1}", "KeyFile", DynaInvoke.SetProperty<String>(iLMergePath, ilMerge, "KeyFile", TxtKeyFile.Text));
                Console.WriteLine("ILMerge.{0}={1}", "DelaySign", DynaInvoke.SetProperty<Boolean>(iLMergePath, ilMerge, "DelaySign", ChkDelayedSign.Checked));
            }

            if (ChkGenerateLog.Checked)
            {
                Console.WriteLine("ILMerge.{0}={1}", "DelaySign", DynaInvoke.SetProperty<Boolean>(iLMergePath, ilMerge, "Log", ChkGenerateLog.Checked).ToString());
                Console.WriteLine("ILMerge.{0}={1}", "LogFile", DynaInvoke.SetProperty(iLMergePath, ilMerge, "LogFile", TxtLogFile.Text));
            }

            Console.WriteLine("ILMerge.{0}={1}", "DebugInfo", DynaInvoke.SetProperty<Boolean>(iLMergePath, ilMerge, "DebugInfo", CboDebug.SelectedIndex == 0 ? true : false));

            //! This must be done better!!
            //! TODO Enumerate Frameworks and find correct directories under Program Files.

            DotNet framework = (DotNet)CboTargetFramework.SelectedItem;

            String frameversion = String.Format("{0}.{1}", framework.version.Major, framework.version.Minor);

            if (Environment.Is64BitOperatingSystem)
            {
                Console.WriteLine("ILMerge.{0}('{1}', '{2}')",
                    "SetTargetPlatform",
                    frameversion,
                    framework.x64WindowsPath);
                DynaInvoke.CallMethod<Object>(iLMergePath, ilMerge, "SetTargetPlatform", new Object[] { frameversion, framework.x64WindowsPath });
            }
            else
            {
                Console.WriteLine("ILMerge.{0}('{1}', '{2}')",
                    "SetTargetPlatform",
                    frameversion,
                    framework.x86WindowsPath);
                DynaInvoke.CallMethod<Object>(iLMergePath, ilMerge, "SetTargetPlatform", new Object[] { frameversion, framework.x86WindowsPath });
            }

            //Console.WriteLine("ILMerge.{0}={1}", "Version", DynaInvoke.GetProperty<Version>(iLMergePath, ilMerge, "Version"));

            //0=Dll
            //1=Exe
            //2=ILMerge.Kind.SameAsPrimaryAssembly
            //3=WinExe

            Console.WriteLine("ILMerge.{0}={1}", "TargetKind", DynaInvoke.SetProperty<Int32>(iLMergePath, ilMerge, "TargetKind", 2));
            Console.WriteLine("ILMerge.{0}={1}", "OutputFile", DynaInvoke.SetProperty<String>(iLMergePath, ilMerge, "OutputFile", TxtOutputAssembly.Text));

            Console.WriteLine("ILMerge.{0}(", "SetInputAssemblies");
            foreach (String asm in arrAssemblies)
            {
                Console.WriteLine("                           '{0}'", asm);
            }
            Console.WriteLine("                          )");

            DynaInvoke.CallMethod<Object>(iLMergePath, ilMerge, "SetInputAssemblies", new Object[] { arrAssemblies.ToArray() });

            //Cursor = Cursors.WaitCursor
            EnableForm(false);

            WorkerILMerge.RunWorkerAsync();
        }

        private void ButOutputPath_Click(object sender, EventArgs e)
        {
            SelectOutputFile();
        }

        private void ChkGenerateLog_CheckedChanged(object sender, EventArgs e)
        {
            TxtLogFile.Enabled = ChkGenerateLog.Checked;
            ButLogFile.Enabled = ChkGenerateLog.Checked;
        }

        private void ChkSignKeyFile_CheckedChanged(object sender, EventArgs e)
        {
            TxtKeyFile.Enabled = ChkSignKeyFile.Checked;
            ButKeyFile.Enabled = ChkSignKeyFile.Checked;
        }

        private void EnableForm(bool Enable)
        {
            ListAssembly.Enabled = Enable;
            ButAddFile.Enabled = Enable;
            BoxOptions.Enabled = Enable;
            BoxOutput.Enabled = Enable;
            ButMerge.Enabled = Enable;

            Application.DoEvents();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Environment.Is64BitOperatingSystem)
            {
                iLMergePath = @Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86),
                    @"Microsoft\ILMerge\ILMerge.exe");
            }
            else
            {
                iLMergePath = @Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles),
                    @"Microsoft\ILMerge\ILMerge.exe");
            }

            RestoreDefaults();

            foreach (String arg in Environment.GetCommandLineArgs())
            {
                if (!arg.StartsWith("/") &&
                    File.Exists(arg) &&
                    Path.GetExtension(arg).Equals(".xml", StringComparison.OrdinalIgnoreCase))
                {
                    RestoreSettings(arg);
                    break;
                }
            }

            foreach (String arg in Environment.GetCommandLineArgs())
            {
                if (arg.Equals("/Merge", StringComparison.OrdinalIgnoreCase))
                {
                    ButMerge.PerformClick();
                }
            }
        }

        private void RestoreDefaults()
        {
            ListAssembly.Items.Clear();
            Primary = String.Empty;
            LblPrimaryAssembly.Text = String.Empty;

            //Not allowed woth a DataSource.
            //CboTargetFramework.Items.Clear();

            frameworks = InstalledDotNetVersions();
            foreach (DotNet framework in frameworks)
            {
                Debug.WriteLine(String.Format("[{0}]", framework.name));
                Debug.WriteLine(String.Format("Version={0}", framework.version));
                if (Environment.Is64BitOperatingSystem)
                {
                    Debug.WriteLine(String.Format("x64 Windir Path={0}", framework.x64WindowsPath));
                    Debug.WriteLine(String.Format("x64 Program Files Path={0}", framework.x64ProgramFilesPath));
                }
                Debug.WriteLine(String.Format("x86 Windir Path={0}", framework.x86WindowsPath));
                Debug.WriteLine(String.Format("x86 Program Files Path={0}", framework.x86ProgramFilesPath));
                Debug.WriteLine("");
            }

            CboTargetFramework.DataSource = frameworks;
            CboTargetFramework.SelectedIndex = frameworks.Count - 1;

            CboDebug.SelectedIndex = 1;
            
            //ChkCopyAttributes.Checked = (Boolean)Settings.Default.Properties["CopyAttributes"].DefaultValue;
            ChkCopyAttributes.Checked = true;
            ChkUnionDuplicates.Checked = false;
            ChkSignKeyFile.Checked = false;
            ChkDelayedSign.Checked = false;

            TxtKeyFile.Text = String.Empty;
            TxtLogFile.Text = String.Empty;
            TxtOutputAssembly.Text = String.Empty;
        }

        private void LblPrimaryAssembly_TextChanged(object sender, EventArgs e)
        {
            ListAssembly.FormattingEnabled = false;
            ListAssembly.FormattingEnabled = true;
        }

        private void LinkILMerge_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(LinkILMerge.Text);
        }

        private void ListAssembly_DragDrop(object sender, DragEventArgs e)
        {
            ProcessFiles((String[])e.Data.GetData(DataFormats.FileDrop));
        }

        private void ListAssembly_DragEnter(object sender, DragEventArgs e)
        {
            // make sure they're actually dropping files (not text or anything else)
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                // allow them to continue
                // (without this, the cursor stays a "NO" symbol
                e.Effect = DragDropEffects.All;
            }
        }

        private void ListAssembly_Format(object sender, ListControlConvertEventArgs e)
        {
            if (!String.IsNullOrEmpty(Primary))
            {
                //String bp = Path.GetDirectoryName(Primary);
                //e.Value = e.Value.ToString().Replace(bp, String.Empty);
                e.Value = MakeRelativePath(Primary, e.Value.ToString());
            }
            else
            {
                e.Value = Path.GetFileName(e.Value.ToString());
            }
        }

        private void ListAssembly_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && ListAssembly.SelectedItem != null)
            {
                Int32 ndx = ListAssembly.SelectedIndex;

                ListAssembly.Items.Remove(ListAssembly.SelectedItem);

                if (ndx > 0 || ListAssembly.Items.Count > 0)
                {
                    ListAssembly.SelectedIndex = Math.Max(0, ndx - 1);
                }

                ButMerge.Enabled = ListAssembly.Items.Count > 1;
            }
        }

        private void ListAssembly_SelectedIndexChanged(object sender, EventArgs e)
        {
            ButMerge.Enabled = ListAssembly.Items.Count > 0;

            if (ListAssembly.SelectedItem != null)
            {
                Primary = ListAssembly.SelectedItem.ToString();
                if (Path.GetFileName(Primary) != LblPrimaryAssembly.Text)
                {
                    LblPrimaryAssembly.Text = Path.GetFileName(Primary);
                }
            }
            else
            {
                Primary = String.Empty;
                if ("···" != LblPrimaryAssembly.Text)
                {
                    LblPrimaryAssembly.Text = "···";
                }
            }
        }

        /// <summary>
        /// Some sanity checks before merge.
        /// </summary>
        private void PreMerge()
        {
            if (String.IsNullOrEmpty(TxtKeyFile.Text))
            {
                ChkSignKeyFile.Checked = false;
            }

            if (String.IsNullOrEmpty(TxtLogFile.Text))
            {
                ChkGenerateLog.Checked = false;
            }

            if (TxtOutputAssembly.Text.Length < 5)
            {
                SelectOutputFile();
            }
        }

        /// <summary>
        /// Process selected or dropped Assemblies.
        /// </summary>
        /// <param name="filenames">The list of file to process.</param>
        private void ProcessFiles(String[] filenames)
        {
            UseWaitCursor = true;

            Boolean isDupe = false;

            for (Int32 i = 0; i < filenames.Length; i++)
            {
                String strExtension = Path.GetExtension(filenames[i]).ToLower();

                if (strExtension == ".dll" || strExtension == ".exe")
                {
                    isDupe = false;

                    for (Int32 z = 0; z < ListAssembly.Items.Count; z++)
                    {
                        if (filenames[i] == ListAssembly.Items[z].ToString())
                        {
                            isDupe = true;
                        }
                    }

                    if (!isDupe)
                    {
                        ListAssembly.Items.Add(filenames[i]);
                    }
                }
                ListAssembly.Refresh();
            }

            ButMerge.Enabled = ListAssembly.Items.Count > 1;

            UseWaitCursor = false;
        }

        /// <summary>
        /// Select a Key File.
        /// </summary>
        private void SelectKeyFile()
        {
            SetOpenFileDefaults("Strong Name Key|*.snk");

            if (!String.IsNullOrEmpty(TxtKeyFile.Text))
            {
                openFile1.FileName = Path.GetFileName(TxtKeyFile.Text);
            }

            if (TxtKeyFile.Text.Length > 3)
            {
                openFile1.InitialDirectory = Path.GetDirectoryName(TxtKeyFile.Text);
            }

            if (openFile1.ShowDialog() == DialogResult.OK)
            {
                ChkSignKeyFile.Checked = true;
                TxtKeyFile.Text = openFile1.FileName;
                TxtKeyFile.Focus();
            }
        }

        /// <summary>
        /// Select a Log File.
        /// </summary>        
        private void SelectLogFile()
        {
            SetOpenFileDefaults("Log file|*.log");

            if (!String.IsNullOrEmpty(TxtLogFile.Text))
            {
                openFile1.FileName = Path.GetFileName(TxtLogFile.Text);
            }

            if (TxtLogFile.Text.Length > 3)
            {
                openFile1.InitialDirectory = Path.GetDirectoryName(TxtLogFile.Text);
            }

            if (openFile1.ShowDialog() == DialogResult.OK)
            {
                ChkGenerateLog.Checked = true;
                TxtLogFile.Text = openFile1.FileName;
                TxtLogFile.Focus();
            }
        }

        /// <summary>
        /// Select the Output File.
        /// </summary>        
        private void SelectOutputFile()
        {
            SetOpenFileDefaults("Assembly|*.dll;*.exe");

            if (ListAssembly.SelectedItem != null)
            {
                openFile1.FileName = Path.GetFileName(ListAssembly.SelectedItem.ToString());
            }

            if (TxtOutputAssembly.Text.Length > 3)
            {
                openFile1.InitialDirectory = Path.GetDirectoryName(TxtOutputAssembly.Text);
            }

            if (openFile1.ShowDialog() == DialogResult.OK)
            {
                TxtOutputAssembly.Text = openFile1.FileName;
                TxtOutputAssembly.Focus();
            }
        }

        /// <summary>
        /// Update the OpenFile Dialog before showing it.
        /// </summary>
        /// <param name="filter">Teh File Filter to set.</param>
        private void SetOpenFileDefaults(string filter)
        {
            openFile1.CheckFileExists = false;
            openFile1.Multiselect = false;
            openFile1.Filter = filter + "|All Files|*.*";
            openFile1.FileName = filter.Substring(filter.IndexOf('|') + 1);
        }

        /// <summary>
        /// The Background Worker Method, Starts the actual ILMerge.
        /// </summary>
        /// <param name="sender">-</param>
        /// <param name="e">-</param>
        private void WorkerILMerge_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                DynaInvoke.DynaClassInfo dci = DynaInvoke.GetClassReference(iLMergePath, "ILMerge");

                Console.WriteLine("ILMerge.{0}()", "Merge");
                DynaInvoke.CallMethod(iLMergePath, ilMerge, "Merge", null);

                e.Result = null;
            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
        }

        /// <summary>
        /// Called when the BackgroundWorker has completed it's task.
        /// </summary>
        /// <param name="sender">-</param>
        /// <param name="e">-</param>
        private void WorkerILMerge_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            //Cursor = Cursors.Default;

            EnableForm(true);

            if (e.Error != null)
            {
                //'ErrorHandler.Handle(e.Error)
            }

            if (e.Result != null)
            {
                //! The InnerException shows the true error from ILMerge (if present).
                String Message = (e.Result as Exception).InnerException == null ? (e.Result as Exception).Message : (e.Result as Exception).InnerException.Message;

                MessageBox.Show(Resources.Error_MergeException + Environment.NewLine + Environment.NewLine + Message, Resources.Error_Term, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!File.Exists(TxtOutputAssembly.Text) || new FileInfo(TxtOutputAssembly.Text).Length == 0)
            {
                MessageBox.Show(Resources.Error_CantMerge, Resources.Error_Term, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show(Resources.AssembliesMerged, Resources.Done, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (ChkGenerateLog.Checked)
            {
                Process.Start(new ProcessStartInfo(TxtLogFile.Text));
            }
        }

        #endregion Methods

        #region Nested Types

        /// <summary>
        /// A structure to keep information on DotNet Frameworks.
        /// </summary>
        public struct DotNet
        {
            #region Fields

            /// <summary>
            /// The Friendly Name.
            /// </summary>
            public String name;

            /// <summary>
            /// The Version.
            /// </summary>
            public Version version;

            /// <summary>
            /// The Path under C:\Program Files\Reference Assemblies.
            /// </summary>
            public String x64ProgramFilesPath;

            /// <summary>
            /// The Path under C:\Windows\Microsoft.NET\Framework64
            /// </summary>
            public String x64WindowsPath;

            /// <summary>
            /// The Path under C:\Program Files (x86)\Reference Assemblies.
            /// </summary>            
            public String x86ProgramFilesPath;

            /// <summary>
            /// The Path under C:\Windows\Microsoft.NET\Framework
            /// </summary>
            public String x86WindowsPath;

            #endregion Fields

            #region Methods

            /// <summary>
            /// Genenerate a Friendly (shorter) ToString().
            /// </summary>
            /// <returns></returns>
            public override String ToString()
            {
                return name;
            }

            #endregion Methods
        }

        #endregion Nested Types

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveSettings(@"c:\temp\ILMerge.xml");
        }

        private void SaveSettings(String filename)
        {
            XDocument doc = new XDocument(new XElement("Settings"));

            //1) Save Switches.
            doc.Root.Add(
                new XComment("Switches"),
                new XElement("CopyAttributes", new XAttribute("Enabled", ChkCopyAttributes.Checked)),
                new XElement("UnionDuplicates", new XAttribute("Enabled", ChkUnionDuplicates.Checked)),
                new XElement("Debug", new XAttribute("Enabled", CboDebug.SelectedIndex)));

            //2) Save Signing.
            doc.Root.Add(
                new XComment("Signing"),
                    new XElement("Sign",
                    new XAttribute("Enabled", ChkSignKeyFile.Checked),
                    new XAttribute("Delay", ChkDelayedSign.Checked),
                    new XText(TxtKeyFile.Text)
                ));

            //3) Save Logging.
            doc.Root.Add(
                new XComment("Logging"),
                    new XElement("Log",
                    new XAttribute("Enabled", ChkGenerateLog.Checked),
                    new XText(TxtLogFile.Text)
                ));

            //4) Save Assemblies.
            XElement assemblies = new XElement("Assemblies");
            foreach (Object item in ListAssembly.Items)
            {
                assemblies.Add(new XElement("Assembly", item.ToString()));
            }
            assemblies.Add(
                new XElement("Primary", Primary));

            doc.Root.Add(
                new XComment("Assemblies"),
                assemblies);

            //5) Save Output.
            doc.Root.Add(
                new XComment("Output"),
                new XElement("OutputAssembly", TxtOutputAssembly.Text));

            //6) Save Framework.
            if (CboTargetFramework.SelectedIndex != -1)
            {
                DotNet framework = (DotNet)(CboTargetFramework.SelectedItem);
                doc.Root.Add(new XElement("Framework", framework.name));
            }

            doc.Save(filename);

            this.Text = String.Format("{0} - [{1}]",
                Application.ProductName,
                Path.GetFileName(filename));
        }

        private void openToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            RestoreSettings(@"c:\temp\ILMerge.xml");
        }

        private void RestoreSettings(String filename)
        {
            XDocument doc = XDocument.Load(filename);

            this.Text = String.Format("{0} - [{1}]",
                Application.ProductName,
                Path.GetFileName(filename));

            //1) Restore Switches.
            ChkCopyAttributes.Checked = Boolean.Parse(doc.Root.Element("CopyAttributes").Attribute("Enabled").Value);
            ChkUnionDuplicates.Checked = Boolean.Parse(doc.Root.Element("UnionDuplicates").Attribute("Enabled").Value);
            CboDebug.SelectedIndex = Int32.Parse(doc.Root.Element("Debug").Attribute("Enabled").Value);

            //2) Restore Signing.
            ChkSignKeyFile.Checked = Boolean.Parse(doc.Root.Element("Sign").Attribute("Enabled").Value);
            ChkDelayedSign.Checked = Boolean.Parse(doc.Root.Element("Sign").Attribute("Delay").Value);
            TxtKeyFile.Text = doc.Root.Element("Sign").Value;

            //3) Restore Logging.
            ChkGenerateLog.Checked = Boolean.Parse(doc.Root.Element("Log").Attribute("Enabled").Value);
            TxtLogFile.Text = doc.Root.Element("Log").Value;

            //4) Restore Assemblies.
            ListAssembly.Items.Clear();
            foreach (XElement assembly in doc.Root.Element("Assemblies").Elements("Assembly"))
            {
                ListAssembly.Items.Add(assembly.Value);
            }
            Primary = doc.Root.Element("Assemblies").Element("Primary").Value;
            LblPrimaryAssembly.Text = Path.GetFileName(Primary);

            //5) Restore Output.
            TxtOutputAssembly.Text = doc.Root.Element("OutputAssembly").Value;

            //6) Restore Framework.
            String framework = doc.Root.Element("Framework").Value;
            foreach (Object o in CboTargetFramework.Items)
            {
                if (((DotNet)o).name.Equals(framework))
                {
                    CboTargetFramework.SelectedItem = o;
                    break;
                }
            }
        }

        private void newToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.Text = Application.ProductName;

            RestoreDefaults();
        }
    }
}