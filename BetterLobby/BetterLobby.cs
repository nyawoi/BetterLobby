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
        // NOTE: Adding more difficulties via the selector will not work
        // This merely exposes the currently available Insane difficulty
        self.difficultySelector.options.Add(new UISelector.Option
        {
            tag = "<insane>",
            imgSprite = null,
            textColor = new Color32(208, 89, 232, 255)
        });

        // Retrieve the client's player object
        var clientPlayer = self.lobby.players.Find(player => player.ItsMe());
        // If not the lobby host, remove difficulty selector buttons
        if (clientPlayer.type == LobbyPlayer.Type.Client)
        {
            self.difficultySelectorButtons.Do(Destroy);
        }

        // Continue with the method's normal operations
        orig(self);

        // If the NoIcon sprite has not been retrieved yet,
        if (NoIcon is null)
        {
            // go through every sprite currently loaded,
            foreach (var sprite in Resources.FindObjectsOfTypeAll<Sprite>())
            {
                // and find the one named "NoIcon"
                if (sprite is not null && sprite.name == "NoIcon")
                {
                    // Save the NoIcon sprite to provide visual feedback
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
            // Retrieve the start button icon
            var imageComponent = GetStartButtonImageComponent(self.lobbyMenu);
            // Set the ready icon to false
            imageComponent.overrideSprite = NoIcon;
        }
        
        // Continue with the method's normal operations
        return orig(self, connection, playername, skinid, skingender, skincolor, applyloadout);
    }

    private static void On_LobbyController_SetPlayerReady(On.LobbyController.orig_SetPlayerReady orig, LobbyController self, int lobbyid, bool isready)
    {
        // Call the original method first, so the `isReady` field is set
        orig(self, lobbyid, isready);
        
        // Retrieve the start button icon
        var imageComponent = GetStartButtonImageComponent(self.lobbyMenu);
        // Check if all players are ready
        var allReady = self.players.TrueForAll(player => player.isReady);
        
        // Override the default sprite (YesIcon) with NoIcon if not all players are ready
        imageComponent.overrideSprite = allReady ? null : NoIcon;
    }

    private static Image GetStartButtonImageComponent(LobbyMenu lobbyMenu)
    {
        // The start button has three children: (0) background, (1) icon, (2) text
        // We must first retrieve the icon's GameObject,
        var startButtonImageObject = lobbyMenu.startButton.transform.GetChild(1).gameObject;
        // so we can retrieve its Image component, which allows us to change its icon
        var startButtonImageComponent = startButtonImageObject.GetComponent<Image>();

        return startButtonImageComponent;
    }
}
