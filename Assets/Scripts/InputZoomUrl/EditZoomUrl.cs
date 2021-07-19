using System;
using System.Collections;
using System.Collections.Generic;
using OpenCvSharp;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

namespace InputZoomUrl
{
    public class EditZoomUrl : MonoBehaviour
    {
        public GameObject gameObject;
        public TMP_InputField  inputRoomNameField;
        public TMP_InputField  inputZoomUrlField;
        public Button addButton;
        public Button editButton;
        public Button editSaveButton;
        public Button backButton;
        public GameObject roomButtons;
        
        private DisplayRooms displayRooms;
        private Button[] clonedButtons;
        
        void Start()
        {
            AllSetActive(false, editSaveButton, backButton);
            
            displayRooms = gameObject.GetComponent<DisplayRooms>();
        }

        public void EditOnClick()
        {
            // 必要なUIのみ描画
            AllSetActive(false, 
                inputRoomNameField, inputZoomUrlField, addButton, editButton);
            AllSetActive(true, backButton);

            // Cloneされたボタンがクリックされた時の振る舞いを変える
            clonedButtons = roomButtons.GetComponentsInChildren<Button>();
            for(int index = 0; index < clonedButtons.Length; index++)
            {
                SetNewListner(clonedButtons[index], index);
            }
            
            // BackButtonの挙動を変更
            backButton.onClick.RemoveAllListeners();
            backButton.onClick.AddListener(() => Back());
        }

        // 引数で受け取ったUIオブジェクトを全てactiveの値にする
        private void AllSetActive(bool active, params UIBehaviour[] UIComponents)
        {
            foreach (var UIComponent in UIComponents)
            {
                UIComponent.gameObject.SetActive(active);
            }
        }
        
        // cloneされたroomボタンのイベントリスナーを書き換える
        private void SetNewListner(Button button, int n)
        {
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => RoomOnClick(n));
        }

        // Clickされたroomの情報を取得し、InputFieldに既存のデータを入れる
        private void RoomOnClick(int n)
        {
            for(int index = 0; index < clonedButtons.Length; index++)
            {
                if (index != n)
                {
                    // 押されたルーム以外を隠す
                    clonedButtons[index].gameObject.SetActive(false);
                }
                else
                {
                    // 押されたルームは再び押せないようにする
                    clonedButtons[index].onClick.RemoveAllListeners();
                    clonedButtons[index].interactable = false;
                }
            }
            Tuple<string, string> data = displayRooms.GetData(n);

            // 既存のデータを取得し、Fieldに入力しておく
            AllSetActive(true, inputRoomNameField, inputZoomUrlField, editSaveButton);
            inputRoomNameField.text = data.Item1;
            inputZoomUrlField.text = data.Item2;
            
            // Edit Saveボタンにリスナーを登録
            editSaveButton.onClick.RemoveAllListeners();
            editSaveButton.onClick.AddListener(() => EditSaveOnClick(n));
        }

        public void EditSaveOnClick(int n)
        {
            // どちらかが空欄なら何もしない
            if (inputRoomNameField.text == "" || inputZoomUrlField.text == "")
                return;
            
            Tuple<string, string> data = new Tuple<string, string>(inputRoomNameField.text, inputZoomUrlField.text);
            
            inputRoomNameField.text = "";
            inputZoomUrlField.text = "";

            // データを保存
            displayRooms.EditData(n, data);
            
            // 描画を元に戻す
            Back();
        }

        // 元の状態に戻るための関数
        public void Back()
        {
            // UIの表示を戻す
            AllSetActive(true, inputRoomNameField, inputZoomUrlField, addButton, editButton);
            AllSetActive(false, editSaveButton, backButton);
            
            // 入力内容を消す
            inputRoomNameField.text = "";
            inputZoomUrlField.text = "";

            // Roomボタンを全て押せるようにする
            foreach (Button clonedButton in clonedButtons)
            {
                clonedButton.gameObject.SetActive(true);
                clonedButton.interactable = true;
            }
            
		    // 描画されているroomボタンを全て削除
		    foreach (Button roomButton in roomButtons.GetComponentsInChildren<Button>())
		    {
			    Destroy(roomButton.gameObject);
		    }
		    
		    // 再描画
		    gameObject.GetComponentInChildren<DisplayRooms>().DisplayAllRoomButtons();
        }
    }
}