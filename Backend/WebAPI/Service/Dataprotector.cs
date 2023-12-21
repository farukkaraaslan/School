using System.Security.Cryptography;
using System.Text;

namespace WebAPI.Service;

public class DataProtector
{
    private string path;
    private string pathCom;
    private byte[] entropy;
    private string entropyBase;
    public DataProtector(string path)
    {
        this.path = path;
        this.pathCom = this.path + "\\jsga.edutr";
        this.path += "\\jsga.edu.tr";
    }
    public int EncryptData(string stringCriticalData)
    {
        entropy = new byte[16];
        entropy = RandomNumberGenerator.GetBytes(16);
        this.entropyBase = Convert.ToBase64String(entropy);

        var encodedData = Encoding.ASCII.GetBytes(stringCriticalData);
        FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate);
        int length = EncryptDataToFile(encodedData, entropy, DataProtectionScope.CurrentUser, fileStream);
        fileStream.Close();

        StreamWriter fs = new StreamWriter(this.pathCom);
        fs.Flush();
        fs.WriteLine(this.entropyBase);
        fs.WriteLine(length);
        fs.Close();

        return length;
    }
    private int EncryptDataToFile(byte[] encodedData, byte[] entropy, DataProtectionScope currentUser, FileStream fileStream)
    {
        int output = 0;
        byte[] encrpytedData = ProtectedData.Protect(encodedData, entropy, currentUser);
        if (fileStream.CanWrite && encrpytedData != null)
        {
            fileStream.Write(encrpytedData, 0, encrpytedData.Length);
            output = encrpytedData.Length;
        }
        return output;
    }
    public string DecryptData()
    {
        string fileName = this.pathCom;

        IEnumerable<string> lines = File.ReadLines(fileName);
        this.entropy = Convert.FromBase64String(lines.ElementAt(0));
        int length = Int32.Parse(lines.ElementAt(1));


        FileStream fileStream = new FileStream(this.path, FileMode.Open);
        byte[] decryptData = DecryptFromFile(this.entropy, DataProtectionScope.CurrentUser, fileStream, length);
        fileStream.Close();
        return Encoding.ASCII.GetString(decryptData);
    }

    private byte[] DecryptFromFile(byte[] entropy, DataProtectionScope currentUser, FileStream fileStream, int length)
    {
        byte[] inputBuffer = new byte[length];
        byte[] outputBuffer;
        if (fileStream.CanRead)
        {
            fileStream.Read(inputBuffer, 0, inputBuffer.Length);
            outputBuffer = ProtectedData.Unprotect(inputBuffer, entropy, currentUser);
        }
        else
        {
            throw new IOException("Cannot read file");
        }
        return outputBuffer;
    }
}