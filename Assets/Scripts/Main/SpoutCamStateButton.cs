using System;
using System.Collections.Generic;
using System.Linq;
using Klak.Spout;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Utility;

namespace Main
{
  public class SpoutCamStateButton : MonoBehaviour, IObservable<bool>
  {
    [SerializeField] private Image background;
    [SerializeField] private TextMeshPro label;
    private readonly List<IObserver<bool>> spoutSenders = new List<IObserver<bool>>();

    public void OnClick(bool isOn)
    {
      if (isOn)
      {
        background.color = Color.white;
        label.text = "カメラ: <color=#ff0000>ON</color>";
      }
      else
      {
        background.color = Color.gray;
        label.text = "カメラ: <color=#333333>OFF</color>";
      }

      // SpoutSenderへのUpdate通知
      foreach (var spoutSender in spoutSenders)
      {
        spoutSender.OnNext(isOn);
      }
    }

    public IDisposable Subscribe(IObserver<bool> observer)
    {
      spoutSenders.Add(observer);
      return new Unsubscriber(spoutSenders, observer);
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
        if (observer != null && observers.Contains(observer))
          observers.Remove(observer);
      }
    }
  }
}