﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Splash : MonoBehaviour
{
    private void Awake()
    {
        int numMusicPlayers = FindObjectsOfType<Splash>().Length;
        if (numMusicPlayers > 1)
        {
            Destroy(gameObject);
        }

        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
   
}
