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
    public class SelectAudioTestPlay
    {
        private Canvas settingsCanvas;
        
        // テスト開始時一度だけ呼ばれる
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
                // SettingsCanvasの初期化
                settingsCanvas = SceneManager.GetSceneByName("SettingsScene").GetRootGameObjects()
                    .First(obj => obj.GetComponent<Canvas>() != null)
                    .GetComponent<Canvas>();
            }
        }
#if !UNITY_CLOUD_BUILD
        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator SelectAudioTest()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            // テストごとの初期化
            SetUp();

            // キー"audio"になんらかの値が保存されている
            Assert.IsTrue(PlayerPrefs.HasKey(SelectAudio.PlayerPrefsKeyAudio));
            int preserved = PlayerPrefs.GetInt(SelectAudio.PlayerPrefsKeyAudio);
            Assert.IsTrue(0 <= preserved && preserved < Microphone.devices.Length);
            yield return null;
        }
#endif
    }
}
