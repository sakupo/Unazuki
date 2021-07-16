using System;
using System.Collections.Generic;
using System.Linq;
using InputZoomUrl;
using UnityEngine;
using Utility;

namespace Main
{
  public class MainCanvas : UICanvas
  {
    [SerializeField] private RoomInfo roomInfo;
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
      // roominfoの更新
      var displayRooms = GetComponentInCanvasChildrenFromScene<DisplayRooms>("HomeScene");
      var currentRoom = displayRooms.getClickedRoom();  
      roomInfo.SetInfo(currentRoom.Item1, currentRoom.Item2);
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