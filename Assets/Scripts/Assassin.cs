using UnityEngine;

public class Assassin : Job
{
    private int stealthDuration;

    // Singleton instance property
    private static Assassin instance;
    public static Assassin Instance
    {
        get
        {
            // If the instance is null, find or create the instance
            if (instance == null)
            {
                instance = FindObjectOfType<Assassin>();
                if (instance == null)
                {
                    GameObject gameObject = new GameObject("Assassin");
                    instance = gameObject.AddComponent<Assassin>();
                }
            }
            return instance;
        }
    }

    public Assassin()
        : base(70, 60, 30, 8, 7) // Default values for healthPoints, manaPoints, attack, and defense
    {
        this.stealthDuration = 10;
    }

    public override void Attack()
    {
        Debug.Log("Assassin strikes from the shadows!");
    }

    public override void Defend()
    {
        Debug.Log("Assassin uses swift movements to evade attacks!");
    }

    public override void Evade()
    {
        Debug.Log("Assassin disappears into the shadows to evade attacks!");
    }

    public override void SpecialAbility()
    {
        Debug.Log("Assassin activates stealth!");
    }
}
