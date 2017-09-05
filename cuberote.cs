using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class cuberote : MonoBehaviour {
    private Vector3 normal;
    private Vector3 mouseStart;
    private Vector3 mouseRun;
    private Vector3 mouseCross;
    private GameObject cubeObject;
    private GameObject thisgamg;
   // public GameObject objnaem;
   // public GameObject hptext;
    public Text objnaem;
    public Text hptext;
    public GameObject colltron;
    private weiyao wei;
    private bool islock;
   private float hitx;
    private float hity;
    private float hitz;
    public   GameObject cube22;
    public GameObject[] objs;
    public Transform obj;
    public Transform y1;
    public Transform y2;
    public Transform y3;
    public Transform y4;
    public Transform y5;
    public Transform y6;
    private float fMouseX;
    private float fMouseY;
    public float speed = 2;
public   LayerMask mask2;
    public bool soldilerturn;//士兵回合是否结束
    public bool buttonmofangturn;//是否按下旋转按钮
    private Vector3 cubelopos;
    Vector3 vecZhou;
    Vector3[] vecPoint = new Vector3[] { Vector3.right, Vector3.up, Vector3.forward, Vector3.left, Vector3.down, Vector3.back };

// Use this for initialization
void Start () {

        islock = true;
        soldilerturn = true;
        buttonmofangturn = false;
    }

    // Update is called once per frame
    void Update()
    {


        // cube22.transform.RotateAround(obj.position, y1.position - y2.position, 90 * Time.deltaTime);
        //transform.RotateAround(Vector3.zero, Vector3.up, 20 * Time.deltaTime);
       

            if (Input.GetMouseButtonDown(0))//只是按下那一瞬
        {

            //if (soldilerturn)//全部士兵不可触碰，防止影响魔方旋转判定
        

            fMouseX = Input.GetAxis("Mouse X");
                fMouseY = Input.GetAxis("Mouse Y");
                //   _mouseDown = true;
                //   gameObject.BroadcastMessage("fuck");
                //从屏幕发出一条射线到鼠标的位置
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                //定义一个获取射线目标点物体的变量
                RaycastHit hitStart;
            //从刚才点击屏幕的射线的初始点，发射一条跟刚才射线方向一样的射线，并返回射线目标体的属性
          RaycastHit hitinfox;
            //LayerMask mask = 0 << 0 | 1 << 8;
            //  bool iscolider = Physics.Raycast(ray.origin, ray.direction, out hitinfox, 100, mask);
            //  if (iscolider)
            //{
            //   if (hitinfox.collider.tag == null) { }
            //   else
            //  {
            //    print(hitinfox.collider.tag);
            //  if (hitinfox.collider.tag == "soldier")
            //  { print("www"); }
            //  else
            //  {


            //  }
            // }
            // }
            if (buttonmofangturn)
            {
             mask2 = 1 << 0 | 0 << 8;

            }
            else
            {

                 mask2 =0 << 0 | 1<< 8;
            }
    // mask2 = 1 << 0 | 0 << 8;
            if (Physics.Raycast(ray.origin, ray.direction, out hitStart,100, mask2.value))
                {
                print(hitStart.collider.tag);

                //鼠标点到的物体就是射线碰触到的目标物体
                cubeObject = hitStart.transform.gameObject;
                if (hitStart.collider.tag == "soldier"|| hitStart.collider.tag == "SoulBoss") 
                  {

                 objnaem.text= hitStart.transform.gameObject.name;
                    hptext.text = hitStart.transform.gameObject.GetComponent<ATKDange>().hp.ToString();
                    colltron.GetComponent<gamecolltron>().dianneam= hitStart.transform.gameObject.name;
                   // colltron.GetComponent<gamecolltron>().chuioce();
                }

                if (hitStart.collider.tag == "cubediamond")
             {

                hitx = cubeObject.transform.localPosition.x;
                    hity = cubeObject.transform.localPosition.y;
                    hitz = cubeObject.transform.localPosition.z;
                    //print(2);
                    //cubelopos = cubeObject.transform.position;//世界坐标

                    //  }
                    //  else
                    // {//获得当前物体的法线
                    normal = hitStart.normal;
                    //   Destroy(cubeObject);
                    //鼠标点击的点就是射线碰触到物体的point
                    mouseStart = hitStart.point;

               

                }
            }
            }


            if (Input.GetMouseButton(0) && cubeObject != null)
            {
                //从屏幕发出一条射线到鼠标的位置
                Ray rayRun = Camera.main.ScreenPointToRay(Input.mousePosition);
                //定义一个获取射线目标点物体的变量
                RaycastHit hitRun;
            //LayerMask mask2 = 1 << 0 | 0 << 8;
            //    Debug.Log(2);
            //从刚才点击屏幕的射线的初始点，发射一条跟刚才射线方向一样的射线，并返回射线目标体的属性
            if (Physics.Raycast(rayRun.origin, rayRun.direction, out hitRun,100, mask2.value))
                {

                if (hitRun.collider.tag == "cubediamond")
                {
                    //鼠标拖动的方向=射线发出碰触到物体的点-鼠标最初点到物体上的点
                    mouseRun = hitRun.point - mouseStart;
                    //  Debug.Log(mouseRun.y);
                    //判断鼠标拖动的方向的长度是否大于0.2f,以此判断鼠标在魔方方体上滑动还是点击
                    if (mouseRun.sqrMagnitude > 0.2f)
                    {
                        float fMouseX2 = Input.GetAxis("Mouse X");
                        float fMouseY2 = Input.GetAxis("Mouse Y");
                        //求得触碰到的物体的法线与鼠标拖动的方向来判断旋转的轴向
                        mouseCross = Vector3.Cross(normal, mouseRun).normalized;
                        //   Debug.Log(mouseCross);
                        //调用旋转函数，求得旋转轴
                        if (islock)//是否没有方块旋转中
                        {

                            RotatePoint(mouseCross);
                        }
                        //滑动过后，将触碰到的物体置空，为下次滑动做准备
                        // cubeObject = null;
                    } 
                }
            }
        }


    }



    void RotatePoint(Vector3 cross)
    {
        Vector3 axisy = y1.position - y2.position;
        Vector3 axisx = y3.position - y4.position;
        Vector3 axisz = y5.position - y6.position;
        Vector3 negativeaxisy = -(y1.position - y2.position);
        Vector3 negativeaxisx = -(y3.position - y4.position);
        Vector3 negativeaxisz = -(y5.position - y6.position);
        Vector3[] normalloca = new Vector3[] { axisy, axisx, axisz, negativeaxisy, negativeaxisx, negativeaxisz };//轴向量
        //, -(y1.position - y2.position), -(y3.position - y4.position), -(y5.position - y6.position)
        //  Debug.Log(normalloca[1]);
        for (int i = 0; i < 6; i++)
        {
            Vector3 vec = normalloca[i];
            float dot = Vector3.Dot(vec, cross);//向量点乘
            //  Debug.Log(dot);
          
            float cos = dot / (Mathf.Sqrt(normalloca[i].x * normalloca[i].x + normalloca[i].y * normalloca[i].y + normalloca[i].z * normalloca[i].z)
                * Mathf.Sqrt(cross.x * cross.x + cross.y * cross.y + cross.z * cross.z));//求余弦公式
                                                                                                                                                    // Debug.Log(cos);
            if (dot > 0.01 || dot <= -0.01)
            {
                if (cos >= 0.9 && cos <= 1)
                {
                   // Debug.Log(normalloca[i]);
                    vecZhou = vec;
                    float l = vec[1];
                 ;
                    Debug.Log(i);
                    Rotatecube(i, vecZhou);
              
                }
            }
        }
    }

    void Rotatecube(int i,Vector3 yzhou)
    {

       
        GameObject[] cubediamond;
        cubediamond = GameObject.FindGameObjectsWithTag("cubediamond");//全部为此标签的物体成一个数组
     
        foreach (GameObject child in cubediamond)
        {
            float x;
            float y;
            float z;
            switch (i)
            {
                case 0://0对应y轴右旋转，当方块的y轴坐标为1时，则表明方块在顶面
                    y = child.transform.localPosition.y;

                    if (y >= hity- 0.05 && y <= hity + 0.05)//是否与点击方块在同一层，会有0.000几的偏差
                    { //wei= GameObject.Find("Cube (2)").GetComponent<weiyao> ();
                      // child.GetComponent<weiyao>().enabled = false;
                        if (y >= 1 - 0.05 && y <= 1 + 0.05) //当方块的y轴坐标为1时，则表明方块在顶面
                        {
                            //cube1
                            child.GetComponent<weiyao>().fuck(1, 0);//右旋转顶面


                        }
                        if (y >= -1 - 0.05 && y <= -1 + 0.05)//当方块的y轴坐标为-1时，则表明方块在底面
                        {

                            child.GetComponent<weiyao>().fuck(2, 0);//右旋转底面
                        }

                        // cube22.transform.RotateAround(obj.position, y1.position - y2.position, 90 * Time.deltaTime);

                    }
                    break;
                case 1:
                    x = child.transform.localPosition.x;


                    if (x >= hitx - 0.05 && x <= hitx + 0.05)
                    { //wei= GameObject.Find("Cube (2)").GetComponent<weiyao> ();
                      // child.GetComponent<weiyao>().enabled = false;
                        if (x >= 1 - 0.05 && x <= 1 + 0.05)
                        {
                            //cube1
                            child.GetComponent<weiyao>().fuck(3, 1);

                        }
                        if (x >= -1 - 0.05 && x <= -1 + 0.05)
                        {

                            child.GetComponent<weiyao>().fuck(4, 1);
                        }

                        // cube22.transform.RotateAround(obj.position, y1.position - y2.position, 90 * Time.deltaTime);

                    }
                    break;
                case 2:
                    z = child.transform.localPosition.z;


                    if (z >= hitz - 0.05 && z <= hitz + 0.05)
                    { //wei= GameObject.Find("Cube (2)").GetComponent<weiyao> ();
                      // child.GetComponent<weiyao>().enabled = false;
                        if (z >= 1 - 0.05 && z<= 1 + 0.05)
                        {
                            //cube1
                            child.GetComponent<weiyao>().fuck(5, 2);
                            //child.FindHideChildGameObject
                        }
                        if (z >= -1 - 0.05 && z <= -1 + 0.05)
                        {

                            child.GetComponent<weiyao>().fuck(6, 2);
                        }

                        // cube22.transform.RotateAround(obj.position, y1.position - y2.position, 90 * Time.deltaTime);

                    }
                    break;
                case 3:
                    y= child.transform.localPosition.y;


                    if (y >= hity - 0.05 && y<= hity + 0.05)
                    { //wei= GameObject.Find("Cube (2)").GetComponent<weiyao> ();
                      // child.GetComponent<weiyao>().enabled = false;
                        if (y >= 1 - 0.05 && y <= 1 + 0.05)
                        {
                            //cube1
                            child.GetComponent<weiyao>().fuck(1, 3);

                        }
                        if (y >= -1 - 0.05 && y <= -1 + 0.05)
                        {

                            child.GetComponent<weiyao>().fuck(2, 3);
                        }

                        // cube22.transform.RotateAround(obj.position, y1.position - y2.position, 90 * Time.deltaTime);

                    }
                    break;
                case 4:
                    x = child.transform.localPosition.x;


                    if (x >= hitx-0.05&& x <= hitx+ 0.05)
                    { //wei= GameObject.Find("Cube (2)").GetComponent<weiyao> ();
                       // child.GetComponent<weiyao>().enabled = false;
                        if (x >= 1- 0.05 && x <=1 + 0.05)
                        {
                            //cube1
                            child.GetComponent<weiyao>().fuck(3, 4);

                        }
                        if (x >= -1 - 0.05 && x <= -1 + 0.05)
                        {

                          child.GetComponent<weiyao>().fuck(4, 4);
                        }

                        // cube22.transform.RotateAround(obj.position, y1.position - y2.position, 90 * Time.deltaTime);

                    }
                    break;
                case 5:
                    z = child.transform.localPosition.z;
                    if (z >= hitz - 0.05 && z <= hitz + 0.05)
                    { //wei= GameObject.Find("Cube (2)").GetComponent<weiyao> ();
                      // child.GetComponent<weiyao>().enabled = false;
                        if (z >= 1 - 0.05 && z <= 1 + 0.05)
                        {
                            //cube1
                            child.GetComponent<weiyao>().fuck(5, 5);

                        }
                        if (z >= -1 - 0.05 && z <= -1 + 0.05)
                        {

                            child.GetComponent<weiyao>().fuck(6, 5);
                        }

                        // cube22.transform.RotateAround(obj.position, y1.position - y2.position, 90 * Time.deltaTime);

                    }
                    break;
            }

            //  Debug.Log("所有该脚本的物体下的子物体名称:" + child.name);
            //float x=  child.transform.localPosition.x;
        }


    }

 public   void lockcube(bool keep){
       // print("good");
        islock = keep;
    }
    public void buttonxuanzhun()
    {
        // print("good");
        buttonmofangturn = true;
    }
    public void candbuttonxuanzhun()
    {
        // print("good");
        buttonmofangturn =false;
    }
}
