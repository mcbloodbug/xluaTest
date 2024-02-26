--lua调用Csharp的方法

--local newGo =CS.UnityEngine.GameObject()
--newGo.name ="LuaGo"

--查找游戏物体，改名
print("Lua脚本启动")
local TexBeg = CS.UnityEngine.GameObject.Find("TextBeg1")
TexBeg.name ="Begin"

local textStart = TexBeg:GetComponent("UnityEngine.UI.Text")
textStart.text ="开始游戏"

