using Utility;

namespace Settings
{
  public class SettingsCanvas: CanvasEx
  {
    protected override void Start()
    {
      Destroy(GetCanvas().worldCamera.gameObject);
    }
  }
}