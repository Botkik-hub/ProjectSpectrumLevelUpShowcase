using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
	private float time;
    private bool m_IsRunning;
    [SerializeField] private float startTime;
    [SerializeField] private bool m_IsInverted = false;
	[SerializeField] private float m_Multiplier = 1.0f;
	private float m_SlowTime = 0;

	void Start()
	{
		Reset();
	}

	void Update()
	{
		if (!m_IsRunning) return;

		if (m_IsInverted && time > 0)
		{
			time -= Time.deltaTime * m_Multiplier;
			if (time <= 0)
			{
				time = 0;
				m_IsRunning = false;
			}
		}
		else
		{
			time += Time.deltaTime * m_Multiplier;
		}
		if(m_SlowTime > 0)
		{
			m_SlowTime -= Time.deltaTime;
			if(m_SlowTime <= 0)
			{
				m_Multiplier = 1.0f;
			}
		}
	}

	public void Reset()
	{
		time = startTime;
		m_IsRunning = false;
		m_Multiplier = 1.0f;
	}

	public void ToggleTimer()
	{
		m_IsRunning = !m_IsRunning;
	}

	public void ModifyMultiplier(float multiplier, float time)
	{
		m_Multiplier = multiplier;
		m_SlowTime = time;
	}

	public void ModifyMultiplier3s(float multiplier)
	{
		m_Multiplier = multiplier;
		m_SlowTime = 3;
	}

	public float GetTime() { return time; }
	public float GetStartTime() { return startTime; }
	public bool IsRunning() { return m_IsRunning; }
}