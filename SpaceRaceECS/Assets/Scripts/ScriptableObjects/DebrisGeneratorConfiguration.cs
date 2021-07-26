using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

namespace SpaceRaceECS
{
    [CreateAssetMenu(fileName = "DebrisGeneratorConfiguration", menuName = "SpaceRaceECS/DebrisGeneratorConfiguration")]
    public class DebrisGeneratorConfiguration : ScriptableObject
    {
        [Range(1, 10)] public int maxBirth1Generate;
        [Range(1, 5)] public float generateIntervalTime;
        public GameObject debrisPrefab;
        public float debrisSpeed;
        public Stack<EcsEntity> debrisEntityStack = new Stack<EcsEntity>();
    }

}
