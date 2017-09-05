using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soldilerATK : ATKDange 
{
    //public bool isattack;
    // Use this for initialization
    //hp=100;
    //全部为此标签的物体成一个数组
    public bool daed=false;
   public float attacka = 4;
    public bool is180 = true;
    private GameObject theboss;
    private Animator animator2;
    public bool iszhuand=false;//是否转动
    //  public GameObject ce;
    string str22;

    Vector3 ta2;
   // private void FixedUpdate()
    //{

    //}
    void FixedUpdate()
    {
        // obj.GetComponent<ATKDange>().isattack = false;
        // obj = GameObject.Find(dianneam).GetComponent<GameObject>();
        GameObject[] boss1;
        boss1 = GameObject.FindGameObjectsWithTag("SoulBoss");
        animator2 = gameObject.GetComponent<Animator>();
        foreach (GameObject child in boss1)
        {

            //theboss = child;
            string str2 = child.name.Substring(8, 1);
          //  print(str2);
            string str3 = gameObject.name.Substring(7, 1);
            if (str3!= str2) {
                float temp = Vector3.Distance(child.transform.position, transform.position);
                if (temp < 1.2)
                {
                    //Vector3 targetpos = ce.transform.position;
                    // targetpos.y = transform.position.y;
                    // transform.LookAt(targetpos);
                    if (is180)
                    {
                        transform.Rotate(Vector3.up * 180);
                        is180 = false;
                    }
                    if ( daed == true)//提前解放
                    {
                        //  print("45");
                        child.GetComponent<bossATK>().isattacka1 = false;
                    }
                    if (daed==false) {
                        animator2.SetBool("ATTACKA", true);
                        if (child.GetComponent<bossATK>().attackanme == gameObject.name || child.GetComponent<bossATK>().isattacka1 == false)
                        {
                            Vector3 targetpos = transform.position;
                            // targetpos.y = child.GetComponent<Transform>().position.y;
                            // Vector3 targetpos2 = new Vector3(0, child.GetComponent<Transform>().position.y,0);
                            //transform.LookAt(targetpos);
                            //ta2 = targetpos;
                            //print(gameObject.name);
                            child.GetComponent<bossATK>().attackanme = gameObject.name;
                            child.GetComponent<Transform>().LookAt(targetpos, child.GetComponent<Transform>().position);//1为z轴指向方向，2为y轴指向方向，新旋转后的y轴与worldUp在该对象初次旋转后的xy平面上的投影向量一致
                            child.GetComponent<bossATK>().isattacka1 = true;
                            if (iszhuand == true||daed==true)
                            {
                                //  print("45");
                                child.GetComponent<bossATK>().isattacka1 = false;
                            }

                        }

                    }

                }
                else {// animator2.SetBool("ATTACKA",false );

                }
            }
        }
    }
    public void attackEventa()
    { GameObject[] boss1;
        boss1 = GameObject.FindGameObjectsWithTag("SoulBoss");
       animator2 = gameObject.GetComponent<Animator>();
     foreach (GameObject child in boss1)
        {
           


            //theboss = child;

           float temp = Vector3.Distance(child.transform.position, transform.position);
           if (temp < 1.3)
           {

                child.GetComponent<bossATK>().takedamage(attacka);
                // Vector3 targetpos = ta2;
                //  if (child.GetComponent<bossATK>().attackanme == gameObject.name||  child.GetComponent<bossATK>().isattacka1== false) {
                //   Vector3 targetpos = transform.position;
                // targetpos.y = child.GetComponent<Transform>().position.y;
                // Vector3 targetpos2 = new Vector3(0, child.GetComponent<Transform>().position.y,0);
                //transform.LookAt(targetpos);
                //ta2 = targetpos;
                //  print(gameObject.name);
                //  child.GetComponent<bossATK>().attackanme = gameObject.name;
                //    child.GetComponent<Transform>().LookAt(targetpos, child.GetComponent<Transform>().position);//1为z轴指向方向，2为y轴指向方向，新旋转后的y轴与worldUp在该对象初次旋转后的xy平面上的投影向量一致
                // child.GetComponent<bossATK>().isattacka1 = true;
                // if (iszhuand == true)
                // {
                //      print("45");
                //      child.GetComponent<bossATK>().isattacka1 = false;
            }

            //  }

            // child.GetComponent<bossATK>().takedamage(attacka);

            // }
        }



    }

    public void attackEventb()
    { }
    public void attackEventrange()
    { }
    public void attackEvent1()
    {
        //iscanattckb = true;
    }

    public void attackEvent2()
    {
      //  iscanattckb = false;
    }


}
