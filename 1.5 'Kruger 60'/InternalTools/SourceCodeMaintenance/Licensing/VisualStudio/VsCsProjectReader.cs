// Copyright (C) 2014-2019, GitHub/Codeplex user AlphaCentaury
// 
// All rights reserved, except those granted by the governing license of this software.
// See 'license.txt' file in the project root for complete license information.
// 
// http://www.alphacentaury.org/movistartv https://github.com/AlphaCentaury

using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace AlphaCentaury.Tools.SourceCodeMaintenance.Licensing.VisualStudio
{
    public class VsCsProjectReader : IVsProjectReader
    {
        #region Implementation of IVsProjectReader

        public string[] SupportedExtensions { get; } = { ".csproj" };

        public VsProject Read(Stream stream, string type)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));
            if (string.IsNullOrEmpty(type)) throw new ArgumentNullException(nameof(type));
            if (!string.Equals(type, ".csproj", StringComparison.InvariantCultureIgnoreCase)) throw new ArgumentOutOfRangeException(nameof(type), type, null);

            var project = new VsProject();
            var xmlProj = XElement.Load(stream);

            // project properties
            foreach (var item in xmlProj.Elements("PropertyGroup"))
            {
                switch (item.Name.LocalName)
                {
                    case "ProjectGuid":
                        if (project.Guid != Guid.Empty) throw new InvalidDataException();
                        project.Guid = Guid.Parse(item.Value);
                        break;

                    case "OutputType":
                        if (project.Type != null) throw new InvalidDataException();
                        project.Type = item.Value;
                        break;

                    case "RootNamespace":
                        if (project.Namespace != null) throw new InvalidDataException();
                        project.Namespace = item.Value;
                        break;

                    case "AssemblyName":
                        if (project.AssemblyName != null) throw new InvalidDataException();
                        project.AssemblyName = item.Value;
                        break;
                } // switch
            } // foreach

            // project references
            var q2 = from itemGroup in xmlProj.Elements("ItemGroup")
                    from reference in itemGroup.Elements("ProjectReference")
                    let guid = reference.Element("Project")
                    where guid != null
                    select Guid.Parse(guid.Value);

            project.ReferencedProjects = q2.ToList();
            if (project.ReferencedProjects.Count == 0)
            {
                project.ReferencedProjects = null;
            } // if

            return project;
        } // Read

        #endregion
    } // class VsCsProjectReader
} // namespace
