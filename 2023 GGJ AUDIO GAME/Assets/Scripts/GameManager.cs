using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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

    public static GameManager instance;

    private void Awake()
    {
        if (GameManager.instance == null)
            GameManager.instance = this;
        else
            Destroy(this.gameObject);
    }

    private void Start()
    {
        managerUI = gameObject.GetComponent<ManagerUI>();

        // RESET STATS
        speedMultiplierPerSecond = 0.002f;
        currSpeedMultiplier = 1f;
        maxSpeedMultiplier = 5f;
        lastSpeedUpdate = 0;
    }

    public bool ProcessCollisionWithPhilosopher()
    {
        bool philosopherDied = true;
        currPhilosphers--;
        managerUI.UpdatePhilosopherCount();
        return philosopherDied;
    }

    void Update()
    {
        if (currSpeedMultiplier < maxSpeedMultiplier &&
            lastSpeedUpdate + 1 > Time.time)
        {
            currSpeedMultiplier += speedMultiplierPerSecond;
            lastSpeedUpdate = Time.time;
        }
        Debug.Log("speed " + currSpeedMultiplier);
    }
}
