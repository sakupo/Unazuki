using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Main
{
  public class ColorSaturationButton : ObservableToggleButton
  {
    protected override void TurnOn()
    {
      background.color = Color.white;
      mark.color = Color.red;
      label.text = "彩度: <color=#ff0000>高</color>";
    }

    protected override void TurnOff()
    {
      background.color = Color.gray;
      mark.color = new Color(128/255f, 0, 0);
      label.text = "彩度: <color=#333333>低</color>";
    }
  }
}