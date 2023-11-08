using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplySavedColorToSp : MonoBehaviour
{
    private UIManager _uiManager;
    private SpriteRenderer sp;
    private Color m_NewColor;

    // Start is called before the first frame update
    void Start()
    {

        _uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        sp = GetComponent<SpriteRenderer>();
        m_NewColor = new Color(_uiManager.so.red, _uiManager.so.green, _uiManager.so.blue, 1);
        sp.color = m_NewColor;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
