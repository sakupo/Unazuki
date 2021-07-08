using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Main
{
  public class ColorSaturationButton : MonoBehaviour
  {
    [SerializeField] private Image background;
    [SerializeField] private Image mark;
    [SerializeField] private TextMeshPro label;
    private readonly List<IObserver<bool>> displays = new List<IObserver<bool>>();

    public IDisposable Subscribe(IObserver<bool> observer)
    {
      displays.Add(observer);
      return new Unsubscriber(displays, observer);
    }

    public void OnClick(bool isOn)
    {
      if (isOn)
      {
        background.color = Color.white;
        mark.color = Color.red;
        label.text = "彩度: <color=#ff0000>高</color>";
      }
      else
      {
        background.color = Color.gray;
        mark.color = new Color(128/255f, 0, 0);
        label.text = "彩度: <color=#333333>低</color>";
      }
      
      foreach (var display in displays)
      {
        display.OnNext(isOn);
      }
    }

    private class Unsubscriber : IDisposable
    {
      private readonly List<IObserver<bool>> observers;
      private readonly IObserver<bool> observer;

      public Unsubscriber(List<IObserver<bool>> observers, IObserver<bool> observer)
      {
        this.observers = observers;
        this.observer = observer;
      }

      public void Dispose()
      {
        if (observer != null && observers.Contains(observer)) observers.Remove(observer);
      }
    }
  }
}