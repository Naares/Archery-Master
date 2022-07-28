using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int numberOfArrows;
    public GameObject arrow;
    public int vellocity;
    public int enemiesRemaining;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clicked();
        }
        if(enemiesRemaining == 0)
        {
            showVictoryScreen();
        }
        if(numberOfArrows == 0)
        {
            showLoseScreen("Out of ammo");
        }
    }

    void clicked()
    {
        numberOfArrows--;
        var rayMouseClick = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //send shooting ball 
        //Create spwan position
        //Instantinate
        GameObject instancedArrow = Instantiate(arrow);
        //cetner to player position - so we don't have to set it up in every level
        instancedArrow.transform.position = this.transform.position;
        Rigidbody2D instacedArrowRigidBody = instancedArrow.GetComponent<Rigidbody2D>();
        Vector2 force = new Vector2(rayMouseClick.x * vellocity, rayMouseClick.y * vellocity);
        Debug.Log("Force added : " + force);
        instacedArrowRigidBody.AddForce(force);
    }

    void showLoseScreen(string reason)
    {
        Debug.Log("You lost : " + reason);
    }

    void showVictoryScreen()
    {
        Debug.Log("Victory");
    }
}
