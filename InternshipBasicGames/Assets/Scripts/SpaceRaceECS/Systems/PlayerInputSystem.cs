using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

namespace SpaceRaceECS
{
    public class PlayerInputSystem : IEcsRunSystem
    {
        private EcsWorld ecsWorld;
        private EcsFilter<PlayerInputComponent> playerFilter;

        public void Run()
        {
            foreach (var i in playerFilter)
            {
                ref var playerInputComponent = ref playerFilter.Get1(i);

                if (playerInputComponent.playerType.Equals(PlayerInputComponent.PlayerType.Player1))
                {
                    if (Input.GetKey(KeyCode.W))
                    {
                        playerInputComponent.moveInput = 1;
                    }
                    else if (Input.GetKey(KeyCode.S))
                    {
                        playerInputComponent.moveInput = -1;
                    }
                    else
                    {
                        playerInputComponent.moveInput = 0;
                    }
                }
                else if (playerInputComponent.playerType.Equals(PlayerInputComponent.PlayerType.Player2))
                {
                    if (Input.GetKey(KeyCode.I))
                    {
                        playerInputComponent.moveInput = 1;
                    }
                    else if (Input.GetKey(KeyCode.K))
                    {
                        playerInputComponent.moveInput = -1;
                    }
                    else
                    {
                        playerInputComponent.moveInput = 0;
                    }
                }

            }


        }
    }

}
