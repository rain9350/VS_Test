using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using KYSharp.SM;
using System.Security.Cryptography.X509Certificates;
using Org.BouncyCastle.Asn1.X9;
using System.Text;

test();

static void test()
{
    string appId = "89J0rCta";
    string appSecret = "b87732e3e68bcee0407136c1616eeb1a72b613ce";
    string publicKey = "04c06778994c90a1bd0aea910b62bb52f398b696cc6aef01919c33384d5c75438ccac11979b4ed4f0fb19db0462282b08c551cac707987ebd164a10f42ef4f5342";
    string secretKey = "tldWdwDfc4PAipE2oH4jEQ==";
    TimeSpan ts = DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1);
    //得到精确到毫秒的时间戳（长度13位）
    long time = (long)ts.TotalMilliseconds;
  
    string requestTime = Convert.ToString(time);
    SM2Utils.GenerateKeyPair(out publicKey, out secretKey);
    string unitcode = "370785001015GB00011W00000000";
    
    string aaa = SM2Utils.Encrypt(publicKey, unitcode);
    string nnn = SM2Utils.Decrypt(secretKey, aaa);
    Console.WriteLine($"资源码加密前数值为： {unitcode}");
    Console.WriteLine($"资源码加密后数值为： {aaa}");
    Console.WriteLine($"资源码解密后数值为： {nnn}");
    Console.WriteLine("/n");

    StringBuilder sb = new StringBuilder();
    sb.Append($"appId=").Append(appId);
    sb.Append("&appSecret=").Append(appSecret);
    sb.Append("&requestTime=").Append(requestTime);
    sb.Append("&requestParams=").Append(aaa);

    SM3 m3 = new SM3();
    string  sign = m3.Encrypt(sb.ToString()).ToLower();

    Console.WriteLine($"签名sign参数sm3加密结果： {sign}");
    Console.WriteLine("");
    Console.WriteLine($"签名为加密原数据： {sb.ToString()}");
}