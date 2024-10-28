# Digimon World Next Order More Education Mod

This mod gives the option to force an education action (praising, scolding) after a certain amount of in-game time if an action is not triggered by the game normally.

A config file is available after the first execution with the mod in the BepInEx's plugins folder.

You can configure the amount of time until an action is forced so you can give the game time to trigger its own and balance the game as you see fit. The minimum time between actions is still 2 in-game hours as defined by the game itself, and the default configuration for the mod adds another 2 hours, meaning every 4 hours an action will be forced to happen if the game didn't automatically trigger one (whenever an action is triggered by the game or this mod the timer is reset).

Note that this mod will force an education action while in the training hall, unlike vanilla where you'd need to change map for one to trigger (if it did trigger).

Also note that due to the way the game handles the education timer when it's 0, the configured time for this mod starts counting after that.

Example: Last education was at 21:00, your digimon go to sleep at 22:00 and wake up at 06:00, at 06:00 the timer is now 0 since 9 hours have passed, from here the configured time for the mod will start counting and forcibly trigger an action at 11:00.

## Installation

1. Install [BepInEx](https://github.com/BepInEx/BepInEx) ([Tutorial by Yasha-jin](https://github.com/Yasha-jin/DWNOModdingGuides/blob/main/Guides/HowToInstallBepInExForDWNO.md))
2. Download the latest release from the [Releases Tab](https://github.com/paulo27ms/DWNO-MoreEducation/releases)
3. Copy the `DWNO_MoreEducation.dll` into the `plugins` folder of BepinEx
