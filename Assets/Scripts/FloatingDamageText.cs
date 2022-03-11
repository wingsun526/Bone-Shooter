using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingDamageText
{
    public bool active;
    public GameObject go;
    public Text txt;
    public Vector3 motion;
    public float duration;
    public float lastShown;
    
    public void Show()
    {
        active = true;
        lastShown = Time.time;
        go.SetActive(active);
    }
    
    public void Hide()
    {
        active = false;
        go.SetActive(active);
    }
    
    public void UpdateFloatingDamageText()
    {
        if (!active)
        {
            return;
        }
        if(Time.time - lastShown > duration)
        {
            Hide();
        }
        
        go.transform.position += motion * Time.deltaTime;
    }
}
