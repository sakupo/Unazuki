using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Spout;
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


        [SetUp]
        public void SetUp()
        {
            // 初期シーンのロード
            SceneManager.LoadScene("RootScene");
            SceneManager.LoadSceneAsync("SpoutScene").completed += _ => {
                quad = GameObject.Find("Quad")?.GetComponent<ColorChangeScript>();
            };


        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator Spout_ColorChangeTest()
        {
            // うなずきが0に初期化されて青になっているかが初期化されているか
            var unazuki_val = quad.UnazukiColor();
            Assert.AreEqual(new Color(0.1f, 0.2f, 0.5f, 1), unazuki_val);
            yield return null;
        }
    }
}