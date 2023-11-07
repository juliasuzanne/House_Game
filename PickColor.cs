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
    private UIManager _uiManager;
    private Hand player;
    private float posX;
    private float posY;
    // Start is called before the first frame update
    void Start()
    {

        sp = GetComponent<SpriteRenderer>();
        player = transform.GetComponent<Hand>();
        colorPanel.SetActive(false);
        _uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        Debug.Log("Blue: " + _uiManager.so.blue);
        redSlider.value = _uiManager.so.red;
        greenSlider.value = _uiManager.so.green;
        blueSlider.value = _uiManager.so.blue;

        Debug.Log("Sp color:" + sp.color);
        m_NewColor = new Color(_uiManager.so.red, _uiManager.so.blue, _uiManager.so.green);

        sp.color = m_NewColor;

    }

    void Update()
    {

        m_Red = redSlider.value;

        m_Blue = blueSlider.value;

        m_Green = greenSlider.value;

        m_NewColor = new Color(m_Red, m_Green, m_Blue);

        sp.color = m_NewColor;
        Debug.Log("Sp color:" + sp.color);

    }

    public void SetColor(float red_m, float green_m, float blue_m)
    {
        m_Blue = blue_m;
        m_Green = green_m;
        m_Red = red_m;
        Color newColor = new Color(red_m, green_m, blue_m);
        sp.color = new Color(red_m, green_m, blue_m);
    }


    public void ChangeColor()
    {
        colorPanel.SetActive(true);
        player.MoveableFalse();

    }

    public void ResumeGame()
    {
        player.MoveableTrue();
        _uiManager.SaveColor(m_Red, m_Green, m_Blue);
        _uiManager.SaveGame();
        colorPanel.SetActive(false);

    }

}
