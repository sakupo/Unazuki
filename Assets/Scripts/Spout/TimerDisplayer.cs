using System;
using Main;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utility;

namespace Spout
{
  public class TimerDisplayer : MonoBehaviour, IObserver<TimerMessage>
  {
    private float time = 10;
    private bool isTimerActive = false;
    private bool isTimerDisplayed = true;
    private float timerBlinkingInterval = 0.5f;
    private float timerBlinkingCount = 0;
    private TimerController ctrl;
    [SerializeField] private TextMeshProUGUI timeText;

    void Start()
    {
      ctrl = CanvasEx.GetComponentInCanvasChildrenFromScene<TimerController>("MainScene");
      ctrl.Subscribe(this);
      gameObject.SetActive(false);
    }
    private void Update()
    {
      if (isTimerActive)
      {
        time -= Time.deltaTime;
        ShowTimer();
      }
    }

    void ShowTimer()
    {
      int minute = (int) Mathf.Floor(time / 60);
      int second = (int) Mathf.Floor(time) % 60;
      string minuteStr;
      if (minute == -1 && second == 0)
      {
        minuteStr = "00";
      }
      else
      {
        minuteStr = (minute < 0) ? "-" + (-minute - 1).ToString("00") : minute.ToString("00");
      }
      string secondStr = Math.Abs(second).ToString("00");
      timeText.text = minuteStr + ":" + secondStr;
      if (minute < 0 && timerBlinkingCount > timerBlinkingInterval)
      {
        DisplayTimer(!isTimerDisplayed);
      }
      else
      {
        timerBlinkingCount += Time.deltaTime;
      }
    }

    public void OnCompleted()
    {
      // do nothing
    }

    public void OnError(Exception error)
    {
      // do nothing
    }

    public void OnNext(TimerMessage message)
    {
      switch (message.state)
      {
        case TimerState.Start:
          ResetTimer(message.time);
          isTimerActive = true;
          break;
        case TimerState.Reset:
          gameObject.SetActive(true);
          ResetTimer(0);
          break;
        case TimerState.Pause:
          isTimerActive = false;
          DisplayTimer(true);
          break;
        case TimerState.Restart:
          isTimerActive = true;
          DisplayTimer(true);
          break;
        case TimerState.Inactive:
          gameObject.SetActive(false);
          break;
      }
    }

    private void DisplayTimer(bool isDisplay)
    {
      isTimerDisplayed = isDisplay;
      timeText.gameObject.SetActive(isDisplay);
      timerBlinkingCount = 0;
    }

    private void ResetTimer(int value)
    {
      time = value;
      isTimerActive = false;
      isTimerDisplayed = true;
      timerBlinkingCount = 0;
      ShowTimer();
    }
    
  }
}