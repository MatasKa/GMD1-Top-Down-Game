# **The third milestone**

### What was made/implemented
- Class selection (3 classes/characters in total)
- 12 different weapons
- Enemy wave system
- Death screen
- Win screen
- Shop (fully implemented, possible to buy items)
- Class stats and upgrades
- Full Bossfight

While there are a few other things I would like to change, or was planning to do differently, I believe the game is now finished and is relatively bug-free.

## **A look at classes**

From the first days of writing the GDD, the 3 classes are here, and can be chosen before the start of the run. While the gameplay is a bit different for each one, I decided to make the difficulty easier.
This made sure that whatever class you choose, you should not have trouble of beating the game.

![Enemies](../Images%20and%20GIFs/Enemies.png)

Here is each class and what it aims for:
1. **Warden** - The one that was used to play/test during the development of the previous milestones. It is the "tank" class of Roguebit.
2. **Wolf** - The "Wolf" is the fastest class, this includes the running speed, the weapon swing speed, and also "dying while standing afk" speed (it has lowest HP).
3. **Duelist** - A bit of a middleground of the Warden and the Wolf class. Average HP, average speed, but it does "excel at long range weapons". (because of its starting stats, more on them below).

### **Stats**
For each class, there is a stat that it excels at. Before a run, the player can choose a class, or more specifically, what stats to start on. The Warden starts with a lot of Strenght stat, meaning he can
more easily access the heavy (slow, but high damage) weapons. The Wolf, for its Dexterity, can buy fast, but low range weapons earlier (my favorite in terms of gameplay :D ). Lastly, the duelist was made
with a high Finesse skill starting out, which is needed if you preffer to keep distance from your enemies and attack from some distance.

## **Weapons and attacking**

When doing the weapons, I was thinking of how could I implement the swinging of them in to the game, without making the player always look at the enemy, as then you would need to always "dive" in to them.
I was thinking of doing so that when pressing a button, the character would swing his weapon behind him, but that would have made it awkward for the stationary enemies. Which lead me to try this, a bit
of a weirder idea that I got.

![Enemies](../Images%20and%20GIFs/Enemies.png)

No buttons need to be pressed or held, just a sword/axe/something else that the character spins 24/7 around themselves. This does introduce some timing requirements, especially if the weapon is a slow one.
The weapon never dissapears, you can buy other weapons, and they will change your current one, meaning you always have only one.

There are 12 weapons in total, four for each class, and one in each tier for that class. When the run starts, the player gets a "starter" weapon, which is obviously the worst one out of the other options
for that class, but it is there to help you get your first gold (which is collected automaticly, as long as the enemy dies, the player is awarded). By progressing trough the waves, of which there are 10 
in total, the player collects gold and can spend it in the shop to buy a weapon of a higher tier.

![Enemies](../Images%20and%20GIFs/Enemies.png)


## **Shop**

The shop did have a bit of a makeover, as I decided I wanted to implement a reroll button for it. This lead to the shop becoming more luck based, but I believe it makes it somewhat more fun.
When the wave (wave timer) has ended and no more enemies are spawning, you can enter the shop and will see two items, a weapon on the left and a potion (upgrade) on the right. When buying a weapon,
you will see under it that it has a requirement of a specific stat. That is where the potions come in, so that you could increase your stats and pass the requirements of better weapons.
A reroll works by pressing 'Y', the specified gold will be deducted, and two random items will apear. They can be the same item as before, so in some cases it may seem that item(s) did not change, but
that is just how chance works. If a player buys an item, it will dissapear. Rerolling still work as expected and the shop then will make an item appear again. The reroll value does rise with each reroll
in this "time-out" (time between the enemy waves).

![BossGIF](../Images%20and%20GIFs/Boss.gif)


## **Scripts**

While I was very proud of how the scripts were turning out during the first two milestones, on this one, I did rush quite a bit. As a result, the shop class, while works exactly as expected,
is quite messy inside, with a humorous ammount of variables. As I am not too keen on showing that here (the script is a few clicks away anyway), I will show how the enemy waves work.

**WaveManager.cs**

```csharp
public void OnY()
    {
        if (enemySpawnManager.enabled == false && shop.shopScreen.activeSelf == false)
        {
            StartCoroutine(StartNextWave());
        }
    }

    private IEnumerator StartNextWave()
    {
        wave++;
        nextWavePrompt.SetActive(false);
        waveCounter.text = wave.ToString();
        enemySpawnManager.setTimeOut(false);
        if (wave != 10)
        {
            waveTimer.gameObject.SetActive(true);
            shop.SetTimeOut(false);
            enemySpawnManager.enabled = true;
            float timeLeft = countdownTime;
            waveTimer.text = "Time left: " + timeLeft.ToString();
            while (timeLeft >= 0)
            {
                yield return new WaitForSeconds(1f);
                timeLeft -= 1f;
                waveTimer.text = "Time left: " + timeLeft.ToString();
            }
            EndWave();
        }
        else
        {
            enemySpawnManager.spawnInterval = 10f;
            shop.SetTimeOut(false);
            enemySpawnManager.enabled = true;
            enemySpawnManager.SpawnBoss();
        }
    }

    private void EndWave()
    {
        shop.SetTimeOut(true);
        enemySpawnManager.setTimeOut(true);
        nextWavePrompt.SetActive(true);
        enemySpawnManager.enabled = false;
        waveCounter.text = wave.ToString();
        waveTimer.gameObject.SetActive(false);
    }
```

Nothing too much to say except that I don't think it follows the one responsability principle, as it does also control some of the UI, and controls the waves quite broadly. 
However, it works flawlessly (from how well the testing went for me), which after rushing this much is just what I need. If the wave is not "on", the player will see a prompt 
that will tell them to press 'Y' to start the next wave. This disables the ability to enter the shop while the wave is running, but after the timer runs out, it does of course 
allow to enter the shop again. If the next wave is the 10th (the last one) this script also calls the enemy spawner manager to spawn the final boss, and changes some settings 
so it is not absolute chaos.

**CharacterChoice.cs**
On the other hand, there is this, probably the shortest script in my game, which just takes a single value and passes it in to another scene, by having a `DontDestroyOnLoad(this.gameObject);`
in its `Awake()`.
