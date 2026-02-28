using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class CharacterSelector : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown characterDropdown;
    [SerializeField] private GameObject[] characterObjects;
    [SerializeField] private TMP_Text descriptionText; // For Step 7

    [TextArea(3, 10)]
    [SerializeField]
    private string[] characterDescriptions = new string[]
    {
        "Drosmīgs uguns burvis no seno laiku karaļvalsts. Viņš ir slavens ar savu neuzvaramo uguns bruņu komplektu un uguns zobenu. Uguns burvis ir cīnījies neskaitāmās kaujās un vienmēr aizstāvējis vājos.",
        "Noslēpumains ledus burvis, kurš apguvis seno maģiju. Viņš pārvalda ledus un zibens burvības. Viņa burvju nūja ir izgatavota no Pasaules ledus koka zara."
    };

    private int currentCharacterIndex = 0;

    private void Start()
    {
        characterDropdown.onValueChanged.AddListener(OnCharacterChanged);
        ShowCharacter(0);
    }

    private void OnCharacterChanged(int index)
    {
        ShowCharacter(index);
        
        if (SoundManager.Instance != null)
            SoundManager.Instance.PlayCharacterSound(index);
    }

    private void ShowCharacter(int index)
    {
        currentCharacterIndex = index;

        // Hide all characters, show selected one
        for (int i = 0; i < characterObjects.Length; i++)
        {
            characterObjects[i].SetActive(i == index);
        }

        // Update description (for Step 7)
        if (descriptionText != null && index < characterDescriptions.Length)
        {
            descriptionText.text = characterDescriptions[index];
        }
    }

    public int GetCurrentCharacterIndex()
    {
        return currentCharacterIndex;
    }
}