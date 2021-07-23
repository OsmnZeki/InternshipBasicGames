using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

namespace SpaceRaceECS
{
    public class ScoreSystem : IEcsRunSystem
    {
        private EcsFilter<PlayerComponent> playerFilter;
        public void Run()
        {
            foreach(var i in playerFilter)
            {
                ref var playerComponent = ref playerFilter.Get1(i);

                if (playerComponent.playerTransform.position.y + playerComponent.playerTransform.localScale.y / 2 > playerComponent.allowedArea.yMax)
                {
                    playerComponent.score += 1;
                    playerComponent.scoreText.text = ""+ playerComponent.score;

                    playerComponent.playerTransform.position = playerComponent.startPoint;
                }
                
            }
        }

    }
}


