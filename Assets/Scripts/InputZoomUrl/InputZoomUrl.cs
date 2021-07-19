using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace InputZoomUrl
{

    public class InputZoomUrl : MonoBehaviour
    {

        //オブジェクトと結びつける
        public TMP_InputField  inputRoomNameField;
        public TMP_InputField  inputZoomUrlField;
        
        public GameObject gameObject;
        private DisplayRooms displayRooms;

        void Start()
        {
            //Componentを扱えるようにする
            inputRoomNameField = inputRoomNameField.GetComponent<TMP_InputField>();
            inputZoomUrlField = inputZoomUrlField.GetComponent<TMP_InputField>();
            
            displayRooms = gameObject.GetComponent<DisplayRooms>();
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
            if (inputRoomNameField.text == "" || inputZoomUrlField.text == "")
                return null;
            
            Tuple<string, string> data = new Tuple<string, string>(inputRoomNameField.text, inputZoomUrlField.text);
            
            inputRoomNameField.text = "";
            inputZoomUrlField.text = "";

            return data;
        }
    }

}