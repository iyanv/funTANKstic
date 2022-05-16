using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   [Header("Attack Values")]
   public GameObject ownBullet;
   public Transform bulletSpot;
   
   [Header ("Movement Related Values")]
   public int speed;
   public LayerMask groundLayer;
   
   private Rigidbody rb;

   private Vector3 movement;
   private float vertical;
   private void Start()
   {
      rb = GetComponent<Rigidbody>();
   }

   private void Update()
   {
      vertical = Input.GetAxis("Vertical1");
      
      // Launch a bullet when mouse clicked
      if(Input.GetMouseButtonDown(0))
      {
         Instantiate(ownBullet, bulletSpot.position, bulletSpot.rotation);
      }
   }

   private void FixedUpdate()
   {
      Move();
      Turning();
   }

   void Move() // To make more accurate "Tank" movement without weird wheel rotation
   {
      if (Input.GetKey("w"))
      {
         transform.Translate(Vector3.forward * speed * Time.deltaTime);
      }

      if (Input.GetKey("s"))
      {
         transform.Translate(-Vector3.forward * speed * Time.deltaTime);
      }
   }
   
   void Turning()
   {
      // Creating (NOT activating) a raycast from camera to mouse position
      Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
      RaycastHit hit;
        
      // Activating the raycast
      if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
      {
         // Creating a Vector from player to mouse position hit point from raycast
         Vector3 playerToMouse = hit.point - transform.position;
         playerToMouse.y = 0; // To avoid undesired/wrong axis turns 
            
         // Z axis of the character is aligned to the mouse position
         Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
         rb.MoveRotation(newRotation);
      }
      // We make the ray visual in red color
      Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
   }
}
