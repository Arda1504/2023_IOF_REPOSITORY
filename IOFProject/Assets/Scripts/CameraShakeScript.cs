using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeScript : MonoBehaviour
{
    public AnimationCurve curve;
    public float duration = 1f;

    IEnumerator Shaking()
    {
        Vector3 startPosition = transform.position;
        float elaspedTime = 0f;

        while (elaspedTime < duration)
        {
            elaspedTime += Time.deltaTime;
            float strength = curve.Evaluate(elaspedTime / duration);
            transform.position = startPosition + Random.insideUnitSphere * strength;
            yield return null;
        }

        transform.position = startPosition;
    }

    public void ShakeEvent()
    {
        StartCoroutine(Shaking());
    }
    
}
