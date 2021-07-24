using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

namespace SpaceRaceECS
{
    public class PlayerInputSystem : IEcsRunSystem
    {
        private EcsWorld ecsWorld;
        private EcsFilter<PlayerComponent,MovementComponent> playerFilter;
        //private GameData gameData;

        public void Run()
        {
            foreach (var i in playerFilter)
            {
                ref var playerComponent = ref playerFilter.Get1(i);
                ref var movementComponent = ref playerFilter.Get2(i);

                if (playerComponent.playerNumber == 1)
                {
                    if (Input.GetKey(KeyCode.W))
                    {
                        movementComponent.direction = new Vector2(0,1);
                    }
                    else if (Input.GetKey(KeyCode.S))
                    {
                        movementComponent.direction = new Vector2(0, -1);
                    }
                    else
                    {
                        movementComponent.direction = new Vector2(0, 0);
                    }
                }
                else if (playerComponent.playerNumber == 2)
                {
                    if (Input.GetKey(KeyCode.I))
                    {
                        movementComponent.direction = new Vector2(0, 1);
                    }
                    else if (Input.GetKey(KeyCode.K))
                    {
                        movementComponent.direction = new Vector2(0, -1);
                    }
                    else
                    {
                        movementComponent.direction = new Vector2(0, 0);
                    }
                }

            }


        }
    }

}
