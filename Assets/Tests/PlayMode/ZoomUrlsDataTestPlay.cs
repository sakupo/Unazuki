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

namespace Tests
{
    public class ZoomUrlsDataTestPlay
    {
        private Canvas homeCanvas;
        
        // テストの開始時に一度だけ呼ばれる
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            // 初期シーンのロード
            SceneManager.LoadScene("RootScene");
            SceneManager.LoadScene("HomeScene", LoadSceneMode.Additive);
            SceneManager.LoadSceneAsync("MainScene", LoadSceneMode.Additive);
            SceneManager.LoadSceneAsync("SpoutScene", LoadSceneMode.Additive);
            SceneManager.LoadSceneAsync("UnazukiScene", LoadSceneMode.Additive);
        }
    
        // canvasの初期化
        public void SetUp()
        {
            homeCanvas = SceneManager.GetSceneByName("HomeScene").GetRootGameObjects()
                .First(obj => obj.GetComponent<Canvas>() != null)
                .GetComponent<Canvas>();
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator DisplayRoomsTest()
        {
            SetUp();
            
            // データを読み込み
            string savedData = PlayerPrefs.GetString("ZoomUrlsData");
            ZoomUrlsData zoomUrlsData;
            if (savedData == "")
            {
                zoomUrlsData = new ZoomUrlsData();
            }
            else
            {
                zoomUrlsData = JsonUtility.FromJson<ZoomUrlsData>(savedData);
            }
            
            // 保存されているデータの個数を取得
            int dataNum = zoomUrlsData.Count();
            
            // canvas上にあるBaseRoomButtonをcloneしたボタンの数を取得
            int buttonNum = 0;
            foreach (Button button in homeCanvas.GetComponentsInChildren<Button>())
            {
                if (button.name == "BaseRoomButton(Clone)") buttonNum++;
            };

            // 数が一致しているか確認
            Assert.AreEqual(dataNum, buttonNum);
            
            yield return null;
        }
    }
}