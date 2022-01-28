using System;
using Main;
using OpenCvSharp;
using UnityEngine;
using Utility;

namespace Unazuki
{
  public class UnazukiScene : MonoBehaviour, IObserver<bool>
  {
    [SerializeField] private UnazukiProcessor processor;
    public UnazukiExtractor Extractor { get; private set; }
    private TimerDisplayButton timerDisplayButton;
    void Awake()
    {
      Extractor = new UnazukiExtractor(processor) {FaceBasePos = new Point(0, 240)};
    }

    private void Start()
    {
      timerDisplayButton = CanvasEx.GetComponentInCanvasChildrenFromScene<TimerDisplayButton>("MainScene");
      timerDisplayButton.Subscribe(this);
    }

    public void OnCompleted()
    {
      // do nothing
    }

    public void OnError(Exception error)
    {
      // do nothing
    }

    public void OnNext(bool value)
    {
      processor.PauseCamera(value);
    }
  }
}