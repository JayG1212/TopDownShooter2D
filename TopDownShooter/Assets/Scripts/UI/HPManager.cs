using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HPManager : MonoBehaviour
{
    public TMP_Text hpText; 
    private int HP = 50;      

  
    void Start()
    {
        UpdateHP();
    }

    private void UpdateHP()
    {
        hpText.text = "HP: " + HP;
    }

    public void SubtractHP(int damage)
    {
        HP -= damage;        
        UpdateHP();      
    }
    public void AddHp(int hp)
    {
     
            HP += hp;
            UpdateHP();
       
    }

}
