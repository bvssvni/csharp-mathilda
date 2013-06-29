csharp-mathilda
===============

A mathematical expression search library.  
![LGPL3 license](http://opensource.org/licenses/lgpl-3.0.html)

##Why The Name 'Mathilda'

'Math'ilda :-D

##How It Works

Some mathematical expressions are preferred even they express the same.  
For example:  

    a + a + b = b + a * 2 = a * 2 + b = 2 * a + b
    
Which of these do you prefer?  
Most people would prefer the last one.  

It turns out that expressions can be compared and sorted in a similar way to words.  
For example, expressions starting with numbers is 'less' than those starting with letters.  

    2 * a    is 'less' than     a * 2
    
By doing changes to the expression that preserve equality,  
we can transform it to a form with 'minimum ordering'.  
In the above example, '2 * a' is the smallest one by ordering.  

Assume that we have 2 expressions and we want to check for equivalence.  
It is a simple question, is the left side equal to the right side?

    left side = right side
    
Mathilda allows you to construct such expressions and check for equality.  
It is done by finding the 'minimum ordering' of the expressions and compare them.  

##Why Use It?

Mathematics becomes harder to program when it is based on high level abstractions.  
Examples of abstractions:

1. Vectors [x, y, z]
2. Quaternions [x, y, z, w]
3. Matrices [[m11, m21, m31], [m12, m22, m32], [m13, m23, m33]]

There are also other abstractions, like 'linear interpolation' that does not have a specific form.  

    a + (b - a) * t = a * (1-t) + b * t
    
The problem is that carrying out operations on unknowns manually is tedious,  
while we are very interested in the form that can be computed with ordinary addition and multiplication.  
Two forms can be equivalent for a specific input, which is difficult to prove using the abstractions alone,  
but hard to do manually, specially for stuff like 'dual quaternions'.  

MathildaLib solves this problem by offering a way to carry out computations on expressions. 

