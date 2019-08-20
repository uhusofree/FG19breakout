using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeDuration;
    public float shakeMagnitude;

    private Vector3 originalPosition;
    private Coroutine shakeRoutine;

    bool test;

    //c# properties

    private void Awake()
    {
        originalPosition = transform.position;
    }
    public bool IsShaking
    {
        get { return shakeRoutine == null ? false : true; } //one line if case

    }

    public void Shake()
    {
        
        shakeRoutine = StartCoroutine(PerformShake());
    }

    public void StopShake()
    {
        if(shakeRoutine != null)
        {
            StopCoroutine(shakeRoutine);
        }
    }

    private IEnumerator PerformShake()
    {
        float elapsedTime = 0f;
        while (elapsedTime < shakeDuration)
        {
            float x = Random.Range(-1f, 1f) * shakeMagnitude;
            float y = Random.Range(-1f, 1f) * shakeMagnitude;
            transform.position = new Vector3(x, y, originalPosition.z);
            elapsedTime += Time.deltaTime;

            yield return null;

        }
        transform.position = originalPosition;
    }


}