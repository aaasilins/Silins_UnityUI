using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class CharacterInputManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInputField;
    [SerializeField] private TMP_InputField birthYearInputField;
    [SerializeField] private Button confirmButton;
    [SerializeField] private TMP_Text resultText;

    private void Start()
    {
        // Restrict birth year to numbers only
        birthYearInputField.contentType = TMP_InputField.ContentType.IntegerNumber;
        confirmButton.onClick.AddListener(OnConfirmClicked);
        resultText.text = "";
    }

    private void OnConfirmClicked()
    {
        string charName = nameInputField.text.Trim();
        string yearStr = birthYearInputField.text.Trim();

        if (string.IsNullOrEmpty(charName))
        {
            resultText.text = "Lūdzu, ievadiet vārdu!";
            return;
        }

        if (string.IsNullOrEmpty(yearStr))
        {
            resultText.text = "Lūdzu, ievadiet dzimšanas gadu!";
            return;
        }

        if (int.TryParse(yearStr, out int birthYear))
        {
            int age = DateTime.Now.Year - birthYear;
            resultText.text = "Supervaronis " + charName + " ir " + age + " gadus vecs!";
        }
        else
        {
            resultText.text = "Nederīgs gads!";
        }
    }
}