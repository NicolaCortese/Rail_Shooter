using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    
    [Tooltip("Seconds")] [SerializeField] float levelLoadDelay = 2f;
    [Tooltip("FX prefab on player")] [SerializeField] GameObject deathFX;
    

    // Start is called before the first frame update
    void Start()
    {
      

    }
    void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
        
    }

    public void StartDeathSequence()
    {
        SendMessage("DeathSequence");
        
        deathFX.SetActive(true);

        Invoke("Respawn", levelLoadDelay);
    }

    private void Respawn()
    {
        SceneManager.LoadScene(1);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
