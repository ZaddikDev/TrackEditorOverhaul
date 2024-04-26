@echo off
SETLOCAL EnableDelayedExpansion
echo Setting up ROBOBEAT enviorement...
echo Looking for ROBOBEAT directory...
goto find_steam

:find_steam
REM Finds the Steam library folders and iterates through all of them
IF EXIST "C:\Program Files (x86)\Steam\steamapps\libraryfolders.vdf" (
    echo Steam libraryfolders found
    copy "C:\Program Files (x86)\Steam\steamapps\libraryfolders.vdf" lf.vdf>nul
    for /f "tokens=*" %%i in (lf.vdf) do (
        set "entryR=%%i"
        set entry=!entryR:~1,4!
        set entryval=!entryR:~9!
        set entryval=!entryval:~0,-1!
        set entryval=!entryval:\\=\!
        if "!entry!"=="path" (
            echo Scanning path !entryval!
            if EXIST "!entryval!\steamapps\common\ROBOBEAT Demo" (
                set "robobeat_dir=!entryval!\steamapps\common\ROBOBEAT Demo"
                echo Found Steam library containing ROBOBEAT Demo
                goto check
            )
            echo This Steam library does not contain ROBOBEAT Demo
        )
    )
    goto check
) ELSE (
    echo No Steam found
    goto check
)

:check
IF NOT "%robobeat_dir%"=="" (
    echo ROBOBEAT directory to check: %robobeat_dir%\
) ELSE (
    echo No ROBOBEAT directory found! Please, write your ROBOBEAT directory path here:
    set /p robobeat_dir=
)

IF EXIST "%robobeat_dir%\" (
    echo Valid directory detected (%robobeat_dir%\)
    if NOT EXIST "%robobeat_dir%\ROBOBEAT_Data\Managed" (
        echo Managed directory missing
        goto end
    )
    if NOT EXIST "Unity\" (
        mkdir Unity
    )
    echo Copying DLL files
    set managed_dir="%robobeat_dir%\ROBOBEAT_Data\Managed"

    copy "%managed_dir%\Assembly-CSharp.dll" \>nul
    echo Copied game assembly

    copy "%managed_dir%\UnityEngine.dll" \Unity\>nul
    copy "%managed_dir%\UnityEngine.CoreModule.dll" \Unity\>nul
    copy "%managed_dir%\UnityEngine.UI.dll" \Unity\>nul
    copy "%managed_dir%\UnityEngine.UIElementsModule.dll" \Unity\>nul
    copy "%managed_dir%\UnityEngine.UIModule.dll" \Unity\>nul
    echo Copied Unity files

    if NOT EXIST "%robobeat_dir%\BepInEx" (
        echo It appears that you have not installed BepInEx in your ROBOBEAT installation. To use or test this mod, you need a copy of BepInEx installed into your game. You can get one here: https://github.com/BepInEx/BepInEx/releases
    )
    goto end
) ELSE (
    echo This directory is not valid (%robobeat_dir%\)
    goto end
)

:end
IF EXIST lf.vdf (
    del /f /q lf.vdf>nul
)

exit /b
