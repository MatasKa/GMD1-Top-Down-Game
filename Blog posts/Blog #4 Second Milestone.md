# **The second milestone**

### What was made/implemented
all of the enemies and a boss were fully implemented and have a prefab (except the wave system) (all sprites are also made by me)
This includes:
- 5 common enemies (with animations)
- A boss enemy (stationary turret with four guns)
- Enemy spawning
- Enemy going after the player
- Enemy shooting at / damaging the player
- Player HP (with a working healthbar, but no death)
- "Shoot" and "Player hurt" sound effects (generated with https://sfxr.me)

There were a few more additions and scripts that were implemented, but not tested as of yet: gold counter, enemy HP and them dying, getting gold from enemies.
In this milestone there were also quite a lot of script sepparating, more details below.

## **In-depth look at the common enemies**

![Enemies](../Images%20and%20GIFs/Enemies.png)

as mentioned there are 5 common enemies now. Here is the descriptions (numbering not based on the image above)

1st: **Slime** - the only enemy that can move towards the player but is not floating. This means it is probably the weakest enemy,as the player can easily walk to another island using a bridge,
and the slime only follows the player in a straight line, so will probably get itself stuck on a ledge, unless there is only the bridge sepparating them.
2nd: **Bee** - lowest HP enemy, but is floating, does decent amount of damage and is quite fast, so it will catch up to the player no matter where they are.
3rd: **Eye** - same as bee, but more HP. Both this and the bee have a simple `FacePlayer` script that makes them always face the player.
4th: **"Sphere"** - floating, has most HP out of the common enemies, and does most damage. This is the only enemy that was not made with Terraria enemies as an inspiration.
5th: **Flower** - Average HP and damage, but is the only common enemy that is stationary, yet is able to shoot. Also has the `FacePlayer` script, so that it aims at the player while shooting.

## **Boss**

The plan so far is that the boss will spawn at the last wave, and other enemies will not be spawning duringd the boss fight.
During the fight, the boss will be stationary, but it has four guns that make it a bit more of a bullet-hell type fight.

The boss also has two states that it changes between every 5-10 seconds using a `BossTurretManager` script:
Aim state - will always aim at the player with one of the guns, and speeds up the firing rate
Spin state - will start spinning and shooting with all 4 guns at the same time  (deactivates the `FacePlayer` script and activates `Spin` script).

To defeat it, the player will need to destroy all 4 of its legs, and the game is won.

![BossGIF](../Images%20and%20GIFs/Boss.gif)

*The boss changing states*

## **Scripts**

after the lecture about game architecture, I tried to play around a bit by separating the scripts, as I had a habit of writting quite huge files rather than multiple small ones.
I made the `Health` script which is responsible for keeping track of how much health someone has. 

**Health.cs**

```csharp
public class Health : MonoBehaviour
{
    [SerializeField] protected int maxHP;
    [SerializeField] protected DamageFlash damageFlash;
    [SerializeField] protected SpriteRenderer spriteRenderer;

    protected int currentHP;

    void Awake()
    {
        currentHP = maxHP;
    }

    public virtual void TakeDamage(int damage)
    {
        currentHP = currentHP - damage;
        StartCoroutine(damageFlash.Damaged(spriteRenderer, 1));
        if (currentHP <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}
```

*during the development of this milestone, one of the things I learned is that `virtual` means it can be overriden by other classes that inherit this one :D*

As the enemies and the player should have some different logic with how their health works, but the main idea matches, the `Health.cs` script is inherited by `PlayerHealth.cs` and `EnemyHealth.cs`.
`EnemyHealth.cs` only overrides the `Die()`, so that it also calls a `GoldManager.cs` script and adds gold for the player.
`PlayerHealth.cs` not only overrides the `TakeDamage()` and `Die()`, but also has its own additions, and a few extra functions - a `IEnumerator Invincibility()` (makes player invincible for a bit after taking damage) and `UpdateHealthBar()`.

**some other scripts**
`DamagedFlash.cs` - takes the spriteRenderer component and changes it color to "flash" the object. It is called by the health scripts.
`Enemy.cs` - moves an object towards another object with a tag "Player", and if its collider touches the player's collider (also checked with tags), calls `TakeDamage()` on `PlayerHealth.cs`.

## **Spawning enemies**

Last thing I wanted to mention is how spawning enemies work. There are 9 predetermined positions for enemies to spawn, each one has `EnemySpawn.cs` (has a bool that says if there is a collider with a tag "AntiSpawn" touhing it).
The "AntiSpawn" tag is on a huge trigger collider on the player, so that enemies don't spawn near. The flower enemy, because is stationary, has a small one.
The main logic is in `EnemySpawnManager.cs`, where each spawn is taken, and is checked by the bool value if enemy can be spawned there. After that, a spawn is randomly selected from the ones that can, and a random common enemy is spawned (might change later).

![EnemyChaseGIF](../Images%20and%20GIFs/EnemyChase.gif)
