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
    public class DeleteZoomUrlTestPlay
    {
        private Canvas homeCanvas;
        private InputZoomUrl.InputZoomUrl inputZoomUrl;
        private DeleteZoomUrl deleteZoomUrl;
        private DisplayRooms displayRooms;
        
        // テストの開始時に一度だけ呼ばれる
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            // 初期シーンのロード
            SceneManager.LoadScene("RootScene");
            SceneManager.LoadScene("MainScene", LoadSceneMode.Additive);
            SceneManager.LoadScene("SpoutScene", LoadSceneMode.Additive);
            SceneManager.LoadScene("UnazukiScene", LoadSceneMode.Additive);
            SceneManager.LoadScene("HomeScene", LoadSceneMode.Additive);
        }
        
        public void SetUp()
        {
            // canvasの初期化
            homeCanvas = SceneManager.GetSceneByName("HomeScene").GetRootGameObjects()
                .First(obj => obj.GetComponent<Canvas>() != null)
                .GetComponent<Canvas>();

            inputZoomUrl = homeCanvas.GetComponentInChildren<InputZoomUrl.InputZoomUrl>();
            deleteZoomUrl = homeCanvas.GetComponentInChildren<DeleteZoomUrl>();
            displayRooms = homeCanvas.GetComponentInChildren<DisplayRooms>();
        }
        
        [UnityTest]
        public IEnumerator DeleteZoomUrlTest()
        {
            SetUp();

            int originDataSize = deleteZoomUrl.roomButtons.GetComponentsInChildren<Button>().Length;

            // 新規データを保存
            string now = DateTime.Now.ToString();
            string oldRoomName = "test-" + now;
            inputZoomUrl.inputRoomNameField.text = oldRoomName;
            string oldZoomUrl = "www.test-" + now;
            inputZoomUrl.inputZoomUrlField.text = oldZoomUrl;
            inputZoomUrl.OnClick();
            
            // 追加したデータのボタンを取得
            Button targetButton = deleteZoomUrl.roomButtons.GetComponentsInChildren<Button>().Last();
            
            // データ数が増えたかの確認
            Assert.AreEqual(originDataSize + 1, deleteZoomUrl.roomButtons.GetComponentsInChildren<Button>().Length);

            // Delete Buttonを押す
            deleteZoomUrl.DeleteOnClick();
            
            // 消すものとしてtarget buttonを選択
            targetButton.onClick.Invoke();
            
            // Destroyには時間がかかるので待つ
            yield return new WaitForSeconds(3f);
            
            // データ数が減ったかの確認
            Assert.AreEqual(originDataSize, deleteZoomUrl.roomButtons.GetComponentsInChildren<Button>().Length);

            // 先ほど入力したデータがないかの確認
            foreach (Button button in deleteZoomUrl.roomButtons.GetComponentsInChildren<Button>())
            {
                TextMeshProUGUI[] texts = button.GetComponentsInChildren<TextMeshProUGUI>();
                if (texts[0].name == "RoomName")
                {
                    Assert.AreNotEqual(texts[0].text, oldRoomName); 
                    Assert.AreNotEqual(texts[1].text, oldZoomUrl); 
                }
                else if (texts[1].name == "RoomName")
                {
                    Assert.AreNotEqual(texts[1].text, oldRoomName); 
                    Assert.AreNotEqual(texts[0].text, oldZoomUrl); 
                }
                else
                {
                    Assert.Fail();
                }
            }
            
            yield return null;
        }
    }
}