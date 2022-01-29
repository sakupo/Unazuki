using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Main
{
  /// <summary>
  /// タイマーの状態
  /// </summary>
  public enum TimerState
  {
    Start,
    Reset,
    Pause,
    Restart,
    Inactive
  }

  /// <summary>
  /// タイマーに送る要求を表すクラス
  /// </summary>
  public class TimerMessage
  {
    public TimerState state { get; }
    public int time { get;}

    public TimerMessage(TimerState state, int time)
    {
      this.state = state;
      this.time = time;
    }
  }
  
  /// <summary>
  /// タイマーの状態を管理するクラス
  /// </summary>
  public class TimerController : MonoBehaviour, IObserver<bool>, IObservable<TimerMessage>
  {
    [SerializeField] private GameObject[] unazukiObjects;

    [SerializeField] private TimerDisplayButton button;

    private IObserver<TimerMessage> display;

    [SerializeField] private GameObject timeField;
    
    [SerializeField] private TMP_InputField timeInputField;

    private bool isTimerPaused = false;

    [SerializeField] private GameObject pauseAndRestartButton;
    [SerializeField] private TextMeshProUGUI pauseAndRestartText; 

    // Start is called before the first frame update
    void Start()
    {
      button.Subscribe(this);
      timeField.SetActive(false);
      pauseAndRestartButton.SetActive(false);
    }

    private int ToTimeInt(string str)
    {
      int time = int.Parse(str);
      int minute = Mathf.Clamp(time / 100, 0, 99);
      int second = Mathf.Clamp(time % 100, 0, 59);
      return minute * 60 + second;
    }
    public void OnClickStart()
    {
      int time;
      try
      {
        time = ToTimeInt(timeInputField.text);
      }
      catch (Exception e)
      {
        timeInputField.text = "";
        return;
      }
      display.OnNext(new TimerMessage(TimerState.Start, time)); 
      pauseAndRestartButton.SetActive(true);
    }

    public void OnClickPauseAndRestart()
    {
      if (isTimerPaused)
      {
        isTimerPaused = false;
        pauseAndRestartText.text = "停止";
        display.OnNext(new TimerMessage(TimerState.Restart, 0));
      }
      else
      {
        isTimerPaused = true;
        pauseAndRestartText.text = "再開";
        display.OnNext(new TimerMessage(TimerState.Pause, 0));
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

    public void OnNext(bool value)
    {
      timeField.SetActive(value);
      if (value)
      {
        display.OnNext(new TimerMessage(TimerState.Reset, 0)); 
      }
      else
      {
        display.OnNext(new TimerMessage(TimerState.Inactive, 0));
      }
      foreach (GameObject o in unazukiObjects)
      {
        o.SetActive(!value);
      }
    }

    public IDisposable Subscribe(IObserver<TimerMessage> observer)
    {
      display = observer;
      return null;
    }
  }
}