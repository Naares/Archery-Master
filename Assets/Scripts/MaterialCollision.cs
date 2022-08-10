using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialCollision : MonoBehaviour
{
    public MateriallCollisionType collisionType = MateriallCollisionType.Void;
    public bool ShowParticles = false;
    public float TimeToDespawn = 5f;
    [HideInInspector] private bool despawnObject = false;
    [HideInInspector] private bool makeExplisionAnimation = false;
    public GameObject fireParticles;
     
    // Start is called before the first frame update
    void Start()
    {
        fireParticles.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (despawnObject)
        {
            if(TimeToDespawn < 0)
            {
                Destroy(this.gameObject);
            }
            else
            {
                TimeToDespawn -= Time.deltaTime;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision occured : " + collision.gameObject.name);
        if(collision.gameObject.name == "fireArrow(Clone)" && collisionType == MateriallCollisionType.Wood)
        {
            //Just Activate Particles on this object
            fireParticles.transform.position = collision.transform.position;
            fireParticles.SetActive(true);
            despawnObject = true;
        }
        if(collision.gameObject.name == "ExplosiveArrow" && collisionType == MateriallCollisionType.Wood || collisionType == MateriallCollisionType.Stone)
        {
            //Make a BOOM :)
        }
    }

    private void OnDestroy()
    {
        //turn the particles off just to be sure
        fireParticles.SetActive(false);
    }

    public enum MateriallCollisionType
    {
        Void,
        Stone,
        Wood
    }
}
