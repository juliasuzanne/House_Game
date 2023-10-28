using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed = 2f;
    private bool falling = false;
    private bool moveable = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void MoveableFalse()
    {
        moveable = false;
    }

    public void MoveableTrue()
    {
        moveable = true;
    }


    void PlatformerMove()
    {
        if (moveable == true)
        { rb.velocity = new Vector2(_moveSpeed * xInput, rb.velocity.y); }
        //keeping y velocity the same, but modifying
        else
        {
            Cursor.visible = true;

            Debug.Log("Hit Collider = " + hit.collider.name);
        }

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
