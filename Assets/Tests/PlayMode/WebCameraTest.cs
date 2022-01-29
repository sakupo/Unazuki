using System.Collections;
using NUnit.Framework;
using Unazuki;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using Utility;

namespace Tests
{
  public class WebCameraTest
  {
    private Canvas unazukiCanvas;

    // テストの開始時に一度だけ呼ばれる
    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
      // 初期シーンのロード
      SceneManager.LoadScene("RootScene");
      SceneManager.LoadScene("MainScene", LoadSceneMode.Additive);
      SceneManager.LoadScene("SpoutScene", LoadSceneMode.Additive);
      SceneManager.LoadScene("UnazukiScene", LoadSceneMode.Additive);
    }
    
    public void SetUp()
    {
      if (unazukiCanvas == null)
      {
        // unazukiCanvasの初期化
        unazukiCanvas = CanvasEx.GetCanvasFromScene("UnazukiScene");
      }
    }

    // WebCameraのテスト
    [UnityTest]
    public IEnumerator BasicWebCameraTest()
    {
      // テスト毎の初期化
      SetUp();
      // WebCamTexture.deviceを参照できるか
      Assert.GreaterOrEqual(WebCamTexture.devices.Length, 0);
      yield return null;
    }
  }
}