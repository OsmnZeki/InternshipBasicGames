using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

namespace SpaceRaceECS
{
    public class PlayerInitSystem : IEcsInitSystem
    {
        private EcsWorld ecsWorld;
        private GameData gameData;

        public void Init()
        {
            //Player1 init
            CreatePlayer(gameData.sceneData.player1,1);
            //Player 2 init
            CreatePlayer(gameData.sceneData.player2,2);

        }

        public void CreatePlayer(GameObject player,int playerNumber)
        {
            var playerEntity = ecsWorld.NewEntity();

            ref var worldObjectComponent = ref playerEntity.Get<WorldObjectComponent>();
            ref var playerComponent = ref playerEntity.Get<PlayerComponent>();
            ref var movementComponent = ref playerEntity.Get<MovementComponent>();

            worldObjectComponent.transform = player.transform;
            playerComponent.startPoint = player.transform.position;
            playerComponent.playerCollider = player.GetComponent<BoxCollider2D>();
            playerComponent.playerNumber = playerNumber;
            movementComponent.speed = gameData.playerMovementConfig.movementSpeed;

            if (playerNumber == 1)
            {
                playerComponent.scoreText = gameData.sceneData.player1ScoreText;
            }
            else
            {
                playerComponent.scoreText = gameData.sceneData.player2ScoreText;
            }

            

        }

    }

}

