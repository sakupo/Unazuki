using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unazuki;
using Main;


using System.Linq;
using System;

namespace Spout {
    public class ColorChangeScript : MonoBehaviour, IObserver<bool>
    {
        [SerializeField]
        private float unazuki;
        public float Unazuki
        {
            get
            {
                return unazuki;
            }
            set
            {
                unazuki = value;
            }
        }
        [SerializeField]
        private bool lowSaturation;
        public bool LowSaturation
        {
            get
            {
                return lowSaturation;
            }
            set
            {
                lowSaturation = value;
            }
        }

        Canvas mainCanvas;
        UnazukiScene unazukiScene;
        public bool unazukiBarState;

        // Start is called before the first frame update
        void Start()
        {
            unazuki = 0;
            mainCanvas = SceneManager.GetSceneByName("MainScene").GetRootGameObjects()
                    .First(obj => obj.GetComponent<Canvas>() != null)
                    .GetComponent<Canvas>();
            unazukiScene = SceneManager.GetSceneByName("UnazukiScene").GetRootGameObjects()
                    .First(obj => obj.GetComponent<UnazukiScene>() != null)
                    .GetComponent<UnazukiScene>();

            unazukiBarState = false;
            mainCanvas.GetComponentInChildren<UnazukiBarStateButton>().Subscribe(this);
        }

        // Update is called once per frame
        void Update()
        {
            Scene scene = SceneManager.GetSceneByName("MainScene");
            if (scene != null)
            {
                if (unazukiBarState)
                {
                    var unazukiBar = mainCanvas.GetComponentInChildren<UnazukiBar>();
                    unazuki = unazukiBar.Value;
                }
                else
                {
                    unazuki = unazukiScene.Extractor.GetUnazukiLevel();
                }
            }
            Color newColor;
            if (lowSaturation)
            {
                newColor = UnazukiColorLowSaturation();
            }
            else
            {
                newColor = UnazukiColor();
            }
            GetComponent<Renderer>().material.color = newColor;
        }

        public Color UnazukiColor()
        {
            float r = unazuki * 0.4f + 0.15f + unazuki * 0.15f;
            float g = 0.2f - Mathf.Abs(unazuki - 0.5f) * 0.4f + 0.15f + unazuki * 0.15f;
            float b = (1 - unazuki) * 0.2f + 0.1f + unazuki * 0.2f;
            return new Color(r, g, b, 1);
        }

        public Color UnazukiColorLowSaturation()
        {
            float r = unazuki * 0.4f + 0.15f + unazuki * 0.15f;
            float g = 0.2f - Mathf.Abs(unazuki - 0.5f) * 0.4f + 0.15f + unazuki * 0.15f;
            float b = (1 - unazuki) * 0.2f + 0.1f + unazuki * 0.2f;
            return new Color(r*0.6f+0.2f + unazuki*0.2f, g * 0.6f + 0.2f + unazuki*0.2f, b * 0.6f + 0.2f + unazuki*0.2f, 1);
        }

        public void OnCompleted()
        {
            //何もしない
        }

        public void OnError(Exception error)
        {
            //何もしない
        }

        public void OnNext(bool value)
        {
            unazukiBarState = value;
        }
    }
}

