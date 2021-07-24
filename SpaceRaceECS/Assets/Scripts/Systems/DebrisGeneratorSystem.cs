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
        private Stack<EcsEntity> debrisStack = new Stack<EcsEntity>();//TODO: ortak bir scripte yerleþtir


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
                    Debug.Log("1");
                    if (debrisStack.Count == 0)
                    {
                        
                        CreateDebrisEntity();
                    }
                    else
                    {
                        //TODO: stackteki entityleri sahneye yerleþtir
                    }


                    randBirthNumber--;
                }

                timer = Random.Range(0, debrisGenConfig.generateIntervalTime);
            }
        }

        public void CreateDebrisEntity()
        {

            var debrisGO = Object.Instantiate(debrisGenConfig.debrisPrefab);

            var debrisEntity = ecsWorld.NewEntity();

            ref var debrisComponent = ref debrisEntity.Get<DebrisComponent>();
            ref var movementComponent = ref debrisEntity.Get<MovementComponent>();
            ref var worldObjectComponent = ref debrisEntity.Get<WorldObjectComponent>();

            ConfigureDebris(ref movementComponent, ref worldObjectComponent, debrisGO);


            debrisComponent.destroyPMaxX = gameData.gameAreaMax.x + .5f;
            debrisComponent.destroyPMinX = gameData.gameAreaMin.x - .5f;
        }

        public void ConfigureDebris(ref MovementComponent movementComponent, ref WorldObjectComponent worldObjectComponent, GameObject debrisGO)
        {
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
            initialPoint.y = Random.Range(gameData.gameAreaMin.y, gameData.gameAreaMax.y);
            debrisGO.transform.position = initialPoint;
            worldObjectComponent.transform = debrisGO.transform;

        }



    }

}

