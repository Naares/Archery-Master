using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject arrow;
    public int vellocity;
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
    }

    void clicked()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.Log(ray.origin.x);

        //send shooting ball 
        //Create spwan position
        //Instantinate
        GameObject instancedArrow = Instantiate(arrow);
        //cetner to player position - so we don't have to set it up in every level
        instancedArrow.transform.position = this.transform.position;
        Rigidbody2D instacedArrowRigidBody = instancedArrow.GetComponent<Rigidbody2D>();
        Vector2 force = new Vector2(this.transform.position.x * ray.origin.x * vellocity, this.transform.position.y * ray.origin.y * vellocity);
        Debug.Log("Force added : " + force);
        instacedArrowRigidBody.AddForce(force);
    }
}
