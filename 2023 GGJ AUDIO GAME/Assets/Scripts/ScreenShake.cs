using System.Collections;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    private Vector3 originalCameraPosition;
    public float amount = 0.01f;
    public Camera mainCamera;

    void Awake()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    void OnEnable()
    {
        originalCameraPosition = mainCamera.transform.position;
    }

    public void Shake()
    {
        StartCoroutine(ShakeCamera());
    }

    private IEnumerator ShakeCamera()
    {
        float elapsed = 0.0f;
        float shakeDuration = 0.5f;

        while (elapsed < shakeDuration)
        {
            float x = Random.Range(-1f, 1f) * amount;
            float y = Random.Range(-1f, 1f) * amount;

            mainCamera.transform.position = new Vector3(x, y, originalCameraPosition.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        mainCamera.transform.position = originalCameraPosition;
    }
}

