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
    [XmlType(Namespace=SerializationCommon.XmlNamespace, AnonymousType=true)]
    public class SpFriendlyName
    {
        [XmlAttribute("domainName")]
        public string Domain
        {
            get;
            set;
        } // Domain

        [XmlText]
        public string Name
        {
            get;
            set;
        } // Name
    } // class SpFriendlyName
} // namespace
