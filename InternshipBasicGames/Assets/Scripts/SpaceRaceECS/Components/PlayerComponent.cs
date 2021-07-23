using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace SpaceRaceECS
{
    public struct PlayerComponent
    {
        public Transform playerTransform;
        public BoxCollider2D playerCollider;
        public float speed;
        public Rect allowedArea;
        public Vector2 startPoint;
        public int score;
        public TextMeshProUGUI scoreText;
    }
}

