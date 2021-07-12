using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Spout;
using Main;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;


namespace Tests
{
    public class SpoutBackColorTestPlay
    {
        private Canvas mainCanvas;
        ColorChangeScript quad;
        UnazukiBarStateButton barState;
        ColorChangeScript colorChange;


        [SetUp]
        public void SetUp()
        {
            // 初期シーンのロード
            SceneManager.LoadScene("RootScene");
            SceneManager.LoadScene("SettingsScene",LoadSceneMode.Additive);
            SceneManager.LoadSceneAsync("MainScene", LoadSceneMode.Additive).completed += _ => {
                var mainCanvas = SceneManager.GetSceneByName("MainScene").GetRootGameObjects()
                    .First(obj => obj.GetComponent<Canvas>() != null)
                    .GetComponent<Canvas>();
                barState = mainCanvas.GetComponentInChildren<UnazukiBarStateButton>();
            };
            SceneManager.LoadScene("UnazukiScene", LoadSceneMode.Additive);
            SceneManager.LoadSceneAsync("SpoutScene", LoadSceneMode.Additive).completed += _ => {
                quad = GameObject.Find("Quad")?.GetComponent<ColorChangeScript>();
                colorChange = quad.GetComponent<ColorChangeScript>();
            };

            


        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator Spout_ColorChangeTest()
        {
            // うなずきが0に初期化されて青になっているかが初期化されているか
            var unazuki_val = quad.UnazukiColor();
            Assert.AreEqual(new Color(0.15f, 0.15f, 0.3f, 1), unazuki_val);
            //Subcribeできていて、ボタンを押した結果が反映されているか
            barState.OnClick(true);
            Assert.AreEqual(true,colorChange.unazukiBarState);
            yield return null;
        }
    }
}