using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    private Transform myTransform;
    [SerializeField] Arrow arrow;
    [SerializeField] private SpriteRenderer arrowSprite;
    void Start()
    {
        myTransform = GetComponent<Transform>();
        //StartCoroutine(SpawnArrow());
    }

    // Update is called once per frame
    void Update()
    {
        //StartCoroutine(SpawnArrow());
        //SpawnArrow();
    }

    public void Shoot()
    {
        StartCoroutine(SpawnArrow());
    }

    IEnumerator SpawnArrow()
    {
        arrowSprite.enabled = true;
        yield return new WaitForSeconds(1);
        Instantiate(arrow, myTransform.position, new Quaternion());
        arrowSprite.enabled = false;
        

    }
    
}
