﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordControllerV2 : MonoBehaviour
{

    public Animator anim;
    public GameObject swordTip;
    public int speed = 1;
    public float rotSpeed = 0.5f;
    public bool inAir = false;
    public float moveTimer;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
            transform.position = mousePos;
        Vector2 swordTipPos = swordTip.transform.position;
        Vector2 swordPos = transform.position;
        Vector2 vectorToTarget = mousePos - swordTipPos;

        float swordToMouseAngle = (Mathf.Atan2(-vectorToTarget.y, -vectorToTarget.x) * Mathf.Rad2Deg) - 90 + 45;


        if (Input.GetMouseButton(0))
        {
            float t = vectorToTarget.magnitude * 3 / rotSpeed;
            Quaternion oldRotation = transform.rotation;
            Quaternion newRotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(swordToMouseAngle, Vector3.forward), t); //rotation towards where the cursor is

            transform.rotation = newRotation;

            if (vectorToTarget.magnitude > 1f)
            {
                inAir = true;
                moveTimer = 1.5f;
                anim.SetBool("Swing", true);
            }
            else
            {
                anim.SetBool("Swing", false);
            }
        }
        else if (inAir == true)
        {
            anim.SetBool("Swing", false);
            float t = 0.1f;
            if (moveTimer > 1f)
            {
                moveTimer -= Time.deltaTime;
                transform.position = Vector2.Lerp(swordPos, mousePos, t);
            }
            else
            {
                inAir = false;
            }

            t = vectorToTarget.magnitude / rotSpeed;
            Quaternion oldRotation = transform.rotation;
            Quaternion newRotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(swordToMouseAngle, Vector3.forward), t); //rotation towards where the cursor is

            transform.rotation = newRotation;

            
        }
    }
}
