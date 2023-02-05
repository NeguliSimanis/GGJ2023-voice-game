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

    // grave
    [SerializeField]
    GameObject graveStone;


    private Dictionary<PhilosopherAnimations, Vector3> philosopherStartPositions = new Dictionary<PhilosopherAnimations, Vector3>();
    private Dictionary<PhilosopherAnimations, Vector3> philosopherTargetPositions = new Dictionary<PhilosopherAnimations, Vector3>();
    private Dictionary<PhilosopherAnimations, float> philosopherMoveTimers = new Dictionary<PhilosopherAnimations, float>();

    private void Start()
    {
        myFollowerAnimations.Add(myAnimations);
    }

    public void Update()
    {
        foreach (PhilosopherAnimations philoAnim in myFollowerAnimations)
        {
            if (philosopherMoveTimers.ContainsKey(philoAnim))
            {
                Debug.Log("Moving philosopher");
                philosopherMoveTimers[philoAnim] -= Time.deltaTime;
                float progress = 1f - (philosopherMoveTimers[philoAnim] / 1f);

                Vector3 startPos = philosopherStartPositions[philoAnim];
                Vector3 targetPos = philosopherTargetPositions[philoAnim];
                if (progress < 0)
                {
                    progress = 0;
                    philosopherMoveTimers.Remove(philoAnim);
                    philosopherStartPositions.Remove(philoAnim);
                    philosopherTargetPositions.Remove(philoAnim);
                }
                Vector3 newPos = Vector3.Lerp(startPos, targetPos, progress);
                Debug.Log("Pos: " + newPos.ToString());
                philoAnim.gameObject.transform.position = newPos;
            }
        }
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
        // new WaitForSeconds(seconds);
        if (followerCount > 0)
            followerCount--;
        hasLostPhilos = true;

        Vector3 gravePos = new Vector3(0, 0, 0);

        if (!removeFromFront && followerCount > 0)
        {
            PhilosopherAnimations animationsToDelete = myFollowerAnimations[myFollowerAnimations.Count - 1];
            animationsToDelete.ChangePhilosopher(Philosopher.Default);
            myFollowerAnimations.Remove(animationsToDelete);

            //grave
            gravePos = animationsToDelete.gameObject.transform.position;
            GameObject newGrave = Instantiate(graveStone, animationsToDelete.transform);
            newGrave.transform.parent = null;

            Destroy(animationsToDelete.gameObject);

            transform.position = new Vector3(transform.position.x - philoDistance, transform.position.y,
               transform.position.z);
        }
        // removefrom front
        else if (myFollowerAnimations.Count >= 0 && GameManager.instance.isGameStarted)
        {

            PhilosopherAnimations animationToDelete = myFollowerAnimations[0];
            myFollowerAnimations.Remove(animationToDelete);
            gravePos = animationToDelete.gameObject.transform.position;
            GameObject newGrave = Instantiate(graveStone, animationToDelete.transform);
            newGrave.transform.parent = null;
            Destroy(animationToDelete.gameObject);
            transform.position = new Vector3(transform.position.x - philoDistance, transform.position.y,
             transform.position.z);

            Debug.Log("Remove");
            foreach (PhilosopherAnimations philoAnim in myFollowerAnimations)
            {
                Transform philoTran = philoAnim.gameObject.transform;

                philosopherStartPositions[philoAnim] = philoAnim.transform.position;

                philosopherTargetPositions[philoAnim] = new Vector3(
                    philoTran.position.x - philoDistance,
                    philoTran.position.y,
                    philoTran.position.z);

                philosopherMoveTimers[philoAnim] = 1f;
            }
        }

        if (followerCount >= 0 && Time.time > lastRemoveTime + 2.4f)
        {
            lastRemoveTime = Time.time;
            GameManager.instance.managerCamera.ZoomIn();
        }
    }
}
