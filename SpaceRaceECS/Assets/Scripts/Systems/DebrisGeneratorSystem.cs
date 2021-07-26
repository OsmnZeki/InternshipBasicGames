using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

namespace SpaceRaceECS
{


    public class DebrisGeneratorSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld ecsWorld;
        private GameData gameData;
        private DebrisGeneratorConfiguration debrisGenConfig;


        float timer;
        public void Init()
        {
            debrisGenConfig = gameData.debrisGeneratorConfig;
            timer = Random.Range(0, debrisGenConfig.generateIntervalTime);
        }

        public void Run()
        {

            timer -= Time.deltaTime;
            if (timer < 0)
            {
                int randBirthNumber = Random.Range(1, debrisGenConfig.maxBirth1Generate);
                while (randBirthNumber > 0)
                {
                    if (debrisGenConfig.debrisEntityStack.Count == 0)
                    {
                        var debrisGo = Object.Instantiate(debrisGenConfig.debrisPrefab, gameData.sceneData.debrisGenerator);

                        var debrisEntity = ecsWorld.NewEntity();
                        ConfigureDebrisEntity(debrisEntity, debrisGo);
                    }
                    else
                    {
                        var debrisEntity = debrisGenConfig.debrisEntityStack.Pop();

                        ref var debrisComponent = ref debrisEntity.Get<DebrisComponent>();
                        ref var movementComponent = ref debrisEntity.Get<MovementComponent>();
                        ref var worldObjectComponent = ref debrisEntity.Get<WorldObjectComponent>();

                        ConfigureDebrisEntity(debrisEntity, debrisComponent.debrisGo);
                        debrisComponent.debrisGo.SetActive(true);
                    }


                    randBirthNumber--;
                }

                timer = Random.Range(0, debrisGenConfig.generateIntervalTime);
            }
        }

        public void ConfigureDebrisEntity(EcsEntity debrisEntity, GameObject debrisGo)
        {
            ref var debrisComponent = ref debrisEntity.Get<DebrisComponent>();
            ref var movementComponent = ref debrisEntity.Get<MovementComponent>();
            ref var worldObjectComponent = ref debrisEntity.Get<WorldObjectComponent>();

            debrisComponent.debrisGo = debrisGo;

            Vector2 initialPoint;

            if (Random.value < 0.5f) //left
            {
                initialPoint.x = gameData.gameAreaMin.x;
                movementComponent.direction = new Vector2(1, 0);
            }
            else
            {

                initialPoint.x = gameData.gameAreaMax.x;
                movementComponent.direction = new Vector2(-1, 0);
            }

            movementComponent.speed = debrisGenConfig.debrisSpeed;
            initialPoint.y = Random.Range(gameData.gameAreaMin.y+2, gameData.gameAreaMax.y);
            debrisGo.transform.position = initialPoint;
            worldObjectComponent.transform = debrisGo.transform;
        }



    }

}

