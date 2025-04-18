# **The first milestone**

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

### Main menu
While I did use Unity before, I haven't done a single game/project that required a controller input. At first I was thinking on how would the script look if I wanted to be able to use the joystick to navigate the menu, but when I took a look at some retro main menus as inspiration, I decided on probably the easiest implementation that also fits the retro theme quite well - a "press A to start" main menu.
I was not sure of this, as I thought that I will still need the navigation system when implementing a shop or a character select screen, but I decided to tackle those implementations in a similar way of pressing the
corresponding ABXY button. The menu is in a sepparate scene from the game itself, and the script simply takes the input of "A" and "B" buttons and either loads the player into the next scene, or quits the game. 

![MainMenuGif](../Images%20and%20GIFs/MainMenu.gif)

### "Arena"
The "Arena" (and the main menu background) were created using the tilemap system and the imported assets. At first, everything that had water also had a collider, but because the map's boundaries is made from full water tiles, the tilemap collider looked cramped with a lot of useless colliders. That is why I chose to fo the colliders only on the "river" and "edge of the land" tiles.
While the player should not be able to walk on a full water tile, there will always be the "edge" tile that limits the player to stay on land.
The "Arena" uses a composite collider with merge selected, so there is this one big collider along the edge of the island and a few for the rivers.

![Arena](../Images%20and%20GIFs/Arena.png)
![ArenaColliders](../Images%20and%20GIFs/Arena%20Colliders.png)

### Walking animations
While the spritesheets were imported, the animation logic was not. As the game has a top-down perspective, the character has 4 idle animations, and 4 walking animations - 1 for each way they are looking at.
The attacking and death is planned to be implemented in a different way, but I am not 100% sure if that will be the case. So for now, this is how the animator window looks like:

![Animator](../Images%20and%20GIFs/Animator%20Image.png)

**Why like this?**
The idle animation can only be played if a player moved in that direction, so only the connection from the same side walking animation is necessary.
The player can try to move the character anytime, anywhere, so the animation to walk in the chosen direction will interupt any other animation, except itself (so that the animation loops, but not too fast),
this is also why "any state" was used instead of making four transitions for every idle animation and some more for walking.
The animations are played by checking only two values: MoveX and MoveY, which are values of the movement (joystick of the controller) that are being inputed by the player.
Also, for the game to feel more responsive, none of the transisions have any "exit time", but the transitions to idle have a very tiny "transition duration".

*the orange tint is there as a personal reminder that I am in play mode, as to not make any changes*

![AnimatorGIF](../Images%20and%20GIFs/Animator.gif)

### Shop screen
*The first milestone seemed a bit underwhelming after I compared it to the plans of the other two, so I decided to add a shop screen to this one.*
The shop has a 'B' button prompt that appears when a player is near enough (inside a "is-trigger" collider) and is in Time-out phase (in between waves).
If the prompt appears, the player should be able to open the shop screen with 'B', as opening of the shop logic is also done with the same checks.
The shop screen has only placeholder assets, as it was planned to be an adition of the third milestone, but the main idea is there.
The player is still able to move while in the shop (as it is a canvas object), script will close the shop if the player exits the buy-zone, the same zone that will show the prompt to open the shop when entered.
You can also close the shop by pressing "B" again.

*The colors are a bit off because of the way I capture my screen, they look different than what is seen here.*
![Animator](../Images%20and%20GIFs/Showcase.gif)
