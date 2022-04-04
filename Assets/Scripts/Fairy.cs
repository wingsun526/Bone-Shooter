using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Fairy : Enemy
{
    [SerializeField] private Bow bow;
    private Transform myWeapon;

    private bool actionInProgress = false;

    private bool rotateWeaponLock = false;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        myWeapon = myTransform.Find("Weapon");
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        RotateWeapon();
       
    }
    
    protected override void IndividualAction()
    {
        if (beingPush) return;
        if (actionInProgress) return;
        StartCoroutine(FairyAction());

    }

    IEnumerator FairyAction()
    {
        actionInProgress = true;
        rotateWeaponLock = true;
        var startTime = Time.time;
        var endTime = Random.Range(0.5f, 3.0f);
        while (Time.time - startTime < endTime)
        {
            // walk closer 
            myRigidbody2D.velocity = (playerTransform.position - myRigidbody2D.transform.position).normalized * (speed * 0.2f);
            yield return null;
        }
        yield return new WaitForSeconds(1);
        rotateWeaponLock = false;
        // walk left or right
        Vector2 origin = (playerTransform.position - myRigidbody2D.transform.position).normalized;
        // random action
        List<Vector2> tempVec2List = new List<Vector2>() {Vector2.zero, new Vector2(-origin.y, origin.x), new Vector2(origin.y, -origin.x) };
        
        // 80% = 0, 10% = 1. 10% = 2
        int randomNumber = Random.Range(0, 10) - 7;
        int toIndex = randomNumber <= 0 ? 0 : randomNumber;
        myRigidbody2D.velocity = tempVec2List[toIndex] * (speed * 3);
        bow.Shoot();
        
        yield return new WaitForSeconds(2);
        rotateWeaponLock = true;
        actionInProgress = false;
        
    }

    private void RotateWeapon()
    {
        if (rotateWeaponLock)
        {
            
        }

        else
        {
            Vector2 direction = (playerTransform.position - myWeapon.position).normalized;
            myWeapon.up = direction;
        }
        
    }
}
