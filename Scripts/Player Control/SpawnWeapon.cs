﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWeapon : MonoBehaviour
{
    public Vector3 center;
    public Vector3 size;

    public GameObject healthOrb;

    public float hpSpawnRate = 5f;
    public int hpSpawnLimit = 2;
    public int hpSpawnAmount = 0;
    public float hpSpawnChance;

    float hpNum;
    float nextSpawn = 0f;
    float nextHpSpawn = 0f;
    int whatToSpawn;

    // Update is called once per frame
    void Update()
    {
        //spawning weaping manually
        if(Input.GetKeyDown(KeyCode.O))
        {
            Spawn();
        }


        hpNum = Random.Range(1, 101);
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));

        if (hpNum < hpSpawnChance && hpSpawnAmount < hpSpawnLimit && Time.time > nextHpSpawn)
        {
            Instantiate(healthOrb, pos, Quaternion.identity);
            hpSpawnAmount++;
            nextHpSpawn = Time.time + hpSpawnRate;
        }

        
    }

    // manual spawn
    void Spawn()
    {
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
        Instantiate(healthOrb, pos, Quaternion.identity);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(center, size);
        
    }
}
