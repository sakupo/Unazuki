using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    // Start is called before the first frame update
    void Start()
    {
        unazuki = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Color newColor = UnazukiColor();
        GetComponent<Renderer>().material.color = newColor;
    }

    Color UnazukiColor()
    {
        float r = unazuki * 0.7f + 0.1f;
        float g = 0.5f - Mathf.Abs(unazuki - 0.5f)*1.0f + 0.2f - unazuki*0.1f;
        float b = (1 - unazuki) * 0.4f + 0.1f;
        return new Color(r, g, b, 1);
    }
}
