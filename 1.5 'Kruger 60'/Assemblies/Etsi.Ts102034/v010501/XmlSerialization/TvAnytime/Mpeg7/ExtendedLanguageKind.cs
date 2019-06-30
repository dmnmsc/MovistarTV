// Copyright (C) 2014-2019, GitHub/Codeplex user AlphaCentaury
// 
// All rights reserved, except those granted by the governing license of this software.
// See 'license.txt' file in the project root for complete license information.
// 
// http://www.alphacentaury.org/movistartv https://github.com/AlphaCentaury

using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace Etsi.Ts102034.v010501.XmlSerialization.TvAnytime.Mpeg7
{
    [GeneratedCode("myxsdtool", "0.0.0.0")]
    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "urn:tva:mpeg7:2008")]
    public enum ExtendedLanguageKind // original: ExtendedLanguageTypeType
    {
        [XmlEnum("original")]
        Original,
        [XmlEnum("dubbed")]
        Dubbed,
        [XmlEnum("background")]
        Background,
    } // enum ExtendedLanguageKind
} // namespace
