# BetterLobby for Zumbi Blocks 2

BetterLobby is a lobby enhancement mod for **Zumbi Blocks 2**.

## Features

- **Insane** difficulty added to the difficulty selector
- Fixed the bug that allowed clients to interact with the difficulty selector
- Prevents the server host from starting the game until all players are ready

---

## Getting Started

Ready to get started with modding Zumbi Blocks 2?  
Simply download `BetterLobby.dll` from the [releases page](https://github.com/nyawoi/BetterLobby/releases), and follow the guide below.

### Prerequisites

This mod uses the [BepInEx modding framework](https://github.com/BepInEx/BepInEx) to dynamically mod the game.  
This means the mod's changes are not permanent, unlike patching the assembly manually using software such as [dnSpy](https://github.com/dnSpy/dnSpy).

- [BepInEx 5](https://github.com/BepInEx/BepInEx/releases)

The file you need depends on your system architecture. If you're on a modern computer, it's very likely 64bit.  
Download the ZIP file that starts with `BepInEx_x64`.

**NOTE:** Do NOT get any files for BepInEx 6. It is currently unstable and does not work with BepInEx 5 plugins.

### Dependencies

In order to make modding quicker and easier, this mod relies on the works on amazingly talented people.  
Below are the two dependencies you'll have to install alongside this mod.

- [MonoMod.RuntimeDetour.HookGen](https://github.com/MonoMod/MonoMod/releases)
- [BepInEx.MonoMod.HookGenPatcher](https://github.com/harbingerofme/Bepinex.Monomod.HookGenPatcher/releases)

For **MonoMod.RuntimeDetour.HookGen**, download the ZIP file that ends in `net452`.  
For **BepInEx.MonoMod.HookGenPatcher**, download the file that ends in `.dll`.

### Installing BepInEx

Installing BepInEx is incredibly easy and won't take much time.

In your Steam client, right-click **Zumbi Blocks 2**, hover over `Manage`, then click on `Browse local files`.  
This will open the game folder in Windows Explorer. If it didn't appear on screen, click on the Explorer icon in the taskbar or tab over to it.

Next, extract the BepInEx ZIP file. This will result in three files and one folder: `changelog.txt`, `doorstop_config.ini`, `winhttp.dll`, and a`BepInEx` folder.

Drag everything into the `Zumbi Blocks 2 Open Alpha` folder. The `BepInEx` folder should now be next to the `MonoBleedingEdge` and `ZumbiBlocks2_Data` folders.

Run the game--either from Steam or the `ZumbiBlocks2.exe` file, and wait for the game to load.  
**You're done!** BepInEx is now installed. Close the game, but keep the game folder open.

For a more comprehensive guide on [installing BepInEx](https://docs.bepinex.dev/articles/user_guide/installation/index.html), as well as several articles on [using it](https://docs.bepinex.dev/articles/user_guide/configuration.html), please refer to the [official BepInEx documentation site](https://docs.bepinex.dev/).

### Installing BepInEx.MonoMod.HookGenPatcher

That was pretty simple, wasn't it? Don't worry, installing the HookGenPatcher is just as easy!

With BepInEx now installed, there will be a `patchers` folder inside the original `BepInEx` folder.  
Open it and create a new folder named `BepInEx.MonoMod.HookGenPatcher`  
The name doesn't actually matter, but a name like this will help us know what it is.

Inside your new folder, drag and drop the `BepInEx.MonoMod.HookGenPatcher.dll` file you downloaded earlier.  
This file works alongside some files from the MonoMod ZIP file. Let's add them!

Extract the MonoMod ZIP file, and you'll be greeted by several files. It may seem a bit intimidating, but don't worry, we only need **two** of them.

Find `MonoMod.exe` and `MonoMod.RuntimeDetour.HookGen.exe`, and drag them into the `BepInEx.MonoMod.HookGenPatcher.dll` folder.

Again, run the game, wait for it to load, and close it once done.  
Your game may freeze for a bit, as the patcher is working on making the game's modding API easier to access.

**That's it!** The HookGenPatcher is now installed. Keep that Zumbi Blocks 2 folder open, since we're now about to install **BetterLobby**.

### Installing BetterLobby

You're almost done! Just one more file to go.

Head back to the main `BepInEx` folder, and you'll see a folder named `plugins`.  
Open it and create a new folder named `BetterLobby`.  
(See the `MMHOOK` folder? That was created by the HookGenPatcher!)

Drag the `BetterLobby.dll` file you downloaded earlier into the `BetterLobby` folder, and you're done!  
Launch the game, start a singleplayer or multiplayer lobby, and experience the changes.

---

## Building From Source

Want to mess around with the code and see what else can be done with it? You can go right ahead!

### Requirements

- [Zumbi Blocks 2](https://store.steampowered.com/app/1941780/Zumbi_Blocks_2_Open_Alpha/)
- [BepInEx 5](https://github.com/BepInEx/BepInEx/releases)
- [.NET 6.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) or [newer](https://dotnet.microsoft.com/en-us/download)
- [.NET Framework 4.8.1](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net481)

### Quick Start

This guide assumes you already have **Zumbi Blocks 2**, **BepInEx**, and **BepInEx.MonoMod.HookGenPatcher** installed.  
If you have not yet completed installation, follow the [Quick Start](#quick-start) guide above and return when done.

1. Using your IDE, CLI, or Git-oriented desktop program, [clone this repository](https://docs.github.com/en/repositories/creating-and-managing-repositories/cloning-a-repository).
2. Open the local repository with your IDE. If prompted to trust the project, accept.
3. **(Optional)** If your Steam library is not on the C: drive, open `BetterLobby.csproj.user`, and enter your Steam library location.

You're done! Since this mod builds upon the [Zumbi Blocks 2 Steam template](https://github.com/Zumbi-Blocks-2-Modding/ZumbiBlocks2.PluginTemplate.Steam), all configuration is taken care of. You can click **Build**, and it'll just work.

---

## Community

Run into issues while installing the mod? If so, join the official [Zumbi Blocks 2 Discord Server](https://discord.gg/eCWaHR9)!  
There's a modding channel where you can share and discuss everything related to mods.
