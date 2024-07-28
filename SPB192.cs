using System; 
using System.Text; 

namespace SpbAlgorithm
{
    public class SPB192
    {
        public static uint GodKey = 0x300AE7F5;
        public static string Hash(string message)
        {
            uint e1 = 0x76662797;
            uint e2 = 0xA2F0528E;
            uint e3 = 0x2E9A9A9C;
            uint e4 = 0x663085B9;
            uint e5 = 0xED51D495;
            uint e6 = 0x6F4DBBAC;
            uint e7 = 0x7D43ADBE;
            uint e8 = 0xB6A6A797;
            uint e9 = 0xED51D495;
            uint e10 = 0xB6A6A797;
            uint e11 = 0x2630D28E;
            uint e12 = 0xAF43ADC1;

            uint[] Angels = new uint[] {

                0x40079CB5,0x084DD54F,0xB74D07D9,0xAF4D84B7,0x19218496,0x2811AD87
                ,0xAD4DD4A1,0xA80D9D94,0x3587D960,0xB0078E69,0xB00D84CC,0x058F9031
                ,0x280DA810,0x058FA3C8,0xAE9A7407,0x2551AD8F,0x374DBF7A,0x258FA186
                ,0x8741D3E3,0xA312D4F0,0xF8189A87,0xB5DABDD3,0x264FBDD3,0x9BDABDD3
        };
            uint[] key = new uint[] {

                0x374D07E4,0xA697DC04,0x26811752,0xA89107E4,0x255107E4,0x738EDC04
,0x680D07E4,0x738EDC04,0x380DDC04,0x088BE8EA,0xAD473E42,0x2911ACEA
,0x800D07E4,0x3F4D0755,0x380AE804,0xA61107E4,0x255107E4,0x3306FBE4
,0x2E90A0AC,0x259249E2,0x738EDC04,0x380AE804,0x260AE804,0xAB0DDC04
,0x374D07E4,0x2B0D07E4,0xAB0FFBE4,0x068D07E4,0xB00CDC04,0x380CDC04
,0x2551A643,0x0006E804,0x680D07E4,0x802B04FB,0xA75199AD,0x25904500
,0xAD5107E4,0x2D920DDD,0xA80FFBE4,0x3F4D8F00,0xB007BAD4,0x2617DC04
,0xB006E804,0x380AE804,0xA80D07E4,0x680D07E4,0xED51D495,0x3746E804
,0x380AE804,0x2D9245F6,0x281107E4,0xA58EDC04,0xA60AE804,0xB80FFBE4
,0x800D07E4,0x281107E4,0x375107E4,0x260AE804,0x374AE804,0x3006FBE4
,0xA806FBE4,0xB605FBE4,0x300CDC04,0x2686E804,0xA58EDC04,0x280D07E4
,0x300CDC04,0xB80DDC04,0x375107E4,0x261107E4,0xAE44F50C,0xB617DC04
,0x254AE804,0x255107E4,0x0843CC04,0x080CDC04,0x255107E4,0xA60AE804
,0xA61107E4,0xA74B279F,0x273EB7E4,0x080CDC04,0x261107E4,0x080CDC04
,0xB81107E4,0xAF5107E4,0x680D07E4,0x280D07E4,0x3806E804,0xA817DC04
,0x2605FBE4,0x8821CC04,0xAE1107E4,0x2B0D07E4,0x2443CC04,0xB00CDC04
,0x080D07E4,0x2F41CC04,0xA80DDC04,0xA74D07E4,0x080D07E4,0x273EB7E4
,0xA74D07E4,0xAD84FBE4,0x673CCC04,0x2807C009,0x255107E4,0x330CDC04
,0x884D07E4,0xA89107E4,0x255107E4,0x260AE804,0x280CDC04,0xA61107E4
            };



            StringBuilder FirstTextByte = new StringBuilder();
            StringBuilder FirstTextlength = new StringBuilder();

            foreach (char c in message.ToCharArray())
            {
                FirstTextByte.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
            }
            int FirstTextByte_length = FirstTextByte.Length;
            FirstTextByte.Append(1);
            FirstTextByte.Append(1);
            FirstTextByte.Append(0);
            while ((FirstTextByte.Length % 768) != 704)
            {
                FirstTextByte.Append(0);
            }
            FirstTextlength.Append(Convert.ToString(GodKey + FirstTextByte_length, 2).PadLeft(64, '0'));
            FirstTextByte.Append(FirstTextlength.ToString());

            //----------------------------------------

            int TempBytelength = FirstTextByte.ToString().Length / 768;
            string[] TempByteArray = new string[TempBytelength];
            for (int i = 0, k = 0; i < FirstTextByte.ToString().Length; i += 768, k++)
            {
                TempByteArray[k] = FirstTextByte.ToString().Substring(i, 768);
            }

            for (int x = 0; x < TempBytelength; x++)
            {
                uint[] AngelArray = new uint[24];

                uint[] splitByte = new uint[TempByteArray[x].Length / 32];
                for (int i = 0, k = 0; i < TempByteArray[x].Length; i += 32, k++)
                {
                    splitByte[k] = Convert.ToUInt32(TempByteArray[x].Substring(i, 32), 2);
                }

                for (int i = 0; i <= 23; i++)
                {
                    AngelArray[i] = (splitByte[i] + Angels[i % 24]);
                }

                for (int i = 0; i <= 23; i++)
                {
                    AngelArray[(i + 2) % 24] = AngelArray[(i + 2) % 24] + ((AngelArray[i]) + (AngelArray[(i + 1) % 24]));
                    Angels[(i + 23) % 24] = AngelArray[(i + 2) % 24];

                }

            }

            for (int i = 0; i < 38; i++)
            {
                uint temp1 = e1 + (Angels[i % 24] ^ key[i]) + ((e5 << 9) | (e5 >> 23));
                uint temp2 = e6 + (Angels[(i + 8) % 24] ^ key[i + 38]) + ((e2 << 8) | (e2 >> 24));
                uint temp3 = e9 + (Angels[(i + 16) % 24] ^ key[i + 76]) + ((e8 << 7) | (e8 >> 25));

                e1 = e2; e2 = e3; e3 = e4; e4 = e5 + temp1;
                e5 = e6; e6 = e7; e7 = e8; e8 = e9 + temp2;
                e9 = e10; e10 = e11; e11 = e12; e12 = e1 + temp3;
            } 
            return string.Format("{0:X8}{1:X8}{2:X8}{3:X8}{4:X8}{5:X8} ",
              (e1 + e2), (e3 + e4), (e5 + e6), (e7 + e8), (e9 + e10), (e11 + e12));
        }
    }
}
