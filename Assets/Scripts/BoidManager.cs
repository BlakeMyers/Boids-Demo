using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BoidManager : MonoBehaviour
{

    public GameObject Boidprefab;
    public GameObject Goalmarker;
    static int NumBoids = 5;
    public static int AreaSize = 10;
    public static GameObject[] Boids = new GameObject[NumBoids];
    public static Vector3 Goal = Vector3.zero;
    float goalmoved = 0.0f;
    public float goal_move_time = 5.0f;
    bool Circletree = false;
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
        if (!Circletree)
        {
            if (Time.time > goalmoved + goal_move_time)
            {
                Goal = new Vector3(Random.Range(-AreaSize + 3, AreaSize - 3), Random.Range(-AreaSize + 3, AreaSize - 3), Random.Range(-AreaSize + 3, AreaSize - 3));
                Goalmarker.transform.position = Goal;
                goalmoved = Time.time;
            }
        }
        else {
            Goal = new Vector3(0,0,0);
            Goalmarker.transform.position = Goal;
        }
    }

   public void toggleMode() {
        if (Circletree)
        {
            Circletree = false;
        }
        else
        {
            Circletree = true;
        }
    
    }
}
