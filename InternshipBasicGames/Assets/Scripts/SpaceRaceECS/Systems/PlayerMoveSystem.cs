using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

namespace SpaceRaceECS
{
    public class PlayerMoveSystem : IEcsRunSystem
    {
        private EcsFilter<PlayerComponent, PlayerInputComponent> playerFilter;

        public void Run()
        {
            foreach (var i in playerFilter)
            {
                ref var playerComponent = ref playerFilter.Get1(i);
                ref var playerInputComponent = ref playerFilter.Get2(i);

                

                Vector2 newPos = playerComponent.playerTransform.position;
                newPos.y += playerComponent.speed * playerInputComponent.moveInput * Time.deltaTime;

                

                if (newPos.y - playerComponent.playerTransform.localScale.y / 2 < playerComponent.allowedArea.yMin)
                {
                    newPos = playerComponent.playerTransform.position;
                }
                playerComponent.playerTransform.position = newPos;

            }

        }
    }
}


