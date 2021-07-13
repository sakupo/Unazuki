using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utility;


public class HomeCanvas : CanvasEx
{
    protected override void InitAtStart()
    {
#if DEBUG
        // 開発環境では以下のCanvasを隠す
        List<CanvasEx> canvasExs = GetCanvasExsFromScene("MainScene", "SpoutScene", "UnazukiScene");
        foreach (var canvasEx in canvasExs)
        {
            canvasEx.HideCanvas();
        }
#endif
    }
    
}
