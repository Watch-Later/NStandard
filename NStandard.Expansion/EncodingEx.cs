﻿using System.Text;

namespace NStandard
{
    /// <summary>
    /// [Refer] https://docs.microsoft.com/zh-cn/dotnet/api/system.text.encodinginfo.name?view=netcore-3.1
    /// </summary>
    public static class EncodingEx
    {
        static EncodingEx()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        public static Encoding ASMO_708 => Encoding.GetEncoding(708);
        public static Encoding BIG5 => Encoding.GetEncoding(950);
        public static Encoding CP1025 => Encoding.GetEncoding(21025);
        public static Encoding CP866 => Encoding.GetEncoding(866);
        public static Encoding CP875 => Encoding.GetEncoding(875);
        public static Encoding CSISO2022JP => Encoding.GetEncoding(50221);
        public static Encoding DOS_720 => Encoding.GetEncoding(720);
        public static Encoding DOS_862 => Encoding.GetEncoding(862);
        public static Encoding EUC_CN => Encoding.GetEncoding(51936);
        public static Encoding EUC_JP => Encoding.GetEncoding(51932);
        public static Encoding EUC_JP_1990 => Encoding.GetEncoding(20932);
        public static Encoding EUC_KR => Encoding.GetEncoding(51949);
        public static Encoding GB18030 => Encoding.GetEncoding(54936);
        public static Encoding GB2312 => Encoding.GetEncoding(936);
        public static Encoding HZ_GB_2312 => Encoding.GetEncoding(52936);
        public static Encoding IBM00858 => Encoding.GetEncoding(858);
        public static Encoding IBM00924 => Encoding.GetEncoding(20924);
        public static Encoding IBM01047 => Encoding.GetEncoding(1047);
        public static Encoding IBM01140 => Encoding.GetEncoding(1140);
        public static Encoding IBM01141 => Encoding.GetEncoding(1141);
        public static Encoding IBM01142 => Encoding.GetEncoding(1142);
        public static Encoding IBM01143 => Encoding.GetEncoding(1143);
        public static Encoding IBM01144 => Encoding.GetEncoding(1144);
        public static Encoding IBM01145 => Encoding.GetEncoding(1145);
        public static Encoding IBM01146 => Encoding.GetEncoding(1146);
        public static Encoding IBM01147 => Encoding.GetEncoding(1147);
        public static Encoding IBM01148 => Encoding.GetEncoding(1148);
        public static Encoding IBM01149 => Encoding.GetEncoding(1149);
        public static Encoding IBM037 => Encoding.GetEncoding(37);
        public static Encoding IBM1026 => Encoding.GetEncoding(1026);
        public static Encoding IBM273 => Encoding.GetEncoding(20273);
        public static Encoding IBM277 => Encoding.GetEncoding(20277);
        public static Encoding IBM278 => Encoding.GetEncoding(20278);
        public static Encoding IBM280 => Encoding.GetEncoding(20280);
        public static Encoding IBM284 => Encoding.GetEncoding(20284);
        public static Encoding IBM285 => Encoding.GetEncoding(20285);
        public static Encoding IBM290 => Encoding.GetEncoding(20290);
        public static Encoding IBM297 => Encoding.GetEncoding(20297);
        public static Encoding IBM420 => Encoding.GetEncoding(20420);
        public static Encoding IBM423 => Encoding.GetEncoding(20423);
        public static Encoding IBM424 => Encoding.GetEncoding(20424);
        public static Encoding IBM437 => Encoding.GetEncoding(437);
        public static Encoding IBM500 => Encoding.GetEncoding(500);
        public static Encoding IBM737 => Encoding.GetEncoding(737);
        public static Encoding IBM775 => Encoding.GetEncoding(775);
        public static Encoding IBM850 => Encoding.GetEncoding(850);
        public static Encoding IBM852 => Encoding.GetEncoding(852);
        public static Encoding IBM855 => Encoding.GetEncoding(855);
        public static Encoding IBM857 => Encoding.GetEncoding(857);
        public static Encoding IBM860 => Encoding.GetEncoding(860);
        public static Encoding IBM861 => Encoding.GetEncoding(861);
        public static Encoding IBM863 => Encoding.GetEncoding(863);
        public static Encoding IBM864 => Encoding.GetEncoding(864);
        public static Encoding IBM865 => Encoding.GetEncoding(865);
        public static Encoding IBM869 => Encoding.GetEncoding(869);
        public static Encoding IBM870 => Encoding.GetEncoding(870);
        public static Encoding IBM871 => Encoding.GetEncoding(20871);
        public static Encoding IBM880 => Encoding.GetEncoding(20880);
        public static Encoding IBM905 => Encoding.GetEncoding(20905);
        public static Encoding IBM_THAI => Encoding.GetEncoding(20838);
        public static Encoding ISO_2022_JP => Encoding.GetEncoding(50220);
        public static Encoding ISO_2022_JP_AllowOneByteKana => Encoding.GetEncoding(50222);
        public static Encoding ISO_2022_KR => Encoding.GetEncoding(50225);
        public static Encoding ISO_8859_1 => Encoding.GetEncoding(28591);
        public static Encoding ISO_8859_13 => Encoding.GetEncoding(28603);
        public static Encoding ISO_8859_15 => Encoding.GetEncoding(28605);
        public static Encoding ISO_8859_2 => Encoding.GetEncoding(28592);
        public static Encoding ISO_8859_3 => Encoding.GetEncoding(28593);
        public static Encoding ISO_8859_4 => Encoding.GetEncoding(28594);
        public static Encoding ISO_8859_5 => Encoding.GetEncoding(28595);
        public static Encoding ISO_8859_6 => Encoding.GetEncoding(28596);
        public static Encoding ISO_8859_7 => Encoding.GetEncoding(28597);
        public static Encoding ISO_8859_8 => Encoding.GetEncoding(28598);
        public static Encoding ISO_8859_8_I => Encoding.GetEncoding(38598);
        public static Encoding ISO_8859_9 => Encoding.GetEncoding(28599);
        public static Encoding JOHAB => Encoding.GetEncoding(1361);
        public static Encoding KOI8_R => Encoding.GetEncoding(20866);
        public static Encoding KOI8_U => Encoding.GetEncoding(21866);
        public static Encoding KS_C_5601_1987 => Encoding.GetEncoding(949);
        public static Encoding MACINTOSH => Encoding.GetEncoding(10000);
        public static Encoding SHIFT_JIS => Encoding.GetEncoding(932);
        public static Encoding US_ASCII => Encoding.GetEncoding(20127);
        public static Encoding UTF_16 => Encoding.GetEncoding(1200);
        public static Encoding UTF_16BE => Encoding.GetEncoding(1201);
        public static Encoding UTF_32 => Encoding.GetEncoding(12000);
        public static Encoding UTF_32BE => Encoding.GetEncoding(12001);
        public static Encoding UTF_7 => Encoding.GetEncoding(65000);
        public static Encoding UTF_8 => Encoding.GetEncoding(65001);
        public static Encoding WINDOWS_1250 => Encoding.GetEncoding(1250);
        public static Encoding WINDOWS_1251 => Encoding.GetEncoding(1251);
        public static Encoding WINDOWS_1252 => Encoding.GetEncoding(1252);
        public static Encoding WINDOWS_1253 => Encoding.GetEncoding(1253);
        public static Encoding WINDOWS_1254 => Encoding.GetEncoding(1254);
        public static Encoding WINDOWS_1255 => Encoding.GetEncoding(1255);
        public static Encoding WINDOWS_1256 => Encoding.GetEncoding(1256);
        public static Encoding WINDOWS_1257 => Encoding.GetEncoding(1257);
        public static Encoding WINDOWS_1258 => Encoding.GetEncoding(1258);
        public static Encoding WINDOWS_874 => Encoding.GetEncoding(874);
        public static Encoding X_CHINESE_CNS => Encoding.GetEncoding(20000);
        public static Encoding X_CHINESE_ETEN => Encoding.GetEncoding(20002);
        public static Encoding X_CP20001 => Encoding.GetEncoding(20001);
        public static Encoding X_CP20003 => Encoding.GetEncoding(20003);
        public static Encoding X_CP20004 => Encoding.GetEncoding(20004);
        public static Encoding X_CP20005 => Encoding.GetEncoding(20005);
        public static Encoding X_CP20261 => Encoding.GetEncoding(20261);
        public static Encoding X_CP20269 => Encoding.GetEncoding(20269);
        public static Encoding X_CP20936 => Encoding.GetEncoding(20936);
        public static Encoding X_CP20949 => Encoding.GetEncoding(20949);
        public static Encoding X_CP50227 => Encoding.GetEncoding(50227);
        public static Encoding X_EBCDIC_KOREANEXTENDED => Encoding.GetEncoding(20833);
        public static Encoding X_EUROPA => Encoding.GetEncoding(29001);
        public static Encoding X_IA5 => Encoding.GetEncoding(20105);
        public static Encoding X_IA5_GERMAN => Encoding.GetEncoding(20106);
        public static Encoding X_IA5_NORWEGIAN => Encoding.GetEncoding(20108);
        public static Encoding X_IA5_SWEDISH => Encoding.GetEncoding(20107);
        public static Encoding X_ISCII_AS => Encoding.GetEncoding(57006);
        public static Encoding X_ISCII_BE => Encoding.GetEncoding(57003);
        public static Encoding X_ISCII_DE => Encoding.GetEncoding(57002);
        public static Encoding X_ISCII_GU => Encoding.GetEncoding(57010);
        public static Encoding X_ISCII_KA => Encoding.GetEncoding(57008);
        public static Encoding X_ISCII_MA => Encoding.GetEncoding(57009);
        public static Encoding X_ISCII_OR => Encoding.GetEncoding(57007);
        public static Encoding X_ISCII_PA => Encoding.GetEncoding(57011);
        public static Encoding X_ISCII_TA => Encoding.GetEncoding(57004);
        public static Encoding X_ISCII_TE => Encoding.GetEncoding(57005);
        public static Encoding X_MAC_ARABIC => Encoding.GetEncoding(10004);
        public static Encoding X_MAC_CE => Encoding.GetEncoding(10029);
        public static Encoding X_MAC_CHINESESIMP => Encoding.GetEncoding(10008);
        public static Encoding X_MAC_CHINESETRAD => Encoding.GetEncoding(10002);
        public static Encoding X_MAC_CROATIAN => Encoding.GetEncoding(10082);
        public static Encoding X_MAC_CYRILLIC => Encoding.GetEncoding(10007);
        public static Encoding X_MAC_GREEK => Encoding.GetEncoding(10006);
        public static Encoding X_MAC_HEBREW => Encoding.GetEncoding(10005);
        public static Encoding X_MAC_ICELANDIC => Encoding.GetEncoding(10079);
        public static Encoding X_MAC_JAPANESE => Encoding.GetEncoding(10001);
        public static Encoding X_MAC_KOREAN => Encoding.GetEncoding(10003);
        public static Encoding X_MAC_ROMANIAN => Encoding.GetEncoding(10010);
        public static Encoding X_MAC_THAI => Encoding.GetEncoding(10021);
        public static Encoding X_MAC_TURKISH => Encoding.GetEncoding(10081);
        public static Encoding X_MAC_UKRAINIAN => Encoding.GetEncoding(10017);

    }
}
