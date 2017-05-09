using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComplexNumber
{
    public float a;
    public float b;

    public ComplexNumber(float a, float b)
    {
        this.a = a;
        this.b = b;
    }

    public static ComplexNumber operator* (ComplexNumber x, ComplexNumber y)
    {
        return new ComplexNumber((x.a * y.a) - (x.b * y.b), (x.a * y.b) + (x.b * y.a)); 
    }

    public static ComplexNumber operator +(ComplexNumber x, ComplexNumber y)
    {
        return new ComplexNumber(x.a + y.a, x.b + y.b);
    }

    public override string ToString()
    {
        return a + " + " + b + "i";
    }
}
