using UnityEngine;

public enum EquipmentType
{
    Effect,
    Modifier,

}

[CreateAssetMenu(fileName = "New Item data", menuName = "Data/BuffEffect_Item")]



public class ItemData_Equipment : ItemData
{
    public EquipmentType equipmentType;

    [Header("Unique effect")]
    public float itemCooldown;
    public ItemEffect[] itemEffects;
    public Modification[] modifications;

    [TextArea]
    public string itemEffectDescription;


    [Header("Major Stats")]
    public int strength; // crit power
    public int agility; // crit chance
    public int intelligence; // magic damage
    public int vitality; // increase health

    [Header("Defensive stats")]
    public int maxhealth;
    public int armor;
    public int evasion;
    public int magicResist;

    [Header("Offensive Stats")]
    public int damage;
    public int critChance;
    public int critPower;

    [Header("Magic Stats")]
    public int fireDamage;
    public int iceDamage;
    public int lightingDamage;


    int minDescriptionLength;
    Player player;
    public void Effect(Transform _enemyPosition)
    {
        foreach (var item in itemEffects) 
        {
            item.ExecuteEffect(_enemyPosition);
        }
    }
    public void AddModifier()
    {
        PlayerStat playerStats = PlayerManager.instance.player.GetComponent<PlayerStat>();
        
        playerStats.strength.AddModifier(strength);
        playerStats.agility.AddModifier(agility);
        playerStats.intelligence.AddModifier(intelligence);
        playerStats.vitality.AddModifier(vitality);

        playerStats.damage.AddModifier(damage);
        playerStats.critChance.AddModifier(critChance);
        playerStats.critPower.AddModifier(critPower);

        playerStats.armor.AddModifier(armor);
        playerStats.magicResist.AddModifier(magicResist);
        playerStats.maxhealth.AddModifier(maxhealth);
        playerStats.evasion.AddModifier(evasion);

        playerStats.fireDamage.AddModifier(fireDamage);
        playerStats.iceDamage.AddModifier(iceDamage);
        playerStats.lightingDamage.AddModifier(lightingDamage);


    }
    /*
    public void ApplyModifications(GameObject gameObject)
    {
        foreach (var mod in modifications)
        {
            if(mod != null)
                mod.ApplyModification(gameObject);
        }
    }*/
    public void RemoveModifier()
    {
        PlayerStat playerStats = PlayerManager.instance.player.GetComponent<PlayerStat>();
        
        playerStats.strength.RemoveModifier(strength);
        playerStats.agility.RemoveModifier(agility);
        playerStats.intelligence.RemoveModifier(intelligence);
        playerStats.vitality.RemoveModifier(vitality);

        playerStats.damage.RemoveModifier(damage);
        playerStats.critChance.RemoveModifier(critChance);
        playerStats.critPower.RemoveModifier(critPower);

        playerStats.armor.RemoveModifier(armor);
        playerStats.magicResist.RemoveModifier(magicResist);
        playerStats.maxhealth.RemoveModifier(maxhealth);
        playerStats.evasion.RemoveModifier(evasion);

        playerStats.fireDamage.RemoveModifier(fireDamage);
        playerStats.iceDamage.RemoveModifier(iceDamage);
        playerStats.lightingDamage.RemoveModifier(lightingDamage);
    }


    public override string GetDescription()
    {
        sb.Length = 0;
        minDescriptionLength = 0;

        AddItemDescription(strength, "Strength");
        AddItemDescription(agility, "Agility");
        AddItemDescription(intelligence, "intelligence");
        AddItemDescription(vitality, "vitality");

        AddItemDescription(damage, "Damage");
        AddItemDescription(critChance, "CritChance");
        AddItemDescription(critPower, "critPower");

        AddItemDescription(maxhealth, "health");
        AddItemDescription(evasion, "evasion");
        AddItemDescription(armor, "armor");
        AddItemDescription(magicResist, "magicResist");

        AddItemDescription(fireDamage, "fire Damage");
        AddItemDescription(iceDamage, "Ice Damage");
        AddItemDescription(lightingDamage, "light Damage");

        if(minDescriptionLength < 5)
        {
            for(int i = 0; i < 5 - minDescriptionLength; i++) 
            {
                sb.AppendLine();
                sb.Append("");
            }
        }

        if(itemEffectDescription.Length > 0)
        {
            sb.AppendLine();
            sb.Append(itemEffectDescription);
        }
        return sb.ToString();
    }

    private void AddItemDescription(int _value, string _name)
    {
        if(_value !=0)
        {
            if(sb.Length > 0)
            {
                sb.AppendLine();
            }
            if(_value>0)
            {
                sb.Append("+ " + _value + " " + _name);
            }
            minDescriptionLength++;
        }
    }

}
