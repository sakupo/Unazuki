namespace Utility
{
  using System.Linq;
  using UnityEngine;

  public static class GameObjectExtensions
  {
    public static T GetComponentInChildrenWithoutSelf<T>(this GameObject self) where T : Component
    {
      return self.GetComponentsInChildren<T>()
        .Where(c => self != c.gameObject)
        .First(obj => obj.GetComponent<T>() != null);
    }
    
    public static T[] GetComponentsInChildrenWithoutSelf<T>(this GameObject self) where T : Component
    {
      return self.GetComponentsInChildren<T>().Where(c => self != c.gameObject).ToArray();
    }
  }
}