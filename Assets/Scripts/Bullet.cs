using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private bool hit;
    public float hitCheckRadious;
    public LayerMask WhatCanHit;
    public Transform hitCheck;

    private void FixedUpdate()
    {
        hit = Physics2D.OverlapCircle(hitCheck.position, hitCheckRadious, WhatCanHit);

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //destroy bullet when hit sth
        if(hit)
        {
            Destroy(gameObject);
            
        }
    }
}
