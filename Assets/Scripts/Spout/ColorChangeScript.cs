using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unazuki;


using System.Linq;
namespace Spout {
    public class ColorChangeScript : MonoBehaviour
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
        // Start is called before the first frame update
        void Start()
        {
            unazuki = 0;
        }

        // Update is called once per frame
        void Update()
        {
            Scene scene = SceneManager.GetSceneByName("MainScene");
            if (scene != null)
            {
                Canvas mainCanvas = SceneManager.GetSceneByName("MainScene").GetRootGameObjects()
                    .First(obj => obj.GetComponent<Canvas>() != null)
                    .GetComponent<Canvas>();
                var unazukiBar = mainCanvas.GetComponentInChildren<UnazukiBar>();
                unazuki = unazukiBar.Value;
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
    }
}

