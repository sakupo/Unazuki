using UnityEngine;

namespace Main
{
  public class TextDisplayButton : ObservableToggleButton
  {
    protected override void TurnOn()
    {
      background.color = Color.white;
      label.text = "テキスト: <color=#ff0000>表示</color>";
    }

    protected override void TurnOff()
    {
      background.color = Color.gray;
      label.text = "テキスト: <color=#333333>非表示</color>";
    }
  }
}