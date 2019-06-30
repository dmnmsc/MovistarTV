// Copyright (C) 2014-2019, GitHub/Codeplex user AlphaCentaury
// 
// All rights reserved, except those granted by the governing license of this software.
// See 'license.txt' file in the project root for complete license information.
// 
// http://www.alphacentaury.org/movistartv https://github.com/AlphaCentaury

using System;
using System.Drawing;

namespace IpTviewr.UiServices.Configuration
{
    public interface IConfigurationItemRegistration
    {
        Guid Id
        {
            get;
        } // Id

        Type ItemType
        {
            get;
        } // ItemType

        int DirectIndex
        {
            get;
            set;
        } // DirectIndex

        IConfigurationItem CreateDefault();

        bool HasEditor
        {
            get;
        } // HasEditor

        string EditorDisplayName
        {
            get;
        } // EditorDisplayName

        string EditorDescription
        {
            get;
        } // EditorDescription

        Image EditorImage
        {
            get;
        } // EditorImage

        int EditorPriority
        {
            get;
        } // EditorPriority

        IConfigurationItemEditor CreateEditor(IConfigurationItem data);
    } // interface IConfigurationItemRegistration
} // namespace
