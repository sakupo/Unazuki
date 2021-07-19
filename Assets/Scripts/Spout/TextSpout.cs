using System;
using Main;
using TMPro;
using UnityEngine;
using Utility;

namespace Spout
{
    public class TextSpout : MonoBehaviour, IObserver<string>, IObserver<bool>
    {
        [SerializeField]
        private TextMeshProUGUI cardNameText;

        private MessageField messageField;
        private bool textDisplay;
        private string text;
        // Start is called before the first frame update
        void Start()
        {
            cardNameText.text = "表示させたい文字列";
            text = "表示させたい文字列";
            messageField = CanvasEx.GetComponentInCanvasChildrenFromScene<MessageField>("MainScene");
            messageField.Subscribe(this);
            var textDisplayButton = CanvasEx.GetComponentInCanvasChildrenFromScene<TextDisplayButton>("MainScene");
            textDisplayButton.Subscribe(this);
            textDisplay = true;
        }

        public void OnCompleted()
        {
            // do nothing
        }

        public void OnError(Exception error)
        {
            // do nothing
        }

        public void OnNext(string text)
        {
            if (textDisplay)
            {
                cardNameText.text = text;
                this.text = text;
            }
            
        }

        public void OnNext(bool value)
        {
            textDisplay = value;
            if (value)
            {
                cardNameText.text = text; 
            }
            else
            {
                cardNameText.text = "";
            }
            
        }
    }
}
