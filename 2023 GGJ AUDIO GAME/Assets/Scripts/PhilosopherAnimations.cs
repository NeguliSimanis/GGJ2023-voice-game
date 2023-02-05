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
    public int maxAge = 121;
    [SerializeField]
    private TextMeshProUGUI ageText;
    public int birthYear;
    public int deathYear;
    private bool isDead = false;
    
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
        if (GameManager.instance.GetCurrentYear() > deathYear)
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
