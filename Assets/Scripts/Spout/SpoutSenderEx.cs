using System;
using Klak.Spout;
using Main;
using UnityEngine;
using Utility;

namespace Spout
{
  public class SpoutSenderEx : MonoBehaviour, IObserver<bool>
  {
    private SpoutSender spoutSender;
    private SpoutCamStateButton spoutCamStateButton;

    private void Start()
    {
      spoutSender = GetComponent<SpoutSender>();
      spoutCamStateButton = CanvasEx.GetComponentInCanvasChildrenFromScene<SpoutCamStateButton>("MainScene");
      spoutCamStateButton.Subscribe(this);
    }

    public void OnCompleted()
    {
      // do nothing
    }

    public void OnError(Exception error)
    {
      // do nothing
    }

    public void OnNext(bool isOn)
    {
      spoutSender.enabled = isOn;
    }
  }
}