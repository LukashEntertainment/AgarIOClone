using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : Unit
{
    [SerializeField] private float minX, maxX, minY, maxY;
    [SerializeField] private LayerMask enemylayer; // проверка того, кто является врагом (нужно указать слои по которым будет поиск)
    [SerializeField] private Transform center;
    
    private Vector3 _direction; // направление движения
    private Transform _enemy; // цель
    private Collider2D[] _results; //полученные коллайдеры в зоне видимости юнита

    public override void Start()
    {
        base.Start();
        if (_results == null)
        {
            _results = new Collider2D[256];
        }
        SetDirection();
        
    }

    public void Update()
    {
        if (_enemy != null) //если враг есть проверяем его положение и размер
        {
            if (_enemy.transform.localScale.x < transform.localScale.x)
            {
                _direction = _enemy.position;
            }
        }

        Move(); //движение
    }

    private void Move()
    {
        transform.position =
            Vector3.MoveTowards(transform.position, _direction, Speed * Time.deltaTime / transform.localScale.x);
        
        if (transform.position == _direction) //достигли назначения
        {
            SetDirection();
        }
    }

    private Transform FindTarget() //нахождение цели
    {
        int units = Physics2D.OverlapCircleNonAlloc(center.position, 5, _results ,enemylayer);
        if (units > 1)
        {
            foreach (var unit in _results)
            {
                if (unit.transform.localScale.x < transform.localScale.x)
                {
                    return unit.transform;
                }
            }
        }
        
        return null;
    }
    
    private Vector3 FindDirection() //генерация случайного направления
    {
        return new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), transform.position.z);
    }

    public void SetDirection()
    {
        _enemy = FindTarget();
        if (_enemy == null) // если врага или еды нет то юнит просто бродит по карте в рандомном направлении
        {
            _direction = FindDirection();
        }
    }
}