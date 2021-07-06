using System;
using System.Linq;
using Klak.Spout;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Utility;

namespace Main
{
  public class SpoutCamStateButton : MonoBehaviour
  {
    [SerializeField] private Image background;
    [SerializeField] private TextMeshPro label;
    private SpoutSender spoutSender;

    private void Start()
    {
      spoutSender = CanvasEx.GetComponentFromScene<SpoutSender>("SpoutScene");
    }

    public void OnClick(bool isOn)
    {
      if (isOn)
      {
        background.color = Color.white;
        label.text = "カメラ: <color=#ff0000>ON</color>";
        spoutSender.enabled = true;
      }
      else
      {
        background.color = Color.gray;
        label.text = "カメラ: <color=#333333>OFF</color>";
        spoutSender.enabled = false;
      }
    }
  }
}
