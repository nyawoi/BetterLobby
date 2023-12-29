using BepInEx;
using HarmonyLib;
using UnityEngine;
using UnityEngine.UI;

namespace AetharNet.Mods.ZumbiBlocks2.BetterLobby;

[BepInPlugin(PluginGUID, PluginName, PluginVersion)]
public class BetterLobby : BaseUnityPlugin
{
    public const string PluginGUID = "AetharNet.Mods.ZumbiBlocks2.BetterLobby";
    public const string PluginAuthor = "awoi";
    public const string PluginName = "BetterLobby";
    public const string PluginVersion = "0.1.0";
    
    private static Sprite NoIcon;

    private void Awake()
    {
        On.LobbyMenu.OnEnable += On_LobbyMenu_OnEnable;
        On.LobbyMenu.LaunchMatch += On_LobbyMenu_LaunchMatch;
        On.LobbyController.AddPlayer += On_LobbyController_AddPlayer;
        On.LobbyController.SetPlayerReady += On_LobbyController_SetPlayerReady;
    }

    private static void On_LobbyMenu_OnEnable(On.LobbyMenu.orig_OnEnable orig, LobbyMenu self)
    {
        // Add Insane difficulty to the selector
        self.difficultySelector.options.Add(new UISelector.Option
        {
            tag = "<insane>",
            imgSprite = null,
            textColor = new Color32(208, 89, 232, 255)
        });

        // If not the lobby host, remove difficulty selector buttons
        var clientPlayer = self.lobby.players.Find(player => player.ItsMe());
        if (clientPlayer.type == LobbyPlayer.Type.Client)
        {
            self.difficultySelectorButtons.Do(Destroy);
        }

        orig(self);

        // Retrieve icon for visual feedback
        if (NoIcon is null)
        {
            foreach (var sprite in Resources.FindObjectsOfTypeAll<Sprite>())
            {
                if (sprite is not null && sprite.name == "NoIcon")
                {
                    NoIcon = sprite;
                    break;
                }
            }
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
    
    private static int On_LobbyController_AddPlayer(On.LobbyController.orig_AddPlayer orig, LobbyController self, SteamP2PConnection connection, string playername, SkinDatabase.SkinID skinid, SkinDatabase.Gender skingender, int skincolor, bool applyloadout)
    {
        // If the connection is null, the host is starting a server;
        // otherwise, it's a player joining the lobby
        if (connection != null)
        {
            // Set the ready icon to false
            var startButtonObject = self.lobbyMenu.startButton.transform.GetChild(1).gameObject;
            var buttonImage = startButtonObject.GetComponent<Image>();
            buttonImage.overrideSprite = NoIcon;
        }
        
        return orig(self, connection, playername, skinid, skingender, skincolor, applyloadout);
    }

    private static void On_LobbyController_SetPlayerReady(On.LobbyController.orig_SetPlayerReady orig, LobbyController self, int lobbyid, bool isready)
    {
        // Call the original method first, so the `isReady` field is set
        orig(self, lobbyid, isready);
        
        var startButtonObject = self.lobbyMenu.startButton.transform.GetChild(1).gameObject;
        var buttonImage = startButtonObject.GetComponent<Image>();
        buttonImage.overrideSprite = self.players.TrueForAll(player => player.isReady) ? null : NoIcon;
    }
}
