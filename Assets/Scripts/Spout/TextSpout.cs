using System;
using Main;
using TMPro;
using UnityEngine;
using Utility;

namespace Spout
{
    public class TextSpout : MonoBehaviour, IObserver<string>
    {
        [SerializeField]
        private TextMeshPro cardNameText;

        private MessageField messageField;
        // Start is called before the first frame update
        void Start()
        {
            cardNameText.text = "表示させたい文字列";
            messageField = CanvasEx.GetComponentInCanvasChildrenFromScene<MessageField>("MainScene");
            messageField.Subscribe(this);
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
            cardNameText.text = text;
        }
    }
}
