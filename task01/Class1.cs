namespace task01;

public static class StringExtensions
{ 
    public static bool IsPalindrome(this string s)
    {
        if(string.IsNullOrEmpty(s)) return false;
        s = new String(s.ToLower().Where(c => !char.IsPunctuation(c) && !char.IsWhiteSpace(c)).ToArray());
        return s == new string(s.Reverse().ToArray());
    }
}
    