using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public int hp = 100;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Sword")
        {
            TakeDamage();
        }
    }

    void TakeDamage()
    {
        hp -= 50;
    }
}
