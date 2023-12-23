using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;

namespace AetharNet.Mods.ZumbiBlocks2.BetterLobby;

[BepInPlugin(PluginGUID, PluginName, PluginVersion)]
public class BetterLobby : BaseUnityPlugin
{
    public const string PluginGUID = "AetharNet.Mods.ZumbiBlocks2.BetterLobby";
    public const string PluginAuthor = "awoi";
    public const string PluginName = "BetterLobby";
    public const string PluginVersion = "0.1.0";

    private new static ManualLogSource Logger;
    
    private void Awake()
    {
        Logger = base.Logger;
        On.LobbyMenu.OnEnable += On_LobbyMenu_OnEnable;
        On.LobbyMenu.LaunchMatch += On_LobbyMenu_LaunchMatch;
    }

    private static void On_LobbyMenu_OnEnable(On.LobbyMenu.orig_OnEnable orig, LobbyMenu self)
    {
        // Add Insane difficulty to the selector
        self.difficultySelector.options.Add(new UISelector.Option
        {
            tag = "<insane>",
            imgSprite = null,
            textColor = new Color32(208, 89,232, 255)
        });

        // If not the lobby host, remove difficulty selector buttons
        var clientPlayer = self.lobby.players.Find(player => player.ItsMe());
        if (clientPlayer.type == LobbyPlayer.Type.Host)
        {
            self.difficultySelectorButtons.Do(Destroy);
        }
    }
    
    private static void On_LobbyMenu_LaunchMatch(On.LobbyMenu.orig_LaunchMatch orig, LobbyMenu self)
    {
        // Only start match if all players are ready
        if (self.lobby.players.TrueForAll(player => player.isReady))
        {
            orig(self);
        }
    }
}
