using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace InputZoomUrl {
	public class DisplayRooms : MonoBehaviour
	{
    	public GameObject canvas;
	    private Vector3 centerToLeftTop; // canvasの中心から左上の座標までのベクトル
    	public Button baseRoomButton; // clone元となるButtonオブジェクト
	    private float buttonWidth;
    	private float buttonHeight;
	    private ZoomUrlsData zoomUrlsData;  // room名とurlのペアを全て保存するデータ構造
    
    
	    void Start()
    	{
        	// 座標変換用に、canvasの中心から左上の座標までのベクトルを計算
	        centerToLeftTop = new Vector3((-1) * canvas.GetComponent<RectTransform>().sizeDelta.x / 2,
    	        canvas.GetComponent<RectTransform>().sizeDelta.y / 2, 0);
        
        	buttonWidth = baseRoomButton.GetComponent<RectTransform>().sizeDelta.x;
 	        buttonHeight = baseRoomButton.GetComponent<RectTransform>().sizeDelta.y;

			// データを読み込み
			string savedData =PlayerPrefs.GetString("ZoomUrlsData");
			if (savedData == "")
			{
				zoomUrlsData = new ZoomUrlsData();
			}
			else
			{
				zoomUrlsData = JsonUtility.FromJson<ZoomUrlsData>(savedData);
			}

	        DisplayAllRoomButtons();
    	}

		// zoomUrlsDataに保存されている全てのデータを描画する
	    private void DisplayAllRoomButtons()
    	{
			for(int index = 0; index < zoomUrlsData.Count(); index++){
				DisplayRoomButton(index);
			}
    	}

		// ZoomUrlsDataのn番目のデータを、ボタンとしてcanvasに描画する
    	private void DisplayRoomButton(int n)
	    {
			Tuple<string, string> zoomUrlData = zoomUrlsData.Get(n);
			string roomName = zoomUrlData.Item1;
			string zoomUrl = zoomUrlData.Item2;

    	    Button clonedButton = Instantiate(baseRoomButton, canvas.transform);
        	clonedButton.gameObject.SetActive(true);  // 表示させる
            Vector3 position = ConvertPosition(n);
	        clonedButton.transform.localPosition = position;

        	foreach (TextMeshProUGUI text in clonedButton.GetComponentsInChildren<TextMeshProUGUI>())
	        {
    	        if (text.name == "RoomName")
        	    {
            	    text.text = roomName;
	            }
    	        else if (text.name == "ZoomUrl")
        	    {
            	    text.text = zoomUrl;
            	}
	        }

	        // click時のcall back関数を登録
    	    clonedButton.GetComponent<Button>().onClick.AddListener(() => ClickRoomButton(n));
	    }

	    // 上から何番目のButtonかを引数(n)で受け取る
    	// canvasの中心基準で、buttonを配置すべき座標を計算し、Vector3オブジェクトとして返す
	    private Vector3 ConvertPosition(int n)
    	{
        	return new Vector3(centerToLeftTop.x + buttonWidth/2,
            	centerToLeftTop.y - n * buttonHeight - buttonHeight/2, 0);
	    }

    	// roomのボタンが押されたときに呼ばれる関数
	    void ClickRoomButton(int n)
    	{
	        Tuple<string, string> zoomUrlData = zoomUrlsData.Get(n);
    	    Debug.Log("room name:'" + zoomUrlData.Item1 + "'(url:'" + zoomUrlData.Item2 + "') is clicked!!!");
		}

	    public void AddData(Tuple<string, string> data)
	    {
		    zoomUrlsData.Add(data);
		    
		    // 今追加したデータを描画
		    DisplayRoomButton(zoomUrlsData.Count() - 1);
	    }

		void OnApplicationQuit(){
			// アプリ終了時にデータを保存する
			string savedData = JsonUtility.ToJson(zoomUrlsData);
			PlayerPrefs.SetString("ZoomUrlsData", savedData);
		}
	}
}
