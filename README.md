# Track Editor Overhaul
A ROBOBEAT Demo mod that overhauls the track editor. It currently adds:
- A text input to the BPM editor so you don't have to painfully choose with the slider.

### Warning!
> This mod is in alpha! A lot of key features are missing. They will be added as development progresses.

## Installing
> These are instructions for setting up the game to **install** the mod. If you want to set up the game for contributing,follow all steps but the final one and head to the [Contributing](#contributing) section.
To install the mod, you need:
- A [copy of ROBOBEAT Demo](https://store.steampowered.com/app/1456760/ROBOBEAT/) (ROBOBEAT will be supported on release)
- A [copy of BepInEx](https://github.com/BepInEx/BepInEx/releases)
- A [copy of the mod](https://github.com/ZaddikDev/TrackEditorOverhaul/releases)

After obtaining all of the requirements above, you first need to install BepInEx into the ROBOBEAT Demo folder. To do that, I would recommend checking out [this article](https://docs.bepinex.dev/articles/user_guide/installation/index.html).
After installing it, you need to run the game at least once to generate configuration files and folders.
Finally, you have to add the mod copy into BepInEx's plugin folder (BepInEx/plugins). To do that, simply copy the downloaded DLL (probably named TrackEditorOverhaul.dll) to said folder.

### Congratulations! You have successfully installed the mod.

## Contributing
> Warning! These are instructions to **contribute** to this mod. To install it, follow the instructions on the [Installing](#installing) section.
To contribute to this project, you need:
- A [copy of ROBOBEAT Demo](https://store.steampowered.com/app/1456760/ROBOBEAT/) (ROBOBEAT will be supported on release)
- A [copy of BepInEx](https://github.com/BepInEx/BepInEx/releases)
- Visual Studio Community 2022 with the .NET desktop development workload
- A fork of the mod's source code (recommended) or a [copy of the mod's source code](https://github.com/ZaddikDev/TrackEditorOverhaul)

### Downloading the mod's source code
There are lots of ways to do this. These are 2 of the most popular options:
- **Using [git](https://git-scm.com/):** This is the most popular one and the one I recommend. To use this method, just install it (if you haven't already) and use the command `git clone`, with either the link of your mod's fork or this mod's GitHub repository. For demonstration purposes, I'm going to use this mod's GitHub repository, but you can (and should) use your own fork. The command would be: `git clone https://github.com/ZaddikDev/TrackEditorOverhaul`. After that, a new folder will be created containing the source code.
- **Downloading the code as .zip:** This is an option, but it it's not the recommended one. Simply head to the mod's source code page and click the green button that reads "Code" and press Download ZIP.

![zip-help-image](https://github.com/ZaddikDev/TrackEditorOverhaul/assets/63800482/ec4f47b2-3e2e-48f1-9ba3-3c95eab6c8b0).

After obtaining all of the requirements above, you first need to install BepInEx into the ROBOBEAT Demo folder. Follow all steps but the final one in the [Installing](#installing) section, if you haven't already.
After that, you need to run `setup_env.bat`, to setup a build environment. This is required, as it copies necessary files such as Unity code and game code.

Finally, after all these steps above, you can finally build your project. Simply open the solution in Visual Studio and right click the project->Build. The mod's DLL file will be built in `bin/Debug/TrackEditorOverhaul.dll`

![project right click and build image](https://github.com/ZaddikDev/TrackEditorOverhaul/assets/63800482/b3db0a12-4e25-48c4-960d-7a762efe8b2a)

### Congratulations! Now you can contribute to the mod's development
