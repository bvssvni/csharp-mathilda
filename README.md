csharp-mathilda
===============

A mathematical number construction library.  
![LGPL3 license](http://opensource.org/licenses/lgpl-3.0.html)

##Why The Name 'Mathilda'

'Math'ilda :-D

##How It Works

Universal algebra is defined by rules of what operations are allowed on numbers.  
The most known example of a constructed number is the complex number.  
With complex numbers, you can multiply, divide and add just like with ordinary numbers.  
Complex numbers are useful to describe rotation.  

There is another kind of number called "dual number" which computes derivates.  
This is particularly useful when you want to study infinitesimal changes.  

You can combine numbers together, for example:  

    Complex<Dual<Scalar>>
    Complex<Complex<Scalar>>

The way you construct numbers control how it behaves under multiplication.  

Mathilda was designed to make it easy to construct new numbers and study them.  
It is not designed for speed, but for flexibility.  
