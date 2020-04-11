using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidManager : MonoBehaviour
{

    public GameObject Boidprefab;
    public GameObject Goalmarker;
    static int NumBoids = 5;
    public int AreaSize = 10;
    public static GameObject[] Boids = new GameObject[NumBoids];
    public static Vector3 Goal = Vector3.zero;
    float goalmoved = 0.0f;
    public float goal_move_time = 5.0f;
    void Start()
    {
        goalmoved = Time.time;
        for (int i = 0; i < NumBoids; i++)
        {
            Vector3 spawnpoint = new Vector3(Random.Range(-AreaSize, AreaSize), Random.Range(-AreaSize, AreaSize), Random.Range(-AreaSize, AreaSize));
            Boids[i] = (GameObject) Instantiate(Boidprefab, spawnpoint, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > goalmoved + goal_move_time)
        {
            Goal = new Vector3(Random.Range(-AreaSize, AreaSize), Random.Range(-AreaSize, AreaSize), Random.Range(-AreaSize, AreaSize));
            Goalmarker.transform.position = Goal;
            goalmoved = Time.time;
        }
    }
}
