using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isActive = false;
    public SpriteRenderer mainSprite;
    private List<PhilosopherAnimations> myFollowerAnimations = new List<PhilosopherAnimations>();
    [SerializeField]
    private PhilosopherAnimations myAnimations;
    [SerializeField]
    private GameObject followerPrefab;

    private float philoDistance = 1f;
    private float followerDistance = 2f;
    private int followerCount = 0;

    private void Start()
    {
        myFollowerAnimations.Add(myAnimations);
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

        if (followerCount > 2)
            GameManager.instance.managerCamera.ZoomOut();
    }

    public void RemovePhilosopher()
    {
        if (followerCount < 1)
            return;
        followerCount--;
        for (int i = 0; i < myFollowerAnimations.Count; i++)
        {
            if (i + 1 < myFollowerAnimations.Count)
            {
                myFollowerAnimations[i].ChangePhilosopher(myFollowerAnimations[i + 1].philosopher);
            }
        }
        PhilosopherAnimations animationsToDelete = myFollowerAnimations[myFollowerAnimations.Count - 1];
        animationsToDelete.ChangePhilosopher(Philosopher.Default);
        myFollowerAnimations.Remove(animationsToDelete);
        Destroy(animationsToDelete.gameObject);

        transform.position = new Vector3(transform.position.x - philoDistance, transform.position.y,
            transform.position.z);


        if (followerCount < 2)
            GameManager.instance.managerCamera.ZoomIn();
    }
}
