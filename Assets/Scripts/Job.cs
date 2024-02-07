// Job.cs
using UnityEngine;

public abstract class Job : MonoBehaviour
{
    protected int healthPoints;
    protected int manaPoints;
    protected int attack;
    protected int defense;

    protected int level;

    public abstract void SpecialAbility();

    // Properties to access the stats
    public int HealthPoints { get { return healthPoints; } }
    public int ManaPoints { get { return manaPoints; } }
    public int AttackPoints { get { return attack; } }
    public int DefensePoints { get { return defense; } }
    public int LevelPoints { get { return level; } }

    public Job(int healthPoints, int manaPoints, int attack, int defense, int level)
    {
        this.healthPoints = healthPoints;
        this.manaPoints = manaPoints;
        this.attack = attack;
        this.defense = defense;
        this.level = level;
    }

    public abstract void Attack();
    public abstract void Defend();
    public abstract void Evade();
}
