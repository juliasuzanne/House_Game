using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickColor : MonoBehaviour
{
    private SpriteRenderer sp;
    private Color m_NewColor;
    float m_Red, m_Blue, m_Green;

    [SerializeField]
    private GameObject colorPanel;

    [SerializeField]
    private Slider redSlider;


    [SerializeField]
    private Slider blueSlider;


    [SerializeField]
    private Slider greenSlider;
    private Player player;
    // Start is called before the first frame update
    void Start()
    {

        sp = GetComponent<SpriteRenderer>();
        sp.color = Color.yellow;
        player = transform.GetComponent<Player>();
        colorPanel.SetActive(false);

    }

    void Update()
    {
        m_Red = redSlider.value;

        m_Blue = blueSlider.value;

        m_Green = greenSlider.value;
        m_NewColor = new Color(m_Red, m_Green, m_Blue);
        sp.color = m_NewColor;



    }
    public void ChangeColor()
    {

        colorPanel.SetActive(true);
        player.MoveableFalse();

        //Set the Color to the values gained from the Sliders

        //Set the SpriteRenderer to the Color defined by the Sliders
    }

    public void ResumeGame()
    {
        player.MoveableTrue();
        colorPanel.SetActive(false);

    }

}
