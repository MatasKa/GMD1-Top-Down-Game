#**The first milestone**

### What was made/implemented
- The assets for the tileset/level (https://gfragger.itch.io/magic-market)
- The assets for the player characters (https://elvgames.itch.io/free-retro-game-world-sprites)
- A pixel-art style font (https://www.1001fonts.com/dpcomic-font.html).
- Assets for ABXY button prompts.
- A main menu screen, with a background and working play and quit buttons.
- An "Arena" - the island where the main gameplay-loop happens.
- A controllable player character, with walking animations.
- A shop in the "Arena", which the player can access, but not use as of yet.

## In-depth look
### "Arena"
The "Arena" (and the main menu background) were created using the tilemap system and the imported assets. The colliders are only on the "river" and "edge of the land" tiles.
While the player should not be able to walk on a full water tile, there will always be the "edge" tile that limits the player to stay on land.
The "Arena" uses a composite collider with merge selected, so there is this big collider along the edge of the island.

### Walking animations
While the spritesheets were imported, the animation logic was not. As the game has a top-down perspective, the character has 4 idle animations, and 4 walking animations - 1 for each way they are looking at.
The attacking is planned to be implemented in a different way, so for now, this is how the animator window looks like:

*insert animator window*

The player can try to move the character anytime, anywhere, so the animation to walk in the chosen direction will interupt any other animation, except itself (so that the animation loops, but not too fast).
The idle animation can only be played if a player moved in that direction, so only the connection from the same side walking animation is necessary.
The animations are played by checking only two values: MoveX and MoveY, which are values of the movement (joystick of the controller) that are being inputed by the player.

### Shop screen
*The first milestone seemed a bit underwhelming after I compared it to the plans of the other two, so I decided to add a shop screen to this one.*
The shop has a 'B' button prompt that appears when a player is near enough (inside a "is-trigger" collider) and is in Time-out phase (in between waves).
If the prompt appears, the player should be able to open the shop screen with 'B', as opening of the shop logic is also done with the same checks.
The shop screen has only placeholder assets, as it was planned to be an adition of the third milestone, but the main idea is there.
Instead of selecting an item with a joystick, I chose to do a simpler solution and let the item be bought by pressing one of the ABXY buttons, with a prompt for what item which button would buy.
The player is still able to move while in the shop (as it is a canvas object), script will close the shop if the player exits the buy-zone, the same zone that will show the prompt to open the shop when entered.
You can also close the shop by pressing "B" again.

*insert a gif of going to the shop screen*

Gallery:
*insert a few gifs*
