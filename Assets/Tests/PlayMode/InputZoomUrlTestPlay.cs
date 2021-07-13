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
    public class InputZoomUrlTestPlay
    {
        private Canvas homeCanvas;
        
        // テストの開始時に一度だけ呼ばれる
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            // 初期シーンのロード
            SceneManager.LoadScene("RootScene");
            SceneManager.LoadScene("HomeScene", LoadSceneMode.Additive);
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
        public IEnumerator InputZoomUrlTest() // 好きな名前をつける
        {
            SetUp();
            
            TMP_InputField[] inputFields = homeCanvas.GetComponentsInChildren<TMP_InputField>();
            
            // 正しいコンポーネントが得られているか
            TMP_InputField inputZoomUrlField = inputFields[0];
            Assert.AreEqual(inputZoomUrlField.name, "InputRoomNameField");
            
            TMP_InputField inputRoomNameField = inputFields[1];
            Assert.AreEqual(inputRoomNameField.name, "InputZoomUrlField");

            yield return null;
        }
    }
}
