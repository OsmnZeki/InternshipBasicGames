using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

namespace SpaceRaceECS
{
    public class MoveSystem : IEcsRunSystem
    {
        private EcsFilter<MovementComponent, WorldObjectComponent, PlayerComponent> playerFilter;
        private EcsFilter<MovementComponent, WorldObjectComponent, DebrisComponent> debrisFilter;
        private GameData gameData;

        public void Run()
        {
            foreach (var i in playerFilter)
            {
                ref var movementComponent = ref playerFilter.Get1(i);
                ref var worldObjectComponent = ref playerFilter.Get2(i);

                Vector2 newPos = worldObjectComponent.transform.position;
                newPos += movementComponent.speed * movementComponent.direction * Time.deltaTime;



                if (newPos.y - worldObjectComponent.transform.localScale.y / 2 < gameData.gameAreaMin.y)
                {
                    newPos = worldObjectComponent.transform.position;
                }

                worldObjectComponent.transform.position = newPos;

            }

            foreach(var i in debrisFilter)
            {
                ref var movementComponent = ref debrisFilter.Get1(i);
                ref var worldObjectComponent = ref debrisFilter.Get2(i);
                ref var debrisComponent = ref debrisFilter.Get3(i);



                Vector2 newPos = worldObjectComponent.transform.position;
                newPos += movementComponent.speed * movementComponent.direction * Time.deltaTime;

                if (newPos.x < gameData.gameAreaMin.x - 0.01f || newPos.x > gameData.gameAreaMax.x + 0.01f)
                {
                    var debrisEntity = debrisFilter.GetEntity(i);
                    gameData.debrisGeneratorConfig.debrisEntityStack.Push(debrisEntity);
                    debrisComponent.debrisGo.SetActive(false);
                    debrisEntity.Del<MovementComponent>();
                }

                worldObjectComponent.transform.position = newPos;
            }

        }
    }
}


