using Utility;

namespace Unazuki
{
  public class UnazukiCanvas: UICanvas
  {
    protected override void Init()
    {
      var unazukiScene = GetComponentFromScene<UnazukiScene>("UnazukiScene");
      unazukiScene.gameObject.SetActive(true);
    }
    
    protected override void Final()
    {
      var unazukiScene = GetComponentFromScene<UnazukiScene>("UnazukiScene");
      unazukiScene.gameObject.SetActive(false);
    }
  }
}