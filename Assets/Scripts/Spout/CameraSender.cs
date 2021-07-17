using System;
using Klak.Spout;
using Klak.Syphon;
using Main;
using UnityEngine;
using Utility;

namespace Spout
{
  public class CameraSender : MonoBehaviour, IObserver<bool>
  {
    private SpoutSender spoutSender;
    private SyphonServer syphonServer;
    private SpoutCamStateButton spoutCamStateButton;

    private void Start()
    {
      spoutSender = GetComponent<SpoutSender>();
      syphonServer = GetComponent<SyphonServer>();
#if UNITY_STANDALONE_WIN
      spoutSender.enabled = true;
      syphonServer.enabled = false;
#endif
#if UNITY_STANDALONE_OSX
      spoutSender.enabled = false;
      syphonServer.enabled = true;
#endif
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
#if UNITY_STANDALONE_WIN
      spoutSender.enabled = isOn;
#endif
#if UNITY_STANDALONE_OSX
      syphonServer.enabled = isOn;
#endif
    }
  }
}