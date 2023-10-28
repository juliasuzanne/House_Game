using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed = 1f;
    private bool falling = false;
    // Start is called before the first frame update
    void Start()
    {

    }


    public void ChangeFallingBool()
    {
        if (falling == true)
        {
            falling = false;
        }
        else
        {
            falling = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (falling == true)
        {

            transform.Translate(Vector3.down * _moveSpeed * Time.deltaTime);

        }
    }
}
