// Copyright (C) 2014-2019, GitHub/Codeplex user AlphaCentaury
// 
// All rights reserved, except those granted by the governing license of this software.
// See 'license.txt' file in the project root for complete license information.
// 
// http://www.alphacentaury.org/movistartv https://github.com/AlphaCentaury

using System.Windows.Forms;

namespace IpTviewr.UiServices.Configuration
{
    public interface IConfigurationItemEditor
    {
        UserControl UserInterfaceItem
        {
            get;
        } // UserInterfaceItem

        bool SupportsWinFormsValidation
        {
            get;
        } // SupportsWinFormsValidation

        bool IsDataChanged
        {
            get;
        } // IsDataChanged

        bool IsAppRestartNeeded
        {
            get;
        } // IsAppRestartNeeded

        bool Validate();
        IConfigurationItem GetNewData();

        void EditorClosing(out bool cancelClose);
        void EditorClosed(bool userCancel);
    } // interface IConfigurationFormItem
} // namespace
