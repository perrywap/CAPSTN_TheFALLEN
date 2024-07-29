using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
    private Player player;

    [Header("Health")]
    [SerializeField] private Image healthImage;

    [Header("Active Character")]
    [SerializeField] private Image activeCharacterImage;
    [SerializeField] private Sprite[] characterImages;

    [Header("Character Switch Icons")]
    public Image[] iconImages;

    [Header("Skills")]
    [SerializeField] private Image[] skillImage;
    [SerializeField] private Sprite defaultSkillSprite;

    public static HudManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        UpdateCharacter(0);
    }

    private void Update()
    {
        CheckActiveCharacter();
    }

    private void FixedUpdate()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        healthImage.fillAmount = player.Health / player.MaxHealth;
    }

    private void CheckActiveCharacter()
    {
        int index = 0;

        if (player.character == Character.HERO)
            index = 0;
        
        if (player.character == Character.LANCER)
            index = 1;

        if (player.character == Character.ARCHER)
            index = 2;

        if (player.character == Character.WIZARD)
            index = 3;

        if (player.character == Character.SAINT)
            index = 4;

        UpdateCharacter(index);
    }

    private void UpdateCharacter(int index)
    {
        activeCharacterImage.sprite = characterImages[index];

        for (int i = 0; i < iconImages.Length; i++)
        {
            if (i == index)
                iconImages[index].rectTransform.localScale = Vector3.one;
            else
                iconImages[i].rectTransform.localScale = new Vector3(0.75f, 0.75f, 0);
        }
    }

    public void UpdateSkillIcons(int index, GameObject player)
    {
        for (int i = 0; i < skillImage.Length; i++)
        {
            if (i == 2 && player.GetComponent<Player>().character != Character.HERO)
            {
                skillImage[i].sprite = defaultSkillSprite;
                skillImage[i+1].sprite = player.GetComponent<CharacterSkillController>().skills[i].skillImage;
                break;
            }    
            skillImage[i].sprite = player.GetComponent<CharacterSkillController>().skills[i].skillImage;
        }
    }
}
