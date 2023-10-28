using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talk : MonoBehaviour
{
    private Hand player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform.GetComponent<Hand>();

    }

    public void ResumeGame()
    {
        player.ChangeFallingBool();
        transform.gameObject.SetActive(false);

    }


    // Update is called once per frame
    void Update()
    {

    }
}
