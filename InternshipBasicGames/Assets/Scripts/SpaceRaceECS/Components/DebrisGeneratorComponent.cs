using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceRaceECS
{
    public struct DebrisGeneratorComponent
    {
        //public Debris[] debrises = new Debris[24];
        [Range(1, 10)] public int maxBirth1Generate;
        [Range(1, 5)] public float generateIntervalTime;
        public int iterator;
        public Vector2[] LeftPoints;
        public Vector2[] RightPoints;

        public float timer;
        public float currentIntervalTime;
    }

}

