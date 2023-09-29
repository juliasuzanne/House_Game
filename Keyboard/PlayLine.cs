using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayLine : MonoBehaviour
{

    [SerializeField]
    private float _speed = 1f;
    private bool _isMoving = false;
    // Start is called before the first frame update
    void Update()
    {
        if (_isMoving == true)
        {
            transform.Translate(new Vector3(0, (_speed), 0) * Time.deltaTime);
            if (transform.position.x > 9f)
            {
                _isMoving = false;
                transform.position = new Vector3(-8.16f, 3.71f, 0);


            }
        }
    }

    // Update is called once per frame
    void OnMouseDown()
    {
        Debug.Log("Mouse Down on play");
        _isMoving = true;



    }
}
