using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utility;

namespace InputZoomUrl
{
  public class HomeCanvas : UICanvas
  {
    protected override void InitAtStart()
    {
      // 以下のCanvasを隠す
      List<CanvasEx> canvasExs = GetCanvasExsFromScene("MainScene");
      foreach (var canvasEx in canvasExs)
      {
        canvasEx.HideCanvas();
      }
    }
  }
}