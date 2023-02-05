using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isActive = false;
    public SpriteRenderer mainSprite;
    private List<PhilosopherAnimations> myFollowerAnimations = new List<PhilosopherAnimations>();
    [SerializeField]
    public PhilosopherAnimations myAnimations;
    [SerializeField]
    private GameObject followerPrefab;

    private float philoDistance = 1f;
    private float followerDistance = 2f;
    private int followerCount = 0;
    private float lastRemoveTime = 0;
    private bool hasLostPhilos = false;
    private float lastAddTime = 0;

    private void Start()
    {
        myFollowerAnimations.Add(myAnimations);
        
    }

    public void InitializePlayer()
    {
        myAnimations.Initialize();
    }

    public void AddPhilosopher(Philosopher philosopher)
    {
        followerCount++;
        // my transform
        gameObject.transform.position = new Vector3(transform.position.x + philoDistance,
            transform.position.y, transform.position.z);

        // other sprites
        GameObject newFollowerObject = Instantiate(followerPrefab.gameObject);
        PhilosopherAnimations newAnimations = newFollowerObject.GetComponent<PhilosopherAnimations>();
        newAnimations.ChangePhilosopher(philosopher);


          
            newFollowerObject.transform.position = new Vector3(-7.07f - ((followerCount) * philoDistance), -2.82f, 0);
            newFollowerObject.transform.parent = this.transform;
            myFollowerAnimations.Add(newAnimations);
            newAnimations.Initialize();
            newAnimations.isPlayer = true;

        if (followerCount > 0 && Time.time > lastAddTime + 2f)
        {
            lastAddTime = Time.time;
            GameManager.instance.managerCamera.ZoomOut();
        }
    }

    public void RemovePhilosopher(bool removeFromFront = false)
    {
        if (followerCount >0)
            followerCount--;
        hasLostPhilos = true;

        if (!removeFromFront && followerCount > 0)
        {
            for (int i = 0; i < myFollowerAnimations.Count; i++)
            {
                myFollowerAnimations[i].transform.position = new Vector3(
                    myFollowerAnimations[i].transform.position.x + philoDistance,
                    myFollowerAnimations[i].transform.position.y,
               myFollowerAnimations[i].transform.position.z);
            }
            PhilosopherAnimations animationsToDelete = myFollowerAnimations[myFollowerAnimations.Count - 1];
            animationsToDelete.ChangePhilosopher(Philosopher.Default);
            myFollowerAnimations.Remove(animationsToDelete);
            Destroy(animationsToDelete.gameObject);
            transform.position = new Vector3(transform.position.x - philoDistance, transform.position.y,
               transform.position.z);
        }
        else if (myFollowerAnimations.Count >= 0)
        {

            PhilosopherAnimations animationToDelete = myFollowerAnimations[0];
            myFollowerAnimations.Remove(animationToDelete);
            Destroy(animationToDelete.gameObject);
            transform.position = new Vector3(transform.position.x - philoDistance, transform.position.y,
             transform.position.z);
            foreach (PhilosopherAnimations philoAnim in myFollowerAnimations)
            {
                Transform philoTran = philoAnim.gameObject.transform;
                philoTran.position =
                    new Vector3(
                        philoTran.position.x + philoDistance + philoDistance,
                        philoTran.position.y,
                        philoTran.position.z);
            }
        }
        
        if (followerCount >= 0 && Time.time > lastRemoveTime + 2.4f)
        {
            lastRemoveTime = Time.time;
            GameManager.instance.managerCamera.ZoomIn();
        }
    }
}
