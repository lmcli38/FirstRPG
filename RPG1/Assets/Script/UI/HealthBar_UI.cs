using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar_UI : MonoBehaviour
{
    private Entity entity => GetComponentInParent<Entity>();
    private CharacterStats myStats => GetComponentInParent<CharacterStats>();
    private RectTransform myTransform;
    private Slider slider;
    private void Start()
    {
        myTransform = GetComponent<RectTransform>();
        slider= GetComponentInChildren<Slider>();

        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        slider.maxValue = myStats.GetMaxHealthValue();
        slider.value = myStats.currentHealth;
    }

    void FlipUI()
    {
        myTransform.Rotate(0, 180, 0);
    }

    private void OnEnable()
    {
        entity.onFlipped += FlipUI;
        myStats.onHealthChanged += UpdateHealthBar;    
    }
    void OnDisable()
    {
        if (entity != null)
            entity.onFlipped -= FlipUI;

        if(myStats != null)
            myStats.onHealthChanged -= UpdateHealthBar;
    }
}
