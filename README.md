# CSharpCode

##01.For循环删除集合元素
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


##02.Foreach删除集合元素
        //用递归的思想，删除完了的集合重新遍历
        List<string> colors = new List<string>() { "red", "green", "blue", "blue", "gray", "yellow", "white", "orange" };
        DeleteElement(colors, "blue");

        colors.ForEach(p => { Debug.LogWarning(p); });


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
