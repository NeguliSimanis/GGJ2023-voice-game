using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    [SerializeField]
    GameObject copy;
    [SerializeField]
    bool shouldRespawnInsteadOfTeleport;
    bool destroying = false;
    public float speed;
    public float maxX;
    public float minX;

    SpriteRenderer objectSprite;
    [SerializeField]
    private bool isFirstObstacle;
    private bool firstObstacleOffsetAdded;

    private void Start()
    {
        objectSprite = gameObject.GetComponent<SpriteRenderer>();
        //InitializeObject(false);
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime * GameManager.instance.currSpeedMultiplier);
        if (transform.position.x < minX)
            ReuseBackground();
    }

    /// <summary>
    /// after image has reached leftmost position, set it's x position to the right
    /// </summary>
    private void ReuseBackground()
    {
        if (isFirstObstacle && !firstObstacleOffsetAdded)
        {
            firstObstacleOffsetAdded = true;
            transform.position = new Vector3(maxX-1, transform.position.y, transform.position.z);
            return;
        }
        transform.position = new Vector3(maxX, transform.position.y, transform.position.z);
    }

    //private void InitializeObject(bool setPos)
    //{
    //    if (setPos && !shouldRespawnInsteadOfTeleport && !destroying)
    //    {
    //        Vector2 pos = new Vector2(minX, transform.position.y);
    //        transform.position = pos;
    //    }
    //    if (isTree)
    //    {
    //        objectSprite.sprite = treeOptions[Random.Range(0, treeOptions.Length)];
    //    }
    //    if (shouldRespawnInsteadOfTeleport && !destroying && setPos)
    //    {
    //        Vector2 pos = new Vector2(minX, transform.position.y);
    //        Instantiate(copy, pos, Quaternion.identity, null);
    //        destroying = true;
    //        StartCoroutine(DestroyAfterSeconds());
    //    }
    //}

    //private IEnumerator DestroyAfterSeconds()
    //{
    //    yield return new WaitForSeconds(130f);
    //    Destroy(gameObject);
    //}
}
