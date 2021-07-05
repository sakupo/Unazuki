using System;
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
        
        public GameObject gameObject;
        private DisplayRooms displayRooms;

        void Start()
        {
            //Componentを扱えるようにする
            inputRoomNameField = inputRoomNameField.GetComponent<InputField>();
            inputRoomNametext = inputRoomNametext.GetComponent<Text>();
            inputZoomUrlField = inputZoomUrlField.GetComponent<InputField>();
            inputZoomUrltext = inputZoomUrltext.GetComponent<Text>();
            
            displayRooms = gameObject.GetComponent<DisplayRooms>();
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
            Tuple<string, string> data = GetZoomInputData();
            if(data != null)
                displayRooms.AddData(data);
        }

        private Tuple<string, string> GetZoomInputData()
        {
            // どちらかが空欄なら何もしない
            if (inputRoomNametext.text == "" || inputZoomUrltext.text == "")
                return null;
            
            Tuple<string, string> data = new Tuple<string, string>(inputRoomNametext.text, inputZoomUrltext.text);

            inputRoomNameField.text = "";
            inputZoomUrlField.text = "";

            return data;
        }
    }

}