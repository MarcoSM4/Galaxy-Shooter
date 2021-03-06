﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float _speed = 10.0f;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector2.up * _speed * Time.deltaTime);

        if (transform.position.y >= 6.5f)
        {
            Destroy(this.gameObject);
        }
    }
}
