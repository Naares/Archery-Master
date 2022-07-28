using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.GetComponent<PlayerController>().enemiesRemaining --;
        Destroy(collision);
        Destroy(this.gameObject);
    }
}
