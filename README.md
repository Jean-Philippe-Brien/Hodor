# Hodor
Chaac test

HOW TO PLAY  
	Summary  
		Have to collect X amount of coin to open a door  
	Control  
		-W = Forward  
		-S = Backward  
		-A = Left  
		-D = Righr  
		-Space = Jump  
  
  
FEATURE  
	Player  
		-Move in any direction (on plan X And Z)  
		-Jump  
	Camera  
		-Cinemachine  
		-Hard fix player  
		-Rotate at same time of player  
	Coin  
		-Spawn X amount of coin randomly in map (Supposed to be 3)  
		-When collected the coin have to "respawn" in random location  
		-When collected play a sound  
	Door  
		-Open when X amount of coin are collected  
		-Animation when door open  
	UI  
		-Display amount of Coin  
		-Display time on level  
		-Display message when door is open (Assumption: make message disapear after X second)  
  
  
Tech Design  
	Manager (Singleton)  
		-CoinManager  
			Manage coin spawn  
		-GameManager  
			Main loop of the game  
		-SoundManager  
			Play one shot sound  
	ScriptableObject(Data)  
		-CoinData  
			Variable  
				CoinValue;  
				OnCollectSound;  
				CoinPrefab  
		-PlayerData  
			Variable  
				maxSpeed;  
				acceleration;  
				rotationSpeed;  
				jumpForce;  
				InputAction directionAction;  
				InputAction jumpAction;  
		-SoundData  
			Variable  
				List of sound data(SoundData is a struct)  
	Object  
		-Coin  
			Variable  
				CoinValue;  
				OnCollectSound;  
				static event OnCoinCollect  
			unity Method  
				OnTriggerEnter  
					Detect if player take coin  
			public Method  
				Initialize(coinValue, OnCollectSound)  
		-Door  
			Variable  
				State (open, close, idle)  
			private Method  
				OnStateChange  
	Enum  
		Class Enum to list all enumeration of the game  
	Delegate  
		Class to create all Delegate of the game (event)  
	Struct  
		Class to create all struct of the game  
  
  
CREATE COINS  
	1-Make a prefab of the coin (prefab need to have Coin script on it)  
	2-Go in (Asset/Resources/Coins) and create a new CoinData (ScriptableObject)  
	3-Fill data and include the prefab in coinPrefab  
	4-Enjoy  