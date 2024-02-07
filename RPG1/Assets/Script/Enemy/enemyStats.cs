using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyStats : CharacterStats
{
    private enemy enemy_00;
    private ItemDrop myDropSystem;
    public Stat soulsDropAmount;

    [Header("Level details")]
    [SerializeField] private int level = 1;
    

    [Range(0f, 1f)]
    [SerializeField] private float percentageModifier = 0.3f;

    protected override void Start()
    {
        soulsDropAmount.SetDefaultValue(10);
        ApplyLevelModifiers();

        base.Start();

        enemy_00 = GetComponent<enemy>();
        myDropSystem = GetComponent<ItemDrop>();
    }

    private void ApplyLevelModifiers()
    {
        Moify(damage);
        Moify(critPower);
        Moify(critChance);

        Moify(maxhealth);
        Moify(armor);
        Moify(evasion);
        Moify(magicResist);

        Moify(fireDamage);
        Moify(iceDamage);
        Moify(lightingDamage);

        Moify(soulsDropAmount);
    }

    private void Moify(Stat _stat)
    {
        for(int i = 1; i < level; i++)
        {
            float modifier = _stat.GetValue() * percentageModifier;

            _stat.AddModifier(Mathf.RoundToInt(modifier));
        }
    }
    public override void TakeDamage(int _damage)
    {
        base.TakeDamage(_damage);
    }

    protected override void Die()
    {
        base.Die();
        enemy_00.Die();

        //PlayerManager.instance.currency += soulsDropAmount.GetValue();
    }
}
