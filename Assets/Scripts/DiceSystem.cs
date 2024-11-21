using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceSystem : MonoBehaviour
{
    public int diceCount = 3;
    private List<int> diceResults;

    void Start()
    {
        RollDice();
        CheckDiceCombos();
    }

    void RollDice()
    {
        diceResults = new List<int>();
        for (int i = 0; i < diceCount; i++)
        {
            int result = Random.Range(1, 7);
            diceResults.Add(result);
            Debug.Log($"Dado {i + 1}: {result}");
        }
    }

    void CheckDiceCombos()
    {
        diceResults.Sort();
        if (IsPair()) Debug.Log("Hai ottenuto una Coppia!");
        if (IsStraight()) Debug.Log("Hai ottenuto una Scala!");
        if (IsMaxStraight()) Debug.Log("Hai ottenuto una Scala Max!");
        if (IsTriple()) Debug.Log("Hai ottenuto un Tris!");
        if (IsSpecialTriple()) Debug.Log("Hai ottenuto un Tris Speciale!");
    }

    bool IsPair()
    {
        return diceResults[0] == diceResults[1] || diceResults[1] == diceResults[2];
    }

    bool IsStraight()
    {
        return diceResults[0] + 1 == diceResults[1] && diceResults[1] + 1 == diceResults[2] && diceResults[2] < 6;
    }

    bool IsMaxStraight()
    {
        return diceResults[0] == 4 && diceResults[1] == 5 && diceResults[2] == 6;
    }

    bool IsTriple()
    {
        return diceResults[0] == diceResults[1] && diceResults[1] == diceResults[2];
    }

    bool IsSpecialTriple()
    {
        return (diceResults[0] == 1 && diceResults[1] == 1 && diceResults[2] == 1) ||
               (diceResults[0] == 6 && diceResults[1] == 6 && diceResults[2] == 6);
    }
}
