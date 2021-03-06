﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBulletGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public BulletPool BulletPool;
    private GameObject _bullet;
    GameObject bulletParticle;

    [ColorUsage(true, true), SerializeField] private Color _straightColor;
    [ColorUsage(true, true), SerializeField] private Color _homingColor;
    [ColorUsage(true, true)] private Color particleColor;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            _bullet = BulletPool.GetInstance(new Homing());
            Homing homing = _bullet.GetComponent<BulletObject>().bulletclass as Homing;
            homing.Velocity = 6f;
            homing.HomingStrength = 1f;
            homing.Target = GameObject.Find("Target");
            homing.AttackPoint = 10f;

            particleColor = _homingColor;
            Generate();
        }else if(Input.GetKeyDown(KeyCode.LeftShift)){
            _bullet = BulletPool.GetInstance(new Straight());
            Straight straight = _bullet.GetComponent<BulletObject>().bulletclass as Straight;
            straight.Velocity = 12f + Random.Range(-4f, 4f);
            straight.AttackPoint = 10f;

            particleColor = _straightColor;
            Generate();
        }
        
    }

    void Generate(){
        float x = Random.Range(-7f, 7f);
        float y = Random.Range(-7f, 7f);
        float z = Random.Range(-7f, 7f);

        _bullet.transform.position = new Vector3(x, y, 20 + z);
        _bullet.transform.rotation = transform.rotation;
        bulletParticle = _bullet.transform.GetChild(0).gameObject;
        

        //randomHDR = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);
        bulletParticle.GetComponent<Renderer>().material.SetColor("_EmissionColor", particleColor);

    }
}
