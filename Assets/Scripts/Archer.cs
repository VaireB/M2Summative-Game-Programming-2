using UnityEngine;

public class Archer : Job
{
    private int arrowCount;

    // Singleton instance property
    private static Archer instance;
    public static Archer Instance
    {
        get
        {
            // If the instance is null, find or create the instance
            if (instance == null)
            {
                instance = FindObjectOfType<Archer>();
                if (instance == null)
                {
                    GameObject gameObject = new GameObject("Archer");
                    instance = gameObject.AddComponent<Archer>();
                }
            }
            return instance;
        }
    }

    public Archer()
        : base(80, 40, 25, 10, 5) // Default values for healthPoints, manaPoints, attack, and defense
    {
        this.arrowCount = 25;
    }

    public override void Attack()
    {
        Debug.Log("Archer shoots arrows with precision!");
    }

    public override void Defend()
    {
        Debug.Log("Archer takes cover and defends with agility!");
    }

    public override void Evade()
    {
        Debug.Log("Archer swiftly evades attacks!");
    }

    public override void SpecialAbility()
    {
        Debug.Log("Archer unleashes a flurry of arrows!");
    }
}
