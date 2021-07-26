using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

namespace SpaceRaceECS
{
    public class CollisionViewer : MonoBehaviour
    {
        public EcsWorld ecsWorld;
        public EcsEntity objEntity;

        private void OnCollisionEnter(Collision collision)
        {
            objEntity.Get<CollisionComponent>();
        }
    }
}

