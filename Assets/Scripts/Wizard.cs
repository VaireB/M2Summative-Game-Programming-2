using UnityEngine;

public class Wizard : Job
{
    private int mana;

    // Singleton instance property
    private static Wizard instance;
    public static Wizard Instance
    {
        get
        {
            // If the instance is null, find or create the instance
            if (instance == null)
            {
                instance = FindObjectOfType<Wizard>();
                if (instance == null)
                {
                    GameObject gameObject = new GameObject("Wizard");
                    instance = gameObject.AddComponent<Wizard>();
                }
            }
            return instance;
        }
    }

    public Wizard()
        : base(50, 100, 50, 5, 15) // Default values for healthPoints, manaPoints, attack, and defense
    {
        this.mana = 100;
    }

    public override void Attack()
    {
        Debug.Log("Mage attacks with compressed mana!");
        // Deduct mana or handle spell casting mechanics
    }

    public override void Defend()
    {
        Debug.Log("Mage creates a magical shield for defense!");
    }

    public override void Evade()
    {
        Debug.Log("Mage uses teleportation magic to evade attacks!");
    }

    public override void SpecialAbility()
    {
        Debug.Log("Mage fires a large fireball!");
    }
}
