using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Main
{
  public class UnazukiBarStateButton : ObservableToggleButton
  {
    [SerializeField] Slider slider;

    private void Start()
    {
      // 起動時にoff
      TurnOff();
    }

    protected override void TurnOn()
    {
      background.color = Color.white;
      label.text = "うなずきバー: <color=#ff0000>有効</color>";
      slider.interactable = true;
    }

    protected override void TurnOff()
    {
      background.color = Color.gray;
      label.text = "うなずきバー: <color=#333333>無効</color>";
      slider.interactable = false;
    }
  }
}