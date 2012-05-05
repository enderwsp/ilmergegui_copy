namespace ILMergeGui
{
    /// <summary>
    /// The mainform.
    /// </summary>
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ToolTips = new System.Windows.Forms.ToolTip(this.components);
            this.LinkILMerge = new System.Windows.Forms.LinkLabel();
            this.ChkSignKeyFile = new System.Windows.Forms.CheckBox();
            this.ListAssembly = new System.Windows.Forms.ListBox();
            this.ButAddFile = new System.Windows.Forms.Button();
            this.ChkGenerateLog = new System.Windows.Forms.CheckBox();
            this.ChkDelayedSign = new System.Windows.Forms.CheckBox();
            this.ButLogFile = new System.Windows.Forms.Button();
            this.ChkUnionDuplicates = new System.Windows.Forms.CheckBox();
            this.TxtLogFile = new System.Windows.Forms.TextBox();
            this.ButKeyFile = new System.Windows.Forms.Button();
            this.ChkCopyAttributes = new System.Windows.Forms.CheckBox();
            this.TxtKeyFile = new System.Windows.Forms.TextBox();
            this.TxtOutputAssembly = new System.Windows.Forms.TextBox();
            this.ButOutputPath = new System.Windows.Forms.Button();
            this.ButMerge = new System.Windows.Forms.Button();
            this.CboDebug = new System.Windows.Forms.ComboBox();
            this.CboTargetFramework = new System.Windows.Forms.ComboBox();
            this.WorkerILMerge = new System.ComponentModel.BackgroundWorker();
            this.openFile1 = new System.Windows.Forms.OpenFileDialog();
            this.LblPrimaryAssembly = new System.Windows.Forms.Label();
            this.LblPrimaryAssemblyInfo = new System.Windows.Forms.Label();
            this.BoxOutput = new System.Windows.Forms.GroupBox();
            this.LblOutputPath = new System.Windows.Forms.Label();
            this.LblDebug = new System.Windows.Forms.Label();
            this.LblTargetFramework = new System.Windows.Forms.Label();
            this.BoxOptions = new System.Windows.Forms.GroupBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.openToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.openToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.openToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BoxOutput.SuspendLayout();
            this.BoxOptions.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolTips
            // 
            this.ToolTips.AutomaticDelay = 800;
            this.ToolTips.IsBalloon = true;
            // 
            // LinkILMerge
            // 
            this.LinkILMerge.ActiveLinkColor = System.Drawing.SystemColors.HotTrack;
            this.LinkILMerge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LinkILMerge.AutoSize = true;
            this.LinkILMerge.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LinkILMerge.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.LinkILMerge.LinkColor = System.Drawing.SystemColors.HotTrack;
            this.LinkILMerge.Location = new System.Drawing.Point(309, 442);
            this.LinkILMerge.Name = "LinkILMerge";
            this.LinkILMerge.Size = new System.Drawing.Size(263, 13);
            this.LinkILMerge.TabIndex = 37;
            this.LinkILMerge.TabStop = true;
            this.LinkILMerge.Text = "http://research.microsoft.com/~mbarnett/ilmerge.aspx";
            this.ToolTips.SetToolTip(this.LinkILMerge, "ILMerge homepage");
            this.LinkILMerge.VisitedLinkColor = System.Drawing.SystemColors.HotTrack;
            this.LinkILMerge.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkILMerge_LinkClicked);
            // 
            // ChkSignKeyFile
            // 
            this.ChkSignKeyFile.AutoSize = true;
            this.ChkSignKeyFile.Location = new System.Drawing.Point(6, 49);
            this.ChkSignKeyFile.Name = "ChkSignKeyFile";
            this.ChkSignKeyFile.Size = new System.Drawing.Size(105, 17);
            this.ChkSignKeyFile.TabIndex = 5;
            this.ChkSignKeyFile.Text = "Sign with key file";
            this.ToolTips.SetToolTip(this.ChkSignKeyFile, "Sign the output assembly with a key file");
            this.ChkSignKeyFile.UseVisualStyleBackColor = true;
            this.ChkSignKeyFile.CheckedChanged += new System.EventHandler(this.ChkSignKeyFile_CheckedChanged);
            // 
            // ListAssembly
            // 
            this.ListAssembly.AllowDrop = true;
            this.ListAssembly.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListAssembly.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ListAssembly.FormattingEnabled = true;
            this.ListAssembly.HorizontalScrollbar = true;
            this.ListAssembly.IntegralHeight = false;
            this.ListAssembly.Location = new System.Drawing.Point(6, 16);
            this.ListAssembly.Name = "ListAssembly";
            this.ListAssembly.Size = new System.Drawing.Size(548, 87);
            this.ListAssembly.Sorted = true;
            this.ListAssembly.TabIndex = 32;
            this.ToolTips.SetToolTip(this.ListAssembly, "Assemblies to be merged");
            this.ListAssembly.SelectedIndexChanged += new System.EventHandler(this.ListAssembly_SelectedIndexChanged);
            this.ListAssembly.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.ListAssembly_Format);
            this.ListAssembly.DragDrop += new System.Windows.Forms.DragEventHandler(this.ListAssembly_DragDrop);
            this.ListAssembly.DragEnter += new System.Windows.Forms.DragEventHandler(this.ListAssembly_DragEnter);
            this.ListAssembly.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ListAssembly_KeyDown);
            // 
            // ButAddFile
            // 
            this.ButAddFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButAddFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButAddFile.Image = global::ILMergeGui.Properties.Resources.IconAdd;
            this.ButAddFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButAddFile.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ButAddFile.Location = new System.Drawing.Point(442, 109);
            this.ButAddFile.Name = "ButAddFile";
            this.ButAddFile.Size = new System.Drawing.Size(112, 23);
            this.ButAddFile.TabIndex = 33;
            this.ButAddFile.Text = "Add assemblies";
            this.ButAddFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ToolTips.SetToolTip(this.ButAddFile, "Click to select and add assemblies to the list");
            this.ButAddFile.UseVisualStyleBackColor = true;
            this.ButAddFile.Click += new System.EventHandler(this.ButAddFile_Click);
            // 
            // ChkGenerateLog
            // 
            this.ChkGenerateLog.AutoSize = true;
            this.ChkGenerateLog.Location = new System.Drawing.Point(6, 99);
            this.ChkGenerateLog.Name = "ChkGenerateLog";
            this.ChkGenerateLog.Size = new System.Drawing.Size(103, 17);
            this.ChkGenerateLog.TabIndex = 13;
            this.ChkGenerateLog.Text = "Generate log file";
            this.ToolTips.SetToolTip(this.ChkGenerateLog, "Write results to a log file");
            this.ChkGenerateLog.UseVisualStyleBackColor = true;
            this.ChkGenerateLog.CheckedChanged += new System.EventHandler(this.ChkGenerateLog_CheckedChanged);
            // 
            // ChkDelayedSign
            // 
            this.ChkDelayedSign.AutoSize = true;
            this.ChkDelayedSign.Location = new System.Drawing.Point(126, 49);
            this.ChkDelayedSign.Name = "ChkDelayedSign";
            this.ChkDelayedSign.Size = new System.Drawing.Size(87, 17);
            this.ChkDelayedSign.TabIndex = 7;
            this.ChkDelayedSign.Text = "Delayed sign";
            this.ToolTips.SetToolTip(this.ChkDelayedSign, "Use delayed sign");
            this.ChkDelayedSign.UseVisualStyleBackColor = true;
            // 
            // ButLogFile
            // 
            this.ButLogFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButLogFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButLogFile.Enabled = false;
            this.ButLogFile.Image = global::ILMergeGui.Properties.Resources.IconFolder;
            this.ButLogFile.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ButLogFile.Location = new System.Drawing.Point(529, 119);
            this.ButLogFile.Name = "ButLogFile";
            this.ButLogFile.Size = new System.Drawing.Size(25, 21);
            this.ButLogFile.TabIndex = 17;
            this.ToolTips.SetToolTip(this.ButLogFile, "Click to select a log path");
            this.ButLogFile.UseVisualStyleBackColor = true;
            this.ButLogFile.Click += new System.EventHandler(this.ButLogFile_Click);
            // 
            // ChkUnionDuplicates
            // 
            this.ChkUnionDuplicates.AutoSize = true;
            this.ChkUnionDuplicates.Location = new System.Drawing.Point(126, 21);
            this.ChkUnionDuplicates.Name = "ChkUnionDuplicates";
            this.ChkUnionDuplicates.Size = new System.Drawing.Size(105, 17);
            this.ChkUnionDuplicates.TabIndex = 3;
            this.ChkUnionDuplicates.Text = "Union duplicates";
            this.ToolTips.SetToolTip(this.ChkUnionDuplicates, "Union duplicate classes and references");
            this.ChkUnionDuplicates.UseVisualStyleBackColor = true;
            // 
            // TxtLogFile
            // 
            this.TxtLogFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtLogFile.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.TxtLogFile.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.TxtLogFile.Enabled = false;
            this.TxtLogFile.Location = new System.Drawing.Point(6, 118);
            this.TxtLogFile.MaxLength = 255;
            this.TxtLogFile.Name = "TxtLogFile";
            this.TxtLogFile.Size = new System.Drawing.Size(517, 20);
            this.TxtLogFile.TabIndex = 15;
            this.ToolTips.SetToolTip(this.TxtLogFile, "Path to the log file");
            // 
            // ButKeyFile
            // 
            this.ButKeyFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButKeyFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButKeyFile.Enabled = false;
            this.ButKeyFile.Image = global::ILMergeGui.Properties.Resources.IconFolder;
            this.ButKeyFile.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ButKeyFile.Location = new System.Drawing.Point(529, 68);
            this.ButKeyFile.Name = "ButKeyFile";
            this.ButKeyFile.Size = new System.Drawing.Size(25, 21);
            this.ButKeyFile.TabIndex = 11;
            this.ToolTips.SetToolTip(this.ButKeyFile, "Click to select a key file");
            this.ButKeyFile.UseVisualStyleBackColor = true;
            this.ButKeyFile.Click += new System.EventHandler(this.ButKeyFile_Click);
            // 
            // ChkCopyAttributes
            // 
            this.ChkCopyAttributes.AutoSize = true;
            this.ChkCopyAttributes.Checked = true;
            this.ChkCopyAttributes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkCopyAttributes.Location = new System.Drawing.Point(6, 21);
            this.ChkCopyAttributes.Name = "ChkCopyAttributes";
            this.ChkCopyAttributes.Size = new System.Drawing.Size(96, 17);
            this.ChkCopyAttributes.TabIndex = 1;
            this.ChkCopyAttributes.Text = "Copy attributes";
            this.ToolTips.SetToolTip(this.ChkCopyAttributes, "Copy assembly attributes");
            this.ChkCopyAttributes.UseVisualStyleBackColor = true;
            // 
            // TxtKeyFile
            // 
            this.TxtKeyFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtKeyFile.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.TxtKeyFile.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.TxtKeyFile.Enabled = false;
            this.TxtKeyFile.Location = new System.Drawing.Point(6, 68);
            this.TxtKeyFile.MaxLength = 255;
            this.TxtKeyFile.Name = "TxtKeyFile";
            this.TxtKeyFile.Size = new System.Drawing.Size(517, 20);
            this.TxtKeyFile.TabIndex = 9;
            this.ToolTips.SetToolTip(this.TxtKeyFile, "Path to the key file");
            // 
            // TxtOutputAssembly
            // 
            this.TxtOutputAssembly.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtOutputAssembly.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.TxtOutputAssembly.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.TxtOutputAssembly.Location = new System.Drawing.Point(6, 37);
            this.TxtOutputAssembly.MaxLength = 255;
            this.TxtOutputAssembly.Name = "TxtOutputAssembly";
            this.TxtOutputAssembly.Size = new System.Drawing.Size(517, 20);
            this.TxtOutputAssembly.TabIndex = 2;
            this.ToolTips.SetToolTip(this.TxtOutputAssembly, "Path to the output generated assembly");
            // 
            // ButOutputPath
            // 
            this.ButOutputPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButOutputPath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButOutputPath.Image = global::ILMergeGui.Properties.Resources.IconFolder;
            this.ButOutputPath.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ButOutputPath.Location = new System.Drawing.Point(529, 37);
            this.ButOutputPath.Name = "ButOutputPath";
            this.ButOutputPath.Size = new System.Drawing.Size(25, 21);
            this.ButOutputPath.TabIndex = 4;
            this.ToolTips.SetToolTip(this.ButOutputPath, "Click to select the path to the output assembly");
            this.ButOutputPath.UseVisualStyleBackColor = true;
            this.ButOutputPath.Click += new System.EventHandler(this.ButOutputPath_Click);
            // 
            // ButMerge
            // 
            this.ButMerge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButMerge.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButMerge.Enabled = false;
            this.ButMerge.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButMerge.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButMerge.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ButMerge.Location = new System.Drawing.Point(448, 72);
            this.ButMerge.Name = "ButMerge";
            this.ButMerge.Size = new System.Drawing.Size(106, 23);
            this.ButMerge.TabIndex = 10;
            this.ButMerge.Text = "Merge!";
            this.ButMerge.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ToolTips.SetToolTip(this.ButMerge, "Click to start merging");
            this.ButMerge.UseVisualStyleBackColor = true;
            this.ButMerge.Click += new System.EventHandler(this.ButMerge_Click);
            // 
            // CboDebug
            // 
            this.CboDebug.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboDebug.FormattingEnabled = true;
            this.CboDebug.Items.AddRange(new object[] {
            "True",
            "False"});
            this.CboDebug.Location = new System.Drawing.Point(54, 72);
            this.CboDebug.Name = "CboDebug";
            this.CboDebug.Size = new System.Drawing.Size(64, 21);
            this.CboDebug.TabIndex = 6;
            this.ToolTips.SetToolTip(this.CboDebug, "Set the debug parameter");
            // 
            // CboTargetFramework
            // 
            this.CboTargetFramework.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CboTargetFramework.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboTargetFramework.FormattingEnabled = true;
            this.CboTargetFramework.Items.AddRange(new object[] {
            ".NET 2.0",
            ".NET 3.0",
            ".NET 3.5",
            ".NET 4.0"});
            this.CboTargetFramework.Location = new System.Drawing.Point(192, 72);
            this.CboTargetFramework.Name = "CboTargetFramework";
            this.CboTargetFramework.Size = new System.Drawing.Size(227, 21);
            this.CboTargetFramework.TabIndex = 8;
            this.ToolTips.SetToolTip(this.CboTargetFramework, "Set the target framework");
            // 
            // WorkerILMerge
            // 
            this.WorkerILMerge.DoWork += new System.ComponentModel.DoWorkEventHandler(this.WorkerILMerge_DoWork);
            this.WorkerILMerge.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.WorkerILMerge_RunWorkerCompleted);
            // 
            // LblPrimaryAssembly
            // 
            this.LblPrimaryAssembly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LblPrimaryAssembly.AutoSize = true;
            this.LblPrimaryAssembly.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblPrimaryAssembly.Location = new System.Drawing.Point(108, 114);
            this.LblPrimaryAssembly.Name = "LblPrimaryAssembly";
            this.LblPrimaryAssembly.Size = new System.Drawing.Size(16, 13);
            this.LblPrimaryAssembly.TabIndex = 30;
            this.LblPrimaryAssembly.Text = "···";
            this.LblPrimaryAssembly.TextChanged += new System.EventHandler(this.LblPrimaryAssembly_TextChanged);
            // 
            // LblPrimaryAssemblyInfo
            // 
            this.LblPrimaryAssemblyInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LblPrimaryAssemblyInfo.AutoSize = true;
            this.LblPrimaryAssemblyInfo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblPrimaryAssemblyInfo.Location = new System.Drawing.Point(6, 114);
            this.LblPrimaryAssemblyInfo.Name = "LblPrimaryAssemblyInfo";
            this.LblPrimaryAssemblyInfo.Size = new System.Drawing.Size(90, 13);
            this.LblPrimaryAssemblyInfo.TabIndex = 31;
            this.LblPrimaryAssemblyInfo.Text = "Primary assembly:";
            // 
            // BoxOutput
            // 
            this.BoxOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BoxOutput.Controls.Add(this.LblOutputPath);
            this.BoxOutput.Controls.Add(this.TxtOutputAssembly);
            this.BoxOutput.Controls.Add(this.ButOutputPath);
            this.BoxOutput.Controls.Add(this.ButMerge);
            this.BoxOutput.Controls.Add(this.CboDebug);
            this.BoxOutput.Controls.Add(this.LblDebug);
            this.BoxOutput.Controls.Add(this.LblTargetFramework);
            this.BoxOutput.Controls.Add(this.CboTargetFramework);
            this.BoxOutput.Location = new System.Drawing.Point(12, 329);
            this.BoxOutput.Name = "BoxOutput";
            this.BoxOutput.Size = new System.Drawing.Size(560, 101);
            this.BoxOutput.TabIndex = 35;
            this.BoxOutput.TabStop = false;
            this.BoxOutput.Text = "Output";
            // 
            // LblOutputPath
            // 
            this.LblOutputPath.AutoSize = true;
            this.LblOutputPath.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblOutputPath.Location = new System.Drawing.Point(3, 21);
            this.LblOutputPath.Name = "LblOutputPath";
            this.LblOutputPath.Size = new System.Drawing.Size(88, 13);
            this.LblOutputPath.TabIndex = 0;
            this.LblOutputPath.Text = "Output assembly:";
            // 
            // LblDebug
            // 
            this.LblDebug.AutoSize = true;
            this.LblDebug.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblDebug.Location = new System.Drawing.Point(3, 75);
            this.LblDebug.Name = "LblDebug";
            this.LblDebug.Size = new System.Drawing.Size(42, 13);
            this.LblDebug.TabIndex = 0;
            this.LblDebug.Text = "Debug:";
            // 
            // LblTargetFramework
            // 
            this.LblTargetFramework.AutoSize = true;
            this.LblTargetFramework.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblTargetFramework.Location = new System.Drawing.Point(124, 75);
            this.LblTargetFramework.Name = "LblTargetFramework";
            this.LblTargetFramework.Size = new System.Drawing.Size(62, 13);
            this.LblTargetFramework.TabIndex = 0;
            this.LblTargetFramework.Text = "Framework:";
            // 
            // BoxOptions
            // 
            this.BoxOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BoxOptions.Controls.Add(this.ChkSignKeyFile);
            this.BoxOptions.Controls.Add(this.ChkGenerateLog);
            this.BoxOptions.Controls.Add(this.ChkDelayedSign);
            this.BoxOptions.Controls.Add(this.ButLogFile);
            this.BoxOptions.Controls.Add(this.TxtKeyFile);
            this.BoxOptions.Controls.Add(this.ChkUnionDuplicates);
            this.BoxOptions.Controls.Add(this.TxtLogFile);
            this.BoxOptions.Controls.Add(this.ButKeyFile);
            this.BoxOptions.Controls.Add(this.ChkCopyAttributes);
            this.BoxOptions.Location = new System.Drawing.Point(12, 171);
            this.BoxOptions.Name = "BoxOptions";
            this.BoxOptions.Size = new System.Drawing.Size(560, 152);
            this.BoxOptions.TabIndex = 34;
            this.BoxOptions.TabStop = false;
            this.BoxOptions.Text = "Options";
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.SystemColors.HotTrack;
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel1.LinkColor = System.Drawing.SystemColors.HotTrack;
            this.linkLabel1.Location = new System.Drawing.Point(413, 460);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(159, 13);
            this.linkLabel1.TabIndex = 36;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "http://ilmergegui.codeplex.com/";
            this.linkLabel1.VisitedLinkColor = System.Drawing.SystemColors.HotTrack;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem3});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(584, 24);
            this.menuStrip1.TabIndex = 38;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem3
            // 
            this.fileToolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem3,
            this.toolStripSeparator6,
            this.openToolStripMenuItem3,
            this.saveToolStripMenuItem2,
            this.toolStripSeparator7,
            this.exitToolStripMenuItem2});
            this.fileToolStripMenuItem3.Name = "fileToolStripMenuItem3";
            this.fileToolStripMenuItem3.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem3.Text = "File";
            // 
            // newToolStripMenuItem3
            // 
            this.newToolStripMenuItem3.Name = "newToolStripMenuItem3";
            this.newToolStripMenuItem3.Size = new System.Drawing.Size(152, 22);
            this.newToolStripMenuItem3.Text = "New";
            this.newToolStripMenuItem3.Click += new System.EventHandler(this.newToolStripMenuItem3_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(100, 6);
            // 
            // openToolStripMenuItem3
            // 
            this.openToolStripMenuItem3.Name = "openToolStripMenuItem3";
            this.openToolStripMenuItem3.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem3.Text = "Open";
            this.openToolStripMenuItem3.Click += new System.EventHandler(this.openToolStripMenuItem3_Click);
            // 
            // saveToolStripMenuItem2
            // 
            this.saveToolStripMenuItem2.Name = "saveToolStripMenuItem2";
            this.saveToolStripMenuItem2.Size = new System.Drawing.Size(103, 22);
            this.saveToolStripMenuItem2.Text = "Save";
            this.saveToolStripMenuItem2.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(100, 6);
            // 
            // exitToolStripMenuItem2
            // 
            this.exitToolStripMenuItem2.Name = "exitToolStripMenuItem2";
            this.exitToolStripMenuItem2.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem2.Text = "Exit";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // fileToolStripMenuItem1
            // 
            this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            this.fileToolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem1.Text = "File";
            // 
            // newToolStripMenuItem1
            // 
            this.newToolStripMenuItem1.Name = "newToolStripMenuItem1";
            this.newToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.newToolStripMenuItem1.Text = "New";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(149, 6);
            // 
            // openToolStripMenuItem1
            // 
            this.openToolStripMenuItem1.Name = "openToolStripMenuItem1";
            this.openToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem1.Text = "Open";
            // 
            // saveToolStripMenuItem1
            // 
            this.saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
            this.saveToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem1.Text = "Save";
            this.saveToolStripMenuItem1.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(149, 6);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem1.Text = "Exit";
            // 
            // fileToolStripMenuItem2
            // 
            this.fileToolStripMenuItem2.Name = "fileToolStripMenuItem2";
            this.fileToolStripMenuItem2.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem2.Text = "File";
            // 
            // newToolStripMenuItem2
            // 
            this.newToolStripMenuItem2.Name = "newToolStripMenuItem2";
            this.newToolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.newToolStripMenuItem2.Text = "New";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(149, 6);
            // 
            // openToolStripMenuItem2
            // 
            this.openToolStripMenuItem2.Name = "openToolStripMenuItem2";
            this.openToolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem2.Text = "Open";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.ListAssembly);
            this.groupBox1.Controls.Add(this.ButAddFile);
            this.groupBox1.Controls.Add(this.LblPrimaryAssemblyInfo);
            this.groupBox1.Controls.Add(this.LblPrimaryAssembly);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(560, 138);
            this.groupBox1.TabIndex = 39;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Assemblies to merge:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 482);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.LinkILMerge);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.BoxOutput);
            this.Controls.Add(this.BoxOptions);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(440, 520);
            this.Name = "Form1";
            this.Text = "ILMerge-GUI";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.BoxOutput.ResumeLayout(false);
            this.BoxOutput.PerformLayout();
            this.BoxOptions.ResumeLayout(false);
            this.BoxOptions.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ToolTip ToolTips;
        internal System.Windows.Forms.LinkLabel LinkILMerge;
        internal System.Windows.Forms.CheckBox ChkSignKeyFile;
        internal System.Windows.Forms.ListBox ListAssembly;
        internal System.Windows.Forms.Button ButAddFile;
        internal System.Windows.Forms.CheckBox ChkGenerateLog;
        internal System.Windows.Forms.CheckBox ChkDelayedSign;
        internal System.Windows.Forms.Button ButLogFile;
        internal System.Windows.Forms.CheckBox ChkUnionDuplicates;
        internal System.Windows.Forms.TextBox TxtLogFile;
        internal System.Windows.Forms.Button ButKeyFile;
        internal System.Windows.Forms.CheckBox ChkCopyAttributes;
        internal System.Windows.Forms.TextBox TxtKeyFile;
        internal System.Windows.Forms.TextBox TxtOutputAssembly;
        internal System.Windows.Forms.Button ButOutputPath;
        internal System.Windows.Forms.Button ButMerge;
        internal System.Windows.Forms.ComboBox CboDebug;
        internal System.Windows.Forms.ComboBox CboTargetFramework;
        internal System.ComponentModel.BackgroundWorker WorkerILMerge;
        internal System.Windows.Forms.OpenFileDialog openFile1;
        internal System.Windows.Forms.Label LblPrimaryAssembly;
        internal System.Windows.Forms.Label LblPrimaryAssemblyInfo;
        internal System.Windows.Forms.GroupBox BoxOutput;
        internal System.Windows.Forms.Label LblOutputPath;
        internal System.Windows.Forms.Label LblDebug;
        internal System.Windows.Forms.Label LblTargetFramework;
        internal System.Windows.Forms.GroupBox BoxOptions;
        internal System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem2;
        private System.Windows.Forms.GroupBox groupBox1;

    }
}

