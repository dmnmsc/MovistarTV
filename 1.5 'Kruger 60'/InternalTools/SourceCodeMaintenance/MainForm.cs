// Copyright (C) 2014-2019, GitHub/Codeplex user AlphaCentaury
// 
// All rights reserved, except those granted by the governing license of this software.
// See 'license.txt' file in the project root for complete license information.
// 
// http://www.alphacentaury.org/movistartv https://github.com/AlphaCentaury

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AlphaCentaury.Tools.SourceCodeMaintenance;
using IpTviewr.UiServices.Common.Forms;

namespace SourceCodeMaintenance
{
    public partial class MainForm : CommonBaseForm
    {
        public MainForm()
        {
            InitializeComponent();
        } // constructor

        private void MainForm_Load(object sender, EventArgs e)
        {

        } // MainForm_Load

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var form = new SelectToolDialog();
            if (form.ShowDialog(this) != DialogResult.OK) return;
            var selected = form.SelectedTool;
            SafeCall(() =>
            {
                var form = selected.Value.GetUi();
                form.MdiParent = this;
                form.Show();
            });
        } // newToolStripMenuItem_Click

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        } // cascadeToolStripMenuItem_Click

        private void tileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        } // tileHorizontalToolStripMenuItem_Click

        private void tileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        } // tileVerticalToolStripMenuItem_Click

        private void arrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        } // arrangeIconsToolStripMenuItem_Click

        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var mdiChild in MdiChildren)
            {
                mdiChild.Close();
            } // foreach
        } // closeAllToolStripMenuItem_Click

        private void windowsToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            var enabled = (MdiChildren.Length != 0);
            arrangeToolStripMenuItem.Enabled = enabled;
            closeAllToolStripMenuItem.Enabled = enabled;
        } // windowsToolStripMenuItem_DropDownOpening
    } // class MainForm
} // namespace
