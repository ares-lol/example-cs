# Example
A C# example for Ares.lol using RSA asymmetrical encryption.

# Encryption
To provide the best security we use asymmetrical encryption with RSA-4096

The client generates a public key/private key pair; then, it encrypts a message containing its public key using the server's public key. The server then decrypts that using its private key and responds with a message encrypted using the client's public key.

![Alice and Bob example](https://bjc.edc.org/March2019/bjc-r/img/3-lists/525px-Public_key_encryption.png)

# Streaming
If you want to stream simply call the `Module` function on an authenticated `Ares` object.
```
Ares.SecureImage secureImage = AresCtx.Module("c59fdc52-e743-453d-a295-2beb8ffccf9a");

int[] DecryptedImage = secureImage.Decrypt();

// Work with image
```

# Variables
To get a variable simply call the `Variable` function on an authenticated `Ares` object.
```
string Var1 = AresCtx.Variable("var1");
```

# Ares.lol
Ares.lol is a authentication system with a focus on security and quality.
[Check it out](https://ares.lol)
