# **Blog #2: Game Design Document**

This is the Game Design Document for my GMD1 course game. So far, this is not the final version, and the decisions that are still not finalized will be marked like `this`.

## **The Main Concept/Idea:**
Roguebit is a Top-Down 2D Rogue-Like game, where a player will go trough waves of enemies or levels to earn gold, and purchase upgrades for their kit.

## **The Current Gameplay Loop:**
1. A player enters a level.
2. They start defeating the enemies.
3. They collect gold from said enemies.
4. After a certain ammount of time the wave ends and a shop opens in the level.
5. In the shop, gold can be spent to get upgrades for the player/weapon.
6. After a certain amount of preparation/shopping time `and/or when the player is ready`, a new wave will begin that is harder than the one before.
7. The game is ends after every wave was beaten.

## **Other Details**
### Enemies
- The number of different non-boss enemies will be 5.
- There will also be one boss, which will have a bullet-hell style boss fight.
- The final wave will be the only one with the boss `and the usual enemies`.

### Player
- Before the run begins, the player will be able to choose one of 3 classes, each one having different stats.
- Each class will have their own starter weapon.
- If the player dies, the game is over.
- The player will be able to take some damage before dying.
- The player will be able to heal after the wave for some coins.

### Shop and Weapons
- The player will have a weapon, which they will be able to change by buying another one from the shop.
- Each weapon will also feature a unique design, different stats and will have some stat requirements.
- There will be 12 different weapons, each aiming to be used by a specific class.
- The shop will have some choice of weapons `and upgrades` for the player.
- `assuming there will be upgrades, each class will be able to upgrade their stats, even if the stat is not the main strenght of said class`
- Items in the shops will be random, but can be "rerolled" for gold.

### Style/Art
- The game will be 2D
- The game will have a top-down perspective
- The game will use pixel-art assets

## The Milestones
***1st - The Set up***
The game will have a main menu, featuring a detailed backgorund and working start and exit buttons, but not the class select screen.
It will be possible to enter the "arena" (the level in which the game-loop is) and walk around. The "arena" will have the assets for the level, the shop and the animations for the player.
The player will be able to enter the shop, but only to see the shop screen, not to buy items yet.

***2nd - Enemies***
The game should have all of the enemies implemented, as well as 1 boss. The game will have some sound effects implemented as well.
This milestone should have all of the enemy functionality working (except waves). This includes: enemies spawning in the level, going after the player, attaking them. Because the player will be attacked,
this milestone will also include player HP, meaning the player will be able to take damage. `Also should have them dying and a deathscreen`.

***3rd - Weapons and Upgrades***
This milestone focuses on the player having tools and choices to beat the enemy, which include:
The player being able to choose one of the classes at the start of the run, player killing the enemies and collecting gold, as well as buying other weapons `and upgrades` in the shop.
The game will feature 12 weapons, and it will also have a game ending screen when the player beats the last wave. This milestone will also add wave system.
Some polishing will also be included depending of how much time is left before the deadline.
