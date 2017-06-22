using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour {

    public Animator anim;
    public GameObject swordTip;
    public int speed = 1;
    public float rotSpeed = 0.5f;

    void Start()
    {
        
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
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

           // anim.SetBool("Swing", true);
        }
        else
        {
            float t = 0.1f;
            if (vectorToTarget.magnitude > 0.35f)
                transform.position = Vector2.Lerp(swordPos, mousePos, t);

            t = vectorToTarget.magnitude / rotSpeed;
            Quaternion oldRotation = transform.rotation;
            Quaternion newRotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(swordToMouseAngle, Vector3.forward), t); //rotation towards where the cursor is

            transform.rotation = newRotation;


            if (newRotation.z - oldRotation.z > 0)
            {
                //    anim.SetBool("flip", true);
            }
            else
            {
                //    anim.SetBool("flip", false);
            }
        }
    }
}
