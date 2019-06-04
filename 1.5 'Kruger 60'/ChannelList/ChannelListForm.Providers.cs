// Copyright (C) 2014-2019, GitHub/Codeplex user AlphaCentaury
// 
// All rights reserved, except those granted by the governing license of this software.
// See 'license.txt' file in the project root for complete license information.
// 
// http://www.alphacentaury.org/movistartv https://github.com/AlphaCentaury

using IpTviewr.Common.Telemetry;
using IpTviewr.Services.EpgDiscovery;
using IpTviewr.UiServices.Common.Forms;
using IpTviewr.UiServices.Configuration.Logos;
using IpTviewr.UiServices.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IpTviewr.ChannelList
{
    partial class ChannelListForm
    {
        #region 'Provider' menu event handlers

        private void menuItemProviderSelect_Click(object sender, EventArgs e)
        {
            SafeCall(Implementation_menuItemProviderSelect_Click, sender, e);
        } // menuItemProviderSelect_Click

        private void menuItemProviderDetails_Click(object sender, EventArgs e)
        {
            SafeCall(Implementation_menuItemProviderDetails_Click, sender, e);
        } // menuItemProviderDetails_Click

        #endregion

        #region 'Provider' menu event handlers implementation

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        private void Implementation_menuItemProviderSelect_Click(object sender, EventArgs e)
        {
            // can't select a new provider if a services scan is in progress; the user must manually cancel it first
            if (IsScanActive()) return;
            SelectProvider();
        } // Implementation_menuItemProviderSelect_Click

        private void Implementation_menuItemProviderDetails_Click(object sender, EventArgs e)
        {
            if (SelectedServiceProvider == null) return;

            using (var dlg = new PropertiesDialog()
            {
                Caption = Properties.Texts.SPProperties,
                ItemProperties = SelectedServiceProvider.DumpProperties(),
                Description = SelectedServiceProvider.DisplayName,
                ItemIcon = SelectedServiceProvider.Logo.GetImage(LogoSize.Size64, true),
            })
            {
                dlg.ShowDialog(this);
            } // using
        } // Implementation_menuItemProviderDetails_Click

        private void SelectProvider()
        {
            using (var dialog = new SelectProviderDialog())
            {
                dialog.SelectedServiceProvider = SelectedServiceProvider;
                var result = dialog.ShowDialog(this);
                BasicGoogleTelemetry.SendScreenHit(this);
                if (result != DialogResult.OK) return;

                SelectedServiceProvider = dialog.SelectedServiceProvider;
                ServiceProviderChanged();
            } // dialog
        } // SelectProvider

        #endregion

        #region Auxiliary methods: providers

        private void ServiceProviderChanged()
        {
            Properties.Settings.Default.LastSelectedServiceProvider = (SelectedServiceProvider != null) ? SelectedServiceProvider.Key : null;
            Properties.Settings.Default.Save();

            labelProviderName.Text = Properties.Texts.NotSelectedServiceProvider;
            labelProviderDescription.Text = null;
            pictureProviderLogo.Image = null;
            menuItemProviderDetails.Enabled = false;
            menuItemChannelRefreshList.Enabled = false;
            menuItemChannelEditList.Enabled = false;
            SetBroadcastDiscovery(null);

            if (SelectedServiceProvider == null) return;

            labelProviderName.Text = SelectedServiceProvider.DisplayName;
            labelProviderDescription.Text = SelectedServiceProvider.DisplayDescription;
            pictureProviderLogo.Image = SelectedServiceProvider.Logo.GetImage(LogoSize.Size32, true);

            menuItemProviderDetails.Enabled = true;
            menuItemChannelRefreshList.Enabled = true;
            menuItemChannelEditList.Enabled = true;

            // TODO: clean-up
            if (enable_Epg)
            {
                var downloader = new EpgDownloader("239.0.2.145:3937");
                downloader.StartAsync(EpgDatastore);
            } // if

            SetBroadcastDiscovery(null);
            LoadBroadcastDiscovery(true);
        } // ServiceProviderChanged

        #endregion
    } // partial class ChannelListForm
} // namespace
