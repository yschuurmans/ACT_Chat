using Advanced_Combat_Tracker;
using System;

namespace ACT_Chat.ACT
{
	public interface IACTWrapper
	{
		//bool ACTLogLineParserEnabled { get; set; }
		IActPluginV1 GetACTPlugin(string pluginFileName, string pluginStatus);
		//void DeInit();
		string GetAppDataFolderFullName();
		string GetCharacterName();
		//void Restart(string message);
	}
}