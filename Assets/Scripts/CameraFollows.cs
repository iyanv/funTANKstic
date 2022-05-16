using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollows : MonoBehaviour
{
    public Transform player;
    public float smoothing; // Following speed

    private Vector3 offset; // Initial distance from camera & player
    
    void Start()
    {
        offset = transform.position - player.position;
    }
    
    void FixedUpdate()
    {
        // Where do I want camera to be
        Vector3 targetCamPos = player.position + offset;
        
        // Moves smoothly from (transform.position) to (targetCamPos) at (Smoothing*Time.deltaTime) speed
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}
