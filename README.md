# HODOR

## Summary  
Have to collect X amount of coins to open a door  

### Control  
- **W**: Forward  
- **S**: Backward  
- **A**: Left  
- **D**: Right  
- **Space**: Jump  

---

## Features  

### Player  
- Move in any direction (on plane X and Z)  
- Jump  

### Camera  
- Uses Cinemachine  
- Hard-fixed to the player  
- Rotates at the same time as the player  

### Coin  
- Spawns X amount of coins randomly on the map (default: 3)  
- Respawns in a random location when collected  
- Plays a sound when collected  

### Door  
- Opens when X amount of coins are collected  
- Plays an animation when the door opens  

### UI  
- Displays the amount of coins collected  
- Displays the time on the level  
- Displays a message when the door is open (message disappears after X seconds)  

---

# Tech Design  

## Script  

### Manager(singleton)  
- **CoinManager**  
  - Manages coin spawning  
- **GameManager**  
  - Main loop of the game  
- **SoundManager**  
  - Plays one-shot sounds  
- **LevelManager**  
  - Manages the size of the level and can swap between levels  
  - **UiManager**  
  - Manages the size of the level and can swap between levels  

### ScriptableObject (Data)  
- **CoinData**  
  - **Variables**:  
    - `CoinValue`  
    - `OnCollectSound`  
    - `CoinPrefab`  

- **PlayerData**  
  - **Variables**:  
    - `maxSpeed`  
    - `acceleration`  
    - `rotationSpeed`  
    - `jumpForce`  
    - `InputAction directionAction`  
    - `InputAction jumpAction`  

- **SoundData**  
  - **Variables**:  
    - List of sound data (SoundData is a struct)  

### Object  
- **Coin**  
  - Detects when the player collects the coin and invokes an event  
- **Door**  
  - Listens to an event triggered when the collected coins exceed X coins  
- **Level**  
  - Contains the level's boundaries and the coin count required to finish the level  

### Enum  
- Contains all enumerations used in the game:  
  - **DoorState**  
  - **SoundName**  

### Delegate  
- Defines all game-related events:  
  - `UnlockingDoor()`  
  - `ModifyPoint(int point)`  
  - `CoinLoot(Coin coin)`  
  - `GameStart()`  
  - `StartLevel()`  
  - `EndLevel()`  
  - `ExitLevelBoxPass()`  

### Struct  
- Defines all structs used in the game:  
  - `SoundData()`  

---

# Tutorial  

### Create Coins  
1. Make a prefab of the coin (ensure it has the Coin script and a trigger collider).  
2. Go to `Assets/Resources/Coins` and create a new `CoinData` (ScriptableObject).  
3. Fill in the data and include the prefab in `coinPrefab`.  
4. Enjoy!  

### Create Levels  
1. Create a level in the editor.  
2. Attach the Level script to the root of your level.  
3. Set up all dependencies in the inspector.  
4. Replace the LevelManager's value with the new level.  

### Add Sounds  
1. Add audio clips to the `Assets/Audio` folder.  
2. Add the name of the audio clip to the `SoundEnum` script.  
3. Open `SoundData` (ScriptableObject located in `Assets/Resources/ScriptableObject/SoundData`).  
4. Add a new entry and fill in the data.  
5. Use `SoundManager.Instance.PlaySoundOneShot(SoundName)` to play the sound.

---

# Optimization Ideas  
1. Implement a factory pattern for coin creation.  
2. Modify `PlayerData` to `PlayerMovementData` and create an abstract parent class `PlayerMovementData`:  
   - Add an abstract method `GetDirection`.  
   - **Advantage**: Usable by both the player and a future AI.  
3. Use an audio mixer.  

---

# Additional Features  
1. Integrate multiple types of coins (e.g., with a percentage chance to spawn different types).  
2. Add an end screen.  
3. Support for multiple levels (work in progress).  
4. Add a variety of sounds.  
5. Pause game
6. Restart game

---

# Assumptions  
1. Collectible are coin  