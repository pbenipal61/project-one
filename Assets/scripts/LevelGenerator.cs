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

    /// <summary>
    /// Generates the level based on <paramref name="levelCreationData"/> passed.
    /// </summary>
    /// <param name="levelCreationData">Level creation data.</param>
    public void Generate(LevelCreationData levelCreationData)
    {
        obstaclesHolder = new GameObject("Obstacles Holder");
        obstaclePool = CreateObstaclePool(10);
        Debug.Log("Number of obstacles in pool: " + obstaclePool.Count);
        StartCoroutine(ObstaclesCycle(obstaclePool));
    }

    private float lastY = 6f;    // Tracks location of the last obstacle printed.
    /// <summary>
    /// Prints obstacles based on number passed.
    /// </summary>
    /// <param name="numberOfObstacles">Number of obstacles.</param>
    private void PrintObstacles(int numberOfObstacles)
    {
        for (int i = 0; i < numberOfObstacles; i++)
        {
            float x = UnityEngine.Random.Range(-2.2f, 2.2f);
            float y = UnityEngine.Random.Range(2f, 6f);

            lastY = lastY + y;
            Obstacle obj = Instantiate(obstacleObjects[0], new Vector2(x, lastY), Quaternion.identity);
            obj.transform.parent = obstaclesHolder.transform;
        }
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
            pool[i].Activate(-11f);
        }
        lastYInCycle = 6f;
        yield return new WaitForSeconds(0f);
        //StartCoroutine(ObstaclesCycle(pool));
    }
}


