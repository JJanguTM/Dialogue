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
        if (string.IsNullOrWhiteSpace(characterName))  //������ ���ڿ��� null�̰ų� ��� �ְų� ���� ���ڷθ� �����Ǿ� �ִ����� ��Ÿ���ϴ�.
        {
           
            characterImage.sprite = null;
          
            return;
        }

        characterImage.color = new Color(1, 1, 1, 1); //���� ������ ����.

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