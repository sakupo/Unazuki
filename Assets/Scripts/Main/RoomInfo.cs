using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Main
{
  public class RoomInfo : MonoBehaviour
  {
    [SerializeField] private TextMeshProUGUI roomNameTMP;
    [SerializeField] private TextMeshProUGUI urlTMP;
    [SerializeField] private TextMeshProUGUI urlFullTMP;
    public void SetInfo(string roomName, string url)
    {
      urlFullTMP.gameObject.SetActive(false);
      SetRoomName(roomName);
      SetUrl(url);
    }

    private void SetRoomName(string roomName)
    {
      roomNameTMP.text = roomName;
    }

    private void SetUrl(string url)
    {
      urlTMP.text = url;
      var urlButtonTransform = urlTMP.gameObject.transform.parent.GetComponent<RectTransform>();
      // クリック領域を設定
      var urlButtonWidth = Math.Min(urlTMP.preferredWidth, 640);
      // 26文字以上なら26文字で切り捨て
      var text = (urlButtonWidth >= 640 && url.Length >= 26) ? url.Substring(0, 25)+"..." : url;
      urlTMP.text = "<link=" + url + ">" + text + "</link>";
      urlFullTMP.text = "<font=\"LiberationSans SDF\"><mark=#ffffffaa padding=\"10,10,0,0\">← " + url + "</mark>";
      urlButtonTransform.sizeDelta = new Vector2(urlButtonWidth, urlButtonTransform.rect.height);
    }

    public void OnPointerEnterUrl(BaseEventData data)
    {
      urlFullTMP.gameObject.SetActive(true);
    }
    
    public void OnPointerExitUrl(BaseEventData data)
    {
      urlFullTMP.gameObject.SetActive(false);
    }
    
    public void OnClickUrl()
    {
      var text = urlTMP;
      var pos = Input.mousePosition;
      var camera = text.canvas.worldCamera;
      int index = TMP_TextUtilities.FindIntersectingLink(text, pos, camera);
      if (index == -1) return;
      var linkInfo = text.textInfo.linkInfo[index];
      var url = linkInfo.GetLinkID();
      Application.OpenURL(url);
      urlFullTMP.gameObject.SetActive(false);
    }
  }
}