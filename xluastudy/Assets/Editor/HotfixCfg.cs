using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
public static class HotfixCfg
{
    [Hotfix]
    public static List<Type> by_field = new List<Type>()
    { 
        typeof(Load),
        typeof(Cube),
        typeof(ButtonControl)
    };

 
}
