using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakePencil : MonoBehaviour
{
    private UsePaper paper;
    // Start is called before the first frame update
    void Start()
    {
        paper = GameObject.Find("paper").GetComponent<UsePaper>();
    }

    void OnMouseDown()
    {
        Debug.Log("Mouse clicked on pencil");
        paper.TookPencil();
        Destroy(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
