# **Blog #1: Roll-a-ball**

### What I learned
Even if I do have experience with Unity, I found this tutorial to be a nice refresher of the basics, but I did learn a few things aswell.
As I was not familiar with the Unity's new input system, when coding the movement for the player, the `OnMove()` function at first seemed weird to me as it was not called anywhere in the script.
But after reading about it, I learned that it is called whenever the player (the object the script is attached to) moves.
I also learned a bit more about NavMeshes, NavMesh agents and especialy how the NavMesh obstacle works, as I have not used those before in previous projects.

### Other observations
There were a few weird moments that I had while following the tutorial, one of them were the scaling of the "Ground" and the static obstacles, as in the tutorial it says to set the X and Z scale of the ground to 2, and then to make the static obstacles the children of the ground object. This makes the child objects "inherit" the scale of the parent object, so when making a ramp it had weird scaling.
To combat this I just set an empty game object as a parent and made the ground and static obstacles the child objects.

Another weird moment was when I tested if the enemy can disable the player. I tried just by pressing play and not moving as the enemy comes to the player itself. The enemy just phased in to the ball, but did not disable it. However if I have moved, it seems to work properly, so you can't really cheat as moving the ball while the enemy is phased into the player, instantly disables it, and you cannot beat the game without moving. Therefore I did not try to fix this one.

## **Personal changes**

#### **Level expansion**
I Changed the background to a solid color, and also imported two asset bundles. Some assets were used to expand (4 times bigger than the original roll-a-ball level) and enhance the level a bit. I used one of the assets to change the enemie's mesh into this ring-like shape, and made it rotate along a local axis so that it looks like it is rolling. I also used some imported assets to make the walls/obstacles of the level (the modular construction kit asset), and used some textures from the other asset to give the collectable, the enemies and the player a new look. 

The level from the top looks like this:
![RollaBallGif](../Images%20and%20GIFs/RollaBallLevel.png)

#### **Difficulty tweak**
I wanted to make the game at least somewhat challenging, so I added two more enemies and made them a bit faster (their speed is set to 3), and after each collectible was collected - to decrease the speed of the player by 1. There are 9 collectables, and the initial player speed is 15, so when the player needs to collect the last collectable, their speed is 7, which does make the game somewhat harder.

#### **Restart Button**
I saw how annoying it to keep restarting the game to replay the level, so I added a button that appears when win/lose condition is met, and activates this line: `SceneManager.LoadScene("MiniGame");`.

The final game looks like this:
![RollaBallGif](../Images%20and%20GIFs/RollaBall.gif)

Assets used:
https://assetstore.unity.com/packages/3d/environments/sci-fi/sci-fi-construction-kit-modular-159280
https://assetstore.unity.com/packages/3d/props/rolling-balls-sci-fi-pack-free-297168
