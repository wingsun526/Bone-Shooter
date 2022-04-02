using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fairy : Enemy
{
    
    private Transform myWeapon;
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
    
    private void RotateWeapon()
    {
        //myWeapon.Rotate(0, 0, Vector2.Angle(mouseWorldPosition, myWeapon.position)); //Vector2.Angle(mouseWorldPosition, myWeapon.transform.position); 
        //myWeapon.rotation = Quaternion.Euler(0, 0, Vector2.Angle(mouseWorldPosition, myWeapon.transform.position) + 90);
        //myWeapon.LookAt(mouseWorldPosition);
        Vector2 direction = (playerTransform.position - myWeapon.position).normalized;
        myWeapon.up = direction;
    }
}
