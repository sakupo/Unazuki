using Utility;

namespace Spout
{
  public class SpoutCanvas : CanvasEx
  {
    protected override void Awake()
    {
#if !DEBUG
      HideCanvas();
#endif
    }
    protected override void Init()
    {
      GetCanvas().worldCamera.gameObject.SetActive(true);
    }
    
    protected override void Final()
    {
      GetCanvas().worldCamera.gameObject.SetActive(false);
    }
    
  }
}