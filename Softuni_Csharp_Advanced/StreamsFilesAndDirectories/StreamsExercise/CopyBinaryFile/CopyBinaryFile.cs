namespace CopyBinaryFile
{
    using System;
    using System.IO;

    public class CopyBinaryFile
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\copyMe.png";
            string outputFilePath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputFilePath, outputFilePath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {

            //read

            //write

            using FileStream fileStreamReader = new FileStream(inputFilePath, FileMode.Open);

            using FileStream fileStreamWriter = new FileStream(outputFilePath, FileMode.Create);

            byte[] bytes = new byte[512];

            while (true)
            {
                int currbytes = fileStreamReader.Read(bytes, 0, bytes.Length);

                if (currbytes == 0)
                {
                    break;
                }

                fileStreamWriter.Write(bytes, 0, bytes.Length);
            }
        }
    }
}
