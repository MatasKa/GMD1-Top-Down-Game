# **Blog #1: Roll-a-ball**

### What I learned
Even if I do have experience with Unity, I found this tutorial to be a nice refresher of the basics, but I did learn a few things aswell.
While going trough the tutorial, I did go trough it quite fast as I am familiar with the layout and navigation, but I did take the time to read the code, so that I fully understand what each line is doing.
As I was not familiar with the Unity's new input system, when coding the movement for the player, the `OnMove()` function at first seemed weird to me as it was not called anywhere in the script.
But after reading about it, I learned that it is called whenever the player (the object the script is attached to) moves.
I also learned a bit more about NavMeshes, NavMesh agents and especialy how the NavMesh obstacle works, as I have not used those before in previous projects.

### other observations
There were a few weird moments that I had while following the tutorial, one of them were the scaling of the "Ground" and the static obstacles, as in the tutorial it says to set the X and Z scale of the ground to 2, and then
to make the static obstacles the children of the ground object. This makes the child objects "inherit" the scale of the parent object, so when making a ramp it had weird scaling.
To combat this I just set an empty game object as a parent and made the ground and static obstacles the child objects.

Another weird moment was when I tested if the enemy can disable the player. I tried just by pressing play and not moving as the enemy comes to the player itself. The enemy just phased in to the ball, but did not disable it.
However if at any time I move, or have moved, it seems to work properly, so you can't really cheat as moving the ball while the enemy is phased into the player, instantly disables it, and you cannot beat the game without moving.
Therefore I did not try to fix this one.

## **Personal changes**

#### **Difficulty tweak**
I wanted to make the game at least somewhat challenging, so the changes I did were to add the second Enemy, and after each collectible was collected - to decrease the speed of the player by 2. There are 6 collectables, and the initial player speed is 15,
so when the player needs to collect the last collectable, their speed is 5, which does make the game a bit harder.

#### **Restart Button**
When I built the game and tested it, I saw how annoying it would be to keep restarting the game to replay the level, if this was a real game. I added a button in the canvas, changed the text and made it disabled as its initial state when starting the game.
the state of the button becomes active whenever a player wins or loses. I Added a simple script that I attached to the button with this line that would activate when the button is pressed: `SceneManager.LoadScene("MiniGame");`

#### **Other minor tweaks**
Changed the background to a solid color, added a texture to the ball so it can be seen rolling and not "sliding around" (as this is how I thought it would move before coding the movement) and made an obstacle a wide sphere that you can climb on to for variety.

The final game looks like this:
