using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Settings
{
    public class InputAPIToken : MonoBehaviour
    {
		// public InputField inputField;
        public TMP_InputField inputField;
		public Button applyButton;
		private string apiToken;
		public string applyedToken;
        // Start is called before the first frame update
        void Start()
        {
        }
		
		// Applyボタンのクリック
		public void OnClick() 
		{
			apiToken = inputField.text;
			// キー"zoomAPI"で保存
			PlayerPrefs.SetString("zoomAPI", apiToken);
			Debug.Log(apiToken + " applyed");
			Debug.Log(PlayerPrefs.GetString("zoomAPI") + " preserved");
		}
    }
}