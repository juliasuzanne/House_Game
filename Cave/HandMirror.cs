using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandMirror : MonoBehaviour
{
    private Image im;
    private Color m_NewColor;
    float m_Red, m_Blue, m_Green;

    [SerializeField]
    private Slider redSlider;

    private Hand _playerScript;
    [SerializeField]
    private Slider blueSlider;


    [SerializeField]
    private Slider greenSlider;
    // Start is called before the first frame update
    void Start()
    {
        im = transform.GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {
        m_Red = redSlider.value;

        m_Blue = blueSlider.value;

        m_Green = greenSlider.value;

        m_NewColor = new Color(m_Red, m_Green, m_Blue);

        im.color = m_NewColor;
    }
}
