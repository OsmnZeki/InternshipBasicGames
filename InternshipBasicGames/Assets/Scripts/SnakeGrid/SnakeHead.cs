using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SnakeGrid
{

    struct GridPos { int x, y; }

    public class SnakeHead : MonoBehaviour
    {
        //public Vector2 pos;   // TODO floatli positiona ya da position to gride gerek yokki hersey gridde zaten ++
        public MyGrid nextGrid;
        public Vector2 direction;
        public float speed;
        public float timeToStep;

        public MyGridSystem myGridSystem;

        public List<GameObject> mySnake = new List<GameObject>();
        public int snakeListIterator;
        public GameObject snakeTailPrefab;
        public GameObject foodPrefab;

        const string FOOD = "food";
        const string TAIL = "tail";

        private void Awake()
        {
            mySnake.Add(gameObject);
        }
        void Start()
        {
            var gridPos = myGridSystem.WorldPositionToGrid(transform.position);
            nextGrid = myGridSystem.GetCurrentGrid(gridPos);
            transform.position = nextGrid.worldPosition;
            GenerateFood();
        }


        void Update()
        {
            //TODO instance :( ++
            var gridPos = myGridSystem.WorldPositionToGrid(transform.position);


            if (direction.x != 0 && Input.GetAxisRaw("Vertical") != 0 && Input.GetAxisRaw("Horizontal") == 0)
            {

                direction.y = Input.GetAxisRaw("Vertical");
                direction.x = 0;
            }
            else if (direction.y != 0 && Input.GetAxisRaw("Horizontal") != 0 && Input.GetAxisRaw("Vertical") == 0)
            {
                direction.x = Input.GetAxisRaw("Horizontal");
                direction.y = 0;
            }

            // TODO timeToStep -= Time.deltaTime daha hos ??
            timeToStep += speed * Time.deltaTime;

            if (timeToStep >= 1)
            {

                gridPos += direction.normalized;
                timeToStep = 0;


                nextGrid = myGridSystem.GetCurrentGridInfinitly(ref gridPos);



                if (nextGrid.placedObj != null)//collider check
                {
                    // TODO string ++
                    if (nextGrid.placedObjTag == FOOD)
                    {
                        Destroy(nextGrid.placedObj);
                        var tailPos = mySnake[snakeListIterator].transform.position;
                        var tail = Instantiate(snakeTailPrefab, tailPos, Quaternion.identity);
                        snakeListIterator++;
                        mySnake.Add(tail);
                        GenerateFood();
                    }
                    else if (nextGrid.placedObjTag == TAIL)
                    {
                        Time.timeScale = 0;
                    }

                }

                if (mySnake.Count >= 2)//tail movement
                {
                    // TODO 
                    /*
                           
                            
                            Queue<GridPos> snakePositions = new Queue<GridPos>();
                            snakePositions.Enqueue(newPos)
                            snakePositions.Dequeue()
                            foreach pos in snakePositions
                                snakeParts[i++].transform.positions = pos;
                     
                    */
                    for (int i = mySnake.Count - 1; i >= 1; i--)
                    {
                        if (i == mySnake.Count - 1)
                        {
                            var gPos = myGridSystem.WorldPositionToGrid(mySnake[i].transform.position);
                            myGridSystem.RemoveTheObjectFromGrid(gPos);
                        }
                        // TODO kisa fonskyon birden falza yerden kullanmiyosan gereksiz ++
                        ReplaceTails(mySnake[i], mySnake[i - 1]);
                    }
                }

                transform.position = nextGrid.worldPosition;

            }



        }

        public void GenerateFood()
        {
            Vector2 foodPos;
            foodPos.x = Random.Range(0, myGridSystem.sizeX);
            foodPos.y = Random.Range(0, myGridSystem.sizeY);

            while (myGridSystem.GetCurrentGrid(foodPos).placedObj != null)
            {
                foodPos.x = Random.Range(0, myGridSystem.sizeX);
                foodPos.y = Random.Range(0, myGridSystem.sizeY);

            }
            var food = Instantiate(foodPrefab);
            myGridSystem.PlaceTheObjToGrid(foodPos, food, "food");

        }

        public void ReplaceTails(GameObject currentTail, GameObject prevTail)
        {
            var prevTailGPos = myGridSystem.WorldPositionToGrid(prevTail.transform.position);
            //var currentTailGPos = MyGridSystem.instance.WorldPositionToGrid(currentTail.transform.position);
            myGridSystem.RemoveTheObjectFromGrid(prevTailGPos);
            myGridSystem.PlaceTheObjToGrid(prevTailGPos, currentTail, "tail");

        }
    }

    
}
