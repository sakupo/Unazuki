using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsButton : MonoBehaviour
{ 
    private Button settingsButton;
    private GameObject inputAPI;
    private bool show = false;


    // Start is called before the first frame update
    void Start()
    { 
        settingsButton = GetComponent<Button>();
        inputAPI = GameObject.FindGameObjectWithTag("InputAPI");
        inputAPI.SetActive(show);
        settingsButton.onClick.AddListener(OnClickSettingsButton);
    }

    public void OnClickSettingsButton() 
    {
        show = !show;
        inputAPI.SetActive(show);
        Debug.Log("clicked " + show);
    }

}

