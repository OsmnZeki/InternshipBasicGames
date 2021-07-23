using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

namespace SpaceRaceECS
{
    public class Startup : MonoBehaviour
    {
        private EcsWorld ecsWorld;
        private EcsSystems systems;


        public SceneData sceneData;
        public MovementConfiguration playerMovementConfig;

        void Start()
        {
            ecsWorld = new EcsWorld();
            var gameData = new GameData();

            gameData.sceneData = sceneData;
            gameData.playerMovementConfig = playerMovementConfig;

            systems = new EcsSystems(ecsWorld)
                    .Add(new PlayerInitSystem())
                    .Add(new PlayerInputSystem())
                    .Add(new PlayerMoveSystem())
                    .Add(new ScoreSystem())
                    .Inject(gameData);



            systems.ProcessInjects();

            systems.Init();
        }

        // Update is called once per frame
        void Update()
        {
            systems.Run();
        }


        private void OnDestroy()
        {
            systems.Destroy();
            ecsWorld.Destroy();
        }
    }

}


