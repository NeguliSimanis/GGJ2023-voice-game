using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerCamera : MonoBehaviour
{
    public const float ZOOM_PER_LEVEL = 0.5f;
    public int zoomLevel = 0;
    public int isZoomingOut = 0;
    private Camera mainCamera;

    private float defaultCameraSize;
    [SerializeField]
    private float cameraSize;

    private void Start()
    {
        mainCamera = Camera.main;
        defaultCameraSize = mainCamera.orthographicSize;
        cameraSize = defaultCameraSize;
    }

    public void ZoomOut()
    {
        zoomLevel++;
        IEnumerator zoom = ChangeZoom(defaultCameraSize + ZOOM_PER_LEVEL * zoomLevel);
        StartCoroutine(zoom);
    }
    public void ZoomIn()
    {
        zoomLevel--;
        IEnumerator zoom = ChangeZoom(defaultCameraSize + ZOOM_PER_LEVEL * zoomLevel);
        StartCoroutine(zoom);
    }

    public IEnumerator ChangeZoom(float targetCameraSize)
    {
        if (targetCameraSize > cameraSize)
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

        float startCameraSize = cameraSize;
        while (currentTime < zoomDuration)
        {
            currentTime += Time.deltaTime;
            mainCamera.orthographicSize = Mathf.Lerp(startCameraSize, targetCameraSize, currentTime / zoomDuration);
            cameraSize = mainCamera.orthographicSize;

            yield return null;
        }

        isZoomingOut = 0;
        yield return null;
    }
}
