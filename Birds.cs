using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class Birds : Animals
{
    //Pola prywatne
    private bool _canFly = true;

    //Właściwości
    public bool CanFly
    {
        get { return _canFly; }
        init { _canFly = value; }
    }

    public override string Info
    {
        get { return CanFly == true ? "(fly+) " : "(fly-) "; }
    }
}
