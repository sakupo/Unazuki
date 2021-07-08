using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utility;

namespace Main
{
  public class MainCanvas : UICanvas
  {
    protected override void InitAtStart()
    {
#if !DEBUG
      HideCanvas();
#endif
    }

    protected override void Init()
    {
      List<CanvasEx> canvasExs = GetCanvasExsFromScene("SpoutScene", "UnazukiScene");
      // main canvasと同時に起動
      foreach (var canvasEx in canvasExs)
      {
        canvasEx.ShowCanvas();
      }
    }

    protected override void Final()
    {
      List<CanvasEx> canvasExs = GetCanvasExsFromScene("SpoutScene", "UnazukiScene");
      // main canvasと同時に終了
      foreach (var canvasEx in canvasExs)
      {
        canvasEx.HideCanvas();
      }
    }
  }
}