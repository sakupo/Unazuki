using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using Settings;

namespace Tests
{
    public class SettingButtonTestPlay
    {
        private Canvas settingsCanvas;

        // テスト開始時に一度だけ呼ばれる
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            // 初期シーンのロード
            SceneManager.LoadScene("RootScene");
            SceneManager.LoadScene("SettingsScene", LoadSceneMode.Additive);
        }

        public void SetUp()
        {
            if (settingsCanvas == null)
            {
                // settingsCanvasの初期化
                settingsCanvas = SceneManager.GetSceneByName("SettingsScene").GetRootGameObjects()
                    .First(obj => obj.GetComponent<Canvas>() != null)
                    .GetComponent<Canvas>();
            }
        }
        

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator SettingButtonTest()
        {
            // テストごとの初期化
            SetUp();
            // settingsButton以外が隠されているか
            var settings = settingsCanvas.GetComponentInChildren<SettingsButton>();
            var parent = settings.parent;
            Assert.IsFalse(parent.activeSelf);
            yield return null;
        }
    }
}
