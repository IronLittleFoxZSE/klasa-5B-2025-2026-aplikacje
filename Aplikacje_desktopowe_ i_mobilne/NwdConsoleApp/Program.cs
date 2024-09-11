
Console.WriteLine("Podaj a");
uint a = uint.Parse(Console.ReadLine());

/*if (a < 0)
{
    Console.WriteLine("Niepoprawna dana");
    return;
}*/

Console.WriteLine("Podaj b");
uint b = uint.Parse(Console.ReadLine());
//c++: unsigned int b;

a = NWD(a, b);

Console.WriteLine("NWD = " + a);

/*
 **********************************************
nazwa funkcji: NWD
opis funkcji: wyznacza największy wspólny dzielnik dwóch liczb
parametry: a - pierwsza liczba
           b - druga liczba
zwracany typ i opis: uint - największy wspólny dzielnik
autor: <numer zdającego>
*********************************************** 
*/
uint NWD(uint a, uint b)
{
    while (a != b)
    {
        if (a > b)
            a = a - b;
        else
            b = b - a;
    }
    return a;
}
