using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Unit : MonoBehaviour
{
    [SerializeField] private TextMesh nameText;
    public string playerName;
    private float _size;
    protected float Speed;
    public GameManager _gameManager;
    protected int Score;

    public virtual void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        playerName = RandomString(5);
        nameText.text = playerName;
        _size = transform.localScale.x;
        Speed = 10;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("food") || other.CompareTag("Player") || other.CompareTag("Enemy"))
        {
            var localFoodScale = other.transform.localScale;
            if (localFoodScale.x < _size)
            {
                Eat(localFoodScale);
                Destroy(other.gameObject);
            }
            else
            {
                other.transform.localScale = DestroyUnit(localFoodScale);
            }
        }
    }

    public virtual void Eat(Vector3 foodSize)
    {
        _size += foodSize.x / 2;
        transform.localScale = new Vector3(_size, _size, _size);
    }

    public virtual Vector3 DestroyUnit(Vector3 foodSize)
    {
        foodSize = new Vector3(foodSize.x + _size,
            foodSize.y + _size,
            foodSize.z + _size);
        Destroy(gameObject);
        return foodSize;
    }
    
    public static string RandomString(int length)
    {
        var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        var stringChars = new char[length];

        for (int i = 0; i < stringChars.Length; i++)
        {
            stringChars[i] = chars[Random.Range(0, chars.Length)];
        }

        var finalString = new String(stringChars);
        return finalString;
    }
}