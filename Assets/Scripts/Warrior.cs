using UnityEngine;

public class Warrior : Job
{
    private int berserk;

    // Singleton instance property
    private static Warrior instance;
    public static Warrior Instance
    {
        get
        {
            // If the instance is null, find or create the instance
            if (instance == null)
            {
                instance = FindObjectOfType<Warrior>();
                if (instance == null)
                {
                    GameObject gameObject = new GameObject("Warrior");
                    instance = gameObject.AddComponent<Warrior>();
                }
            }
            return instance;
        }
    }

    public Warrior()
        : base(100, 50, 20, 20, 10) // Default values for healthPoints, manaPoints, attack, and defense
    {
        this.berserk = 0;
    }

    public override void Attack()
    {
        Debug.Log("Warrior attacks with a powerful strike!");
    }

    public override void Defend()
    {
        Debug.Log("Warrior raises a sturdy shield to defend!");
    }

    public override void Evade()
    {
        Debug.Log("Warrior dodges incoming attacks with agility!");
    }

    public override void SpecialAbility()
    {
        Debug.Log("Warrior unleashes Berserk!");
    }
}
