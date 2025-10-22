using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using System;

namespace Egzamin2024_06MauiApp
{
    internal class Program : MauiApplication
    {
        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }
    }
}
