using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerCamera : MonoBehaviour
{
    public int zoomLevel = 0;
    /// <summary>
    /// -1 zooming in +1 zooming out, 0 nothing
    /// </summary>
    public int isZoomingOut = 0; 
    private Camera thisCamera;

    private float defaultCameraSize;
    [SerializeField]
    private float bigCameraSize;
    private float currCameraSize;

    private Vector3 defaultCameraPos;
    [SerializeField]
    private Vector3 bigCameraPos;
    private Vector3 currCameraPos;

    private void Start()
    {
        thisCamera = gameObject.GetComponent<Camera>();
        defaultCameraSize = thisCamera.orthographicSize;
        defaultCameraPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        currCameraSize = defaultCameraSize;
        currCameraPos = defaultCameraPos;
    }

    public void ZoomOut()
    {
        if (zoomLevel > 0)
            return;
        zoomLevel++;
        IEnumerator zoom = ChangeZoom(
            startSize: defaultCameraSize,
            bigCameraSize,
            bigCameraPos, startPos: new Vector3(defaultCameraPos.x, defaultCameraPos.y, defaultCameraPos.x));
        StartCoroutine(zoom);
    }
    public void ZoomIn()
    {
        if (zoomLevel <= 0)
        {
            return;
        }
        zoomLevel--;
        IEnumerator zoom = ChangeZoom(bigCameraSize, defaultCameraSize, 
            defaultCameraPos,
            startPos: new Vector3(bigCameraPos.x, bigCameraPos.y, defaultCameraPos.x));
        StartCoroutine(zoom);
    }

    public IEnumerator ChangeZoom(float startSize,
        float targetCameraSize, Vector3 targetCameraPosition, Vector3 startPos)
    {
        Debug.Log("ye");
        if (targetCameraSize > currCameraSize)
        {
            isZoomingOut = 1;
        }
        else
        {
            isZoomingOut = -1; // zooming in
        }
        //zoom out
        float currentTime = 0;
        float zoomDuration = 1.4f;
       // float zoomEndTime = currentTime + zoomDuration;
        float startCameraSize = currCameraSize;
        float startCameraX = currCameraPos.x;
        float startCameraY = currCameraPos.y;
        while (currentTime < zoomDuration)
        {
            currentTime += Time.deltaTime;
            //Debug.Log("auafsaff");
            //if (isZoomingOut == 1 && targetCameraSize < currCameraSize)
            //    break;
            //if (isZoomingOut == -1 && targetCameraSize > currCameraSize)
            //    break;

            // size
            thisCamera.orthographicSize = Mathf.Lerp(startCameraSize, targetCameraSize, currentTime / zoomDuration);
            currCameraSize = thisCamera.orthographicSize;

            // position
            transform.position = new Vector3(
                Mathf.Lerp(startPos.x, targetCameraPosition.x, currentTime / zoomDuration),
                Mathf.Lerp(startPos.y, targetCameraPosition.y, currentTime / zoomDuration),
                targetCameraPosition.z);
            currCameraPos = transform.position;

            yield return null;
        }

        isZoomingOut = 0;
        yield return null;
    }
}
