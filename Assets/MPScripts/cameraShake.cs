using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraShake : MonoBehaviour
{
    public float duration = 1f;
    public AnimationCurve curve;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public IEnumerator Shaking() {
        Vector3 startPosition = transform.position;
        float elapedTime = 0f;

        while (elapedTime < duration) {
            elapedTime += Time.deltaTime;
            float strength = curve.Evaluate(elapedTime/duration);
            transform.position = startPosition + Random.insideUnitSphere * strength;
            yield return null;
        }

        transform.position = startPosition;
    
    }
}
