using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATKDange : MonoBehaviour {
    public float hp;
    public float nromalAttack;
    public float Attackdistance;
    public bool isattack;
    //  public GameObject hitboss;
    // Use this for initialization
    void Start()
    {
        isattack = true;
    }
    private Animator animator;

    public IEnumerator Timer(float time)
    {
        yield return new WaitForSeconds(5);
        gameObject.GetComponent<soldilerATK>().daed = false;
        gameObject.GetComponent<soldilerATK>().hp = 50;
      //  gameObject.GetComponent<soldilerATK>().iszhuand = false;
         animator.SetTrigger("lift");
    }

    public virtual void takedamage(float damage) {
        animator = GetComponent<Animator>();
        if (hp > 0)
        {
            hp -= damage;
        }
        if (hp > 0)
        {
            
          //  animator.SetTrigger("danage");
            if (this.tag == "SoulBoss")
            {
            // GameObject.Instantiate(Resources.Load("Hitboss"),transform.position,transform.rotation);
            }
            }
        else {
            //死是boos
            if (this.tag == "SoulBoss")
            {
                // GameObject.Instantiate(Resources.Load("Hitboss"),transform.position,transform.rotation);
                animator.SetTrigger("death");
                GameObject[] soldilers;
                soldilers = GameObject.FindGameObjectsWithTag("soldier");//全部为此标签的物体成一个数组

                foreach (GameObject child in soldilers)
                {
                    //child.GetComponent<CharacterController>().enabled = true;
                    //  child.GetComponent<ATKDange>().isattack = true;
                    string str3 = child.name.Substring(7, 1);
                    //  print(str2);
                    string str2 = gameObject.name.Substring(8, 1);//比较名字
                    if (str3 == str2)
                    {
                        // print("hhj");
                        if (child.GetComponent<soldilerATK>().daed == false)//如果没死的小兵都死了
                        {
                            Animator animator2 = child.GetComponent<Animator>();
                            animator2.SetTrigger("death");
                           // child.GetComponent<soldilerATK>().isattacka1 = true;//相当于转动了失去目标
                            child.GetComponent<soldilerATK>().daed = true;

                        }
                    }
                }

            }
            else
            {//小兵被boss打死
                if (gameObject.GetComponent<soldilerATK>().daed == false)
                {
                    animator.SetTrigger("death");
                    StartCoroutine(Timer(5));
                   // gameObject.GetComponent<soldilerATK>().iszhuand = true;//相当于转动了失去目标
                    gameObject.GetComponent<soldilerATK>().daed = true;
                }

            }


        }


    }

  
   
}
