using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave", menuName ="Waves/Wave")]

public class WaveSO : ScriptableObject
{

    //[SerializeField] List<Test> enemyCollection;


    [SerializeField] List<Enemy> enemies;

    public List<Enemy> Enemies => enemies;


   




}


//[Serializable]

//    struct Test

  //  {
    //[SerializeField] Enemy enemyType;
    //[SerializeField] int amount;
    
    //}
