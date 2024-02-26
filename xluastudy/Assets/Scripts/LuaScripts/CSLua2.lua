ganlan = {s1="吃饭",s2="喝水",s3="睡觉",s4="走路"}

gameUser ={

name ="老虎",
age =25,
ID ="88888",
Speak= function ()
	print(string.format("%s游戏玩家说话", gameUser.name))
end ,
walking = function () 
	print(string.format("%s玩家在运动", gameUser.name))
end,
    culate = function (self, num1, num2)
        return self.age + num1 + num2
    end
}

function MyFunc1()
	print("MyFunc1 是无参函数")
	end

function MyFunc2(num1,num2)
	print("MyFunc2 是有参函数+"..num1+num2)
end

function MyFunc3(num1,num2)
	print("有返回值函数")
	return num1+num2
end

function MyFunc4(num1,num2)
	local result =num1+num2
	print(string.format("输出结果=%d+%d=%d",num1,num2,result))
	return num1,num2,result
end