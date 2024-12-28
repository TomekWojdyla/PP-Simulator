using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simulator;

public class Animals
{
    //Pola Prywatne
    private string _description = "Unknown"; //konwencja nazywania pól prywatnych _camelCase

    //Właściwości + gettery/settery
    public required string Description
    {
        get
        {
            return _description;
        }
        init
        {
            _description = Validator.Shortener(value, 3, 15, '#'); 
        }
    }
    public uint Size { get; set; } = 3;

    public virtual string Info { get; }
 

    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Description} {Info}<{Size}>";
    }
}
