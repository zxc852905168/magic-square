using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossATK : ATKDange
{
    private Animator animator3;
    public bool isattacka1=false;
    public int attackanum ;
    public string attackanme;
    public   float bossattack=10;
    private void LateUpdate()
    {
        animator3 = gameObject.GetComponent<Animator>();
        // Use this for initialization
        if (hp<3000) {
           // isattacka = true;
            animator3.SetBool("ATTACKA", true);
        }
    }
 public void boosatEvent1()
    {
       // if (attackanme!=null) {
            if (GameObject.Find(attackanme).GetComponent<soldilerATK>().hp>=0) {
                //print(attackanme);
                GameObject.Find(attackanme).GetComponent<soldilerATK>().takedamage(bossattack); }
        }
    //}
}
