using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerCharacter
{
    HERO,
    LANCER,
    ARCHER,
    WIZARD,
    SAINT
}

public class Player : UnitBase
{
    [Header("Character")]
    [SerializeField] private PlayerCharacter character;
}
