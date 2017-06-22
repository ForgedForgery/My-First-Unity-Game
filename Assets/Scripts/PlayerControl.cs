using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    public Transform heroTransform;
    public Animator heroAnim;

    float heroPosX;
    float heroPosY;

    float maxEdge = 2/0.75f;

    private void Awake()
    {
       // Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Use this for initialization
    void Update() {

        UpdateHeroPos();

        if (Input.GetMouseButton(1))
        {
            RightClickCam();
        }
        else
        {
            NormalCam();
        }

    }

    private void RightClickCam()
    {
        Vector2 heroToCamPos = new Vector2();

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 newHeroPos = new Vector2(heroPosX, heroPosY);

        heroToCamPos = ((mousePos - newHeroPos) / 2);

        //move cam
        if (heroToCamPos.x < maxEdge && heroToCamPos.x > -maxEdge) {
            transform.position =
                Vector3.Lerp(transform.position, new Vector3(heroToCamPos.x * 0.75f + heroPosX, transform.position.y, -1), 0.1f);
             //   new Vector3(heroToCamPos.x*0.75f + heroPosX, transform.position.y, -1);
        }

        if (heroToCamPos.y < maxEdge && heroToCamPos.y > -maxEdge)
        {
            transform.position =
                Vector3.Lerp(transform.position, new Vector3(transform.position.x, heroToCamPos.y * 0.75f + heroPosY, -1), 0.1f);
                // new Vector3(transform.position.x, heroToCamPos.y*0.75f + heroPosY, -1);

        }


        ResetAnim(0, 0);
        //face hero to cam
        if (transform.position.x > heroTransform.position.x && Mathf.Abs(heroToCamPos.x) > Mathf.Abs(heroToCamPos.y))
        {
            heroAnim.SetFloat("input_x", 1);
        }
        else if (transform.position.x < heroTransform.position.x && Mathf.Abs(heroToCamPos.x) > Mathf.Abs(heroToCamPos.y))
        {
            heroAnim.SetFloat("input_x", -1);
        }
        if (transform.position.y > heroTransform.position.y && Mathf.Abs(heroToCamPos.y) > Mathf.Abs(heroToCamPos.x))
        {
            heroAnim.SetFloat("input_y", 1);
        }
        else if (transform.position.y < heroTransform.position.y && Mathf.Abs(heroToCamPos.y) > Mathf.Abs(heroToCamPos.x))
        {
            heroAnim.SetFloat("input_y", -1);
        }
    }

    void NormalCam()
    {
     //   transform.position =
      //       new Vector3(heroPosX, heroPosY, -1);

        transform.position =
            Vector3.Lerp(transform.position, new Vector3(heroPosX, heroPosY, -1), 0.1f);


        Vector2 movement_vec = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (movement_vec != Vector2.zero)
        {
            heroAnim.SetFloat("input_x", movement_vec.x);
            heroAnim.SetFloat("input_y", movement_vec.y);
        }
    }

    void UpdateHeroPos()
    {
        heroPosX = heroTransform.position.x + 0.32f;
        heroPosY = heroTransform.position.y - 0.32f;
    }

    void ResetAnim(float setX, float setY)
    {
        heroAnim.SetFloat("input_x", setX);
        heroAnim.SetFloat("input_y", setY);
    }
}
