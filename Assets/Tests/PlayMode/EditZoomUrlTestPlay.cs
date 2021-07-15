using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using InputZoomUrl;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using TMPro;

namespace Tests
{
    public class EditZoomUrlTestPlay
    {
        private Canvas homeCanvas;
        private InputZoomUrl.InputZoomUrl inputZoomUrl;
        private EditZoomUrl editZoomUrl;
        private DisplayRooms displayRooms;
        
        // テストの開始時に一度だけ呼ばれる
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            // 初期シーンのロード
            SceneManager.LoadScene("RootScene");
            SceneManager.LoadScene("HomeScene", LoadSceneMode.Additive);
        }
        
        public void SetUp()
        {
            // canvasの初期化
            homeCanvas = SceneManager.GetSceneByName("HomeScene").GetRootGameObjects()
                .First(obj => obj.GetComponent<Canvas>() != null)
                .GetComponent<Canvas>();

            inputZoomUrl = homeCanvas.GetComponentInChildren<InputZoomUrl.InputZoomUrl>();
            editZoomUrl = homeCanvas.GetComponentInChildren<EditZoomUrl>();
            displayRooms = homeCanvas.GetComponentInChildren<DisplayRooms>();
        }
        
        [UnityTest]
        public IEnumerator EditZoomUrlTest()
        {
            SetUp();

            // 新規データを保存
            string now = DateTime.Now.ToString();
            string oldRoomName = "test-" + now;
            inputZoomUrl.inputRoomNameField.text = oldRoomName;
            string oldZoomUrl = "www.test-" + now;
            inputZoomUrl.inputZoomUrlField.text = oldZoomUrl;
            inputZoomUrl.OnClick();
            
            // 追加したデータのボタンを取得
            Button targetButton = editZoomUrl.roomButtons.GetComponentsInChildren<Button>().Last();
            CheckRoomData(targetButton, oldRoomName, oldZoomUrl);

            // Edit Buttonを押す
            editZoomUrl.EditOnClick();
            
            // targetButtonのイベントリスナーを起動
            targetButton.onClick.Invoke();
            
            // データを編集
            string newRoomName = "test-new-" + now;
            editZoomUrl.inputRoomNameField.text = newRoomName;
            string newZoomUrl = "www.test-new-" + now;
            editZoomUrl.inputZoomUrlField.text = newZoomUrl;
            
            // 編集を適用
            editZoomUrl.editSaveButton.onClick.Invoke();
            
            // 変更されているか確認
            CheckRoomData(targetButton, newRoomName, newZoomUrl);
            
            // テストデータを削除
            displayRooms.DeleteData(editZoomUrl.roomButtons.GetComponentsInChildren<Button>().Length - 1);

            yield return null;
        }

        // 引数のbuttonに格納されているデータのroomNameとzoomUrlが一致するか確認する
        private void CheckRoomData(Button button, string roomName, string zoomUrl)
        {
            foreach (TextMeshProUGUI text in button.GetComponentsInChildren<TextMeshProUGUI>())
            {
                if (text.name == "RoomName")
                {
                    Assert.AreEqual(text.text, roomName);
                } else if (text.name == "ZoomUrl")
                {
                    Assert.AreEqual(text.text, zoomUrl);
                }
            }
        }
    }
}