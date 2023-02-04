using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerCamera : MonoBehaviour
{
    public int zoomLevel = 0;
    private Camera thisCamera;

    private float defaultCameraSize;
    [SerializeField]
    private float bigCameraSize;

    private Vector3 defaultCameraPos;
    [SerializeField]
    private Vector3 bigCameraPos;

    private void Start()
    {
        thisCamera = gameObject.GetComponent<Camera>();
        defaultCameraSize = thisCamera.orthographicSize;
        defaultCameraPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    public void ZoomOut()
    {
        if (zoomLevel > 0)
            return;
        zoomLevel++;
        thisCamera.orthographicSize = bigCameraSize;
        transform.position = bigCameraPos;
    }
    public void ZoomIn()
    {
        if (zoomLevel <= 0)
        {
            return;
        }
        zoomLevel--;
        thisCamera.orthographicSize = defaultCameraSize;
        transform.position = defaultCameraPos;
    }
}
