using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUI : MonoBehaviour
{
    public string CharacterName;
    public int Classindex = 0;
    public Text TextName;
    public Image ImageSprite;
    public Sprite CharacterSprite;
    public Button SelectClass;
    public PlayerController playerController;

    private void Awake()
    {
        SetUi();
        SelectClass.onClick.AddListener(() => playerController.SelectClass(Classindex));
    }

    void SetUi()
    {
        TextName.text = CharacterName;
        ImageSprite.sprite = CharacterSprite;
    }

}
