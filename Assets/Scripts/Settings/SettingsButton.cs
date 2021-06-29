using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Settings
{
    public class SettingsButton : MonoBehaviour
    {
        public Button settingsButton;
        public GameObject inputAPI;
        public GameObject applyAPI;
        public GameObject selectDevice;
        private bool show = false;


        // Start is called before the first frame update
        void Start()
        {
            settingsButton = GetComponent<Button>();
            inputAPI = GameObject.FindGameObjectWithTag("InputAPI");
            applyAPI = GameObject.FindGameObjectWithTag("ApplyAPI");
            selectDevice = GameObject.FindGameObjectWithTag("AudioDevice");
            // settingsButton以外非表示
            inputAPI.SetActive(show);
            applyAPI.SetActive(show);
            selectDevice.SetActive(show);
        }

        // ボタンクリック時の処理
        public void onClick()
        {
            show = !show;
            inputAPI.SetActive(show);
            applyAPI.SetActive(show);
            selectDevice.SetActive(show);
            Debug.Log("clicked " + show);
        }


    }
}

