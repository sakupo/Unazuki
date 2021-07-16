using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utility;
using TMPro;

namespace InputZoomUrl {
	public class DisplayRooms : MonoBehaviour
	{
    	public GameObject canvas;
	    private Vector3 centerToLeftTop; // canvasの中心から左上の座標までのベクトル
    	public Button baseRoomButton; // clone元となるButtonオブジェクト
        public GameObject RoomButtons; // cloneされたButton達の親オブジェクト
	    private float buttonWidth;
    	private float buttonHeight;
	    private ZoomUrlsData zoomUrlsData;  // room名とurlのペアを全て保存するデータ構造
	    private Tuple<string, string> clickedRoom;  // クリックされたroomデータを保持
    
    
	    void Start()
    	{
	        buttonWidth = baseRoomButton.GetComponent<RectTransform>().sizeDelta.x;
	        buttonHeight = baseRoomButton.GetComponent<RectTransform>().sizeDelta.y;
	        
        	// 座標変換用に、canvasの中心から左上の座標までのベクトルを計算
	        centerToLeftTop = new Vector3((-1) * buttonWidth / 2,
    	        canvas.GetComponent<RectTransform>().sizeDelta.y / 2, 0);
        
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
	    public void DisplayAllRoomButtons()
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

    	    Button clonedButton = Instantiate(baseRoomButton, RoomButtons.transform);
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
	        clonedButton.GetComponent<Button>().onClick.RemoveAllListeners();
    	    clonedButton.GetComponent<Button>().onClick.AddListener(() => ClickRoomButton(n));
	    }

	    // 上から何番目のButtonかを引数(n)で受け取る
    	// canvasの中心基準で、buttonを配置すべき座標を計算し、Vector3オブジェクトとして返す
	    private Vector3 ConvertPosition(int n)
    	{
            return new Vector3(centerToLeftTop.x, centerToLeftTop.y + (-1) * n * buttonHeight, 0);
	    }

    	// roomのボタンが押されたときに呼ばれる関数
	    public void ClickRoomButton(int n)
    	{
	        clickedRoom = zoomUrlsData.Get(n);
            
            var homeCanvasEx = CanvasEx.GetCanvasExFromScene("HomeScene");
            homeCanvasEx.HideCanvas();
            var mainCanvasEx = CanvasEx.GetCanvasExFromScene("MainScene");
            mainCanvasEx.ShowCanvas();
        }

	    // クリックされたroom情報を取り出す。主にMainSceneから呼ばれる
	    public Tuple<string, string> getClickedRoom()
	    {
		    return clickedRoom;
	    }

	    public void AddData(Tuple<string, string> data)
	    {
		    zoomUrlsData.Add(data);
		    
		    // 今追加したデータを描画
		    DisplayRoomButton(zoomUrlsData.Count() - 1);
	    }
	    
	    // n番目のデータを取得
	    public Tuple<string, string> GetData(int n)
	    {
		    return zoomUrlsData.Get(n);
	    }
	    
	    // n番目のデータを変更(この関数単体では描画は変更されない)
	    public void EditData(int n, Tuple<string, string> data)
	    {
		    zoomUrlsData.Edit(n, data);
	    }
	    
	    // n番目のデータを削除
	    public void DeleteData(int n)
	    {
		    // 描画されているroomボタンを全て削除
		    foreach (Button roomButton in RoomButtons.GetComponentsInChildren<Button>())
		    {
			    Destroy(roomButton.gameObject);
		    }

		    // データも削除
		    zoomUrlsData.Delete(n);
		    
		    // 再描画
		    DisplayAllRoomButtons();
	    }

		void OnApplicationQuit(){
			// アプリ終了時にデータを保存する
			string savedData = JsonUtility.ToJson(zoomUrlsData);
			PlayerPrefs.SetString("ZoomUrlsData", savedData);
		}
	}
}
