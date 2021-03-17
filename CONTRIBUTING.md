# CONTRIBUTING

If you would like to contribute to the development of this mod, feel free to post a pull request!
Here I will explain how I have set up my dev environment for working with multiple branches of
Bannerlord. If I have accepted your changes I will credit you by your GitHub username in the
changelog and you will be named as a contributor here on the GitHub project page.

Note: This guide is intended for Windows because that is the system I use, but if you are a Linux
user you probably have the knowledge to adapt it to your system anyway. 

## Setting up Bannerlord using SteamCMD

### Prerequisites
- A Steam account that owns Mount & Blade II: Bannerlord
- About 90GB of available disk space for two instances of the game

### Installing SteamCMD
1. Download SteamCMD from [here](https://steamcdn-a.akamaihd.net/client/installer/steamcmd.zip). AFAIK this is an official Valve mirror.
   Documentation for SteamCDM can be found [here](https://developer.valvesoftware.com/wiki/SteamCMD).
2. Extract the ZIP file to an easily accessible location like ``C:\SteamCMD`` and remember that location for later.
3. Run `steamcmd.exe` once and let it download the necessary files.
4. When it has finished type `quit` to exit SteamCMD.

### Installing Bannerlord Stable
1. Create a new `.bat` file in the SteamCMD folder and name it something like `install_stable.bat`.
2. Open the file with a text editor and enter the following:
   ````
   steamcmd.exe +login [username] +force_install_dir .\mb2b_stable +app_update "261550 validate" +quit
   ````
3. Replace `[username]` with the Steam username that owns the game.
4. Save and close the file, then execute it from a console or from the explorer.
5. It will ask for a password. Enter the password of the Steam user and press continue.
6. It will then download the game in the latest stable branch into a folder called `mb2b_stable` in the SteamCMD directory.
7. Whenever the game has an update ready, you can just run the batch file again and it will update just like the Steam client.

### Installing Bannerlord Beta
1. Create a new `.bat` file in the SteamCMD folder and name it something like `install_beta.bat`.
2. Open the file with a text editor and enter the following:
   ````
   steamcmd.exe +login [username] +force_install_dir .\mb2b_beta +app_update "261550 -beta [version] validate" +quit
   ````
3. Replace `[username]` with the Steam username that owns the game.
4. Replace `[version]` with the game version of the latest beta, which at the time of writing this is `e1.5.9`.
5. Save and close the file, then execute it from a console or from the explorer.
6. It will ask for a password. Enter the password of the Steam user and press continue.
7. It will then download the game in the latest beta branch into a folder called `mb2b_beta` in the SteamCMD directory.
8. Whenever the game has an update ready, you can just run the batch file again and it will update just like the Steam client.

### Building the project
1. Fork the project, clone it and check out the branch `develop` for the stable game or `beta-develop` for the beta branch.
2. Open the solution in your dev environment of choice. I personally use Jetbrains Rider, but Visual Studio should work just as well. 
3. Open the file `Directory.Build.props` and check that the parameters fit your installation of the game instances.
   Most important are `GameVersion` and `GameFolder`.
4. Build the project `BannerlordCheats.csproj`.
5. The build process should automatically have placed the mod files into your game installation's `Modules` folder.
   If not, then check the file `Directory.Build.targets` which contains the console commands that copy the files.

### Running the game
1. First of all, download the latest version of [Mod Configuration Menu](https://pages.github.com/) and all of its requirements
   and install them into the `Modules` folders of both `mb2b_stable` and `mb2b_beta`.
2. Create a launch configuration in your dev environment with the following properties:
   - Executable Path: `[Game Folder]/bin/Win64_Shipping_Client/Bannerlord.exe` (Replace game folder with the same path as in the `GameFolder` property in `Directory.Build.props`.)
   - Working Directory: `[Game Folder]/bin/Win64_Shipping_Client` (Replace same as above.)
   - Launch Arguments: `/singleplayer _MODULES_*Bannerlord.Harmony*Bannerlord.ButterLib*Bannerlord.UIExtenderEx*Bannerlord.MBOptionScreen*Native*SandBoxCore*CustomBattle*SandBox*StoryMode*Cheats*_MODULES_`
3. Run the configuration. As you can see, Bannerlord is launched directly with a set list of Modules, which is the same thing the native launcher would do for you.
4. You should be able to debug the running module code. Try by setting a breakpoint for example in `SubModule.cs`

## Tips for contributing
Now you can change the code and commit it. When ready just post the pull request, but please keep these things in mind:
- Be sure your pull request is based on either the `develop` or `beta-develop` branch. You can just commit to one (preferably `develop`) and I will pull the changes
  to the other after I have merged your changes. They are supposed to stay the same except for compatibility fixes.
  `master` and `beta` are only for releases.
- Please match your code formatting to the existing formatting in the mod.
- Please do not commit any changes to `Directory.Build.props` or `Directory.Build.targets`. This includes version increments.
  I will take care of that.
