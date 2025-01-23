using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ImageManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI characterNameText; 
    [SerializeField] private Image characterImage; 
    [SerializeField] private Sprite image1; 
    [SerializeField] private Sprite image2; 

    void Update()
    {
        UpdateCharacterImage(characterNameText.text);
    }

    private void UpdateCharacterImage(string characterName)
    {
        if (string.IsNullOrWhiteSpace(characterName))  //지정된 문자열이 null이거나 비어 있거나 공백 문자로만 구성되어 있는지를 나타냅니다.
        {
           
            characterImage.sprite = null;
          
            return;
        }

        characterImage.color = new Color(1, 1, 1, 1); //원본 바탕이 보임.

        switch (characterName)
        {
            case "Taemin":
                characterImage.sprite = image1;
                break;
            case "ChaeWon":
                characterImage.sprite = image2;
                break;
            default:
                
                characterImage.sprite = null; 
                break;
        }
    }
}