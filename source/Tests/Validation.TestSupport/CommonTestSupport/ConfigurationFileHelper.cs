﻿// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using EnterpriseLibrary.Common.Configuration;

namespace EnterpriseLibrary.Common.TestSupport.Configuration
{
    public class ConfigurationFileHelper : IDisposable
    {
        private System.Configuration.Configuration configuration;
        private IConfigurationSource configurationSource;
        private string configurationFileName;

        public ConfigurationFileHelper(IDictionary<string, ConfigurationSection> sections)
        {
            configurationFileName = Path.GetTempFileName();
            File.Copy("test.exe.config", configurationFileName, true);

            configuration = GetConfigurationForCustomFile(configurationFileName);

            SaveSections(configuration, sections);

            configurationSource = GetConfigurationSourceForCustomFile(configurationFileName);
        }

        public static IConfigurationSource GetConfigurationSourceForCustomFile(string fileName)
        {
            return new FileConfigurationSource(fileName, false);
        }

        public static System.Configuration.Configuration GetConfigurationForCustomFile(string fileName)
        {
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
            fileMap.ExeConfigFilename = fileName;
            File.SetAttributes(fileMap.ExeConfigFilename, FileAttributes.Normal);
            return ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
        }

        private static void SaveSections(System.Configuration.Configuration configuration,
                                    IDictionary<string, ConfigurationSection> sections)
        {
            foreach (string sectionName in sections.Keys)
            {
                configuration.Sections.Remove(sectionName);
                configuration.Sections.Add(sectionName, sections[sectionName]);
            }

            configuration.Save();
        }

        public IConfigurationSource ConfigurationSource
        {
            get { return this.configurationSource; }
        }

        #region IDisposable Members

        public void Dispose()
        {
            File.Delete(this.configurationFileName);
        }

        #endregion
    }
}
