namespace task01;

public static class StringExtensions
{ 
    public static bool IsPalindrome(this string s)
    {
        s = new String(s.Where(c => !char.IsPunctuation(c) && !char.IsWhiteSpace(c)).ToArray());
        return s == new string(s.Reverse().ToArray());
    }
}
    