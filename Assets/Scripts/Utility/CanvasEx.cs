using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utility
{
  public class CanvasEx : MonoBehaviour
  {
    protected virtual void Awake()
    {
    }
    
    protected virtual void Start()
    {
    }
    
    public void ShowCanvas()
    {
      gameObject.SetActive(true);
      Init();
    }

    public void HideCanvas()
    {
      Final();
      gameObject.SetActive(false);
    }

    protected virtual void Final()
    {
      /* do nothing */
    }

    protected virtual void Init()
    {
      /* do nothing */
    }

    /// <summary>
    /// このクラスまたは派生クラスがアタッチされたゲームオブジェクトにアタッチされているCanvasを返します
    /// </summary>
    /// <returns></returns>
    public Canvas GetCanvas()
    {
      return gameObject.GetComponent<Canvas>();
    }

    /// <summary>
    /// シーン直下のゲームオブジェクトを全て返します
    /// </summary>
    /// <param name="sceneName"></param>
    /// <returns></returns>
    public static GameObject[] GetRootObjectsFromScene(string sceneName)
    {
      GameObject[] objs = SceneManager.GetSceneByName(sceneName).GetRootGameObjects();
      return objs;
    }
    
    /// <summary>
    /// シーン直下にある任意のコンポーネントを返します
    /// </summary>
    /// <param name="sceneName"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T GetComponentFromScene<T>(string sceneName) where T : Component
    {
      var component = GetRootObjectsFromScene(sceneName)
        .First(obj => obj.GetComponent<T>() != null)
        .GetComponent<T>();
      return component;
    }

    /// <summary>
    /// scene直下にあるCanvasの子オブジェクトにある任意のコンポーネントを返します
    /// </summary>
    /// <param name="sceneName"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T GetComponentInCanvasChildrenFromScene<T>(string sceneName) where T : Component
    {
      var canvas = GetCanvasFromScene(sceneName);
      var childComponent = canvas.GetComponentInChildren<T>();
      return childComponent;
    }

    /// <summary>
    /// scene直下にあるCanvasを返します
    /// </summary>
    /// <param name="sceneName"></param>
    /// <returns></returns>
    public static Canvas GetCanvasFromScene(string sceneName)
    {
      return GetComponentFromScene<Canvas>(sceneName);
    }
    
    /// <summary>
    /// scene直下にあるCanvasExを返します
    /// </summary>
    /// <param name="sceneName"></param>
    /// <returns></returns>
    public static CanvasEx GetCanvasExFromScene(string sceneName)
    {
      return GetComponentFromScene<CanvasEx>(sceneName);
    }
    
    /// <summary>
    /// 複数のscene直下にあるCanvasExを返します
    /// </summary>
    /// <returns></returns>
    public List<CanvasEx> GetCanvasExsFromScene(params string[] sceneNames)
    {
      var canvasExs = sceneNames.Select(sceneName =>
      {
        var canvasEx = GetCanvasExFromScene(sceneName);
        return canvasEx;
      }).ToList();
      return canvasExs;
    }
  }
}