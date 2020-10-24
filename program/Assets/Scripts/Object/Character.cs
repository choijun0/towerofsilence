using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Character : ObjectStatus
{
    [Header("CharacterData")]
    [SerializeField] protected float health; 
    [SerializeField] protected float damage; 
    [SerializeField] protected int amountOfMana; 
}
