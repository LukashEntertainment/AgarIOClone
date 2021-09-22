using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSelecter : MonoBehaviour
{
    [SerializeField] private GameObject[] text;

    [SerializeField] private Color[] colors;

    public Color _color;
    
    public void Start()
    {
        SelectColor("green");
    }

    public void SelectColor(string color)
    {
        if (color == "green")
        {
            ResetColor();
            _color = colors[0];
            text[0].SetActive(true);
            PlayerPrefs.SetString("color", JsonUtility.ToJson(_color));
        }

        if (color == "purple")
        {
            ResetColor();
            _color = colors[1];
            text[1].SetActive(true);
            PlayerPrefs.SetString("color", JsonUtility.ToJson(_color));
        }

        if (color == "blue")
        {
            ResetColor();
            _color = colors[2];
            text[2].SetActive(true);
            PlayerPrefs.SetString("color", JsonUtility.ToJson(_color));
        }
    }

    private void ResetColor()
    {
        _color = Color.green;
        for (int i = 0; i < text.Length; i++)
        {
            text[i].SetActive(false);
        }
    }
}
