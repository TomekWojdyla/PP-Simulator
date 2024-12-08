using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simulator;

internal class Animals
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
            string validatedDescription = value.Trim(); //Ucina białe znaki na początku i na końcu
            if (validatedDescription == "" || validatedDescription == null) //Wyłapanie sytuacji w której z nazwy nic nie zostało po Trim()
            {
                _description = "Unknown";
            }
            else
            {
                if (validatedDescription.Length < 3)
                {
                    validatedDescription = validatedDescription.PadRight(3, '#'); //Uzyskanie nazwy na min 3 znaki
                }
                else if (validatedDescription.Length > 15)
                {
                    validatedDescription = validatedDescription.Substring(0, 15).TrimEnd(); //ucięcie stringa do max 25 znaków + ucięcie białych znaków z końca
                    if (validatedDescription.Length < 3)
                    {
                        validatedDescription = validatedDescription.PadRight(3, '#'); //Uzyskanie nazwy na min 3 znaki
                    }
                }
                if (char.IsLower(validatedDescription[0]))
                {
                    validatedDescription = char.ToUpper(validatedDescription[0]) + validatedDescription.Substring(1); //Ustawienie pierwszej litery na wielka
                }
                _description = validatedDescription;
            }
        }
    }
    public uint Size { get; set; } = 3;

    public string Info
    {
        get { return $"{Description} <{Size}>"; }
    }
}
