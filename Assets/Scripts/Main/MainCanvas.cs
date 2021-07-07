using System;
using UnityEngine;
using Utility;

namespace Main
{
  public class MainCanvas : UICanvas
  {
    private CanvasEx spoutCanvasEx;
    private CanvasEx unazukiCanvasEx;

    private void Awake()
    {
      spoutCanvasEx = CanvasEx.GetCanvasExFromScene("SpoutScene");
      unazukiCanvasEx = CanvasEx.GetCanvasExFromScene("UnazukiScene");
#if !DEBUG
      HideCanvas();
#endif
    }

    protected override void Init()
    {
      // main canvasと同時に起動
      spoutCanvasEx.ShowCanvas();
      unazukiCanvasEx.ShowCanvas();
    }

    protected override void Final()
    {
      // main canvasと同時に終了
      spoutCanvasEx.HideCanvas();
      unazukiCanvasEx.HideCanvas();
    }
  }
}