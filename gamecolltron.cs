using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class gamecolltron : MonoBehaviour {
    public string dianneam;
    public string dianneam2;
    private GameObject obj;
    public Button attackbutton;
    public Text COLOERTEXT;
    private Animator animator;
    public GameObject attackbutton2;
    public GameObject canclbutton2;
    public GameObject[] soldilerA;
    public GameObject[] soldilerB;
    public GameObject[] soldilerC;
    public GameObject[] soldilerD;
    public GameObject[] soldilerE;
    public GameObject[] soldilerF;
    public int turn;
    public int soldilerturn;
    public bool checkbutton;

    private GameObject[] thesoldilers;
    // Use this for initialization
    void Start () {
        // attackbutton.GetComponent<CanvasRenderer>(). = false;
        attackbutton2.SetActive(false) ;
        canclbutton2.SetActive(false);
        turn = 1;
        soldilerturn = 0;
        checkbutton = true;
    }
	
	// Update is called once per frame
	void Update () {
      
        switch (turn)
        {
           
            case 1:
                thesoldilers= soldilerA;
                COLOERTEXT.text = "白色的回合";

                break;
            case 2:
                COLOERTEXT.text = "紫色的回合";
                thesoldilers = soldilerB;
                break;
            case 3:
                thesoldilers = soldilerC;
                COLOERTEXT.text = "绿色的回合";
                break;
            case 4:
                thesoldilers = soldilerD;
                COLOERTEXT.text = "黄色的回合";
                break;
            case 5:
                COLOERTEXT.text = "红色的回合";
                thesoldilers = soldilerE;
                break;
            case 6:
                COLOERTEXT.text = "蓝色的回合";
                thesoldilers = soldilerF;
                break;




        }

        foreach (GameObject child in thesoldilers)
         {
            // child.GetComponent<CharacterController>().enabled = true;
            print(dianneam);
            print(child.name);
            if (child.name ==dianneam)
            {
                if (child.tag == "SoulBoss") { } else {
                    if (GameObject.Find(dianneam).GetComponent<ATKDange>().isattack == true) {

                        attackbutton2.SetActive(true);
                        canclbutton2.SetActive(true);
                        obj = GameObject.Find(dianneam);

                        /// dianneam = "fuck";
                    }
                    else
                    {
                        canclbutton2.SetActive(false);
                        attackbutton2.SetActive(false);
                    }
                }
            }
           

           }



    }
    public void chuioce()
    {
        obj = GameObject.Find(dianneam).GetComponent<GameObject>();
      //  attackbutton.GetComponent<Renderer>().enabled = true;
      //  attackbutton2.SetActive(true);
    }
    public void attack1()
    {
        obj.GetComponent<ATKDange>().isattack = false;
        // obj = GameObject.Find(dianneam).GetComponent<GameObject>();
        animator = obj.GetComponent<Animator>();
        animator.SetBool("ATTACKA", true);
        soldilerturn++;
        print(soldilerturn);
        attackbutton2.SetActive(false);
        canclbutton2.SetActive(false);
        // checkbutton = true;

        if (soldilerturn == 4)
        {
            soldilerturn = 0;
            turn++;
           // print(turn);
            if (turn==7)
            {
                turn = 1;
                GameObject[] soldilers;
                soldilers = GameObject.FindGameObjectsWithTag("soldier");//全部为此标签的物体成一个数组

               foreach (GameObject child in soldilers)
                  {
                    //child.GetComponent<CharacterController>().enabled = true;
                    child.GetComponent<ATKDange>().isattack = true;
                 }
                GameObject[] boss1;
                boss1 = GameObject.FindGameObjectsWithTag("SoulBoss");//全部为此标签的物体成一个数组

                foreach (GameObject child in boss1)
                {
                    //child.GetComponent<CharacterController>().enabled = true;
                    child.GetComponent<ATKDange>().isattack = true;
                }
            }
        }
      
    }

    public void cancl()
    {

        obj.GetComponent<ATKDange>().isattack = false;
        // obj = GameObject.Find(dianneam).GetComponent<GameObject>();
       
        soldilerturn++;
        canclbutton2.SetActive(false);
        attackbutton2.SetActive(false);
        // checkbutton = true;

        if (soldilerturn == 4)
        {
            soldilerturn = 0;
            turn++;
            // print(turn);
            if (turn == 7)
            {
                turn = 1;
                GameObject[] soldilers;
                soldilers = GameObject.FindGameObjectsWithTag("soldier");//全部为此标签的物体成一个数组

                foreach (GameObject child in soldilers)
                {     
                    //child.GetComponent<CharacterController>().enabled = true;
                    child.GetComponent<ATKDange>().isattack = true;
                }
                GameObject[] boss1;
                boss1 = GameObject.FindGameObjectsWithTag("SoulBoss");//全部为此标签的物体成一个数组

                foreach (GameObject child in boss1)
                {
                    //child.GetComponent<CharacterController>().enabled = true;
                    child.GetComponent<ATKDange>().isattack = true;
                }
            }
        }


    }

    }
