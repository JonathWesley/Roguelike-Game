﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeShooting : MonoBehaviour
{
    public GameObject projectile;
    private GameObject player;
    public float minDamage;
    public float maxDamage;
    public float projectileForce;
    public float cooldown;

    void Start()
    {
        StartCoroutine(ShootPlayer());
        player = FindObjectOfType<PlayerMovement>().gameObject;
    }

    IEnumerator ShootPlayer()
    {
        yield return new WaitForSeconds(cooldown);
        if (player != null)
        {
            GameObject attack = Instantiate(projectile, transform.position, Quaternion.identity);
            Vector2 myPos = transform.position;
            Vector2 targetPos = player.transform.position;
            Vector2 direction = (targetPos - myPos).normalized;
            attack.GetComponent<Rigidbody2D>().velocity = direction * projectileForce;
            attack.GetComponent<SlimeProjectile>().damage = Random.Range(minDamage, maxDamage);
            StartCoroutine(ShootPlayer());
        }
    }
}
