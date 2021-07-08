using System;
using System.Collections.Generic;
using UnityEngine;

namespace Main
{
  public class ManShapeMenuItem : MonoBehaviour, IObservable<string>
  {
    private readonly List<IObserver<string>> controllers = new List<IObserver<string>>();

    public void OnClick()
    {
      if (controllers.Count < 1)
      {
        throw new Exception("Button controller is not set.");
      }
      foreach (var controller in controllers)
      {
        controller.OnNext(gameObject.name);
      }
    }

    public IDisposable Subscribe(IObserver<string> observer)
    {
      controllers.Add(observer);
      return new Unsubscriber(controllers, observer);
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