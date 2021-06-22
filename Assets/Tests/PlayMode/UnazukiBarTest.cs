using System.Collections;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using Unazuki;

namespace Tests
{
  public class UnazukiBarTestPlay
  {
    private Canvas mainCanvas;

    // テストの開始時に一度だけ呼ばれる
    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
      // 初期シーンのロード
      SceneManager.LoadScene("RootScene");
      SceneManager.LoadScene("MainScene", LoadSceneMode.Additive);
    }
    
    public void SetUp()
    {
      if (mainCanvas == null)
      {
        // mainCanvasの初期化
        mainCanvas = SceneManager.GetSceneByName("MainScene").GetRootGameObjects()
          .First(obj => obj.GetComponent<Canvas>() != null)
          .GetComponent<Canvas>();
      }
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator UnazukiBarTest()
    {
      // テスト毎の初期化
      SetUp();
      // うなずきバーが0に初期化されているか
      var unazukiBar = mainCanvas.GetComponentInChildren<UnazukiBar>();
      Assert.AreEqual(0f, unazukiBar.Value);
      yield return null;
    }
  }
}