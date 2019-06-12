using System;
using System.Collections;
using UnityEngine;
using UtilityMethodsAndEnums.Models;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour
{

    #region Instance
    private static LevelGenerator instance;
    public static LevelGenerator Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<LevelGenerator>();
                if (instance == null)
                {
                    instance = new GameObject("LevelGenerator", typeof(LevelGenerator)).GetComponent<LevelGenerator>();
                }
            }
            return instance;
        }

        set
        {
            instance = value;
        }
    }


    #endregion
    [Header("Logic")]
    private GameObject obstaclesHolder;                            // Object to parent all obstacles
    private List<Obstacle> obstaclePool;                           // Obstacle pool
    private int currentObstacle = 0;                               // Index of current obstacle used from the pool
    private float speed = 10f;                                     // Speed of flow of obstacles
    public List<Obstacle> obstacleObjects = new List<Obstacle>();   // List of obstacle bases to be duplicated for use.
    private List<Vector2> obstaclesPositions;                       // List of initial positions of all obstacles
    private CameraControllerV2 cameraController;                    // Reference to camera controller

    private void Start()
    {
        // Finds reference to camera controller 
        if (cameraController == null)
        {
            cameraController = FindObjectOfType<CameraControllerV2>();
        }
    }

    /// <summary>
    /// Generates the level based on <paramref name="levelCreationData"/> passed.
    /// </summary>
    /// <param name="levelCreationData">Level creation data.</param>
    public void Generate(LevelCreationData levelCreationData)
    {
        obstaclesHolder = new GameObject("Obstacles Holder");
        obstaclePool = CreateObstaclePool(5);
        Debug.Log("Number of obstacles in pool: " + obstaclePool.Count);
        StartCoroutine(ObstaclesCycle(obstaclePool));
    }

   
    /// <summary>
    /// Creates the obstacle pool.
    /// </summary>
    /// <returns>The obstacle pool.</returns>
    /// <param name="numberOfObjects">Number of objects.</param>
    private List<Obstacle> CreateObstaclePool(int numberOfObjects)
    {
        List<Obstacle> pool = new List<Obstacle>();
        for (int i = 0; i < numberOfObjects; i++)
        {
            Obstacle obj = Instantiate(obstacleObjects[0], new Vector2(0, 0), Quaternion.identity);
            obj.name = i.ToString();
            pool.Add(obj);
            obj.Deactivate();
            obj.transform.parent = obstaclesHolder.transform;
        }
        return pool;

    }

    private float lastYInCycle = 6f;
    /// <summary>
    /// Starts the obstacle flow
    /// </summary>
    /// <returns>The cycle starts to flow.</returns>
    /// <param name="pool">Pool.</param>
    private IEnumerator ObstaclesCycle(List<Obstacle> pool)
    {
        for (int i = 0; i < pool.Count; i++)
        {
            float x = UnityEngine.Random.Range(-2.2f, 2.2f);
            float y = UnityEngine.Random.Range(2f, 6f);

            lastYInCycle = lastYInCycle + y;
            Vector2 pos = new Vector2(x, lastYInCycle);
            pool[i].Activate(pos);
        }

        yield return new WaitForSeconds(0f);
        //StartCoroutine(ObstaclesCycle(pool));
    }

    private float lastY; // Tracks location of the last obstacle printed.
    /// <summary>
    /// Generates a new position.
    /// </summary>
    /// <returns>The new position.</returns>
    public virtual Vector2 GenerateNewPosition()
    {

        float x = UnityEngine.Random.Range(-2.2f, 2.2f);
        float y = UnityEngine.Random.Range(3, 6);

        lastY = lastY + y;
        Vector2 pos = new Vector2(x, lastY);

        return pos;
    }

    private void Update()
    {
        for( int i = 0; i < obstaclePool.Count; i++)
        {
            Obstacle obstacle = obstaclePool[i];

            float EPSILON = 0;
            if (System.Math.Abs(cameraController.GetYPosition() - 7) > EPSILON)
            {
                if (obstacle.GetPosition().y <= cameraController.GetYPosition() - 7)
                {

                    obstacle.SetPosition(GenerateNewPosition());
                }
            }
        }
    }
}


