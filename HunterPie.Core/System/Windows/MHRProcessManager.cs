﻿using HunterPie.Core.Address.Map;
using HunterPie.Core.Client;
using HunterPie.Core.Logger;
using System.Diagnostics;
using System.IO;

namespace HunterPie.Core.System.Windows
{
    internal class MHRProcessManager : WindowsProcessManager
    {

        public override string Name => "MonsterHunterRise";

        protected override bool ShouldOpenProcess(Process process)
        {
            if (!process.MainWindowTitle.ToUpper().StartsWith("MONSTERHUNTERRISE"))
                return false;

            string riseVersion;
            try
            {
                riseVersion = process.MainModule.FileVersionInfo.FileVersion;
            } catch
            {
                Log.Error("Failed to get Monster Hunter Rise version, missing permissions. Try running as administrator.");
                pooler.Dispose();
                return false;
            }


            Log.Info($"Detected Monster Hunter Rise version: {riseVersion}");

            AddressMap.Parse(Path.Combine(ClientInfo.AddressPath, $"MonsterHunterRise.{riseVersion}.map"));

            if (!AddressMap.IsLoaded)
                return false;

            return true;
        }
    }
}
