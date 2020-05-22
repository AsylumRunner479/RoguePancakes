﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float damage, range, attackSpeed, attackRate;
    public Camera cam;
    public LayerMask enemy;
    public ParticleSystem bullets;

    // Update is called once per frame
    void Update()
    {
        attackSpeed += Time.deltaTime;
        if (Input.GetMouseButton(0) && attackSpeed > 0)
        {
            attackSpeed = -3f / attackRate;
            Shoot();
            bullets.Emit(1);

        }
    }
    private void OnParticleCollision(GameObject other)
    {
        //EnemyAI enemy = other.transform.GetComponent<EnemyAI>();
        Material skin = other.transform.GetComponent<Material>();
        
            //enemy.TakeDamage(damage);
            //skin.SetFloat("Damaged", enemy.curHealth);
        
    }
    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            //EnemyAI enemy = hit.transform.GetComponent<EnemyAI>();
            Material skin = hit.transform.GetComponent<Material>();
            
                //enemy.TakeDamage(damage);
                //skin.SetFloat("Damaged", enemy.curHealth);
            
        }
    }
}