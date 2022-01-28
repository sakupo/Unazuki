using UnityEngine;

namespace Main
{
  public class TimerDisplayButton : ObservableToggleButton 
  {
    protected override void TurnOn()
    {
      background.color = Color.white;
      label.text = "タイマー: <color=#ff0000>表示</color>";
    }

    protected override void TurnOff()
    {
      background.color = Color.gray;
      label.text = "タイマー: <color=#333333>非表示</color>";
    }
  }
}