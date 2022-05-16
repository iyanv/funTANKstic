using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    private int speed = 25;

    private void Start()
    {
        Destroy(gameObject, 3f);
    }

    void Update()
    {
        transform.Translate(speed * Vector3.forward * Time.deltaTime);
    }
    
    void OnTriggerEnter(Collider other)
    {
        // Explosion animation pending
        Destroy(this.gameObject);
    }
}
