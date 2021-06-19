using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputZoomUrl : MonoBehaviour {

    //オブジェクトと結びつける
    public InputField inputZoomUrlField;
    public Text inputZoomUrltext;

    void Start() {
        //Componentを扱えるようにする
        inputZoomUrlField = inputZoomUrlField.GetComponent<InputField> ();
        inputZoomUrltext = inputZoomUrltext.GetComponent<Text> ();
    }

    public void InputText() {
        //テキストにinputZoomUrlFieldの内容を反映
        inputZoomUrltext.text = inputZoomUrlField.text; 
    }
    
    /// ボタンをクリックした時の処理
    public void OnClick() {
        Debug.Log(inputZoomUrlField.text);
        inputZoomUrlField.text = "";
    }

}