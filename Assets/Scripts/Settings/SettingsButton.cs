using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utility;

namespace Settings
{
    public class SettingsButton : MonoBehaviour
    {
        public Button settingsButton;
        private bool show = false;

        public GameObject parent;
        private GameObject cameraObj;
        [SerializeField] private GameObject bgCanvasObj;


        // Start is called before the first frame update
        void Start()
        {
            parent.SetActive(show);
            bgCanvasObj.SetActive(show);
        }

        // ボタンクリック時の処理
        public void OnClick()
        {
            show = !show;
            parent.SetActive(show);
            bgCanvasObj.SetActive(show);
            Debug.Log("clicked " + show);
        }


    }
}

