## Description
It features a smooth and intuitive shift from the main menu to the 3D world by switching out the UI while activating gameplay visuals and audio, ensuring visual continuity. The audio integration includes distinct background tracks for the menu and game scenes, along with responsive button click sounds, all managed through dedicated AudioSources.

## How to Play
# Main Menu

When the game starts, the Main Menu appears automatically.

Background music specific to the menu will play.

# Start Game

Click the Start button to begin the game.
The Main Menu fades out and the 3D world scene activates.

Gameplay music replaces the menu music.

# Instructions

Click the Instructions button to view how to play.
The Instructions panel opens on top of the Main Menu.

Click the X button on the top corner to close it.

# Credits

Click the Credits button to view credits.
The Credits panel opens over the Main Menu.

Close it using the X button at the top corner.

# Escape Key

Press the Escape key at any time to bring back the Main Menu.

# Quit

Click the Quit button to exit the game application.

# Audio Feedback
Every button press will play a click sound.
Music changes based on whether you are in the menu or the game.

## Asset Source
# Game Music
Asset Name: GameMusicClip.mp3
Asset Source: https://pixabay.com/
Asset Source Name: stranger-things-124008.mp3

Purpose: Provides an immersive and dynamic atmosphere during gameplay.
Looping: Yes
Triggered: Starts when the game begins and the Main Menu is hidden.

# Menu Music

Asset Name: MenuMusicClip.mp3
Asset Source: https://opengameart.org/
Asset Source Name: song18.mp3

Purpose: Sets a calm and welcoming tone while the Main Menu is active.
Looping: Yes
Triggered: Automatically plays when the Main Menu is shown.

# Button Click Sound

Asset Name: ButtonClickClip.wav
Asset Source: https://opengameart.org/
Asset Source Name: Menu Selection Click.wav

Purpose: Gives immediate auditory feedback for all UI button presses.
Looping: No (played once per interaction)
Triggered: Every time a UI button is clicked.

# Audio Sources

Music Source: Dedicated AudioSource set to loop, handles either menuMusicClip or gameMusicClip depending on context.

SFX Source: Separate AudioSource using PlayOneShot to play buttonClickClip on button interactions.
