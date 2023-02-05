using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grave : MonoBehaviour
{
    private float moveSpeed = 1;
    [SerializeField]
    private float yOffset;

    private void Start()
    {
        transform.position =
            new Vector3(transform.position.x,
            transform.position.y + yOffset,
            transform.position.z);
    }

    void FixedUpdate()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime * GameManager.instance.currSpeedMultiplier);
        if (transform.position.x < -20)
            Destroy(gameObject);
    }

}
