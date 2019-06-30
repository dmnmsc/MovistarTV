// Copyright (C) 2014-2019, GitHub/Codeplex user AlphaCentaury
// 
// All rights reserved, except those granted by the governing license of this software.
// See 'license.txt' file in the project root for complete license information.
// 
// http://www.alphacentaury.org/movistartv https://github.com/AlphaCentaury

using System;
using System.Xml.Serialization;

namespace IpTviewr.UiServices.Configuration.Schema2014.ContentProvider
{
    [Serializable]
    [XmlType(TypeName="SP-FriendlyNames", Namespace=SerializationCommon.XmlNamespace)]
    public class SpFriendlyNames : ILocalizedObject
    {
        [XmlAttribute("culture")]
        public string CultureName
        {
            get;
            set;
        } // CultureName

        [XmlElement("Provider")]
        public SpFriendlyName[] Names
        {
            get;
            set;
        } // Names
    } // class ServiceProviderFriendlyName
} // namespace
