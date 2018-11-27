using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 12;
    [SerializeField] int hits = 3;

    Scoreboard scoreBoard;

	// Use this for initialization
	void Start()
    {
        AddNonTriggerBoxCollider();
        scoreBoard = FindObjectOfType<Scoreboard>();
	}

    private void AddNonTriggerBoxCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHits();
        if (hits < 1)
        {
            KillEnemy();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        KillEnemy();
    }

    private void ProcessHits()
    {
        scoreBoard.ScoreHit(scorePerHit);
        hits--;
        // TODO consider hit FX
    }

    private void KillEnemy()
    {
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
