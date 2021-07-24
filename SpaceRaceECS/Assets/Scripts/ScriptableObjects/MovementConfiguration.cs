using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceRaceECS
{
    [CreateAssetMenu(fileName = "MovementConfiguration",menuName = "SpaceRaceECS/MovementConfiguration")]
    public class MovementConfiguration : ScriptableObject
    {
        public float movementSpeed;
    }

}

