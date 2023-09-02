using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSharpCode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Test01_ForDelElement();
    }
    #region 01.For循环删除集合元素
    void Test01_ForDelElement()
    {
        //错误代码 虽然可以跑起来看似是正常的 有错误
        //List<string> list = new List<string>() { "red", "green", "blue", "gray", "yellow", "white", "orange" };
        //for (int i = 0; i < list.Count; i++)
        //{
        //    if (list[i].Equals("blue"))
        //    {
        //        list.Remove("blue");
        //    }
        //}
        //list.ForEach(p => { Debug.LogWarning(p); });


        //错误代码 连续两个"blue"只能删除一个
        //        List<string> list = new List<string>() { "red", "green", "blue", "blue", "gray", "yellow", "white", "orange" };
        ////                                                  0       1       2       3       4 
        ////                                                                 删除2元素,原来3元素会填充到2的位置，3位置会变为“gray”
        //        for (int i = 0; i < list.Count; i++)
        //        {
        //            if (list[i].Equals("blue"))
        //            {
        //                list.Remove("blue");
        //            }
        //        }
        //        list.ForEach(p => { Debug.LogWarning(p); });


        //从后面往前删除
        List<string> list = new List<string>() { "red", "green", "blue", "blue", "gray", "yellow", "white", "orange" };
        for (int i = list.Count-1; i >=0 ; i--)
        {
            //if (list[i].Equals("blue"))
            //优化：常量在前面 后面的值可能为空会报异常
            if ("blue".Equals(list[i]))
            {
                list.Remove("blue");
            }
        }
        list.ForEach(p => { Debug.LogWarning(p); });
    }


    #endregion
}
