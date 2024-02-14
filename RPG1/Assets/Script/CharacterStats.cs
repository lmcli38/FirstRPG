using System.Collections;
using UnityEngine;


public enum StatType
{
    strength,
    agility,
    intelegence,
    vitality,
    damage,
    critChance,
    critPower,
    health,
    armor,
    evasion,
    magicRes,
    fireDamage,
    icedamage,
    lighting

}
public class CharacterStats : MonoBehaviour
{
    private EntityFX fx;

    [Header("Major Stats")]
    public Stat strength; // crit power
    public Stat agility; // crit chance
    public Stat intelligence; // magic damage
    public Stat vitality; // increase health

    [Header("Defensive stats")]
    public Stat maxhealth;
    public Stat armor;
    public Stat evasion;

    [Header("Offensive Stats")]
    public Stat damage;
    public Stat critChance;
    public Stat critPower;
    public Stat magicResist;

    [Header("Magic Stats")]
    public Stat fireDamage;
    public Stat iceDamage;
    public Stat lightingDamage;

    public bool isIgnited;
    public bool isChilled;
    public bool isShocked;

    [SerializeField] float ailmentsDuration = 4;
    float ignitedTimer;
    float chilledTimer;
    float shockedTimer;

    float ignitedDamageCoolDown = .3f;
    float igniteDamagrTimer;
    int igniteDamage;


    public int currentHealth;
    public System.Action onHealthChanged;
    public bool isDead { get; private set; }
    public bool isInvincible { get; private set; }

    protected virtual void Start()
    {
        critPower.SetDefaultValue(150);
        currentHealth = GetMaxHealthValue();

        fx = GetComponent<EntityFX>();

    }
    protected virtual void Update()
    {
        ignitedTimer -= Time.deltaTime;
        chilledTimer -= Time.deltaTime;
        shockedTimer -= Time.deltaTime;

        igniteDamagrTimer -= Time.deltaTime;

        if (ignitedTimer < 0)
        {
            isIgnited = false;
        }
        if (chilledTimer < 0)
        {
            isChilled = false;
        }
        if (shockedTimer < 0)
        {
            isShocked = false;
        }

        ApplyIgniteDamage();
    }

    public virtual void InceaseStatBy(int _modifier,float _duration,Stat _statToModifiy)
    {
        StartCoroutine(StartModCoroutine(_modifier, _duration, _statToModifiy));
    }
    IEnumerator StartModCoroutine(int _modifier,float _duration,Stat _statToModifiy)
    {
        _statToModifiy.AddModifier(_modifier);
        yield return new WaitForSeconds(_duration);
        _statToModifiy.RemoveModifier(_modifier);
    }

    public virtual void DoDamage(CharacterStats _targetStats)
    {
        if (CanAvoidAttack(_targetStats))
        {
            return;
        }
        int totalDamage = damage.GetValue() + strength.GetValue();
        if (CanCrit())
        {
            totalDamage = CalculateCriticalDamage(totalDamage);
        }
        totalDamage = CheckTargetArmor(_targetStats, totalDamage);
        _targetStats.TakeDamage(totalDamage);
        DoMagicalDamage(_targetStats);
    }


    #region Magical damage and ailments
    public virtual void DoMagicalDamage(CharacterStats _targetStats)
    {
        int _fireDamage = fireDamage.GetValue();
        int _iceDamage = iceDamage.GetValue();
        int _lightingDamage = lightingDamage.GetValue();

        int totalMagicalDamage = _fireDamage + _iceDamage + _lightingDamage + intelligence.GetValue();

        totalMagicalDamage = CheckMagicResist(_targetStats, totalMagicalDamage);
        _targetStats.TakeDamage(totalMagicalDamage);

        bool canApplyIgnite = _fireDamage > _iceDamage && _fireDamage > _lightingDamage;
        bool canApplyChill = _iceDamage > _fireDamage && _iceDamage > _lightingDamage;
        bool canApplyShock = _lightingDamage > _fireDamage && _lightingDamage > _iceDamage;

        if (canApplyIgnite)
            _targetStats.SetupIgniteDamage(Mathf.RoundToInt(_fireDamage * .2f));


        _targetStats.ApplyAilments(canApplyIgnite, canApplyChill, canApplyShock);

    }
    public virtual void ApplyAilments(bool _ignite, bool _chill, bool _shock)
    {
        if (isIgnited || isChilled || isShocked)
        {
            return;
        }
        if(_ignite) 
        {
            isIgnited = _ignite;
            ignitedTimer = ailmentsDuration;

            fx.IngiteFxFor(ailmentsDuration);
        }
        if(_chill) 
        { 
            chilledTimer = ailmentsDuration;
            isChilled = _chill;

            fx.ChillFxFor(ailmentsDuration);
        }
        if(_shock)
        {
            shockedTimer = ailmentsDuration;
            isShocked = _shock;

            fx.ShockFxFor(ailmentsDuration);
        }
    }
    private void ApplyIgniteDamage()
    {
        if (igniteDamagrTimer < 0 && isIgnited)
        {

            currentHealth -= igniteDamage;
            if (currentHealth < 0 && !isDead)
                Die();

            igniteDamagrTimer = ignitedDamageCoolDown;
        }
    }
    public void SetupIgniteDamage(int _damage) => igniteDamage = _damage;

    #endregion

    public virtual void TakeDamage(int _damage)
    {
        if (isInvincible)
            return;

        DecreaseHealth(_damage);

        GetComponent<Entity>().DamageEffect();
        

        if (currentHealth <= 0 && !isDead)
        {
            Die();
        }

    }
    public virtual void IncreaseHealth(int _amount)
    {
        currentHealth += _amount;

        if(currentHealth > GetMaxHealthValue())
            currentHealth = GetMaxHealthValue();
        if(onHealthChanged != null)
            onHealthChanged();
    }
    protected virtual void DecreaseHealth(int _damage)
    {
        currentHealth -= _damage;
        if(_damage > 0)
            fx.CreatePopUpText(_damage.ToString());

        if (onHealthChanged != null)
            onHealthChanged();
    }

    protected virtual void Die()
    {
        isDead = true;
    }
    public void KillEntity()
    {
        if (!isDead)
            Die();

    }

    public void MakeInvinciblee(bool _invincible) => isInvincible = _invincible;
        #region Stat Calculations
        private bool CanAvoidAttack(CharacterStats _targetStats)
    {
        int totalEvasion = _targetStats.evasion.GetValue() * _targetStats.agility.GetValue(); ;

        if (Random.Range(0, 100) < totalEvasion)
        {
            return true;
        }
        return false;
    }
    private int CheckTargetArmor(CharacterStats _targetStats, int totalDamage)
    {
        totalDamage -= _targetStats.armor.GetValue();
        totalDamage = Mathf.Clamp(totalDamage, 0, int.MaxValue);
        return totalDamage;
    }
    private  int CheckMagicResist(CharacterStats _targetStats, int totalMagicalDamage)
    {
        totalMagicalDamage -= _targetStats.magicResist.GetValue() + (_targetStats.intelligence.GetValue() * 3);
        totalMagicalDamage = Mathf.Clamp(totalMagicalDamage, 0, int.MaxValue);
        return totalMagicalDamage;
    }

    private bool CanCrit()
    {
        int totalCriticalChance = critChance.GetValue() + agility.GetValue();
        if (Random.Range(0, 100) <= totalCriticalChance)
        {
            return true;
        }
        return false;
    }

    private int CalculateCriticalDamage(int _damage)
    {
        float totalCriticalPower = (critPower.GetValue() + strength.GetValue()) * .01f;
        float critDamage = _damage * totalCriticalPower;
        return Mathf.RoundToInt(critDamage);
    }

    public int GetMaxHealthValue()
    {
        return maxhealth.GetValue() + vitality.GetValue() * 5;
    }
    #endregion

    public Stat StatToModify(StatType _statType)
    {
        if (_statType == StatType.strength) return strength;
        else if (_statType == StatType.agility) return agility;
        else if (_statType == StatType.intelegence) return intelligence;
        else if (_statType == StatType.vitality) return vitality;
        else if (_statType == StatType.damage) return damage;
        else if (_statType == StatType.critChance) return critChance;
        else if ((_statType == StatType.critPower)) return critPower;
        else if (_statType == StatType.health) return maxhealth;
        else if (_statType == StatType.armor) return armor;
        else if (_statType == StatType.evasion) return evasion;
        else if (_statType == StatType.magicRes) return magicResist;
        else if (_statType == StatType.fireDamage) return fireDamage;
        else if (_statType == StatType.icedamage) return iceDamage;
        else if (_statType == StatType.lighting) return lightingDamage;
            
        return null;
    }


}
