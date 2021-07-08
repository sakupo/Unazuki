using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Main
{
  public class UnazukiBarStateButton : ObservableToggleButton
  {
    protected override void TurnOn()
    {
      background.color = Color.white;
      label.text = "うなずきバー: <color=#ff0000>有効</color>";
    }

    protected override void TurnOff()
    {
      background.color = Color.gray;
      label.text = "うなずきバー: <color=#333333>無効</color>";
    }
  }
}