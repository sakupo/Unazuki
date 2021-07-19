using UnityEngine;

namespace Main
{
  public class SoundDisplayButton : ObservableToggleButton 
  {
    protected override void TurnOn()
    {
      background.color = Color.white;
      label.text = "サウンド: <color=#ff0000>表示</color>";
    }

    protected override void TurnOff()
    {
      background.color = Color.gray;
      label.text = "サウンド: <color=#333333>非表示</color>";
    }
  }
}