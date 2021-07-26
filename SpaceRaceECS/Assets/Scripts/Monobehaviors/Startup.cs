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
        public DebrisGeneratorConfiguration debrisGeneratorConfig;
        public Vector2 gameAreaMax, gameAreaMin;
        void Start()
        {
            ecsWorld = new EcsWorld();
            systems = new EcsSystems(ecsWorld);
            var gameData = new GameData();

            gameData.sceneData = sceneData;
            gameData.playerMovementConfig = playerMovementConfig;
            gameData.debrisGeneratorConfig = debrisGeneratorConfig;
            gameData.gameAreaMax = gameAreaMax;
            gameData.gameAreaMin = gameAreaMin;
            

#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(ecsWorld);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(systems);
#endif

            systems.Add(new PlayerInitSystem())
                    .Add(new PlayerInputSystem())
                    .Add(new DebrisGeneratorSystem())
                    .Add(new MoveSystem())
                    .Add(new CollisionSystem())
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


        private void OnDrawGizmosSelected()
        {
            Vector2 upLeft = new Vector2(gameAreaMin.x, gameAreaMax.y);
            Vector2 upRight = new Vector2(gameAreaMax.x, gameAreaMax.y);
            Vector2 downLeft = new Vector2(gameAreaMin.x, gameAreaMin.y);
            Vector2 downRight = new Vector2(gameAreaMax.x, gameAreaMin.y);

            Debug.DrawLine(upLeft, upRight, Color.red);
            Debug.DrawLine(downLeft, downRight, Color.red);
            Debug.DrawLine(upRight, downRight, Color.blue);
            Debug.DrawLine(upLeft, downLeft, Color.blue);
        }
    }

}


