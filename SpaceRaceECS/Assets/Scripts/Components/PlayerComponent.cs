using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace SpaceRaceECS
{
    public struct PlayerComponent
    {
        public Vector2 startPoint;
        public int score;
        public TextMeshProUGUI scoreText;
        public int playerNumber;
    }
}

