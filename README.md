
# HODOR

SUMMARY  
    Have to collect X amount of coin to open a door

	Control  
		-W = Forward  
		-S = Backward  
		-A = Left  
		-D = Righr  
		-Space = Jump  
  
  
FEATURE  
	&emsp; Player  
&emsp;&emsp;-Move in any direction (on plan X And Z)  
&emsp;&emsp;-Jump  
&emsp;Camera  
&emsp;&emsp;-Cinemachine  
&emsp;&emsp;-Hard fix player  
&emsp;&emsp;-Rotate at same time of player  
&emsp;Coin  
&emsp;&emsp;-Spawn X amount of coin randomly in map (Supposed to be 3)  
&emsp;&emsp;-When collected the coin have to "respawn" in random location  
&emsp;&emsp;-When collected play a sound  
&emsp;Door  
&emsp;&emsp;-Open when X amount of coin are collected  
&emsp;&emsp;-Animation when door open  
&emsp;UI  
&emsp;&emsp;-Display amount of Coin  
&emsp;&emsp;-Display time on level  
&emsp;&emsp;-Display message when door is open (Assumption: make message disapear after X second)  

  
# Tech Design  
Script  

&emsp;Manager  
&emsp;&emsp;-CoinManager  
&emsp;&emsp;&emsp;Manage coin spawn    
&emsp;&emsp;-GameManager (singleton)  
&emsp;&emsp;&emsp;Main loop of the game  
&emsp;&emsp;-SoundManager(singleton)  
&emsp;&emsp;&emsp;Play one shot sound  
&emsp;&emsp;-LevelManager(singleton)  
&emsp;&emsp;&emsp;Manage size of the level. Can swap between level  

&emsp;ScriptableObject(Data)  
&emsp;&emsp;-CoinData  
&emsp;&emsp;&emsp;Variable  
&emsp;&emsp;&emsp;&emsp;CoinValue;  
&emsp;&emsp;&emsp;&emsp;OnCollectSound;  
&emsp;&emsp;&emsp;&emsp;CoinPrefab  

&emsp;&emsp;-PlayerData  
&emsp;&emsp;&emsp;Variable  
&emsp;&emsp;&emsp;&emsp;maxSpeed;  
&emsp;&emsp;&emsp;&emsp;acceleration;  
&emsp;&emsp;&emsp;&emsp;rotationSpeed;  
&emsp;&emsp;&emsp;&emsp;jumpForce;  
&emsp;&emsp;&emsp;&emsp;InputAction directionAction;  
&emsp;&emsp;&emsp;&emsp;InputAction jumpAction;  
&emsp;&emsp;-SoundData  
&emsp;&emsp;&emsp;Variable  
&emsp;&emsp;&emsp;&emsp;List of sound data(SoundData is a struct)  

&emsp;Object  
&emsp;&emsp;-Coin  
&emsp;&emsp;&emsp; Detect when player it that coin and invoke event  
&emsp;&emsp;-Door  
&emsp;&emsp;&emsp;Listen to a event (event is invoke when coin collected is over X coin)  
&emsp;&emsp;-Level  
&emsp;&emsp;&emsp;Contain limit off that level and the coin for finish the level  
&emsp;Enum  
&emsp;&emsp;Class Enum to list all enumeration of the game  
&emsp;&emsp;&emsp;-DoorState  
&emsp;&emsp;&emsp;-SoundName  
&emsp;Delegate  
&emsp;&emsp;Class to create all Delegate of the game (event)  
&emsp;&emsp;&emsp;-UnlockingDoor();  
&emsp;&emsp;&emsp;-ModifyPoint(int point);  
&emsp;&emsp;&emsp;-CoinLoot(Coin coin);  
&emsp;&emsp;&emsp;-GameStart();  
&emsp;&emsp;&emsp;-StartLevel();  
&emsp;&emsp;&emsp;-EndLevel();  
&emsp;&emsp;&emsp;-ExitLevelBoxPass();  
&emsp;Struct  
&emsp;&emsp;Class to create all struct of the game  
&emsp;&emsp;&emsp;-SoundData();
  
# Tuto

CREATE COINS  
&emsp;1-Make a prefab of the coin (prefab need to have Coin script on it and a trigger collider)  
&emsp;2-Go in (Asset/Resources/Coins) and create a new CoinData (ScriptableObject)  
&emsp;3-Fill data and include the prefab in coinPrefab  
&emsp;4-Enjoy  

Create level  
&emsp;1- Create a level in editor   
&emsp;3- Put level script on root of your level  
&emsp;4- Refer all Dependencie in inspector  
&emsp;5- Replace the level in LevelManager value with the new level  

# optimization idea
1-Create interface for coin  
2-Make factory for coin  
3-Modify PlayerData to PlayerMovementData and make a mother abstract class call PlayerMovementData  
&emsp;Add abstract method call GetDirection  
&emsp;Advantage: can be used by player and a future ia  
