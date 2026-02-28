using UnityEngine;
using UnityEngine.UI;

public class ClothingCategoryManager : MonoBehaviour
{
    [System.Serializable]
    public class ClothingCategory
    {
        public string categoryName;
        public Toggle categoryToggle;
        public GameObject categoryPanel;
    }

    [SerializeField] private ClothingCategory[] categories;

    private void Start()
    {
        foreach (var category in categories)
        {
            // Save reference for the closure
            ClothingCategory cat = category;
            cat.categoryToggle.onValueChanged.AddListener((bool isOn) =>
            {
                cat.categoryPanel.SetActive(isOn);
            });

            // Set initial state
            cat.categoryPanel.SetActive(cat.categoryToggle.isOn);
        }
    }
}