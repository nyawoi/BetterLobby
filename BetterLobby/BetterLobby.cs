using BepInEx;

namespace AetharNet.Mods.ZumbiBlocks2.BetterLobby;

[BepInPlugin(PluginGUID, PluginName, PluginVersion)]
public class BetterLobby : BaseUnityPlugin
{
    public const string PluginGUID = "AetharNet.Mods.ZumbiBlocks2.BetterLobby";
    public const string PluginAuthor = "awoi";
    public const string PluginName = "BetterLobby";
    public const string PluginVersion = "0.1.0";
    
    private void Awake()
    {
        Logger.LogInfo($"Initialized plugin: {PluginName} ({PluginGUID}@{PluginVersion})");
        Logger.LogInfo($"Current Zumbi Blocks 2 version is {ZBMain.instance.gameVersion}");
    }
}
