using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weiyao : MonoBehaviour {
  //  public Transform zx;
	// Use this for initialization
    public bool iskoxuan;
    private Vector3 obj;
    private Vector3 yzhou;
    public Transform obj2;
    public Transform y1;//顶面中心点
    public Transform y2;//底面中心点

    public Transform y5;//正面中心点
    public Transform y6;//背面中心点
    public Transform y3;//右侧面中心点
    public Transform y4;//左侧面中心点
    public GameObject mofang;
    public int biaoji;
    public int zxbiaoji;
    private bool issend;
    private float xuantime;
    private float beforeobjx;
    private float fffobjx;
    void Start () {
        iskoxuan = false;
        issend = true;
    }

    // Update is called once per frame
    void Update()
    {
        



    }
    private void FixedUpdate()
    {
        Vector3 axisy = y1.position - y2.position;
        Vector3 axisx = y3.position - y4.position;
        Vector3 axisz = y5.position - y6.position;
        Vector3 negativeaxisy = -(y1.position - y2.position);
        Vector3 negativeaxisx = -(y3.position - y4.position);
        Vector3 negativeaxisz = -(y5.position - y6.position);
        Vector3[] normalloca = new Vector3[] { axisy, axisx, axisz, negativeaxisy, negativeaxisx, negativeaxisz };//轴向量
    switch (zxbiaoji)
    {
            case 6:
                obj = y6.position;
                //  obj2 = y3;
                break;
            case 1:
                obj = y1.position;
                //  obj2 = y3;
                break;
            case 2:
                obj = y2.position;
                //  obj2 = y3;
                break;
            case 3:
                obj = y3.position;
                //  obj2 = y3;
                break;
            case 4:
            obj = y4.position;
          //  obj2 = y3;
            break;
            case 5:
                obj = y5.position;
                //  obj2 = y3;
                break;

        }

        if (iskoxuan)
        {
           // Time.
            transform.RotateAround(obj, normalloca[biaoji], 90 * Time.deltaTime);
            if (issend) {
                
                mofang.GetComponent<cuberote>().lockcube(false);//不能同时旋转
                mofang.GetComponent<cuberote>().candbuttonxuanzhun();//切换射线层
                issend = false;
            }

           
            xuantime += 90 * Time.deltaTime;
            // print(xuantime);
            if (xuantime >= 90)
            {


               // GameObject[] soldilers;
              //  soldilers = GameObject.FindGameObjectsWithTag("soldier");//全部为此标签的物体成一个数组

               // foreach (GameObject child in soldilers)
              //  {
                    //child.GetComponent<CharacterController>().enabled = true;

               // }
              

            }
            if (xuantime >= 90)
            {
                iskoxuan = false;
                mofang.GetComponent<cuberote>().lockcube(true);
              
                issend = true;
                xuantime = 0;
                foreach (Transform child in transform)
                {

                    //   print(1);
                    // Destroy();
                    if (child.gameObject.tag == "soldier")
                    {
                        // print(1);
                        child.gameObject.GetComponent<soldilerATK>().iszhuand = false;
                        //print(child.gameObject.GetComponent<soldilerATK>().hp);
                    }
                }

            }
        }
    }
    public void fuck(int obj1,int i) {// print("sas"); 
        iskoxuan = true;
     //   obj = obj1;o
        //yzhou = yzhou1;
        biaoji = i;
       // if (y3.position==obj1)
       // {
         zxbiaoji = obj1;
        // obj = obj1;
        //}
        childgo();
    }
    public void childgo()
    {
        foreach (Transform child in transform)
        {

            //   print(1);
            // Destroy();
            if (child.gameObject.tag == "soldier")
            {
               // print(1);
                child.gameObject.GetComponent<soldilerATK>().iszhuand =true;
                //print(child.gameObject.GetComponent<soldilerATK>().hp);
            }
        }

    }

}
