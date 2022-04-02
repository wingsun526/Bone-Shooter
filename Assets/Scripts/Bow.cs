using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    private Transform myTransform;
    [SerializeField] GameObject arrow;
    void Start()
    {
        myTransform = GetComponent<Transform>();
        StartCoroutine(SpawnArrow());
    }

    // Update is called once per frame
    void Update()
    {
        //StartCoroutine(SpawnArrow());
        //SpawnArrow();
    }

    IEnumerator SpawnArrow()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);
            Instantiate(arrow, myTransform.position, new Quaternion());
        }

    }
    
}
