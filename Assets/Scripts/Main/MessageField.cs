using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Main
{
  public class MessageField : MonoBehaviour, IObservable<string>
  {
    private readonly List<IObserver<string>> displays = new List<IObserver<string>>();
    [SerializeField] private TextMeshProUGUI message;
    
    public IDisposable Subscribe(IObserver<string> observer)
    {
     displays.Add(observer);
      return new Unsubscriber(displays, observer);
    }

    public void SendText()
    {
      var text = message.text;
      foreach (var display in displays)
      {
        display.OnNext(text);
      }
    }
    private class Unsubscriber : IDisposable
    {
      private readonly List<IObserver<string>>observers;
      private readonly IObserver<string> observer;

      public Unsubscriber(List<IObserver<string>> observers, IObserver<string> observer)
      {
        this.observers = observers;
        this.observer = observer;
      }

      public void Dispose()
      {
        if (observer != null && observers.Contains(observer))
          observers.Remove(observer);
      }
    }

    
    
  }
}