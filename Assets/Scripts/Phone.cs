[System.Serializable]
public class Phone {

    /// <summary>   The amount of charge our battery currently has.</summary>
    [UnityEngine.SerializeField]private float juice = 50f;

    /// <summary>   If juice > 0 return true, else false.</summary>
    public bool IsCharged
    {
        get { return juice > 0; }
    }

    /// <summary>
    /// Adds the given amount to teh current juice (amount must be postive).
    /// </summary>
    /// <param name="amount"></param>
    public void AddJuice(float amount)
    {
        juice += amount;
    }

    /// <summary>
    /// Reduces teh juice by a given amount (amount must be postive).
    /// </summary>
    /// <param name="amount"></param>
    public void ReduceJuice(float amount)
    {
        AddJuice(-amount);
    }
}
