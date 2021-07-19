using Spout;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;
using Main;

public class SaturationObserver : MonoBehaviour, IObserver<bool>
{
    // Start is called before the first frame update
    void Start()
    {
        var colorSaturationButton = CanvasEx.GetComponentInCanvasChildrenFromScene<ColorSaturationButton>("MainScene");
        colorSaturationButton.Subscribe(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCompleted()
    {
        //何もしない
    }

    public void OnError(Exception error)
    {
        //何もしない
    }

    public void OnNext(bool value)
    {
        GetComponent<ColorChangeScript>().LowSaturation = !value;
    }

}
