using UnityEngine;

namespace Utility
{
  public class CanvasEx : MonoBehaviour
  {
    protected virtual void Start()
    {
      InitAtStart();
    }
    
    public void ShowCanvas()
    {
      gameObject.SetActive(true);
      Init();
    }

    public void HideCanvas()
    {
      gameObject.SetActive(false);
    }

    protected virtual void Init()
    {
      /* do nothing */
    }
    
    protected virtual void InitAtStart()
    {
      /* do nothing */
    }

    public Canvas GetCanvas()
    {
      return gameObject.GetComponent<Canvas>();
    }
  }
}