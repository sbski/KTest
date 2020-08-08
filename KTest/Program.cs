using System;
using System.Net.Http.Headers;
using System.Threading;
using OpenLibSys;

namespace KTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Ols ols = new Ols();
            // Check support library status
            switch (ols.GetStatus())
            {
                case (uint)Ols.Status.NO_ERROR:
                    Console.WriteLine("WinRing Dll_NO_ERROR");
                    break;
                case (uint)Ols.Status.DLL_NOT_FOUND:
                    throw new ApplicationException("WinRing DLL_NOT_FOUND");
                case (uint)Ols.Status.DLL_INCORRECT_VERSION:
                    throw new ApplicationException("WinRing DLL_INCORRECT_VERSION");
                case (uint)Ols.Status.DLL_INITIALIZE_ERROR:
                    throw new ApplicationException("WinRing DLL_INITIALIZE_ERROR");
            }

            // Check WinRing0 status
            switch (ols.GetDllStatus())
            {
                case (uint)Ols.OlsDllStatus.OLS_DLL_NO_ERROR:
                    Console.WriteLine("WinRing OLS_Dll_NO_ERROR");
                    break;
                case (uint)Ols.OlsDllStatus.OLS_DLL_DRIVER_NOT_LOADED:
                    throw new ApplicationException("WinRing OLS_DRIVER_NOT_LOADED");
                case (uint)Ols.OlsDllStatus.OLS_DLL_UNSUPPORTED_PLATFORM:
                    throw new ApplicationException("WinRing OLS_UNSUPPORTED_PLATFORM");
                case (uint)Ols.OlsDllStatus.OLS_DLL_DRIVER_NOT_FOUND:
                    throw new ApplicationException("WinRing OLS_DLL_DRIVER_NOT_FOUND");
                case (uint)Ols.OlsDllStatus.OLS_DLL_DRIVER_UNLOADED:
                    throw new ApplicationException("WinRing OLS_DLL_DRIVER_UNLOADED");
                case (uint)Ols.OlsDllStatus.OLS_DLL_DRIVER_NOT_LOADED_ON_NETWORK:
                    throw new ApplicationException("WinRing DRIVER_NOT_LOADED_ON_NETWORK");
                case (uint)Ols.OlsDllStatus.OLS_DLL_UNKNOWN_ERROR:
                    throw new ApplicationException("WinRing OLS_DLL_UNKNOWN_ERROR");
            }








            Console.WriteLine("---------------------------------");
            uint eax = default, edx = default;

            Console.WriteLine("Test starting in 3: ");
            Thread.Sleep(1000);
            Console.WriteLine("Test starting in 2: ");
            Thread.Sleep(1000);
            Console.WriteLine("Test starting in 1: ");
            Thread.Sleep(1000);
            Console.WriteLine("Test starting...");

            uint voltage = 0x90000000;
            bool result;


            for(int i = 0; i<100; i++)
            {
                edx = 0x80000011;
                eax = voltage;
                result = ols.WrmsrTx(0X150, eax, edx, (UIntPtr)(1)) == 1;

                edx = 0x80000111;
                eax = voltage;
                result = ols.WrmsrTx(0X150, eax, edx, (UIntPtr)(1)) == 1;

                edx = 0x80000211;
                eax = voltage;
                result = ols.WrmsrTx(0X150, eax, edx, (UIntPtr)(1)) == 1;

                edx = 0x80000311;
                eax = voltage;
                result = ols.WrmsrTx(0X150, eax, edx, (UIntPtr)(1)) == 1;

                edx = 0x80000411;
                eax = voltage;
                result = ols.WrmsrTx(0X150, eax, edx, (UIntPtr)(1)) == 1;

                edx = 0x80000010;
                eax = 0x00000000;
                result = ols.WrmsrTx(0X150, eax, edx, (UIntPtr)(1)) == 1;
            }

            Console.WriteLine("Not Vulnerable. Please report your system info to sbski. Thank you.");
        }
    }
}

