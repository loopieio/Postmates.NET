//-----------------------------------------------------------------------------
// FILE:	    UsStates.cs
// CONTRIBUTOR: Marcus Bowyer
// COPYRIGHT:	Copyright (c) 2017-2018 by Loopie, LLC.  All rights reserved.

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using System.Runtime.Serialization;

namespace Postmates.Model
{
    /// <summary>
    /// Enumerates the US States, Commonwealth, and Territories.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum UsStates
    {
        /// <summary>
        /// No state code is specified.
        /// </summary>
        [EnumMember(Value = "unspecified")]
        Unspecified = 0,

        //-------------------------------------------------
        // States

        /// <summary>
        /// Alabama
        /// </summary>
        [EnumMember(Value = "AL")]
        AL,

        /// <summary>
        /// Alaska
        /// </summary>
        [EnumMember(Value = "AK")]
        AK,

        /// <summary>
        /// Arizona
        /// </summary>
        [EnumMember(Value = "AZ")]
        AZ,

        /// <summary>
        /// Arkansas
        /// </summary>
        [EnumMember(Value = "AR")]
        AR,

        /// <summary>
        /// California
        /// </summary>
        [EnumMember(Value = "CA")]
        CA,

        /// <summary>
        /// Colorado
        /// </summary>
        [EnumMember(Value = "CO")]
        CO,

        /// <summary>
        /// Connecticut
        /// </summary>
        [EnumMember(Value = "CT")]
        CT,

        /// <summary>
        /// Delaware
        /// </summary>
        [EnumMember(Value = "DE")]
        DE,

        /// <summary>
        /// Florida
        /// </summary>
        [EnumMember(Value = "FL")]
        FL,

        /// <summary>
        /// Georgia
        /// </summary>
        [EnumMember(Value = "GA")]
        GA,

        /// <summary>
        /// Hawaii
        /// </summary>
        [EnumMember(Value = "HI")]
        HI,

        /// <summary>
        /// Idaho
        /// </summary>
        [EnumMember(Value = "ID")]
        ID,

        /// <summary>
        /// Illinois
        /// </summary>
        [EnumMember(Value = "IL")]
        IL,

        /// <summary>
        /// Indiana
        /// </summary>
        [EnumMember(Value = "IN")]
        IN,

        /// <summary>
        /// Iowa
        /// </summary>
        [EnumMember(Value = "IA")]
        IA,

        /// <summary>
        /// Kansas
        /// </summary>
        [EnumMember(Value = "KS")]
        KS,

        /// <summary>
        /// Kentucky
        /// </summary>
        [EnumMember(Value = "KY")]
        KY,

        /// <summary>
        /// Louisiana
        /// </summary>
        [EnumMember(Value = "LA")]
        LA,

        /// <summary>
        /// Maine
        /// </summary>
        [EnumMember(Value = "ME")]
        ME,

        /// <summary>
        /// Maryland
        /// </summary>
        [EnumMember(Value = "MD")]
        MD,

        /// <summary>
        /// Massachusetts
        /// </summary>
        [EnumMember(Value = "MA")]
        MA,

        /// <summary>
        /// Michigan
        /// </summary>
        [EnumMember(Value = "MI")]
        MI,

        /// <summary>
        /// Minnesota
        /// </summary>
        [EnumMember(Value = "MN")]
        MN,

        /// <summary>
        /// Mississippi
        /// </summary>
        [EnumMember(Value = "MS")]
        MS,

        /// <summary>
        /// Missouri
        /// </summary>
        [EnumMember(Value = "MO")]
        MO,

        /// <summary>
        /// Montana
        /// </summary>
        [EnumMember(Value = "MT")]
        MT,

        /// <summary>
        /// Nebraska
        /// </summary>
        [EnumMember(Value = "NE")]
        NE,

        /// <summary>
        /// Nevada
        /// </summary>
        [EnumMember(Value = "NV")]
        NV,

        /// <summary>
        /// New Hampshire
        /// </summary>
        [EnumMember(Value = "NH")]
        NH,

        /// <summary>
        /// New Jersey
        /// </summary>
        [EnumMember(Value = "NJ")]
        NJ,

        /// <summary>
        /// New Mexico
        /// </summary>
        [EnumMember(Value = "NM")]
        NM,

        /// <summary>
        /// New York
        /// </summary>
        [EnumMember(Value = "NY")]
        NY,

        /// <summary>
        /// North Carolina
        /// </summary>
        [EnumMember(Value = "NC")]
        NC,

        /// <summary>
        /// North Dakota
        /// </summary>
        [EnumMember(Value = "ND")]
        ND,

        /// <summary>
        /// Ohio
        /// </summary>
        [EnumMember(Value = "OH")]
        OH,

        /// <summary>
        /// Oklahoma
        /// </summary>
        [EnumMember(Value = "OK")]
        OK,

        /// <summary>
        /// Oregon
        /// </summary>
        [EnumMember(Value = "OR")]
        OR,

        /// <summary>
        /// Pennsylvania
        /// </summary>
        [EnumMember(Value = "PA")]
        PA,

        /// <summary>
        /// Rhode Island
        /// </summary>
        [EnumMember(Value = "RI")]
        RI,

        /// <summary>
        /// South Carolina
        /// </summary>
        [EnumMember(Value = "SC")]
        SC,

        /// <summary>
        /// South Dakota
        /// </summary>
        [EnumMember(Value = "SD")]
        SD,

        /// <summary>
        /// Tennessee
        /// </summary>
        [EnumMember(Value = "TN")]
        TN,

        /// <summary>
        /// Texas
        /// </summary>
        [EnumMember(Value = "TX")]
        TX,

        /// <summary>
        /// Utah
        /// </summary>
        [EnumMember(Value = "UT")]
        UT,

        /// <summary>
        /// Vermont
        /// </summary>
        [EnumMember(Value = "VT")]
        VT,

        /// <summary>
        /// Virginia
        /// </summary>
        [EnumMember(Value = "VA")]
        VA,

        /// <summary>
        /// Washington
        /// </summary>
        [EnumMember(Value = "WA")]
        WA,

        /// <summary>
        /// West Virginia
        /// </summary>
        [EnumMember(Value = "WV")]
        WV,

        /// <summary>
        /// Wisconsin
        /// </summary>
        [EnumMember(Value = "WI")]
        WI,

        /// <summary>
        /// Wyoming
        /// </summary>
        [EnumMember(Value = "WY")]
        WY,

        //-------------------------------------------------
        // Territories

        /// <summary>
        /// American Samoa
        /// </summary>
        [EnumMember(Value = "AS")]
        AS,

        /// <summary>
        /// District of Columbia
        /// </summary>
        [EnumMember(Value = "DC")]
        DC,

        /// <summary>
        /// Federated States of Micronesia
        /// </summary>
        [EnumMember(Value = "FM")]
        FM,

        /// <summary>
        /// Guam
        /// </summary>
        [EnumMember(Value = "GU")]
        GU,

        /// <summary>
        /// Marshall Islands
        /// </summary>
        [EnumMember(Value = "MH")]
        MH,

        /// <summary>
        /// Northern Mariana Islands
        /// </summary>
        [EnumMember(Value = "MP")]
        MP,

        /// <summary>
        /// Palau
        /// </summary>
        [EnumMember(Value = "PW")]
        PW,

        /// <summary>
        /// Puerto Rico
        /// </summary>
        [EnumMember(Value = "PR")]
        PR,

        /// <summary>
        /// Virgin Islands
        /// </summary>
        [EnumMember(Value = "VI")]
        VI
    }
}
