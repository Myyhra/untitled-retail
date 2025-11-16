using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class ChangeBio : MonoBehaviour
{
    [Header("The Character")]
    public Material characterPortrait;
    [TextArea] public string bio;

    [Header("Put Character Bio")]
    [SerializeField] Image image;
    [SerializeField] TextMeshProUGUI characterBioText;

    public void ChangePanel()
    {
        image.material = characterPortrait;
        characterBioText.text = bio;
    }
}
