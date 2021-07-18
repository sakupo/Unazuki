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
    public class DeleteZoomUrl : MonoBehaviour
    {
        public GameObject gameObject;
        public TMP_InputField  inputRoomNameField;
        public TMP_InputField  inputZoomUrlField;
        public Button addButton;
        public Button editButton;
        public Button deleteButton;
        public Button backButton;
        public GameObject roomButtons;
        
        private DisplayRooms displayRooms;
        private InputZoomUrl inputZoomUrl;
        
        void Start()
        {
            AllSetActive(false, backButton);
            
            displayRooms = gameObject.GetComponent<DisplayRooms>();
        }

        public void DeleteOnClick()
        {
            // 必要なUIのみ描画
            AllSetActive(false, inputRoomNameField, inputZoomUrlField, addButton, editButton, deleteButton);
            AllSetActive(true, backButton);
        
            // Cloneされたボタンがクリックされた時の振る舞いを変える
            Button[] clonedButtons = roomButtons.GetComponentsInChildren<Button>();
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
        
        // 押されたRoomボタンのデータを削除する
        private void RoomOnClick(int n)
        {
            // データを削除
            displayRooms.DeleteData(n);
            
            // 描画を元に戻す
            Back();
        }
        
        // 元の状態に戻るための関数
        public void Back()
        {
            // UIの表示を戻す
            AllSetActive(true, inputRoomNameField, inputZoomUrlField, addButton, editButton, deleteButton);
            AllSetActive(false, backButton);
            
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