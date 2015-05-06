using  System.Security;
using  System.Security.Cryptography;
using  System.Text;

namespace ModSoftDog
{
    public static class ClsDES
    {
       //产品ID
        public const string SoftProductID = "A358";


        private static DESCryptoServiceProvider des = new DESCryptoServiceProvider();
        private  static  string sKey="Mtsciteh";
        
        //public ModSoftDog()
        //{
        //}

        public static string Encrypt(string StrInput) //加密函数 
        {
            byte[] ByteArrayInput = Encoding.Default.GetBytes(StrInput);
            System.IO.MemoryStream ms = new System.IO.MemoryStream();

            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
            //使用 DES 加密法轉換 stream 成 Crypto Stream  
            //Dim DES As New DESCryptoServiceProvider()
            //8位數字, 8個字  
            CryptoStream CryptoStream=new CryptoStream(ms, des.CreateEncryptor(des.Key, des.IV), CryptoStreamMode.Write);
            //寫入 DES 加密 
            CryptoStream.Write(ByteArrayInput, 0, ByteArrayInput.Length);
            CryptoStream.FlushFinalBlock();

            return System.Convert.ToBase64String(ms.ToArray());
         
        }
        
        public static string Decrypt(string StrInput) //解密函数
        {
            try
            {
                byte[] ByteArrayInput = System.Convert.FromBase64String(StrInput);
                
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                
                des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
                des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);

                //'Dim DES As New DESCryptoServiceProvider()
                //'使用 DES 解密法轉換 bytes 成 crypto stream 
                CryptoStream CryptoStream=new CryptoStream(ms, des.CreateDecryptor(des.Key, des.IV), CryptoStreamMode.Write);
                CryptoStream.Write(ByteArrayInput, 0, ByteArrayInput.Length);
                CryptoStream.FlushFinalBlock();

                return System.Text.Encoding.Default.GetString(ms.ToArray());
            }
            catch 
            {
                return "";
            }
        }

        public static void Encrypt_A_File(string n_InputFileNmae, string n_OutputFileName) //加密一个文件
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray;
            inputByteArray = System.IO.File.ReadAllBytes(n_InputFileNmae);

            //''建立加密对象的密钥和偏移量
            //''原文使用ASCIIEncoding.ASCII方法的GetBytes方法
            //''使得输入密码必须输入英文文本
            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
            //''写二进制数组到加密流
            //''(把内存流中的内容全部写入)
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);


            //''写二进制数组到加密流
            //''(把内存流中的内容全部写入)
            cs.Write(inputByteArray, 0, inputByteArray.Length);

            cs.FlushFinalBlock();

            //''建立输出字符串    
            System.IO.File.WriteAllBytes(n_OutputFileName, ms.ToArray());
            return;
        }
          
        public static void  Decrypt_A_File(string n_InputFileName, string n_OuputFileName) //解密一个文件
        {
            DESCryptoServiceProvider  des =new DESCryptoServiceProvider();
            byte[] inputByteArray = System.IO.File.ReadAllBytes(n_InputFileName);
            //''建立加密对象的密钥和偏移量，此值重要，不能修改
            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            CryptoStream  cs =new  CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            System.IO.File.WriteAllBytes(n_OuputFileName, ms.ToArray());
            return;
        }

        public static string GetSN(string InS) //返回序列号
        {
            return ClsDES.Encrypt(InS);
        }

    }
}
