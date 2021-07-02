﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace InternLibrary.Border
{
    [System.Serializable]
    public class Borders
    {
        public Vector2 p1, p2;
        public Vector2 normal;
        public Vector2 hitPoint;
        public string borderName;
        public Borders() { }

        public Borders(Vector2 p1, Vector2 p2,Vector2 normal, string borderName)
        {
            this.p1 = p1;
            this.p2 = p2;
            this.normal = normal;
            this.borderName = borderName;
        }
    }
}

