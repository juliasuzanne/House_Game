using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3f;

    private Hand _player;

    //ID for powerups to make script modular
    //0 = Triple Shot
    //1 = Speed
    //2 = Shields
    [SerializeField]
    private int _powerupID;
    [SerializeField]


    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Hand>();

        if (_player == null)
        {
            Debug.LogError("The player is NULL");
        }


    }

    // Update is called once per frame
    void Update()
    {
        //move down at a speed of 3
        //will not be reused
        //when we leave the screen, destroy this object
        transform.Translate(new Vector3(0, _speed, 0) * Time.deltaTime);

        if (transform.position.y > 8)
        {
            //
            Destroy(this.gameObject);
        }
    }

    //check for collisions
    //OnTriggerCollison2D
    //use tages to collect by player only
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            switch (_powerupID)
            {
                case 0:
                    Destroy(this.gameObject);
                    break;
                case 1:
                    Destroy(this.gameObject);
                    break;
                case 2:
                    Destroy(this.gameObject);
                    break;
            }

        }
    }
}
