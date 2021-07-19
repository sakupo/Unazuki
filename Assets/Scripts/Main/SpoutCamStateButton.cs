using System;
using System.Collections.Generic;
using System.Linq;
using Klak.Spout;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Utility;

namespace Main
{
  public class SpoutCamStateButton : ObservableToggleButton
  {
    protected override void TurnOn()
    {
      background.color = Color.white;
      label.text = "カメラ: <color=#ff0000>ON</color>";
    }

    protected override void TurnOff()
    {
      background.color = Color.gray;
      label.text = "カメラ: <color=#333333>OFF</color>";
    }
  }
}