using System;
using System.Collections.Generic;
using UnityEngine;

namespace Main
{
  public class ManShapeController : MonoBehaviour, IObserver<string>
  {
    private List<string> shapeNames;
    // 現在の形のid(0~6)
    public int CurrentShapeNumber { get; private set; } = 0;

    private void Start()
    {
      var menu = GetComponent<ManShapeScrollMenu>();
      shapeNames = menu.shapeNames;
    }

    public void OnCompleted()
    {
      // do nothing
    }

    public void OnError(Exception error)
    {
      // do nothing
    }

    public void OnNext(string itemName)
    {
      for (var i = 0; i < shapeNames.Count; i++)
      {
        if (itemName != shapeNames[i]) continue;
        CurrentShapeNumber = i;
        Debug.Log(i);
        break;
      }
    }
  }
}