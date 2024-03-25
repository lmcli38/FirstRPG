using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_StatButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private UI ui;
    public bool unlocked;
    
    public int healthChangeAmount = 20;
    public int damageChangeAmount = 10;

    [SerializeField] private string statName;
    [TextArea]
    [SerializeField] private string statDescription;

    [SerializeField] private UI_StatButton[] shouldBeUnLocked;
    [SerializeField] private UI_StatButton[] shouldBeLocked;
    [SerializeField] private Image skillImage;

    private void Start()
    {
        skillImage = GetComponent<Image>();
        ui = GetComponentInParent<UI>();
        
        skillImage.color = Color.red;

        GetComponent<Button>().onClick.AddListener(() => Unlock());

    }
    public void Unlock()
    {
        for (int i = 0; i < shouldBeUnLocked.Length; i++)
        {
            if (shouldBeUnLocked[i].unlocked == false)
            {
                Debug.Log("Cannot unlock skill");
                return;
            }
        }

        for (int i = 0; i < shouldBeLocked.Length; i++)
        {
            if (shouldBeLocked[i].unlocked == true)
            {
                Debug.Log("can't unlocek skill");
                return;
            }
        }

        unlocked = true;
        skillImage.color = Color.green;

        if (statName == "Health")
            ModifiyHealth();
        else if (statName == "Damage")
            Modifiydamage();

        GetComponent<Button>().interactable = false;
    }

    public void ModifiyHealth()
    {
        PlayerStat playerStats = PlayerManager.instance.player.GetComponent<PlayerStat>();
        if (unlocked)
        {
            playerStats.maxhealth.AddModifier(healthChangeAmount);
            Debug.Log("max health moifiy:" + healthChangeAmount);   
        }  
    }
    
    public void Modifiydamage()
    {
        PlayerStat playerStats = PlayerManager.instance.player.GetComponent<PlayerStat>();
        if (unlocked)
            playerStats.damage.AddModifier(damageChangeAmount);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ui.statToolTip.ShowToolTip(statDescription, statName);
        Vector2 mousePosition = Input.mousePosition;

        float xOffset = 0;
        float yOffset = 0;
        if (mousePosition.x > 600)
            xOffset = -150;
        else
            xOffset = 150;

        if (mousePosition.y > 320)
            yOffset = -150;
        else
            xOffset = 150;
        ui.statToolTip.transform.position = new Vector2(mousePosition.x + xOffset, mousePosition.y+ yOffset);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ui.statToolTip.HideToolTip();
    }
}
