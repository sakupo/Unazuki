using System.Collections;
using Main;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using Utility;

namespace Tests
{
  public class MainSceneButtonTest
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
        mainCanvas = CanvasEx.GetCanvasFromScene("MainScene");
      }
    }

    // MainSceneにある全トグルボタンをテストします
    [UnityTest]
    public IEnumerator MainSceneButtonInitTest()
    {
      SetUp();
      
      TestToggleButton<SpoutCamStateButton>(true);
      TestToggleButton<ColorSaturationButton>(true);
      // うなずきバーはデフォルトで無効
      TestToggleButton<UnazukiBarStateButton>(false);
      TestToggleButton<TextDisplayButton>(true);
      TestToggleButton<SoundDisplayButton>(true);

      yield return null;
    }

    // トグルボタンをテストします
    private void TestToggleButton<T>(bool expected) where T : ObservableToggleButton
    {
      var toggleButton = mainCanvas.GetComponentInChildren<T>();
      Assert.AreEqual(expected, toggleButton.IsOn);
    }
  }
}