using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceRaceECS
{
    public class GameData
    {
        public SceneData sceneData;
        public MovementConfiguration playerMovementConfig;
        public DebrisGeneratorConfiguration debrisGeneratorConfig;
        public Vector2 gameAreaMax, gameAreaMin;
    }
}

