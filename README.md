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
