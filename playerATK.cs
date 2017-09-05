using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerATK : ATKDange
{
    public float attacka=1;
    public float attackrange=100;
    public float attackb;
    public float attackgun;
   public GameObject boss;
    // Use this for initialization
    public void attackEventa()
    {
        float temp = Vector3.Distance(boss.transform.position,transform.position);
        if (temp<Attackdistance) {
            Vector3 targetpos = boss.transform.position;
            targetpos.y = transform.position.y;
            transform.LookAt(targetpos);
            boss.GetComponent<bossATK>().takedamage(attacka);
        }
        //iscanattckb = true;
    }
    public void attackEventb()
    {
        //iscanattckb = true;
        float temp = Vector3.Distance(boss.transform.position, transform.position);
        if (temp < Attackdistance)
        {
            Vector3 targetpos = boss.transform.position;
            targetpos.y = transform.position.y;
            transform.LookAt(targetpos);
            boss.GetComponent<bossATK>().takedamage(attacka);
        }
    }
    public void attackEventrange()
    {
        //iscanattckb = true;
        float temp = Vector3.Distance(boss.transform.position, transform.position);
        if (temp < Attackdistance)
        {
            Vector3 targetpos = boss.transform.position;
            targetpos.y = transform.position.y;
            transform.LookAt(targetpos);
            boss.GetComponent<bossATK>().takedamage(attacka);
        }
    }
    public void attackEventgun()
    {
        //iscanattckb = true;
    }
}
