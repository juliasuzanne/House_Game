using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickColor : MonoBehaviour
{
    private SpriteRenderer sp;
    private Color newColor;
    // Start is called before the first frame update
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        sp.color = Color.blue;

    }

}
