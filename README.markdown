Instead of this:


     if( x != null && x.Length > 0 && x.Contains(foo) )
     {
        //Do Stuff
     }




the mathematician in me wants to be able to write code like this:

    if( xs.IsNotEmpty().Implies(xs.Contains(foo)) )
    {
        //Do Stuff
    }




