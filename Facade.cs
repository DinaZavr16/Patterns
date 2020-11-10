using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade.Examples
{
    // Mainapp test application 
    class MainApp
    {
        public static void Main()
        {
            AppFacade facade = new AppFacade();
            facade.ShortUse();
            facade.FullUse();
        }
    }


    // "Subsystem ClassA" 
    class InfoAboutApp
    {
        public void GetInfo()
        {
            Console.WriteLine("We are the Grassman's");
        }
    }

    // Subsystem ClassB" 
    class HowToUseApp
    {
        public void HowToUse()
        {
            Console.WriteLine("There are some instructions");
        }
    }


    // Subsystem ClassC" 
    class UsefulFeatures
    {
        public void GetFeatures()
        {
            Console.WriteLine("Feature #1: Ask Siri to take a selfie" + "\n" +
                "Feature #2: Voicemail transcription");
        }
    }
    class UseApp
    {
        public void UsingApp()
        {
            Console.WriteLine("App is loaded");
        }
    }
    // Subsystem ClassD" 
    class ExitSystem
    {
        public void Exit()
        {
            Console.WriteLine("Exit is done");
        }
    }
    // "Facade" 
    class AppFacade
    {
        InfoAboutApp info;
        HowToUseApp howTo;
        UsefulFeatures features;
        ExitSystem exit;
        UseApp use;

        public AppFacade()
        {
            info = new InfoAboutApp();
            howTo = new HowToUseApp();
            features = new UsefulFeatures();
            exit = new ExitSystem();
            use = new UseApp();
        }

        public void ShortUse()
        {
            Console.WriteLine("\nShort use. Only introductory ---- ");
            info.GetInfo();
            howTo.HowToUse();
            exit.Exit();
        }

        public void FullUse()
        {
            Console.WriteLine("\nFull use ---- ");
            info.GetInfo();
            use.UsingApp();
            howTo.HowToUse();
            features.GetFeatures();
            exit.Exit();
        }
    }
}
