﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 0.5f;
    float rotationSpeed = 4.0f;
    Vector3 averageHeading;
    Vector3 averagePosition;
    float detectionDistance = 13.0f;
    void Start()
    {
        speed = Random.Range(0.5f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        ApplyRules();
        transform.Translate(0, 0, Time.deltaTime * speed);
    }

    void ApplyRules() {
        GameObject[] Boids = BoidManager.Boids;
        Vector3 toCenter = Vector3.zero;
        Vector3 toAvoid = Vector3.zero;
        Vector3 toGoal = BoidManager.Goal;
        float groupSpeed = 0.1f;
        int groupSize = 0;
        float dist;

        foreach (GameObject boid in Boids) {
            if (boid != this.gameObject) {
                dist = Vector3.Distance(boid.transform.position, this.transform.position);
                if (dist <= detectionDistance) {
                    toCenter += boid.transform.position;
                    groupSize++;
                    if (dist < 1.0f) {
                        toAvoid = toAvoid + (this.transform.position - boid.transform.position);
                    }

                    Boid anotherBoid = boid.GetComponent<Boid>();
                    groupSpeed += anotherBoid.speed;
                }
            }
        }

        if (groupSize > 0) {
            toCenter = toCenter / groupSize + (toGoal - this.transform.position);
            speed = groupSpeed / groupSize;

            Vector3 direction = (toCenter + toAvoid) - transform.position;
            if (direction != Vector3.zero)
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
        }
    
    }
}
