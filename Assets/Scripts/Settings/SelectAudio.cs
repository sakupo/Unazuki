using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Settings {
	public class SelectAudio : MonoBehaviour
	{
		public TMP_Dropdown selectAudio;
    	// Start is called before the first frame update
    	void Start()
    	{
    	    if (selectAudio) {
				selectAudio.ClearOptions();
				List<string> list = new List<string>();
				for (int i=0; i<Microphone.devices.Length; i++) {
					list.Add(Microphone.devices[i]);
				}
				selectAudio.AddOptions(list);
				// デフォルト値の設定
				selectAudio.value = 0;
				PlayerPrefs.SetInt("audio", 0);
			}
    	}

		// 値変更時
    	public void OnValueChanged() 
		{
			// キー"audio"で保存
			PlayerPrefs.SetInt("audio", selectAudio.value);
			Debug.Log(selectAudio.value + " selected");
		}
	}
}

