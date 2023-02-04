using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isActive = false;
    public SpriteRenderer mainSprite;
    private List<SpriteRenderer> mySprites = new List<SpriteRenderer>();
    [SerializeField]
    private GameObject followerObject;

    private float philoDistance = 1f;
    private float followerDistance = 2f;
    private int followerCount = 0;

    private void Start()
    {
        mySprites.Add(mainSprite);
    }

    public void AddPhilosopher(Sprite philosopherSprite)
    {
        followerCount++;
        gameObject.transform.position = new Vector3(transform.position.x + philoDistance,
            transform.position.y, transform.position.z);
        GameObject newFollowerObject = Instantiate(mainSprite.gameObject);
        //newFollowerObject.transform.parent = this.transform;
        SpriteRenderer newSprite = newFollowerObject.GetComponent<SpriteRenderer>();
        newSprite.sprite = philosopherSprite;
        newFollowerObject.transform.position = new Vector3(-7.07f - ((followerCount) * philoDistance), -2.82f, 0);
        newFollowerObject.transform.parent = this.transform;
        mySprites.Add(newSprite);
    }

    public void RemovePhilosopher()
    {
        if (followerCount < 1)
            return;
        followerCount--;
        for (int i = 0; i < mySprites.Count; i++)
        {
            if (i + 1 < mySprites.Count)
            {
                mySprites[i].sprite = mySprites[i + 1].sprite;
            }
        }
        mySprites[mySprites.Count - 1].enabled = false;
        mySprites.RemoveAt(mySprites.Count - 1);
        //foreach(SpriteRenderer sprite in mySprites)
        //{
        //    Vector3 oldPos = sprite.gameObject.transform.position;
        //        sprite.gameObject.transform.position =
        //        new Vector3(oldPos.x - philoDistance, oldPos.y, oldPos.z);
        //}
        transform.position = new Vector3(transform.position.x - philoDistance, transform.position.y,
            transform.position.z);
    }
}
