using UnityEngine;
using UnityEngine.SceneManagement;
using Utility;

namespace Main
{
  public class HomeButton : MonoBehaviour
  {
    public void OnClick()
    {
      var mainCanvasEx = CanvasEx.GetCanvasExFromScene("MainScene");
      mainCanvasEx.HideCanvas();
      var homeCanvasEx = CanvasEx.GetCanvasExFromScene("HomeScene");
      homeCanvasEx.ShowCanvas();
    }
  }
}