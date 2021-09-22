using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MainMenu
{
    [SerializeField] private Slider volumeMusic;
    [SerializeField] private GameObject optionsPanel;
    private AudioSource _music;
    private float _musicVolume;

    public void Start()
    {
        _musicVolume = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        volumeMusic.value = _musicVolume;
        _music = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OpenOrClosePanel(optionsPanel);
        }

        if (_music != null)
        {
            _music.volume = _musicVolume;
        }
    }

    public void ChangeVolume()
    {
        _musicVolume = volumeMusic.value;
        Debug.Log(_musicVolume);
        PlayerPrefs.SetFloat("MusicVolume", _musicVolume);
    }
}