using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    public Transform bulletSpawn;
    public GameObject bullet;
    private GameObject newBullet;
    public float bulletSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(bulletSpawn.position.x < GetComponent<Rigidbody2D>().position.x)
            {
                newBullet = Instantiate(bullet, new Vector2(bulletSpawn.position.x - 0.5f,bulletSpawn.position.y) , bulletSpawn.rotation);
                newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-bulletSpeed,0);

            }
            else
            {
                newBullet = Instantiate(bullet, new Vector2(bulletSpawn.position.x + 0.5f, bulletSpawn.position.y), bulletSpawn.rotation);
                newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed, 0);
            }
            


        }
    }
}
