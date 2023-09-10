namespace example_cs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Ares.Ares AresCtx = new Ares.Ares();
            Console.WriteLine("Connecting..");
            int[] AppEncrypted = { 62413, 62361, 62362, 62411, 62410, 62414, 62412, 62365, 62418, 62361, 62411, 62412, 62361, 62418, 62411, 62414, 62406, 62413, 62418, 62366, 62415, 62414, 62365, 62418, 62411, 62411, 62407, 62407, 62407, 62410, 62411, 62414, 62361, 62361, 62413, 62406 };
            if (!AresCtx.Connect(AppEncrypted)) {
                return;
            }

            Console.WriteLine("Connected!");

            Console.Write("Enter your license: ");
            string License = Console.ReadLine();

            Ares.AuthResponse authResponse = AresCtx.Authenticate(License);
            if(authResponse == Ares.AuthResponse.Valid) {
                Console.Write($"Valid!\nApp Name: {AresCtx.App.Name}\nExpiry {AresCtx.License.Expiry}\nIP: {AresCtx.License.IP}\nHWID: {AresCtx.License.HWID}\nLast Login: {AresCtx.License.LastLogin}\n");

                // string yourVariable = AresCtx.Variable("var_name_1");

                // Remember to either remove this code or add a module
                Ares.SecureImage secureImage = AresCtx.Module("c59fdc52-e743-453d-a295-2beb8ffccf9a");

                int[] DecryptedImage = secureImage.Decrypt();
                foreach (char c in DecryptedImage)
                {
                    Console.Write(c);
                }

                Console.WriteLine("Done!");
                Console.ReadKey();
            } else {
                switch(authResponse)
                {
                    case Ares.AuthResponse.Invalid:
                        Console.WriteLine("Invalid license!");
                        break;
                    case Ares.AuthResponse.HWID:
                        Console.WriteLine("HWID doesn't match.");
                        break;
                    case Ares.AuthResponse.Expired:
                        Console.WriteLine("Your license is expired.");
                        break;
                    case Ares.AuthResponse.Banned:
                        Console.WriteLine("You're banned!");
                        break;
                }
            }
        }
    }
}