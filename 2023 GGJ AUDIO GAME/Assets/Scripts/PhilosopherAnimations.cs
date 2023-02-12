using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PhilosopherAnimations : MonoBehaviour
{
    private bool playerInitialized = false;
    public bool isPlayer = false;

    // AGE STUFF
    public int myAge = 1;
    public int maxAge;
    [SerializeField]
    private TextMeshProUGUI ageText;
    public int birthYear;
    public int deathYear;
    private bool isDead = false;

    float deathTime;
    float birthTime;
    float yearLength = 0.16f;
    
    // ANIMATIONS
    public Philosopher philosopher;
    [SerializeField]
    GameObject aristotle;
    [SerializeField]
    GameObject thomas;
    [SerializeField]
    GameObject descartes;
    [SerializeField]
    GameObject nietzsche;

    private void Start()
    {
        if (!isPlayer)
            return;

    }

    public void ResetAge()
    {
        isDead = false;
        birthYear = (int)GameManager.instance.GetCurrentYear();
        deathYear = birthYear + maxAge;
    }

    public void Initialize()
    {
        
        ageText.gameObject.SetActive(true);
        birthYear = (int)GameManager.instance.GetCurrentYear();
        deathYear = birthYear + maxAge;
        Debug.Log(" birth: " + birthYear + " . Death: " + deathYear);

        birthTime = Time.time;
        deathTime = birthTime + yearLength * maxAge;
        playerInitialized = true;
  
    }
    private void Update()
    {
        if (isDead)
            return;
        if (!isPlayer)
            return;
        if (!playerInitialized)
            return;
        //Debug.Log(GameManager.instance.GetCurrentYear() + " ? " + deathYear);
        if (myAge > maxAge)
        {
            isDead = true;
            Debug.Log(gameObject + " MUST DIE!");
            GameManager.instance.currPlayer.RemovePhilosopher(removeFromFront: true);
            GameManager.instance.AddPhilosopher(-1, playSFX: false);
        }
        SetCurrAge();
        
        ageText.text = myAge.ToString();
    }

    private void SetCurrAge()
    {
        float temp = (Time.time - birthTime) / yearLength;
        if (GameManager.instance.difficulty == 0)
            temp *= 1.4f;
        else if (GameManager.instance.difficulty == 2)
            temp *= 1.3f;
        myAge = (int)temp + 1;

        if (myAge > 80)
        {
            ageText.color = Color.red;
        }
        return;
        int currYear = (int)GameManager.instance.GetCurrentYear();
        if (birthYear < 0 && currYear < 0)
        {
            myAge = Mathf.Abs(birthYear - currYear);
        }
        else if (birthYear < 0 && currYear >= 0)
        {
            myAge = Mathf.Abs(birthYear) + currYear;
        }
        else
        {
            myAge = currYear - birthYear;


        }
    }

    public void ChangePhilosopher(Philosopher newPhilo)
    {
        if (newPhilo == philosopher)
            return;
        switch (newPhilo)
        {
            case Philosopher.Aristotle:
                aristotle.SetActive(true);
                thomas.SetActive(false);
                descartes.SetActive(false);
                nietzsche.SetActive(false);
                break;
            case Philosopher.Thomas:
                aristotle.SetActive(false);
                thomas.SetActive(true);
                descartes.SetActive(false);
                nietzsche.SetActive(false);
                break;
            case Philosopher.Decartes:
                aristotle.SetActive(false);
                thomas.SetActive(false);
                descartes.SetActive(true);
                nietzsche.SetActive(false);
                break;
            case Philosopher.Nietszche:
                aristotle.SetActive(false);
                thomas.SetActive(false);
                descartes.SetActive(false);
                nietzsche.SetActive(true);
                break;
            case Philosopher.Default:
                aristotle.SetActive(false);
                thomas.SetActive(false);
                descartes.SetActive(false);
                nietzsche.SetActive(false);
                break;
        }
    }
}
