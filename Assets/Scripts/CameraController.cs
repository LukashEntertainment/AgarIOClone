using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Player _player;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, -10);
        if (_player != null)
        {
            transform.position = Vector3.Lerp(transform.position, _player.transform.position, 5.5f * Time.deltaTime);
        }
    }
}
