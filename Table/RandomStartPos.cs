using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomStartPos : MonoBehaviour
{
    [SerializeField]
    private float posX;

    [SerializeField]
    private float posY;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(5f, Random.Range(0f, 10f), 0);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
