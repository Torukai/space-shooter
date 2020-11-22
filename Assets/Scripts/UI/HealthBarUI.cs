using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HealthBarUI : MonoBehaviour
{
    public Player player;
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public BarType type;
    public Text text;

    public enum BarType
	{
        Health,
        Shield
	}

    public void SetMaxHealth(float health)
	{
        slider.maxValue = health;
        slider.value = health;
        fill.color = gradient.Evaluate(1f);
	}

    public void SetHealth(float health)
	{
        slider.value = health;
        text.text = health.ToString();
        fill.color = gradient.Evaluate(slider.normalizedValue);
	}

    // Start is called before the first frame update
    void Start()
    {
        if (type == BarType.Health)
		{
            slider.maxValue = player.health;
            slider.value = player.health;
        } else if (type == BarType.Shield)
		{
            slider.maxValue = player.shield;
            slider.value = player.shield;
        }

        fill.color = gradient.Evaluate(1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (type == BarType.Health)
        {
            SetHealth(player.health);
        }
        else if (type == BarType.Shield)
        {
            SetHealth(player.shield);
        }

        text.text = ((float)Math.Round(slider.value, 0)).ToString();
    }
}
