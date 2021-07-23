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
            CreatePlayer(gameData.sceneData.player1, PlayerInputComponent.PlayerType.Player1);
            //Player 2 init
            CreatePlayer(gameData.sceneData.player2, PlayerInputComponent.PlayerType.Player2);

        }

        public void CreatePlayer(GameObject player, PlayerInputComponent.PlayerType playerType)
        {
            var playerEntity = ecsWorld.NewEntity();

            ref var playerComponent = ref playerEntity.Get<PlayerComponent>();
            ref var playerInputComponent = ref playerEntity.Get<PlayerInputComponent>();

            playerComponent.allowedArea = gameData.playerMovementConfig.allowedArea;
            playerComponent.startPoint = player.transform.position;
            playerComponent.speed = gameData.playerMovementConfig.movementSpeed;
            playerComponent.playerTransform = player.transform;
            playerComponent.playerCollider = player.GetComponent<BoxCollider2D>();
            if (playerType.Equals(PlayerInputComponent.PlayerType.Player1))
            {
                playerComponent.scoreText = gameData.sceneData.player1ScoreText;
            }
            else if (playerType.Equals(PlayerInputComponent.PlayerType.Player2))
            {
                playerComponent.scoreText = gameData.sceneData.player2ScoreText;
            }
            playerInputComponent.playerType = playerType;
        }

    }

}

