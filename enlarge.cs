using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enlarge : MonoBehaviour {

    private float mx;
    private float my;

    private float xSpeed = 3;
    private float ySpeed = 3;

    private Vector2 start;
    private Quaternion mRoation;

    void Start()
    {
        Input.multiTouchEnabled = true;

    }

    // Update is called once per frame  
    void Update()
    {
        MoblieInput();

    }

    void MoblieInput()
    {
        if (Input.touchCount == 0)
        {
            return;
        }

        if (Input.touchCount == 1)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                start = Input.touches[0].position;


            }

            if (Input.touches[0].phase == TouchPhase.Moved)
            {
             //   mx += Input.touches[0].deltaPosition.x * xSpeed;
             //   my += Input.touches[0].deltaPosition.y * ySpeed; ;

            }

         //   mRoation = Quaternion.Euler(mx, my, 0);
           /// transform.rotation = mRoation;



        }

        else if (Input.touchCount > 1)
        {
            Vector2 finger1 = new Vector2();
            Vector2 finger2 = new Vector2();

            Vector2 mov1 = new Vector2();
            Vector2 mov2 = new Vector2();

            //  Vector2 mov = new Vector2();  

            for (int i = 0; i < 2; i++)
            {
                Touch touch = Input.touches[i];//上一帧触摸状态

                if (touch.phase == TouchPhase.Ended)
                {
                    break;
                }

                if (touch.phase == TouchPhase.Moved)
                {
                    float mov = 0;

                    if (i == 0)
                    {
                        finger1 = touch.position;
                        mov1 = touch.deltaPosition;

                    }
                    else
                    {
                        finger2 = touch.position;
                        mov2= touch.deltaPosition;

                        //开始做移动判断  
                        if (finger1.x > finger2.x)
                        {
                            mov = mov1.x;

                        }
                        else
                        {
                            mov = mov2.x;
                        }

                        if (finger1.y > finger2.y)
                        {
                            mov += mov1.y;
                        }
                        else
                        {
                            mov += mov2.y;
                        }

                    }

                    Camera.main.transform.Translate(0, 0, mov * Time.deltaTime);//主要通过控制主摄像的远近来放大缩小  

                }
            }


        }
    }
}
