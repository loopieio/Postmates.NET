//-----------------------------------------------------------------------------
// FILE:	    StringHelper.cs
// CONTRIBUTOR: Marcus Bowyer
// COPYRIGHT:	Copyright (c) 2019 by Loopie, LLC.  All rights reserved.

using System;
using System.Globalization;
using System.Linq;

/// <summary>
/// Loopie string helper extension methods
/// </summary>
public static class StringHelper
{
    /// <summary>
    /// A collection of string helper methods
    /// </summary>
    private static readonly CultureInfo _cultureInfo = CultureInfo.InvariantCulture;

    /// <summary>
    /// Safe string to lower method
    /// </summary>
    public static string SafeToLower(this string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return string.Empty;
        }
        return value.ToLower();
    }

    /// <summary>
    /// Formats a string as a phone number e.g. (###) ###-####
    /// </summary>
    public static string ToPhoneNumber(this string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return string.Empty;
        }

        value = GetNumbers(value);

        if (value.Length > 10)
        {
            value = value.TrimStart('+');
            value = value.TrimStart('1');
        }
        return string.Format("{0:(###) ###-####}", Convert.ToUInt64(value));

    }

    /// <summary>
    /// Formats a string as a simple phone number e.g. ###-###-####
    /// </summary>
    public static string ToSimplePhoneNumber(this string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return string.Empty;
        }

        value = GetNumbers(value);

        if (value.Length > 10)
        {
            value = value.TrimStart('+');
            value = value.TrimStart('1');
        }
        return string.Format("{0:###-###-####}", Convert.ToUInt64(value));

    }

    /// <summary>
    /// Returns numbers from a string
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static string GetNumbers(string input)
    {
        return new string(input.Where(c => char.IsDigit(c)).ToArray());
    }

    /// <summary>
    /// Formats a string to title case
    /// </summary>
    public static string ToTitleCase(this string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return string.Empty;
        }
        CultureInfo cultureInfo = new CultureInfo("en-US");
        TextInfo textInfo = cultureInfo.TextInfo;

        return textInfo.ToTitleCase(value);
        ;

    }

    /// <summary>
    /// Properly formats a US address
    /// </summary>
    public static string ToAddress(this string value)
    {

        if (string.IsNullOrEmpty(value))
        {
            return string.Empty;
        }

        // set all chars to lowercase
        value = value.ToLower();

        // make the words we want to be uppercase uppercase 
        // TextInfo.ToTitleCase ignores all caps words


        TextInfo myTI = new CultureInfo("en-US", false).TextInfo;
        value = myTI.ToTitleCase(value);

        return value.Trim();
    }

    /// <summary>
    /// Strips off leading and trailing whitespace as well as any
    /// runs of multiple spaces.
    /// </summary>
    /// <param name="value"></param>
    /// <returns>The cleaned output.</returns>
    public static string TrimWhitespace(this string value)
    {
        if (value == null)
        {
            return null;
        }

        value = value.Trim();

        while (value.Contains("  "))
        {
            value = value.Replace("  ", " ");
        }

        return value;
    }

    /// <summary>
    /// Returns whether a string is a number or not
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool IsNumeric(this string value)
    {
        return int.TryParse(value, out int number);
    }


}