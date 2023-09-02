using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading.Tasks;

public class CSharpCode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Test01_ForDelListElement();
        //Test02_ForeachDelListElement();
        Test03_CSharpClosure();
    }
    #region 01.For循环删除集合元素
    void Test01_ForDelListElement()
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
        for (int i = list.Count - 1; i >= 0; i--)
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

    #region 02.Foreach删除集合元素
    void Test02_ForeachDelListElement()
    {
        //经典错误：集合不能被修改
        //List<string> colors = new List<string>() { "red", "green", "blue", "blue", "gray", "yellow", "white", "orange" };
        //foreach (var item in colors)
        //{
        //    if ("blue".Equals(item))
        //    {
        //        colors.Remove("blue");
        //    }
        //}
        //colors.ForEach(p => { Debug.LogWarning(p); });


        //用递归的思想，删除完了的集合重新遍历
        List<string> colors = new List<string>() { "red", "green", "blue", "blue", "gray", "yellow", "white", "orange" };
        DeleteElement(colors, "blue");

        colors.ForEach(p => { Debug.LogWarning(p); });
    }


    void DeleteElement(List<string> list, string delStr)
    {
        foreach (var item in list)
        {
            if (delStr.Equals(item))
            {
                list.Remove(item);

                //用递归的思想，删除完了的集合重新遍历
                DeleteElement(list, delStr);
                return;
            }
        }
    }

    #endregion


    #region 03.C#闭包问题
    void Test03_CSharpClosure()
    {
        ////打印6次6，错误的，for循环之后i的值变为6，actions调用时捕获的变量都是6
        //List<Action> actions = new List<Action>();
        //for (int i = 0; i < 6; i++)
        //{
        //    actions.Add(() => Debug.LogWarning(i));
        //}
        //foreach (var item in actions)
        //{
        //    item();
        //}

        //打印0-5，正确的
        //List<Action> actions = new List<Action>();
        //for (int i = 0; i < 6; i++)
        //{
        //    int num = i;
        //    actions.Add(() => Debug.LogWarning(num));
        //}
        //foreach (var item in actions)
        //{
        //    item();
        //}


        ////Task任务也存在闭包的问题
        ////打印的完全为6
        //for (int i = 0; i < 6; i++)
        //{
        //    Task.Run(() => { Debug.LogWarning(i); });
        //}


        ////打印0-5，但是是无序的
        //for (int i = 0; i < 6; i++)
        //{
        //    int num = i;
        //    Task.Run(() => { Debug.LogWarning(num); });
        //}

        //Wait方法可以解决，打印0-5
        for (int i = 0; i < 6; i++)
        {
            Task task = Task.Run(() => { Debug.LogWarning(i); });
            task.Wait();
        }

        //foreach没有闭包问题
        //打印1-6
        List<Action> actions = new List<Action>();
        int[] nums = new int[] { 1, 2, 3, 4, 5, 6 };
        foreach (var item in nums)
        {
            actions.Add(() => { Debug.LogWarning(item); });
        }
        foreach (var item in actions)
        {
            item();
        }
    }
    #endregion
}
