using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Tooltip("FX prefab on Enemies")] [SerializeField] GameObject EnemyDeathFX;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 10;
    [SerializeField] int health = 5;

    ScoreBoard scoreBoard;

    // Start is called before the first frame update
    void Start()
    {
        AddBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void AddBoxCollider()
    {
        Collider bc = gameObject.AddComponent<BoxCollider>();
        bc.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        // add hit FX
        health--;
        scoreBoard.ScoreHit(scorePerHit);
        if (health <= 0)
        {
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        GameObject fx = Instantiate(EnemyDeathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
