using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool isGameOver = true;

    // UI
    [Header("Managers")]
    public ManagerUI managerUI;

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

    [Header("year")]
    public int currentYear;
    public bool isBC;
    private float lastYearUpdateTime = 0;
    private float yearUpdateInterval = 0.72f;
    public int totalYears = 0;
    public int aristotleEndYear = 1200;
    public int thomasEndYear = 1610;
    public int decartesEndYear = 1860;

    [Header("input")]
  

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
        managerUI = GameObject.FindGameObjectWithTag("ManagerOther").GetComponent<ManagerUI>();

        // RESET STATS
        speedMultiplierPerSecond = 0.0015f;
        currSpeedMultiplier = 1f;
        maxSpeedMultiplier = 3.0f;
        lastSpeedUpdate = 0;

        isGameOver = false;
        nextEnemySpawnTime = Time.time + minEnemySpawnCooldown;
        lastSpeedUpdate = Time.time;
        currPhilosphers = 1;

        // year
        currentYear = 350;
        isBC = true;
        lastYearUpdateTime = Time.time;
        totalYears = 0;

        enemies.Clear();
    }


    public bool ProcessCollisionWithPhilosopher()
    {
        bool philosopherDied = true;
        AddPhilosopher(-1);
        return philosopherDied;
    }

    public void AddPhilosopher(int count)
    {
        currPhilosphers+=count;
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
        UpdateCurrentYear();
            
    }

    private void ManageEnemySpawning()
    {
        if (Time.time > nextEnemySpawnTime)
        {
            nextEnemySpawnTime = Time.time + Random.Range(minEnemySpawnCooldown, maxEnemySpawnCooldown);
            GameObject newEnemy = Instantiate(enemy1);
            newEnemy.transform.position = new Vector3(
                enemySpawnPosX+1f,
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


    private void UpdateCurrentYear()
    {
        float yearSpeedMultiplier = yearUpdateInterval / currSpeedMultiplier;
        if (currentYear < aristotleEndYear)
            yearSpeedMultiplier = yearSpeedMultiplier/4;
        else if (currentYear < thomasEndYear)
            yearSpeedMultiplier = yearSpeedMultiplier/2;
        if (Time.time < lastYearUpdateTime + yearSpeedMultiplier)
            return;
        lastYearUpdateTime = Time.time;
        totalYears++;
        if (isBC)
        {
            currentYear--;
            if (currentYear == 0)
            {
                isBC = false;
            }
        }
        else
        {
            currentYear++;
        }
        managerUI.UpdateYearText();
    }
}
