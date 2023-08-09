using System.Text;

// Init string
string str1;
string str2 = null;
string str3 = String.Empty;

//To String Connversion
int myInt = 32;
float floatingPoint = 42.98f;
char c = 'c';
bool t = true;

Console.WriteLine(myInt.ToString());
Console.WriteLine(floatingPoint.ToString());
Console.WriteLine(c.ToString());
Console.WriteLine(t.ToString());

//Verbatum
string str4 = "C:\\Program Files\\Steam";
string str5 = @"C:\Program Files\Steam";
string str6 = @$"C:\Program Files\Steam {floatingPoint}";

Console.WriteLine(str4);
Console.WriteLine(str5);
Console.WriteLine(str6);

//Escape Sequences
string str7 = "Waduh\n\n";
string str8 = "Wa\td\tuh";

Console.WriteLine(str7);
Console.WriteLine(str8);

//Implicit String
var str9 = "wanjay";

//Constant string
const string str10 = "wanjay waduh";

//Char Array to String
char[] charArr = { 'a', 'b', 'c', 'd', 'e' };
string str11 = new string(charArr);

Console.WriteLine(str9);
Console.WriteLine(str10);
Console.WriteLine(str11);

//String Interpolation and String Formating
int num = 15;
string str12 = $"\nI Have {num} Apples";
string str13 = String.Format("{0}\nI am Going To Eat All The {1} Apples", str12, num);

Console.WriteLine(str13);

// Substring
string mainString = "Goku is Verry Strong";
string subString = mainString.Substring(8, 5);
string subString2 = "Strong";
Console.WriteLine(subString);
Console.WriteLine(mainString.Replace(subString, "Very"));
Console.WriteLine(mainString.Replace(subString2, "Powerful"));

//Index Searching
Console.WriteLine(
    $"{subString2} is positioned {mainString.IndexOf(subString2)} In \"{mainString}\" string"
);

// Is not performant
const string goku = "goku";
for (int i = 0; i < goku.Length; i++)
{
    Console.Write(goku[goku.Length - i - 1]);
}
Console.WriteLine();

//Use String Builder Instead
StringBuilder sb = new StringBuilder();
sb.AppendLine("The sun was setting over the horizon,");
sb.AppendLine("casting a warm glow across the tranquil landscape.");
sb.AppendLine("Birds chirped softly in the trees,");
sb.AppendLine("creating a soothing melody that filled the air.");
sb.AppendLine("It was a moment of pure serenity.");

sb[5] = 'a';

System.Console.WriteLine(sb.ToString());

Console.ReadKey();
