using System;
using System.Linq;
using ACT_FFXIV.Aetherbridge;
using Advanced_Combat_Tracker;
using static Advanced_Combat_Tracker.ActGlobals;

namespace ACT_Chat.ACT
{
    public class ACTWrapper : IACTWrapper
    {
        private static volatile ACTWrapper _actWrapper;
        private static readonly object Lock = new object();


        public IActPluginV1 GetACTPlugin(string pluginFileName, string pluginStatus)
        {
            var actPluginInstances = oFormActMain.ActPlugins.Where(actPlugin =>
                    actPlugin.pluginFile.Name.ToUpper().Contains(pluginFileName.ToUpper()) &&
                    actPlugin.lblPluginStatus.Text.ToUpper().Contains(pluginStatus.ToUpper()))
                .Select(actPlugin => actPlugin.pluginObj).ToList();

            switch (actPluginInstances.Count)
            {
                case 0:
                    throw new Exception("Plugin not found: " + pluginFileName);
                case 1:
                    return actPluginInstances[0];
                default:
                    throw new Exception("Multiple plugins found: " + pluginFileName);
            }
        }

        public string GetAppDataFolderFullName()
        {
            return oFormActMain.AppDataFolder.FullName;
        }

        public string GetCharacterName()
        {
            return charName;
        }

        //public void Restart(string message)
        //{
        //    var method = oFormActMain.GetType().GetMethod("RestartACT");
        //    if (method != null) method.Invoke(oFormActMain, new object[] { true, message });
        //}

        public static IACTWrapper GetInstance()
        {
            if (_actWrapper != null) return _actWrapper;

            lock (Lock)
            {
                if (_actWrapper == null) _actWrapper = new ACTWrapper();
            }

            return _actWrapper;
        }

    }
}