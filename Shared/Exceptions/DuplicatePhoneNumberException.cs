using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ReplyFlow.Shared.Exceptions
{
    public class DuplicatePhoneNumberException : Exception
    {
         public DuplicatePhoneNumberException(string phoneNumber)
        : base("This phone number is already registered")
    {
        PhoneNumber = phoneNumber;
    }

    public string PhoneNumber { get; }
    }
}
