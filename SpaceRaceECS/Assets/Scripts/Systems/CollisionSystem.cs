using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

namespace SpaceRaceECS
{
    public class CollisionSystem : IEcsRunSystem
    {
        private EcsFilter<WorldObjectComponent,PlayerComponent, CollisionComponent> playerFilter;

        public void Run()
        {
            foreach(var i in playerFilter)
            {
                ref var worldObjectComponent = ref playerFilter.Get1(i);
                ref var playerComponent = ref playerFilter.Get2(i);

                worldObjectComponent.transform.position = playerComponent.startPoint;

                playerFilter.GetEntity(i).Del<CollisionComponent>();
            }
        }
    }

}

