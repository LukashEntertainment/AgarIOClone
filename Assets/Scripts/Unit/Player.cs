using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    private SpriteRenderer _spriteRenderer;
    public void Start()
    {
        base.Start();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.color = JsonUtility.FromJson<Color>(PlayerPrefs.GetString("color"));
        Score = 0;
    }
    public void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 Target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Target.z = transform.position.z;
        transform.position = Vector3.MoveTowards(transform.position, Target, Speed * Time.deltaTime / transform.localScale.x);
    }
    
    public override void Eat(Vector3 foodSize)
    {
        Score += 1;
        _gameManager.UpdateScore(Score, playerName);
        _gameManager.CheckEnemies();
        base.Eat(foodSize);
    }

    public override Vector3 DestroyUnit(Vector3 foodSize)
    {
        _gameManager.Lose();
        return base.DestroyUnit(foodSize);
    }
}
