using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Settings
{
    public class SettingsButton : MonoBehaviour
    {
        public Button settingsButton;
        private bool show = false;

        public GameObject parent;


        // Start is called before the first frame update
        void Start()
        {
            parent.SetActive(show);
        }

        // ボタンクリック時の処理
        public void OnClick()
        {
            show = !show;
            parent.SetActive(show);
            Debug.Log("clicked " + show);
        }


    }
}

