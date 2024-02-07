using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;

public class EnemyStat : CharacterStats
{
    enemy enemy_00;
    ItemDrop myDropSystem;

    [SerializeField] int level;

    [Range(0f, 1f)]
    [SerializeField] float percantageModifier;
    protected override void Start()
    {
        ApplyLevelMoifier();

        base.Start();
        enemy_00 = GetComponent<enemy>();
        myDropSystem = GetComponent<ItemDrop>();
    }

    private void ApplyLevelMoifier()
    {
        Moify(damage);
        Moify(critChance);
        Moify(critPower);

        Moify(maxhealth);
        Moify(armor);
        Moify(evasion);
        Moify(magicResist);

        Moify(fireDamage);
        Moify(iceDamage);
        Moify(lightingDamage);
    }

    private void Moify(Stat _stat)
    {
        for (int i = 1; i <= level; i++)
        {
            float moifier = _stat.GetValue() * percantageModifier;

            _stat.AddModifier(Mathf.RoundToInt(moifier));
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

        myDropSystem.GenerateDrop();
        Destroy(gameObject, 2f);
    }
}
