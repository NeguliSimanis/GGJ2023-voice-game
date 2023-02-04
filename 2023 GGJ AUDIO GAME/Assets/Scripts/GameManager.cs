using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public ScreenShake screenShake;
    public AnimationCurve yearCurve;
    private float playtime;
    public float maxPlaytime;
    public float minYears;
    public float maxYears;
    bool isGameOver = true;
    public int difficulty = 0;

    // UI
    [Header("Managers")]
    public ManagerUI managerUI;
    public ManagerCamera managerCamera;
    public ManagerAudio managerAudio;

    // Player stats
    [Header("player")]
    public int currPhilosphers = 1;
    public Player currPlayer;


    // BACKGROUND SPEED
    public float speedMultiplierPerSecond;
    public float currSpeedMultiplier;
    public float maxSpeedMultiplier;
    public float lastSpeedUpdate;

    // Enemy spawning
    [Header("enemy")]
    public GameObject enemy1;
    private float minEnemySpawnCooldown = 4.2f;
    private float maxEnemySpawnCooldown = 8f;
    private float lastEnemySpawnTime = 0;
    private float nextEnemySpawnTime;
    private float enemySpawnPosX = 8f;

    [Header("speech and texts")]
    public Texts texts;
    public List<SpeechTypes> speechToBeDetected = new List<SpeechTypes>();
    public bool isDifficultEnemyAlive = false;
    public Obstacle difficultEnemy;
    public List<Obstacle> enemies = new List<Obstacle>();

    public int aristotleEndYear = 1200;
    public int thomasEndYear = 1610;
    public int decartesEndYear = 1860;

    public static GameManager instance;

    private void Awake()
    {
        if (GameManager.instance == null)
            GameManager.instance = this;
        else
            Destroy(this.gameObject);
        DontDestroyOnLoad(this);
    }

    public void StartGame()
    {
        currPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        GameObject otherManagers = GameObject.FindGameObjectWithTag("ManagerOther");
        managerUI = otherManagers.GetComponent<ManagerUI>();
        managerAudio = otherManagers.GetComponent<ManagerAudio>();
        managerCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ManagerCamera>();

        // RESET STATS
        speedMultiplierPerSecond = 0.0005f;
        currSpeedMultiplier = 1f;
        maxSpeedMultiplier = 6.2f;
        lastSpeedUpdate = 0;

        isGameOver = false;
        nextEnemySpawnTime = Time.time + 0.2f;
        lastSpeedUpdate = Time.time;
        currPhilosphers = 1;


        enemies.Clear();
        difficulty = 0;
        playtime = 0;
    }


    public bool ProcessCollisionWithPhilosopher()
    {
        bool philosopherDied = true;
        AddPhilosopher(-1);
        this.screenShake.TriggerShake(0.5f);
        return philosopherDied;
    }

    public void AddPhilosopher(int count)
    {
        currPhilosphers += count;
        managerUI.UpdatePhilosopherCount();
        if (currPhilosphers <= 0)
            GameOver();
    }

    public void GameOver()
    {
        isGameOver = true;
        managerUI.ShowGameOverScreen();
    }

    void Update()
    {
        if (isGameOver)
            return;
        ManageGameSpeed();
        ManageEnemySpawning();
        UpdatePlaytime();
        ListenToPlayerInput();
        UpdateDifficulty();
    }

    private void ManageEnemySpawning()
    {
        if (Time.time > nextEnemySpawnTime && enemies.Count < 1)
        {
            nextEnemySpawnTime = Time.time + Random.Range(minEnemySpawnCooldown, maxEnemySpawnCooldown);
            GameObject newEnemy = Instantiate(enemy1);
            newEnemy.transform.position = new Vector3(
                enemySpawnPosX + 1f,
                -2.82f,
                newEnemy.transform.position.z);
            Obstacle newEnemyController = newEnemy.gameObject.GetComponent<Obstacle>();
            if (!isDifficultEnemyAlive)
            {
                isDifficultEnemyAlive = true;
                newEnemyController.isDifficultEnemy = true;
                newEnemyController.InitializeEnemy();
                difficultEnemy = newEnemyController;
            }
        }
    }
    private void ManageGameSpeed()
    {
        if (currSpeedMultiplier < maxSpeedMultiplier &&
           lastSpeedUpdate + 1 > Time.time)
        {
            currSpeedMultiplier += speedMultiplierPerSecond;
            lastSpeedUpdate = Time.time;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }


    private void UpdatePlaytime()
    {

        this.playtime += Time.deltaTime;
        managerUI.UpdateYearText();
    }

    public float GetCurrentYear()
    {
        return this.yearCurve.Evaluate(this.playtime / this.maxPlaytime) * (this.maxYears - this.minYears) + this.minYears;
    }
    private void ListenToPlayerInput()
    {
        if (enemies.Count < 1)
            return;
        if (!enemies[0].isInitialized)
            return;
        string requiredText = enemies[0].myText.text;
        if (enemies[0].lettersTyped >= requiredText.Length)
            return;
        string nextChar = "" + requiredText[enemies[0].lettersTyped];
        if (nextChar == " ")
        {
            enemies[0].lettersTyped++;
            enemies[0].wordTyped += " ";
            nextChar = "" + requiredText[enemies[0].lettersTyped];
        }


        string inputString = "";
        // Debug.Log(" char " + Input.inputString);
        if (Input.GetKeyDown(key: KeyCode.A))
        {
            inputString += "a";
        }
        else if (Input.GetKeyDown(key: KeyCode.B))
        {
            inputString += "b";
        }
        else if (Input.GetKeyDown(key: KeyCode.C))
            inputString += "c";
        else if (Input.GetKeyDown(key: KeyCode.D))
            inputString += "d";
        else if (Input.GetKeyDown(key: KeyCode.E))
            inputString += "e";
        else if (Input.GetKeyDown(key: KeyCode.F))
            inputString += "f";
        else if (Input.GetKeyDown(key: KeyCode.G))
            inputString += "g";
        else if (Input.GetKeyDown(key: KeyCode.H))
            inputString += "h";
        else if (Input.GetKeyDown(key: KeyCode.I))
            inputString += "i";
        else if (Input.GetKeyDown(key: KeyCode.J))
            inputString += "j";
        else if (Input.GetKeyDown(key: KeyCode.K))
            inputString += "k";
        else if (Input.GetKeyDown(key: KeyCode.L))
            inputString += "l";
        else if (Input.GetKeyDown(key: KeyCode.M))
            inputString += "m";
        else if (Input.GetKeyDown(key: KeyCode.N))
            inputString += "n";
        else if (Input.GetKeyDown(key: KeyCode.O))
            inputString += "o";
        else if (Input.GetKeyDown(key: KeyCode.P))
            inputString += "p";
        else if (Input.GetKeyDown(key: KeyCode.Q))
            inputString += "q";
        else if (Input.GetKeyDown(key: KeyCode.R))
            inputString += "r";
        else if (Input.GetKeyDown(key: KeyCode.S))
            inputString += "s";
        else if (Input.GetKeyDown(key: KeyCode.T))
            inputString += "t";
        else if (Input.GetKeyDown(key: KeyCode.U))
            inputString += "u";
        else if (Input.GetKeyDown(key: KeyCode.V))
            inputString += "v";
        else if (Input.GetKeyDown(key: KeyCode.W))
            inputString += "w";
        else if (Input.GetKeyDown(key: KeyCode.X))
            inputString += "x";
        else if (Input.GetKeyDown(key: KeyCode.Y))
            inputString += "y";
        else if (Input.GetKeyDown(key: KeyCode.Z))
            inputString += "z";
        else if (Input.GetKeyDown(key: KeyCode.Space))
            inputString += " ";

        if (inputString == nextChar.ToLower())
        {
            enemies[0].wordTyped += nextChar;
            enemies[0].audioText.gameObject.SetActive(true);
            enemies[0].audioText.color = Color.green;
            enemies[0].audioText.text = enemies[0].wordTyped;
            enemies[0].lettersTyped++;
            managerAudio.PlaySuccessSFX();

            if (enemies[0].lettersTyped >= requiredText.Length
                || enemies[0].wordTyped == requiredText.ToLower())
            {

                enemies[0].canHurtPlayer = false;
                enemies[0].ProcessDeath(ObstacleDeath.PunchedByPlayer);
            }

        }
        else if (inputString != "")
        {
            managerAudio.PlayFailSFX();
            this.screenShake.TriggerShake(0.5f);
        }
    }

    void UpdateDifficulty()
    {
        difficulty = 3;
        return;
        int year = (int)this.GetCurrentYear();
        if (year < aristotleEndYear)
        {
            difficulty = 0;
        }
        else if (year < thomasEndYear)
        {
            difficulty = 1;
        }
        else if (year < GameManager.instance.decartesEndYear)
        {
            difficulty = 2;
        }
        else
        {
            difficulty = 3;
        }
    }
}
