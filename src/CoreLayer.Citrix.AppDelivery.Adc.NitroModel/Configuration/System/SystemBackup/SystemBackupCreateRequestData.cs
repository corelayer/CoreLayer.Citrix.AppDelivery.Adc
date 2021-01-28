﻿using CoreLayer.Citrix.AppDelivery.Adc.NitroInterfaces;

namespace CoreLayer.Citrix.AppDelivery.Adc.NitroModel.Configuration.System.SystemBackup
{
    public class SystemBackupCreateRequestData : INitroRequestData
    {
        public string Level { get; }
        public string Filename { get; set; } = string.Empty;
        public string Comment { get; set; } = string.Empty;


        public SystemBackupCreateRequestData(SystemBackupLevel level)
        {
            Level = level.ToString();
        }

        public SystemBackupCreateRequestData(SystemBackupLevel level, string fileName) : this(level)
        {
            Filename = fileName.Replace(".tgz", "");
        }

        public SystemBackupCreateRequestData(SystemBackupLevel level, string fileName, string comment) : this(level, fileName)
        {
            Comment = comment;
        }
    }
}
