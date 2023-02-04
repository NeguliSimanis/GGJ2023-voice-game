using System.Collections;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public float shakeAmount = 0.7f;

    Vector3 originalPos;
    float shakeTime;

    void Start()
    {
        originalPos = transform.localPosition;
    }

    void Update()
    {
        if (shakeTime > 0)
        {
            transform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
            shakeTime -= Time.deltaTime;
        }
        else
        {
            shakeTime = 0f;
            transform.localPosition = originalPos;
        }
    }

    public void TriggerShake(float shake)
    {
        shakeTime = shake;
    }
}