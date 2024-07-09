using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Character
{
    HERO,
    LANCER,
    ARCHER,
    WIZARD,
    SAINT
}

public class Player : BaseUnit
{
    public Character character;
}
