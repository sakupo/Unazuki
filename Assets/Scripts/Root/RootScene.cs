using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Root
{
  public class RootScene : MonoBehaviour
  {
    [SerializeField] private List<string> initSceneNames;

    private void Start()
    {
#if !DEBUG
      // 本番環境でのみ呼ばれる
      InitScene();
#endif
    }

    void InitScene()
    {
      foreach (var sceneName in initSceneNames)
      {
        Scene scene = SceneManager.GetSceneByName(sceneName);
        if (! scene.isLoaded)
        {
          // シーンがヒエラルキー上に存在しないとき
          SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        }
      }
    }
  }
}