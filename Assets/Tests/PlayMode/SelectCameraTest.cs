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
using Unazuki;

namespace Tests
{
    public class SelectCameraTestPlay
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
                // settingsCanvasの初期化
                settingsCanvas = SceneManager.GetSceneByName("SettingsScene").GetRootGameObjects()
                    .First(obj => obj.GetComponent<Canvas>() != null)
                    .GetComponent<Canvas>();
            }
        }

#if !UNITY_CLOUD_BUILD
        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator SelectCameraTest()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            
            // テストごとの初期化
            SetUp();
            
            // キー"camera"に何らかの値が保存されている
            Assert.IsTrue(PlayerPrefs.HasKey(WebCamera.PlayerPrefsKeyCamera));
            string preserved = PlayerPrefs.GetString(WebCamera.PlayerPrefsKeyCamera);
            int i = 0;
            for (i = 0; i <= WebCamTexture.devices.Length; i++)
            {
                if (preserved.Equals(WebCamTexture.devices[i].name)) break;
            }

            Assert.IsTrue(i < WebCamTexture.devices.Length);
            yield return null;
        }
#endif
    }
}
