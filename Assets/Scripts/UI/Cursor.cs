using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class Cursor : MonoBehaviour
{
    RectTransform UIComponentToFollow, myTransform;
    [SerializeField]Camera myCamera;

    public event Action<RectTransform> SelectionChanged;

    private void Start()
    {
        myTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (UIComponentToFollow != null)
            myTransform.position = myCamera.ScreenToWorldPoint(myCamera.WorldToScreenPoint(UIComponentToFollow.position) + Utils.Vec2To3(new Vector2(-myTransform.sizeDelta.x*2,0)));
        
    }


    public void MarkOption(RectTransform rect)
    {
        UIComponentToFollow = rect;
        SelectionChanged?.Invoke(UIComponentToFollow);
    }
    public RectTransform GetSelectedItem()
    {
        return UIComponentToFollow;
    }
  

}
