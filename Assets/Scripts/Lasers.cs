﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lasers : MonoBehaviour {

    private void Start()
    {
        
    }

    public void OnAnimationFinished()
    {
        Destroy(this.gameObject);
    }
}
