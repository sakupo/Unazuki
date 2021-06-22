using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Unazuki;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Tests
{
  public class UnazukiBarTestPlay
  {
    private Canvas mainCanvas;
    [SetUp]
    public void SetUp()
    {
      // 初期シーンのロード
      SceneManager.LoadScene("RootScene");
      SceneManager.LoadScene("MainScene", LoadSceneMode.Additive);
      mainCanvas = SceneManager.GetSceneByName("MainScene").GetRootGameObjects()
        .First(obj => obj.GetComponent<Canvas>() != null)
        .GetComponent<Canvas>();
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator UnazukiBarTest()
    {
      // うなずきバーが0に初期化されているか
      var unazukiBar = mainCanvas.GetComponentInChildren<UnazukiBar>();
      Assert.AreEqual(0f, unazukiBar.Value);
      yield return null;
    }
  }
}