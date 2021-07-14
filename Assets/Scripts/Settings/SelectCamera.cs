using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using Unazuki;

namespace Settings
{
    public class SelectCamera : MonoBehaviour
    {
        public TMP_Dropdown selectCamera;
        // Start is called before the first frame update
        void Start()
        {
            if (selectCamera)
            {
                selectCamera.ClearOptions();
                List<string> list = new List<string>();
                for (int i=0; i<WebCamTexture.devices.Length; i++)
                {
                    list.Add(WebCamTexture.devices[i].name);
                }
                selectCamera.AddOptions(list);
                // デフォルト値
				if (PlayerPrefs.HasKey(WebCamera.PlayerPrefsKeyCamera))
				{
					string camera  = PlayerPrefs.GetString(WebCamera.PlayerPrefsKeyCamera);
					int camera_i;

					for (camera_i=0; camera_i<WebCamTexture.devices.Length; camera_i++)
					{
						if (camera.Equals(WebCamTexture.devices[camera_i].name)) break;
					}
					selectCamera.value = camera_i;
				} 
				else 
				{ 
					selectCamera.value = 0;
                	PlayerPrefs.SetString(WebCamera.PlayerPrefsKeyCamera, WebCamTexture.devices[0].name);
					PlayerPrefs.Save();
				}
            }
        }

        // 値変更時
        public void onValueChanged()
        {
            Debug.Log(selectCamera.value + " selected");
            string camera = WebCamTexture.devices[selectCamera.value].name;
            PlayerPrefs.SetString(WebCamera.PlayerPrefsKeyCamera, camera);
			PlayerPrefs.Save();
            Debug.Log(camera + " selected");
        }
    }
}
