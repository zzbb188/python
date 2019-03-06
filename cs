# 1.不能每次都真的 耗血
# 2. 伤害不能固定
# 3.鞭尸了 给个提示
import random
class Person:
    def __init__(self,name_str,life_num):
        self.name = name_str
        self.life = life_num

    def __str__(self):
        # 状态描述 0挂了 - 1 重伤 70 轻伤  99  100 无伤
        state = ""  # 假设状态变量
        if self.life == 0:
            state = "挂了"
        elif self.life >= 1 and self.life < 70:
            state = "重伤"
        elif self.life >= 70 and self.life <= 99:
            state = "轻伤"
        else:
            state = "无伤"

        return "%s处于%s状态" % (self.name, state)

class Is(Person):
    def fire(self,p):
        wei_li = random.randint(1, 5)  # 伤害值 不能固定
        range_num = random.randint(1, 100)
        if range_num >= 80:
            print("%s打中了%s消耗了%s血量值" % (self.name,p.name,wei_li))
            # 进行 生命值 负数 修复
            if p.life > wei_li:
                p.life -= wei_li
            else:
                p.life = 0
        else:
            print("%s没打着" % self.name)


class Hero(Person):
    def fire(self,p):   # self=h1  h1开枪 self就是h1 ,p=is1

        wei_li = random.randint(40,100)  # 伤害值 不能固定

        # 如果数值 在20====>80间内 就 让他 耗血,否则就没打中
        range_num = random.randint(1,100)
        if range_num >=20:  # 有时候可以 有时候不可以
            print("%s打中了%s消耗了%s血量值" % (self.name,p.name,wei_li))
            # 修复生命值为负的问题射击时如果生命值 > 伤害值常减生命，否则生命值 = 0，
            if p.life > wei_li:
                p.life -= wei_li
            else:
                p.life = 0
        else:
            print("%s没打中啊"%self.name)


h1 = Hero("盖伦",100)
# 1.整三个 匪徒
is1 = Is("不要命1",100)
is2 = Is("不要命2",100)
is3 = Is("不要命3",100)

while True:
    if h1.life <= 0:
        print("英雄阵亡")
        break
    # 4.英雄也要打三个人: 来个随机数  如果num==1 打is1  再如果 num==2 打is2  否则 就打 is3
    num = random.randint(1,3)
    if num == 1:
        if is1.life == 0:  # 如果被打的is1 的血量 是0了 但是又随机到了,就是鞭尸了
            print("你怎么在鞭尸啊,别打is1了")
        h1.fire(is1)

    elif num == 2:
        if is2.life == 0:
            print("你怎么在鞭尸啊,别打is2了")
        h1.fire(is2)
    else:
        if is3.life == 0:
            print("你怎么在鞭尸啊,别打is3了")
        h1.fire(is3)


    print(is1)
    print(is2)
    print(is3)

    # 2.判断:三个人 都死 游戏才结束
    if is1.life <= 0 and is2.life <= 0 and is3.life<=0:
        print("匪徒全部阵亡")
        break

    # 3.三个匪徒都开枪
    is1.fire(h1)
    is2.fire(h1)
    is3.fire(h1)

    print(h1)

