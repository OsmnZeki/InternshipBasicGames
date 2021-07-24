using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

namespace SpaceRaceECS
{
    public class ScoreSystem : IEcsRunSystem
    {
        private EcsFilter<MovementComponent,WorldObjectComponent,PlayerComponent> playerFilter;
        private GameData gameData;
        public void Run()
        {
            foreach(var i in playerFilter)
            {
                ref var movementComponent = ref playerFilter.Get1(i);
                ref var worldObjectComponent = ref playerFilter.Get2(i);
                ref var playerComponent = ref playerFilter.Get3(i);

                if (worldObjectComponent.transform.position.y + worldObjectComponent.transform.localScale.y / 2 > gameData.gameAreaMax.y)
                {
                    playerComponent.score += 1;
                    playerComponent.scoreText.text = ""+ playerComponent.score;

                    worldObjectComponent.transform.position = playerComponent.startPoint;
                }
                
            }
        }

    }
}


