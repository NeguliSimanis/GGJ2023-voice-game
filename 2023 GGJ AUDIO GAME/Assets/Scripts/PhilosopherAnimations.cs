using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhilosopherAnimations : MonoBehaviour
{
    public Philosopher philosopher;
    [SerializeField]
    GameObject aristotle;
    [SerializeField]
    GameObject thomas;
    [SerializeField]
    GameObject descartes;
    [SerializeField]
    GameObject nietzsche;

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
