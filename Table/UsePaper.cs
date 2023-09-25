using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsePaper : MonoBehaviour
{

    private bool pencil = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnMouseDown()
    {
        if (pencil == true)
        {
            Debug.Log("Going To Draw");
        }
    }

    public void TookPencil()
    {
        pencil = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
