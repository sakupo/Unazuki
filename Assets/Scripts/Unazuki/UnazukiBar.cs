using UnityEngine;
using UnityEngine.UI;

namespace Unazuki
{
  public class UnazukiBar : MonoBehaviour
  {
    private Slider slider;

    /// <summary>
    /// sliderの値
    /// </summary>
    public float Value
    {
      get
      {
        if (slider is null)
        { // slider が読み込まれていないとき
          return 0f;
        }
        return slider.value;
      }
    }

    // Start is called before the first frame update
    void Start()
    {
      slider = GetComponent<Slider>();
    }
  }
}