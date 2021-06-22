using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputZoomUrl : MonoBehaviour {

    //オブジェクトと結びつける
    public InputField inputRoomNameField;
    public Text inputRoomNametext;
    public InputField inputZoomUrlField;
    public Text inputZoomUrltext;

    void Start() {
        //Componentを扱えるようにする
        inputRoomNameField = inputRoomNameField.GetComponent<InputField> ();
        inputRoomNametext = inputRoomNametext.GetComponent<Text> ();
        inputZoomUrlField = inputZoomUrlField.GetComponent<InputField> ();
        inputZoomUrltext = inputZoomUrltext.GetComponent<Text> ();
    }

    public void InputText() {
        //テキストにinputZoomUrlFieldの内容を反映
        inputRoomNametext.text = inputRoomNameField.text;
        inputZoomUrltext.text = inputZoomUrlField.text;
    }
    
    /// ボタンをクリックした時の処理
    public void OnClick() {
        Debug.Log(inputRoomNameField.text);
        Debug.Log(inputZoomUrlField.text);

        inputRoomNameField.text = "";
        inputZoomUrlField.text = "";
    }

}