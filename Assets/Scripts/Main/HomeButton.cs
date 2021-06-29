using UnityEngine;
using UnityEngine.SceneManagement;

namespace Main
{
  public class HomeButton : MonoBehaviour
  {
    public void OnClick()
    {
      SceneManager.UnloadSceneAsync("MainScene");
      SceneManager.LoadScene("HomeScene", LoadSceneMode.Additive);
    }
  }
}