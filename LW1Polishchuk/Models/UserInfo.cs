using System;

namespace KMA.ProgrammingInCSharp.LW1Polishchuk.Models
{
    public class UserInfo
    {
        public DateTime BirthDay { get; set; }
        
        public ChineseHoroscopeSign ChineseHoroscopeSign { get; set; }

        public ZodiacSign ZodiacSign { get; set; }

        public UserInfo(DateTime birthDay)
        {
            BirthDay = birthDay;
            ChineseHoroscopeSign = GetChineseSign(birthDay);
            ZodiacSign = GetZodiacSign(birthDay);
        }

        private static ChineseHoroscopeSign GetChineseSign(DateTime dateTime) => (ChineseHoroscopeSign) (dateTime.Year % 12);

        private static ZodiacSign GetZodiacSign(DateTime dateTime)
        {
            ZodiacSign zodiac;
            switch (dateTime.Month)
            {
                case 1: zodiac = dateTime.Day <= 20 ? ZodiacSign.Capricorn : ZodiacSign.Aquarius; break;
                case 2: zodiac = dateTime.Day <= 18 ? ZodiacSign.Aquarius : ZodiacSign.Pisces; break;
                case 3: zodiac = dateTime.Day <= 20 ? ZodiacSign.Pisces : ZodiacSign.Aries; break;
                case 4: zodiac = dateTime.Day <= 20 ? ZodiacSign.Aries : ZodiacSign.Taurus; break;
                case 5: zodiac = dateTime.Day <= 21 ? ZodiacSign.Taurus : ZodiacSign.Gemini; break;
                case 6: zodiac = dateTime.Day <= 21 ? ZodiacSign.Gemini : ZodiacSign.Cancer; break;
                case 7: zodiac = dateTime.Day <= 22 ? ZodiacSign.Cancer : ZodiacSign.Leo; break;
                case 8: zodiac = dateTime.Day <= 23 ? ZodiacSign.Leo : ZodiacSign.Virgo; break;
                case 9: zodiac = dateTime.Day <= 22 ? ZodiacSign.Virgo : ZodiacSign.Libra; break;
                case 10: zodiac = dateTime.Day <= 23 ? ZodiacSign.Libra : ZodiacSign.Scorpio; break;
                case 11: zodiac = dateTime.Day <= 22 ? ZodiacSign.Scorpio : ZodiacSign.Sagittarius; break;
                case 12: zodiac = dateTime.Day <= 21 ? ZodiacSign.Sagittarius : ZodiacSign.Capricorn; break;
                default: goto case 1;
            }

            return zodiac;
        }
    }
}