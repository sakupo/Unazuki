using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace InputZoomUrl
{

    public class InputZoomUrl : MonoBehaviour
    {

        //オブジェクトと結びつける
        public InputField inputRoomNameField;
        public Text inputRoomNametext;
        public InputField inputZoomUrlField;
        public Text inputZoomUrltext;

        void Start()
        {
            //Componentを扱えるようにする
            inputRoomNameField = inputRoomNameField.GetComponent<InputField>();
            inputRoomNametext = inputRoomNametext.GetComponent<Text>();
            inputZoomUrlField = inputZoomUrlField.GetComponent<InputField>();
            inputZoomUrltext = inputZoomUrltext.GetComponent<Text>();
        }

        public void InputText()
        {
            //テキストにinputZoomUrlFieldの内容を反映
            inputRoomNametext.text = inputRoomNameField.text;
            inputZoomUrltext.text = inputZoomUrlField.text;
        }

        /// ボタンをクリックした時の処理
        public void OnClick()
        {
            Dictionary<string, string> data = GetZoomInputData();
        }

        private Dictionary<string, string> GetZoomInputData()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add(inputRoomNametext.text, inputZoomUrltext.text);
            
            inputRoomNameField.text = "";
            inputZoomUrlField.text = "";

            return data;
        }
    }

}