using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragRound : MonoBehaviour {
    private Vector3 normal;
    private Vector3 mouseStart;
    private GameObject cubeObject;
    public Transform obj;
    public float speed = 2;
    private float timeadd;
    private bool isjishi;
    private bool _mouseDown = false;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))//只是按下那一瞬
        {
            isjishi = true;
            _mouseDown = true;
           // print(timeadd);
            //从屏幕发出一条射线到鼠标的位置
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //定义一个获取射线目标点物体的变量
            RaycastHit hitStart;
            //从刚才点击屏幕的射线的初始点，发射一条跟刚才射线方向一样的射线，并返回射线目标体的属性

            if (Physics.Raycast(ray.origin, ray.direction, out hitStart))
            {
                //鼠标点到的物体就是射线碰触到的目标物体
                cubeObject = hitStart.transform.gameObject;
                _mouseDown = false;
                

            }

        }
        else if (Input.GetMouseButtonUp(0))
        {
            isjishi = false;
              _mouseDown = false;
            timeadd = 0;
        }
        if (isjishi)
        {

            timeadd += Time.deltaTime;
        }
        if (_mouseDown)
        {
            if (timeadd>=0.1)
            {
                float fMouseX = Input.GetAxis("Mouse X");
                float fMouseY = Input.GetAxis("Mouse Y");
                obj.Rotate(Vector3.up, -fMouseX * speed/2, Space.World);
                obj.Rotate(Vector3.right, fMouseY * speed, Space.World);

            }
        }
    }
}
