using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingDamageTextManager : MonoBehaviour
{
    public static FloatingDamageTextManager instance;
    private void Awake()
    {
        instance = this;
    }

    [SerializeField] GameObject textContainer;
    [SerializeField] GameObject textPrefab;

    private List<FloatingDamageText> poolOfTexts = new List<FloatingDamageText>();

  

    private void Update()
    {
        foreach (FloatingDamageText txt in poolOfTexts)
        {
            txt.UpdateFloatingDamageText();
        }
    }
   
    public void Show(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        FloatingDamageText floatingText = GetFloatingText();

        floatingText.txt.text = msg;
        floatingText.txt.fontSize = fontSize;
        floatingText.txt.color = color;
        floatingText.go.transform.position = Camera.main.WorldToScreenPoint(position); // Transfer world space to screen space so we can use it in the UI
        floatingText.motion = motion;
        floatingText.duration = duration;
      
        floatingText.Show();
    }
   
    private FloatingDamageText GetFloatingText()
    {
        FloatingDamageText txt = poolOfTexts.Find(t => !t.active); //  reusing old FloatingText instance that are inactive, https://gameprogrammingpatterns.com/object-pool.html, 
        // a technique that save resources.

        if (txt == null)
        {
            txt = new FloatingDamageText();
            txt.go = Instantiate(textPrefab);                        // give it a gameObject which is a floating text prefab  (This instance of the FloatingText class still doesn't have a body/gameObject.)
            txt.go.transform.SetParent(textContainer.transform);     
            txt.txt = txt.go.GetComponent<Text>();                   // the floating text gameObject has a text component, link it to this (class)FloatingText instance txt variable/property
            poolOfTexts.Add(txt);
        }

        return txt;
    }
}
