﻿using System;
// *Abstract Parent Child Implementation 2
abstract class A
{
    public abstract void MethodA();
}
abstract class B : A
{
    public abstract void MethodB();
    public override void MethodA()
    {
        //...
    }
}
class C : B
{
    public override void MethodB()
    {
        // !remember below will crash your program
        throw new NotImplementedException();
    }
}
