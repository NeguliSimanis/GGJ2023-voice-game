using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Obstacle : MonoBehaviour
{

    public Player player;
    private bool hasInteractedWithPlayer = false;
    private bool isDead = false;
    public bool isInitialized = false;

    /// <summary>
    /// leftmost position obstacle moves before it is destroyed
    /// </summary>
    [Header("movement")]
    public float speed;
    [SerializeField]
    private float minPosX;
    [SerializeField]
    private float colliderLeftOffset;
    [SerializeField]
    private float colliderRightOffset;
    [SerializeField]
    private float colliderTopOffset;
    [SerializeField]
    private float colliderPlayerHandicap;
    private bool isInPlayerRange = false;
    public bool canHurtPlayer = true;

    [Header("VISUAL")]
    [SerializeField] public TextMeshProUGUI myText;
    [SerializeField] private PhilosopherAnimations myAnimations;
    private Philosopher myPhilosopher = Philosopher.Aristotle;

    [Header("voic recog")]
    public bool isDifficultEnemy;
    [SerializeField] public TextMeshProUGUI audioText;
    public SpeechTypes mySpeechType = SpeechTypes.Join;

    [Header("PHILOSOPHERS")]
    [SerializeField] Sprite aristotle;
    [SerializeField] Sprite thomasSprite;
    [SerializeField] Sprite decartes;
    [SerializeField] Sprite nietszsche;
    public Dictionary<int, Philosopher> philosopherRequirements;

    // text input
    public string wordTyped = "";
    public int lettersTyped = 0;

    private void Start()
    {
        player = GameManager.instance.currPlayer;
        myText.text = GameManager.instance.texts.GetRandomText(difficulty: GameManager.instance.difficulty);
        InitializeEnemy();
    }

    private void SetMySprite()
    {
        int year = (int)GameManager.instance.GetCurrentYear();
        if (year < GameManager.instance.aristotleEndYear)
        {
            myAnimations.ChangePhilosopher(Philosopher.Aristotle);
            myPhilosopher = Philosopher.Aristotle;
        }
        else if (year < GameManager.instance.thomasEndYear)
        {
            myAnimations.ChangePhilosopher(Philosopher.Thomas);
            myPhilosopher = Philosopher.Thomas;
        }
        else if (year < GameManager.instance.decartesEndYear)
        {
            myAnimations.ChangePhilosopher(Philosopher.Decartes);
            myPhilosopher = Philosopher.Decartes;
        }
        else
        {
            myAnimations.ChangePhilosopher(Philosopher.Nietszche);
            myPhilosopher = Philosopher.Nietszche;
        }
    }

    public void InitializeEnemy()
    {
        audioText.gameObject.SetActive(false);
        SetMySprite();
        GameManager.instance.enemies.Add(this);
        GameManager.instance.enemies[0] = this;

        isInPlayerRange = true;
        myText.color = Color.yellow;
        myText.fontStyle = FontStyles.Bold;
        isInitialized = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime * GameManager.instance.currSpeedMultiplier);
        if (transform.position.x < minPosX)
            Destroy(gameObject);
    }

    private void Update()
    {
        CheckForCollisionWithPlayer();
    }

    private void CheckForCollisionWithPlayer()
    {

        if (player.transform.position.x > transform.position.x + 0.2f &&
            player.transform.position.x < colliderRightOffset * 0.4f + transform.position.x &&
            player.transform.position.y < colliderTopOffset * 0.4f + transform.position.y)
        {
            if (canHurtPlayer &&
                !hasInteractedWithPlayer && GameManager.instance.ProcessCollisionWithPhilosopher())
            {
                hasInteractedWithPlayer = true;
                ProcessDeath(ObstacleDeath.MissedByPlayer);
            }

        }
    }



    public void ProcessDeath(ObstacleDeath death)
    {
        if (isDead)
            return;
        isDead = true;
        IEnumerator die = DieAfterSeconds();
        if (death == ObstacleDeath.PunchedByPlayer ||
            death == ObstacleDeath.RecruitedByPlayer)
            canHurtPlayer = false;
        else
        {
            StartCoroutine(die);
            GameManager.instance.currPlayer.RemovePhilosopher();
            return;
        }
        if (death == ObstacleDeath.PunchedByPlayer)
        {
            myAnimations.enabled = false;
            myText.color = Color.green;
            GameManager.instance.currPlayer.AddPhilosopher(myPhilosopher);
            GameManager.instance.AddPhilosopher(1);
            die = DieAfterSeconds(0.9f);
            StartCoroutine(die);
        }
        else if (death == ObstacleDeath.RecruitedByPlayer)
        {
            audioText.color = Color.green;
            myText.enabled = false;
            myAnimations.enabled = false;
            GameManager.instance.AddPhilosopher(1);
            GameManager.instance.currPlayer.AddPhilosopher(myPhilosopher);
            die = DieAfterSeconds(0.9f);
            StartCoroutine(die);
        }
    }

    IEnumerator DieAfterSeconds(float seconds = 0)
    {
        for (int i = 0; i < GameManager.instance.speechToBeDetected.Count; i++)
        {
            if (GameManager.instance.speechToBeDetected[i] == mySpeechType)
                GameManager.instance.speechToBeDetected.RemoveAt(i);
        }
        GameManager.instance.enemies.Remove(this);
        GameManager.instance.enemies.Clear();
        yield return new WaitForSeconds(seconds);
        GameManager.instance.isDifficultEnemyAlive = false;
        Destroy(gameObject);
    }
}
