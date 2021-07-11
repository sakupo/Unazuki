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
                for (int i = 0; i<WebCamTexture.devices.Length; i++)
                {
                    list.Add(WebCamTexture.devices[i].name);
                }
                selectCamera.AddOptions(list);
                // デフォルト値
                selectCamera.value = 0;
                PlayerPrefs.SetString(WebCamera.PlayerPrefsKeyCamera, WebCamTexture.devices[0].name);
            }
        }

        // 値変更時
        public void onValueChanged()
        {
            Debug.Log(selectCamera.value + " selected");
            string camera = WebCamTexture.devices[selectCamera.value].name;
            PlayerPrefs.SetString(WebCamera.PlayerPrefsKeyCamera, camera);
            Debug.Log(camera + " selected");
        }
    }
}
