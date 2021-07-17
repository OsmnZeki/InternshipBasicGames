﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pong
{
    public class Player : MonoBehaviour
    {
        public float movementSpeed = 1;
        public Rect allowedArea;


        void Update()
        {

            Movement();
        }

        void Movement()
        {
            float direction = Input.GetAxisRaw("Vertical");
            Vector2 newPos = transform.position;
            newPos.y += movementSpeed * direction * Time.deltaTime;
            if (!allowedArea.Contains(newPos))
            {
                newPos = transform.position;
            }
            transform.position = newPos;
        }

    }
}


