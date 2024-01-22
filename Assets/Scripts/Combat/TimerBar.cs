using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerBar : MonoBehaviour
{
    private bool m_IsRunning;
    [SerializeField] private Timer m_Timer;
    [SerializeField] private Slider m_Slider;
    [SerializeField] private TMP_Text m_Text;
    [SerializeField] private Image m_Image;
    [SerializeField] private Sprite m_PlayImage;
    [SerializeField] private Sprite m_PauseImage;
    [SerializeField] List<Color> m_Colors;
    Gradient m_Gradient = new Gradient();

    // Start is called before the first frame update
    void Start()
    {
        m_IsRunning = m_Timer.IsRunning();
        m_Image.sprite = m_IsRunning ? m_PlayImage: m_PauseImage;

        if (m_Slider)
        {
            m_Slider.maxValue = m_Timer.GetStartTime();
            m_Slider.value = m_Timer.GetStartTime();
        }
        SetGradient(m_Colors);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_IsRunning != m_Timer.IsRunning())
        {
            m_IsRunning = m_Timer.IsRunning();
            if(!m_IsRunning)
            {
                m_Image.sprite = m_PauseImage;
                return;
            }
            m_Image.sprite = m_PlayImage;

        }
        if (m_Text)
        {
            m_Text.text = "Time: " + m_Timer.GetTime().ToString("F");
        }

        if (m_Slider)
        {
            m_Slider.value = m_Timer.GetTime();
            m_Slider.fillRect.GetComponent<Image>().color = m_Gradient.Evaluate(m_Slider.value / m_Slider.maxValue);
        }
    }

    void SetGradient(List<Color> colors)
    {
        int numColors = colors.Count;
        GradientColorKey[] colorKey = new GradientColorKey[numColors];

        for (int i = 0; i < numColors; i++)
        {
            colorKey[i].color = colors[i];
            colorKey[i].time = (float)i / (numColors - 1);
        }

        m_Gradient.colorKeys = colorKey;
    }
}
