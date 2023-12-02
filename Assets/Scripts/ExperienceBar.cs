using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Add this to use TextMeshPro

public class ExperienceBar : MonoBehaviour
{
    
    private TextMeshProUGUI _experienceText;
    
    private int _currentExperience = 0;

    void Start()
    {
        _experienceText = GetComponent<TextMeshProUGUI>();
        UpdateExperienceDisplay(); 
    }

    public void UpdateExperience(int newExperienceLevel)
    {
        _currentExperience = newExperienceLevel;
        UpdateExperienceDisplay();
    }

    private void UpdateExperienceDisplay()
    {
        _experienceText.text = _currentExperience.ToString("D6");
    }
}