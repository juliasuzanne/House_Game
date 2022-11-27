using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject item;
    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void SpawnItem() {
        Vector2 playerPos = new Vector2(player.position.x + 1, player.position.y);
        Instantiate(item, playerPos, Quaternion.identity);
    }
}
