using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Main
{
  public abstract class ObservableToggleButton : MonoBehaviour, IObservable<bool>
  {
    [SerializeField] protected Image background;
    [SerializeField] protected Image mark;
    [SerializeField] protected TextMeshPro label;
    [SerializeField] protected Image labelBackGround;

    public bool IsOn => GetComponent<Toggle>().isOn;

    private readonly List<IObserver<bool>> displays = new List<IObserver<bool>>();

    public IDisposable Subscribe(IObserver<bool> observer)
    {
      displays.Add(observer);
      return new Unsubscriber(displays, observer);
    }

    protected abstract void TurnOn();

    protected abstract void TurnOff();

    public void OnClick(bool isOn)
    {
      if (isOn)
      {
        TurnOn();
      }
      else
      {
        TurnOff();
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