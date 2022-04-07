using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private float shakeDuration = 0.5f;
    [SerializeField] float shakeMagnitude = 0.01f;
    
    private Vector3 initialPosition;


    private void Start()
    {
        
    }
     
    

    public void PlayScreenShake()
    {
        initialPosition = transform.position;
        StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {
        //initialPosition = transform.position;
        float elapsedTime = 0;
        while (elapsedTime < shakeDuration)
        {
            
            transform.position = initialPosition + (Vector3)Random.insideUnitCircle * shakeMagnitude;
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        transform.position = initialPosition;
    }
}
