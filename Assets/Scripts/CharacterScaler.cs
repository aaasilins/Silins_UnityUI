using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterScaler : MonoBehaviour
{
    [SerializeField] private RectTransform[] characterTransforms;
    [SerializeField] private Slider heightSlider;
    [SerializeField] private Slider widthSlider;
    [SerializeField] private TMP_Text heightLabel;
    [SerializeField] private TMP_Text widthLabel;

    private void Start()
    {
        heightSlider.minValue = 0.5f;
        heightSlider.maxValue = 2.0f;
        heightSlider.value = 1.0f;

        widthSlider.minValue = 0.5f;
        widthSlider.maxValue = 2.0f;
        widthSlider.value = 1.0f;

        heightSlider.onValueChanged.AddListener(OnSliderChanged);
        widthSlider.onValueChanged.AddListener(OnSliderChanged);
    }

    private void OnSliderChanged(float value)
    {
        float w = widthSlider.value;
        float h = heightSlider.value;

        // Apply to all character transforms (only active one will be visible)
        foreach (var charTransform in characterTransforms)
        {
            if (charTransform != null)
                charTransform.localScale = new Vector3(w, h, 1f);
        }

        // Update labels
        if (heightLabel != null)
            heightLabel.text = "Garums: " + h.ToString("F1") + "x";
        if (widthLabel != null)
            widthLabel.text = "Platums: " + w.ToString("F1") + "x";
    }

    public void ResetScale()
    {
        heightSlider.value = 1f;
        widthSlider.value = 1f;
    }
}