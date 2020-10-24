using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Human : ObjectStatus
{
    [Header("HumanData")]
    [SerializeField] protected float health; //Hp
    [SerializeField] protected string type;  //EnemyOrCompany
}
