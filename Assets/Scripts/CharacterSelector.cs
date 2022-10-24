using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    public GameObject[] characters;
    public GameObject[] characters2;
    private int selectedCharacter = 0;

    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject ch in characters)
        {
            ch.SetActive(false);
        }

        foreach (GameObject ch in characters2)
        {
            ch.SetActive(false);
        }

        characters[selectedCharacter].SetActive(true);
        characters2[selectedCharacter].SetActive(true);
    }

    public void ChangeCharacter(int newCharacter)
    {
        characters[selectedCharacter].SetActive(false);
        characters[newCharacter].SetActive(true);
        characters2[selectedCharacter].SetActive(false);
        characters2[newCharacter].SetActive(true);
        selectedCharacter = newCharacter;
    }
}
